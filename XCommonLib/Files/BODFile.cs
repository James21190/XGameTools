using CommonToolLib.Generics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files
{
    public class BODFile
    {
        public struct Material
        {
            public string matType;
            public string Texture;
        }
        public class Body
        {
            public struct Vertex
            {
                public double X, Y, Z;
            }
            public struct Face
            {
                public struct VertexData
                {
                    public int Index;
                    public double TextureX, TextureY;
                }
                public int Material;
                public VertexData[] Vertices;
            }

            public string Name;
            // How many times the vertices need to be multiplied to get the full scale object.
            // The larger this is, the larger the final object and smaller the vertices stored.
            // Is a fixed point decimal where 0x10000 = 1.
            public int ObjectSize;

            public List<Vertex> Vertices = new List<Vertex>();
            public List<Face> Faces = new List<Face>();

            public void Rescale(double value)
            {
                Rescale(value, value, value);
            }
            public void Rescale(double x, double y, double z)
            {
                for (int i = 0; i < Vertices.Count(); i++)
                {
                    var vertex = Vertices[i];
                    vertex.X *= x;
                    vertex.Y *= y;
                    vertex.Z *= z;
                    Vertices[i] = vertex;
                }
            }
        }

        public string Name;
        public List<Material> Materials = new List<Material>();
        public List<Body> Bodies = new List<Body>();

        public string ToText()
        {
            throw new NotImplementedException();
        }


        private enum ParsingStage
        {
            Material,
            BodySize,
            Vertices,
            Faces
        }

        private enum FaceCode
        {
            NoAdditionalData = -1,
            TextureCoordinates = -9,
            AdditionalNumber = -17,
            NumberAndTextureCoordinates = -25,
            NumberAndTextureCoordinates_2 = -57,
            TextureCoordinatesAndExtra = -137,
            NumberAndTextureCoordinatesAndExtra = -153
        }

        public void Rescale(double x, double y, double z)
        {
            foreach(var body in Bodies)
                body.Rescale(x, y, z);
        }

        public void Rescale(double value)
        {
            Rescale(value, value, value);
        }

        /// <summary>
        /// Rescales the object to a set object size.
        /// </summary>
        /// <param name="objectSize"></param>
        public void RelativeRescale(double objectSize)
        {
            if (Bodies.Count() == 0)
                return;
            var primary = Bodies[0];
            var factor = (double)primary.ObjectSize / objectSize;
            foreach (var body in Bodies)
                body.Rescale(factor);
        }

        public void AppendBody(BODFile bodFile, Vector3_32 positionOffset)
        {
            var materialOffset = Materials.Count();

            Materials.AddRange(bodFile.Materials);

            int bodynum = 0;

            foreach(var body in bodFile.Bodies)
            {
                for(int i = 0; i < body.Vertices.Count; i++)
                {
                    var vertex = body.Vertices[i];
                    vertex.X += positionOffset.X;
                    vertex.Y += positionOffset.Y;
                    vertex.Z += positionOffset.Z;
                    body.Vertices[i] = vertex;
                }

                for(int i = 0; i < body.Faces.Count(); i++)
                {
                    var face = body.Faces[i];
                    face.Material += materialOffset;
                    body.Faces[i] = face;
                }
                if (bodFile != null)
                    body.Name = bodFile.Name + " " + bodynum;
                else
                    body.Name = bodynum.ToString();
                Bodies.Add(body);

                bodynum++;
            }
        }

        public void ApplyRotationMatrix(double[,] rotationMatrix)
        {
            foreach (var body in Bodies)
            {
                for (int i = 0; i < body.Vertices.Count(); i++)
                {
                    var vertex = body.Vertices[i];

                    // apply matrix

                    // 3 x 3 * 3 x 1 = 3 x 1

                    var result = new Body.Vertex();

                    result.X = vertex.X * rotationMatrix[0 ,0] + vertex.Y * rotationMatrix[0,1] + vertex.Z * rotationMatrix[0,2];
                    result.Y = vertex.X * rotationMatrix[1 ,0] + vertex.Y * rotationMatrix[1,1] + vertex.Z * rotationMatrix[1,2];
                    result.Z = vertex.X * rotationMatrix[2 ,0] + vertex.Y * rotationMatrix[2,1] + vertex.Z * rotationMatrix[2,2];

                    body.Vertices[i] = result;
                }
            }
        }

        public void FromText(string text, int modelID = -1)
        {
            const string ALLOWED = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.-+:;";
            var sb = new StringBuilder();
            bool isComment = false;
            foreach(var character in text)
            {
                if (!isComment)
                {
                    if (character == '/')
                    {
                        isComment = true;
                        continue;
                    }

                    if(ALLOWED.Contains(character))
                        sb.Append(character);
                }
                else
                {
                    if (character == '\n')
                    {
                        isComment = false;
                    }
                }
            }

            var formatted = sb.ToString().TrimEnd(';').Split(';');

            var stage = ParsingStage.Material;
            Body currentBody = new Body();

            for(int i = 0; i < formatted.Length; i++)
            {
                switch (stage)
                {
                    case ParsingStage.Material:
                        if (formatted[i].Contains("MATERIAL:"))
                        {
                            Materials.Add(new Material()
                            {
                                matType = "MATERIAL",
                                Texture = formatted[i + 1]
                            });
                            i += 10;
                        }
                        else if (formatted[i].Contains("MATERIAL2:"))
                        {
                            Materials.Add(new Material()
                            {
                                matType = "MATERIAL2",
                                Texture = formatted[i + 1]
                            });
                            i += 15;
                        }
                        else if (formatted[i].Contains("MATERIAL3:"))
                        {
                            Materials.Add(new Material()
                            {
                                matType = "MATERIAL3",
                                Texture = formatted[i + 1]
                            });
                            i += 22;
                        }
                        else if (formatted[i].Contains("MATERIAL5:"))
                        {
                            Materials.Add(new Material()
                            {
                                matType = "MATERIAL5",
                                Texture = formatted[i + 1]
                            });
                            i += 24;
                        }
                        else if (formatted[i].Contains("MATERIAL6:"))
                        {
                            var newMat = new Material()
                            {
                                matType = "MATERIAL6",
                            };


                            switch(formatted[i +1].Trim(' '))
                            {
                                case "0x2000000":
                                    i += 5;
                                    while (true)
                                    {
                                        var varName = formatted[i];
                                        var varType = formatted[i + 1];
                                        switch (varName)
                                        {
                                            case "diffcompression":
                                            case "bumpcompression":
                                            case "speccompression":
                                            case "lightcompression":
                                            case "nofiltering":
                                            case "autofree":
                                            case "Tex2":
                                            case "TexAnimStartU":
                                            case "TexAnimStartV":
                                            case "TexAnimEndU":
                                            case "TexAnimEndV":
                                            case "TexAnimDuration":
                                            case "TexAnimRotation":
                                            case "TexAnimOriginU":
                                            case "TexAnimOriginV":
                                            case "Brightness":
                                            case "contrast":
                                            case "saturation":
                                            case "hue":
                                            case "colormatrix":
                                            case "LightDir_Dir0":
                                            case "LightDir_Color0":
                                            case "LightDir_Dir1":
                                            case "LightDir_Color1":
                                            case "LightDirDir0":
                                            case "LightDirColor0":
                                            case "LightDirDir1":
                                            case "LightDirColor1":

                                            case "g_ColorWriteEnable":
                                            case "g_Wrap":
                                            case "g_CullMode":
                                            case "g_AlphaBlendEnable":
                                            case "g_BlendOp":
                                            case "g_SrcBlend":
                                            case "g_DestBlend":
                                            case "g_ZEnable":
                                            case "g_ZWriteEnable":
                                            case "g_ALPHATESTENABLE":
                                            case "g_LightAmbientIntensity":
                                            case "g_MatSpecularStrength":
                                            case "g_MatSpecularPower":
                                            case "g_MatReflectionStrength":
                                            case "g_MatReflectionBias":
                                            case "g_MatReflectionBlur":
                                            case "g_AlphaValue":
                                            case "g_MatEmissiveColor":
                                            case "t_FilterTypeDiffuse":
                                            case "t_SamplerAddressMode":
                                            case "t_SamplerMaxAnisotropy":
                                            case "t_MipMapLODBias":
                                            case "t_DiffuseTexture":
                                            case "t_MinFilterTypeDiffuse":
                                            case "g_MatDiffuseStrength":
                                            case "t_AlphaTexture":
                                            case "t_BumpTexture":
                                            case "t_MinFilterTypeBump":
                                            case "t_BumpMipMapLODBias":
                                            case "t_FilterTypeBump":
                                            case "t_SpecularTexture":
                                            case "t_LightMapTexture":
                                            case "t_CubeMapTexture":

                                            case "gBrightness":
                                            case "gContrast":
                                            case "gSaturation":
                                            case "gHue":
                                            case "gColorWriteEnable":
                                            case "gWrap":
                                            case "gCullMode":
                                            case "gAlphaBlendEnable":
                                            case "gBlendOp":
                                            case "gSrcBlend":
                                            case "gDestBlend":
                                            case "gZEnable":
                                            case "gZWriteEnable":
                                            case "gALPHATESTENABLE":
                                            case "gLightAmbientIntensity":
                                            case "gMatSpecularStrength":
                                            case "gMatSpecularPower":
                                            case "gMatReflectionStrength":
                                            case "gMatReflectionBias":
                                            case "gMatReflectionBlur":
                                            case "gAlphaValue":
                                            case "gMatEmissiveColor":
                                            case "tFilterTypeDiffuse":
                                            case "tSamplerAddressMode":
                                            case "tSamplerMaxAnisotropy":
                                            case "tMipMapLODBias":
                                            case "tDiffuseTexture":
                                            case "tMinFilterTypeDiffuse":
                                            case "gMatDiffuseStrength":
                                            case "tAlphaTexture":
                                            case "tBumpTexture":
                                            case "tMinFilterTypeBump":
                                            case "tBumpMipMapLODBias":
                                            case "tFilterTypeBump":
                                            case "tSpecularTexture":
                                            case "tLightMapTexture":
                                            case "tCubeMapTexture":
                                            case "gBumpMapStrength":

                                            case "effectfile":
                                            case "gFresnelExpon":
                                            case "gMatMinFresnel":
                                            case "gColorEnvipaint":
                                            case "renderEnabled":
                                            case "renderMaterial":
                                            case "technique":
                                            case "gambLightmap":
                                            case "gLightMapStrength":
                                                break;
                                            default:
                                                i--;
                                                goto breakloop;

                                        }
                                        switch (varType)
                                        {
                                            case "SPTYPE_FLOAT4":
                                            case "SPTYPEFLOAT4":
                                                i += 4;
                                                break;
                                            default:
                                                i++;
                                                break;
                                        }
                                        i += 2;
                                    }
                                    breakloop:
                                    break;
                                default:
                                    newMat.Texture = formatted[i + 2];
                                    i += 29;
                                    break;
                            }

                            Materials.Add(newMat);
                        }
                        else
                        {
                            stage = ParsingStage.BodySize;
                            i--;
                        }
                        break;
                    case ParsingStage.BodySize:
                        currentBody = new Body();
                        if(modelID != -1)
                            currentBody.Name = modelID.ToString();
                        currentBody.ObjectSize = int.Parse(formatted[i]);
                        stage = ParsingStage.Vertices;
                        break;
                    case ParsingStage.Vertices:
                        var vertex = new Body.Vertex()
                        {
                            X = int.Parse(formatted[i]),
                            Y = int.Parse(formatted[i + 1]),
                            Z = int.Parse(formatted[i + 2])
                        };
                        // If end code...
                        if (vertex.X == -1 && vertex.Y == -1 && vertex.Z == -1)
                        {
                            stage = ParsingStage.Faces;
                        }
                        else
                        {
                            currentBody.Vertices.Add(vertex);
                        }
                        i += 2;
                        break;
                    case ParsingStage.Faces:

                        // If end code...
                        if (int.Parse(formatted[i]) == -99)
                        {
                            if(int.Parse(formatted[i+2]) == -99)
                            {
                                Bodies.Add(currentBody);
                                stage = ParsingStage.BodySize;
                                i += 3;
                            }
                            else
                            {
                                i += 1;
                            }
                        }
                        else
                        {
                            var face = new Body.Face();
                            face.Material = int.Parse(formatted[i]);

                            // Count how many vertices there are.
                            int vertexCount = 0;
                            while(int.Parse(formatted[i + 1 + vertexCount]) >= 0)
                            {
                                vertexCount++;
                            }
                            FaceCode code = (FaceCode)int.Parse(formatted[i + 1 + vertexCount]);

                            int offset;

                            switch (code)
                            {
                                case FaceCode.NumberAndTextureCoordinates:
                                case FaceCode.NumberAndTextureCoordinates_2:
                                case FaceCode.AdditionalNumber:
                                case FaceCode.NumberAndTextureCoordinatesAndExtra:
                                    offset = 1;
                                    break;
                                case FaceCode.TextureCoordinates:
                                case FaceCode.NoAdditionalData:
                                case FaceCode.TextureCoordinatesAndExtra:
                                    offset = 0;
                                    break;
                                default:
                                    throw new NotImplementedException();
                            }

                            face.Vertices = new Body.Face.VertexData[vertexCount];
                            
                            for(int faceVertex = 0; faceVertex < vertexCount; faceVertex++)
                            {
                                face.Vertices[faceVertex].Index = int.Parse(formatted[i + 1 + faceVertex]);
                                if(code != FaceCode.AdditionalNumber && code != FaceCode.NoAdditionalData)
                                {
                                    face.Vertices[faceVertex].TextureX = double.Parse(formatted[i + vertexCount + 2 + offset + faceVertex * 2]);
                                    face.Vertices[faceVertex].TextureY = -double.Parse(formatted[i + vertexCount + 3 + offset + faceVertex * 2]);
                                }
                            }

                            switch (code)
                            {
                                case FaceCode.TextureCoordinates:
                                case FaceCode.NumberAndTextureCoordinates:
                                case FaceCode.NumberAndTextureCoordinates_2:
                                    i += vertexCount * 3 + 1 + offset;
                                    break;
                                case FaceCode.NumberAndTextureCoordinatesAndExtra:
                                case FaceCode.TextureCoordinatesAndExtra:
                                    i += vertexCount * 5 + 1 + offset;
                                    break;
                                case FaceCode.AdditionalNumber:
                                case FaceCode.NoAdditionalData:
                                    i += vertexCount + 1 + offset;
                                    break;
                            }

                            currentBody.Faces.Add(face);

                        }
                        break;

                }
                
            }

            _NormalizeBodies();

        }

        private void _NormalizeBodies()
        {
            double largest = 0;
            foreach(var body in Bodies)
            {
                foreach(var vertex in body.Vertices)
                {
                    if(vertex.X > largest)
                        largest = vertex.X;
                    if (vertex.Y > largest)
                        largest = vertex.Y;
                    if (vertex.Z > largest)
                        largest = vertex.Z;
                }
                double scale = 0x10000 / largest;
                body.Rescale(scale, scale, scale);
            }
        }

        private void ExportMaterials(string path, string textureDir)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < Materials.Count(); i++)
                {
                    if(textureDir != null && Materials[i].Texture != null)
                    {
                        sw.WriteLine("newmtl " + i + "_" + Path.GetFileNameWithoutExtension(Materials[i].Texture));
                        var texturePath = Path.Combine(textureDir,Path.GetFileNameWithoutExtension(Materials[i].Texture));
                        sw.WriteLine("map_Kd " + texturePath + ".jpg");
                    }
                    else
                    {
                        sw.WriteLine("newmtl " + i);
                    }
                }
            }
        }

        public void ExportAsOBJ(string path, string textureDir = null)
        {

            string materialFilePath = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path)+".mtl");

            ExportMaterials(materialFilePath, textureDir);

            using (StreamWriter sw = new StreamWriter(path))
            {

                sw.WriteLine("mtllib " + Path.GetFileName(materialFilePath));

                int vertexcount = 0;
                int textureCordCount = 0;
                int bodyCount = 0;

                foreach(var body in Bodies)
                {
                    List<string> names = new List<string>();
                    if (Name != null)
                        names.Add(Name);
                    names.Add(bodyCount++.ToString());
                    if (body.Name != null)
                        names.Add("(" + body.Name + ")");


                    sw.WriteLine("o " + String.Join(" ", names));

                    // Vertices
                    foreach (var vertex in body.Vertices)
                    {
                        sw.WriteLine(String.Join(" ","v", ((double)vertex.X/0x10000), ((double)vertex.Y / 0x10000), ((double)vertex.Z/0x10000)));
                    }
                    int lastMaterial = -1;
                    // Faces
                    foreach (var face in body.Faces)
                    {
                        // Set material
                        if(face.Material != lastMaterial)
                        {
                            if(face.Material >= 0 && face.Material < Materials.Count() && Materials[face.Material].Texture != null)
                                sw.WriteLine("usemtl " + face.Material + "_" + Path.GetFileNameWithoutExtension(Materials[face.Material].Texture));
                            else
                                sw.WriteLine("usemtl " + face.Material);

                            lastMaterial = face.Material;
                        }
                        // Set texture
                        for(int i = 0; i < face.Vertices.Count(); i++)
                        {
                            sw.WriteLine(String.Join(" ", "vt", face.Vertices[i].TextureX, face.Vertices[i].TextureY));
                        }
                        // Set vertices
                        string[] vertexIndex = new string[face.Vertices.Length];
                        for(int i = 0; i < face.Vertices.Length; i++)
                        {
                            vertexIndex[i] = (vertexcount + face.Vertices[i].Index + 1).ToString() + "/" + (++textureCordCount);
                        }
                        sw.WriteLine("f " + string.Join(" ", vertexIndex));
                    }
                    vertexcount += body.Vertices.Count();
                }
            }
        }
    }
}
