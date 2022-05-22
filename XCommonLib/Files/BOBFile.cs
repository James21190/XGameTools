using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonToolLib.Generics;
using XCommonLib;
using XCommonLib.Files.CatDat;

namespace XCommonLib.Files
{
    public class BOBFile
    {
        private CatDat.AbstractCatDatPair _ReferenceCatDat = null;

        public string Name;
        public string Info;
        public int Unknown_1;
        public ModelData[] Models;

        public struct ModelData
        {
            // The ID of the model in V
            public int ModelID;
            public int Unknown_1, Unknown_3, Unknown_4, Unknown_5;
            public string PathName;
            public ConsObject[] ConsObjects;
            public NoteObject[] NoteObjects;
            public PositionStateObject[] PositionStates;
            public RotationStateObject[] RotationStates;

            public struct ConsObject
            {
                public int Unknown_1, Unknown_2;
            }

            public struct NoteObject
            {
                public int Unknown;
                public string Text;
            }

            public class PositionStateObject
            {
                public Vector3_32 Position;
            }

            public class RotationStateObject
            {
                public int Angle;
                public Vector3_32 Axis;

                public double AngleRadian => ((double)Angle / 0x10000) * 2 * Math.PI;
                public double[] AxisNormalized => new double[] { ((double)Axis.X) / (double)0x10000, ((double)Axis.Y) / (double)0x10000, ((double)Axis.Z) / (double)0x10000 };

                public Matrix<XFixedPointValue> RotationMatrix
                {
                    get
                    {
                        var cosAngle = Math.Cos(AngleRadian);
                        var sinAngle = Math.Sin(AngleRadian);
                        var matrix = new Matrix<XFixedPointValue>(3, 3);
                        matrix.Values[0, 0].Double = cosAngle + Math.Pow(AxisNormalized[0],2) * (1- cosAngle);
                        matrix.Values[0, 1].Double = AxisNormalized[0] * AxisNormalized[1] * (1 - cosAngle) - AxisNormalized[2] * sinAngle;
                        matrix.Values[0, 2].Double = AxisNormalized[0] * AxisNormalized[2] * (1 - cosAngle) + AxisNormalized[1] * sinAngle;
                        matrix.Values[1, 0].Double = AxisNormalized[1] * AxisNormalized[0] * (1 - cosAngle) + AxisNormalized[2] * sinAngle;
                        matrix.Values[1, 1].Double = cosAngle + Math.Pow(AxisNormalized[1], 2) * (1 - cosAngle);
                        matrix.Values[1, 2].Double = AxisNormalized[1] * AxisNormalized[2] * (1 - cosAngle) - AxisNormalized[0] * sinAngle;
                        matrix.Values[2, 0].Double= AxisNormalized[2] * AxisNormalized[0] * (1-cosAngle) - AxisNormalized[1] * sinAngle;
                        matrix.Values[2, 1].Double= AxisNormalized[2] * AxisNormalized[1] * (1-cosAngle) + AxisNormalized[0] * sinAngle;
                        matrix.Values[2, 2].Double= cosAngle + Math.Pow(AxisNormalized[2],2) * (1-cosAngle);

                        return matrix;
                    }
                }
            }

            public override string ToString()
            {
                return String.Format("Model {0}", ModelID);
            }
        }

        private static byte[] EncryptionKey = new byte[2] { 4, 0 };
        private static void DecryptBytes(ref byte[] bytes)
        {
            int EncryptionKeyPosition = 0;
            int i = 0;
            byte temp;
            do
            {
                switch (EncryptionKey[EncryptionKeyPosition])
                {
                    case 0:
                        EncryptionKeyPosition = 0;
                        continue;
                    case 1:
                        i += 1;
                        break;
                    case 2:
                        temp = bytes[i];
                        bytes[i] = bytes[i + 1];
                        bytes[i] = temp;
                        i += 2;
                        break;
                    case 4:
                        temp = bytes[i];
                        bytes[i] = bytes[i + 3];
                        bytes[i+3] = temp;
                        temp = bytes[i+1];
                        bytes[i+1] = bytes[i + 2];
                        bytes[i+2] = temp;
                        i += 4;
                        break;
                }
                EncryptionKeyPosition += 1;
            } while (i < bytes.Length);
        }

        private class FileReader
        {
            public byte[] FileData;
            public int Index;
            public FileReader(string path)
            {
                FileData = File.ReadAllBytes(path);
                Index = 0;
            }

            public FileReader(byte[] bytes)
            {
                FileData = bytes;
                Index = 0;
            }

            public string GetNextAsTag(bool incrementIndex = true)
            {
                var str = Encoding.ASCII.GetString(FileData, Index, 4);
                if (incrementIndex)
                {
                    Index += 4;
                }
                return str;
            }

            public byte GetNextAsByte()
            {
                var b = FileData[Index];
                Index++;
                return b;
            }

            public int GetNextAsInt()
            {
                return BitConverter.ToInt32(GetNextAsBytes(4, true),0);
            }

            public byte[] GetNextAsBytes(int length, bool decrypt)
            {
                byte[] bytes = new byte[length];
                for(int i = 0; i < length; i++)
                {
                    bytes[i] = GetNextAsByte();
                }

                if (decrypt)
                {
                    DecryptBytes(ref bytes);
                }

                return bytes;
            }
        }

        public BOBFile(CatDat.AbstractCatDatPair abstractCatDatPair)
        {
            _ReferenceCatDat = abstractCatDatPair;
        }

        public void FromFile(byte[] fileContents)
        {
            var fileData = new FileReader(fileContents);

            if(fileData.GetNextAsTag(true) != "CUT1")
            {
                return;
                throw new Exception();
            }

            if(fileData.GetNextAsTag(false) == "INFO")
            {
                fileData.Index += 4;
                var sb = new StringBuilder();
                char infoChar = (char)fileData.GetNextAsByte();
                while(infoChar != '\0')
                {
                    sb.Append(infoChar);
                    infoChar = (char)fileData.GetNextAsByte();
                }
                Info = sb.ToString();
                if(fileData.GetNextAsTag(true) !=  "/INF")
                {
                    throw new Exception();
                }
            }

            Unknown_1 = fileData.GetNextAsInt();

            Models = new ModelData[fileData.GetNextAsInt()];

            for(int CurrentModelIndex = 0; Models.Length > CurrentModelIndex; CurrentModelIndex++)
            {
                // Ensure tag is PATH
                if(fileData.GetNextAsTag(true) != "PATH")
                {
                    throw new Exception();
                }

                Models[CurrentModelIndex].Unknown_1 = fileData.GetNextAsInt();
                Models[CurrentModelIndex].ModelID = fileData.GetNextAsInt();
                Models[CurrentModelIndex].Unknown_3 = fileData.GetNextAsInt();
                Models[CurrentModelIndex].Unknown_4 = fileData.GetNextAsInt();
                Models[CurrentModelIndex].Unknown_5 = fileData.GetNextAsInt();

                var nextTag = fileData.GetNextAsTag(false);
                // Check for name tag
                if(nextTag == "NAME")
                {
                    fileData.Index += 4;
                    var sb = new StringBuilder();
                    char pathNameChar = (char)fileData.GetNextAsByte();
                    while(pathNameChar != '\0')
                    {
                        sb.Append(pathNameChar);
                        pathNameChar = (char)fileData.GetNextAsByte();
                    }
                    Models[CurrentModelIndex].PathName = sb.ToString();
                    if (fileData.GetNextAsTag(true) != "/NAM")
                        throw new Exception();
                    nextTag = fileData.GetNextAsTag(false);
                }
                
                if(nextTag == "CONS")
                {
                    fileData.Index += 4;
                    var consObjectCount = fileData.GetNextAsInt();
                    Models[CurrentModelIndex].ConsObjects = new ModelData.ConsObject[consObjectCount];
                    for(int i = 0; i < Models[CurrentModelIndex].ConsObjects.Length; i++)
                    {
                        Models[CurrentModelIndex].ConsObjects[i].Unknown_1 = fileData.GetNextAsInt();
                        Models[CurrentModelIndex].ConsObjects[i].Unknown_2 = fileData.GetNextAsInt();
                    }

                    if (fileData.GetNextAsTag(false) != "/CON")
                        throw new Exception();
                    nextTag = fileData.GetNextAsTag(true);
                }

                if (nextTag == "BOB1")
                {
                    fileData.Index += 4;

                    //Models[CurrentModelIndex].ModelID = Models[CurrentModelIndex].ModelID + ModelCollectionID * 100000 - 100000;

                    // This bit is complicated, so I'll just skip it
                    while (fileData.GetNextAsTag(false) != "/BOB")
                        fileData.Index += 1;

                    if (fileData.GetNextAsTag(true) != "/BOB")
                        throw new Exception();
                }

                Models[CurrentModelIndex].NoteObjects = new ModelData.NoteObject[fileData.GetNextAsInt()];

                if(Models[CurrentModelIndex].NoteObjects.Length != 0)
                {
                    if (fileData.GetNextAsTag(true) != "NOTE")
                        throw new Exception();

                    for(int i = 0;i < Models[CurrentModelIndex].NoteObjects.Length; i++)
                    {
                        Models[CurrentModelIndex].NoteObjects[i].Unknown = fileData.GetNextAsInt();
                        var sb = new StringBuilder();
                        while (true)
                        {
                            char noteChar = (char)fileData.GetNextAsByte();
                            if (noteChar == '\0')
                                break;
                            sb.Append(noteChar);
                        }

                        Models[CurrentModelIndex].NoteObjects[i].Text = sb.ToString();
                    }

                    if (fileData.GetNextAsTag(true) != "/NOT")
                        throw new Exception();
                }

                var statCounter = fileData.GetNextAsInt();
                Models[CurrentModelIndex].PositionStates = new ModelData.PositionStateObject[statCounter];
                Models[CurrentModelIndex].RotationStates = new ModelData.RotationStateObject[statCounter];

                for(int i = 0; i < statCounter; i++)
                {
                    Models[CurrentModelIndex].PositionStates[i] = new ModelData.PositionStateObject();
                    Models[CurrentModelIndex].RotationStates[i] = new ModelData.RotationStateObject();
                }

                if(Models[CurrentModelIndex].PositionStates.Length != 0)
                {
                    if(Models[CurrentModelIndex].ModelID == 774)
                    {
                        Console.WriteLine();
                    }
                    if(fileData.GetNextAsTag(true) != "STAT")
                    {
                        throw new Exception();
                    }

                    for (int i = 0; i < statCounter; i++)
                    {
                        var statFlag = fileData.GetNextAsInt();
#if true
                        if((statFlag & 0x10) == 0)
                        {
                            Models[CurrentModelIndex].PositionStates[i].Position.X = fileData.GetNextAsInt();
                            Models[CurrentModelIndex].PositionStates[i].Position.Y = fileData.GetNextAsInt();
                            Models[CurrentModelIndex].PositionStates[i].Position.Z = fileData.GetNextAsInt();

                            if((statFlag & 0x4000) != 0)
                            {
                                var u4 = fileData.GetNextAsInt();
                                var u5 = fileData.GetNextAsInt();
                                var u6 = fileData.GetNextAsInt();
                                var u7 = fileData.GetNextAsInt();
                                var u8 = fileData.GetNextAsInt();
                            }

                            if((statFlag & 8) == 0)
                            {
                                if((statFlag & 0x20) == 0)
                                {
                                    if((statFlag & 2) != 0)
                                    {
                                        Models[CurrentModelIndex].RotationStates[i].Angle = fileData.GetNextAsInt();
                                        Models[CurrentModelIndex].RotationStates[i].Axis.X = fileData.GetNextAsInt();
                                        Models[CurrentModelIndex].RotationStates[i].Axis.Y = fileData.GetNextAsInt();
                                        Models[CurrentModelIndex].RotationStates[i].Axis.Z = fileData.GetNextAsInt();
                                    }
                                    if((statFlag >> 8) < 0)
                                    {
                                        var u13 = fileData.GetNextAsInt();
                                        var u14 = fileData.GetNextAsInt();
                                        var u15 = fileData.GetNextAsInt();
                                        var u16 = fileData.GetNextAsInt();
                                        var u17 = fileData.GetNextAsInt();
                                    }
                                    if((statFlag & 0x40000)!= 0)
                                    {
                                        statFlag |= 0x8000;
                                    }
                                }
                                else if (i == 0 && (statFlag & 2) != 0)
                                {

                                }
                            }
                            else
                            {
                                if((statFlag & 0x40) == 0)
                                {
                                    var u18 = fileData.GetNextAsInt();
                                    var u19 = fileData.GetNextAsInt();
                                    var u20 = fileData.GetNextAsInt();

                                    if((statFlag & 0x20000) != 0)
                                    {
                                        var u21 = fileData.GetNextAsInt();
                                        var u22 = fileData.GetNextAsInt();
                                        var u23 = fileData.GetNextAsInt();
                                        var u24 = fileData.GetNextAsInt();
                                        var u25 = fileData.GetNextAsInt();
                                    }
                                }
                                if((statFlag & 0x20) == 0)
                                {
                                    var u26 = fileData.GetNextAsInt();
                                }
                            }
                            if((statFlag & 0x200) != 0 && (statFlag & 0x400) == 0)
                            {
                                var u27 = fileData.GetNextAsInt();
                                var u28 = fileData.GetNextAsInt();
                                var u29 = fileData.GetNextAsInt();
                            }
                            if((statFlag & 0x800) != 0 && (statFlag & 0x1000) == 0)
                            {
                                var u30 = fileData.GetNextAsInt();
                            }

                            var u31 = fileData.GetNextAsInt();
                            var u32 = fileData.GetNextAsInt();
                        }
#endif
                    }

                    // This bit is complicated and involves a lot of objects, so I'll just skip it
                    while (fileData.GetNextAsTag(false) != "/STA")
                        fileData.Index += 1;

                    if (fileData.GetNextAsTag(true) != "/STA")
                        throw new Exception();
                }

                if (fileData.GetNextAsTag(true) != "/PAT")
                    throw new Exception();
            }

        }
    
        public BODFile ConvertToBOD(BODFile[] bodFiles)
        {
            if(Models == null || Models.Count() == 0)
            {
                return null;
            }

            var baseModel = new BODFile();

            int modelIndex = 0;

            foreach(var model in Models)
            {
                if (model.ModelID == -1)
                    continue;
                try
                {
                    //var bodFile = new BODFile();
                    //var file = _ReferenceCatDat.GetInternalFile(String.Format("v/{0}.pbd", model.ModelID.ToString("D5")), AbstractCatDatPair.ExtractionMode.DecryptAndExtract);
                    //var filedata = Encoding.Default.GetString(file);
                    //bodFile.FromText(filedata, model.ModelID);

                    BODFile bodFile = null;
                    foreach(var bod in bodFiles)
                    {
                        if(bod.ID == model.ModelID)
                        {
                            bodFile = (BODFile)bod.Clone();
                            break;
                        }    
                    }
                    if (bodFile == null)
                        throw new Exception();

                    // Rotate
                    if(model.RotationStates.Length > 0)
                        bodFile.ApplyRotationMatrix(model.RotationStates[0].RotationMatrix);

                    const double RESCALE_TO = 2000;
                    // Resize the body to the same relative size before appending it.
                    bodFile.RelativeRescale(RESCALE_TO);
                    // Append body with offset given as a value between -1 and 1 calculated by deviding 0x10000 by the objectsize.
                    baseModel.AppendBody(bodFile, model.PositionStates.Length == 0 ? new Vector3_32(0, 0, 0) : model.PositionStates[0].Position * ((double)0x10000 / (double)RESCALE_TO));
                    //baseModel.AppendBody(bodFile, new Vector3_32(0, 0, 0));
                }
                catch (Exception ex)
                {

                }

                modelIndex++;
            }
            return baseModel;
        }
    }
}
