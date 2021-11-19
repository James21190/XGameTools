using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Sector;

namespace XCommonLib.UI.Bases.Sector
{
    public partial class SectorMapView : UserControl
    {
        public int GridFactor = 12;
        private int GridSize => GridFactor * 2;
        public int UnitsPerCell = 1000000;

        public float CameraX = 0;
        public float CameraY = 0;

        public GameHook ReferenceGameHook = null;

        #region Structs
        public struct SectorObjectPoint
        {
            public int X, Y;
            public GameHook.GeneralRaces Race;
            public int ObjectType;

            public SectorObjectPoint(int x, int y, GameHook.GeneralRaces race, int objectType)
            {
                X = x;
                Y = y;
                Race = race;
                ObjectType = objectType;
            }

            public SectorObjectPoint(SectorObject sectorObject, GameHook referenceGameHook)
            {
                X = sectorObject.Position.X;
                Y = sectorObject.Position.Z;
                Race = referenceGameHook.GetRaceByID(sectorObject.RaceID);
                ObjectType = sectorObject.ObjectType.MainType;
            }
        }

        #endregion

        private Graphics _Canvas;

        public List<SectorObjectPoint> SectorObjects = new List<SectorObjectPoint>();
        public SectorMapView()
        {
            InitializeComponent();
            _Canvas = pnlMapCanvas.CreateGraphics();
        }
        private void SectorMap_Load(object sender, EventArgs e)
        {
            pnlMapCanvas.MouseWheel += pnlMapCanvas_MouseWheel;
        }

        public void ReloadFromGameHook()
        {
            SectorObjects.Clear();
            var sector = ReferenceGameHook.SectorBase.GetSectorObjects()[0];
            foreach (var child in sector.Meta.GetChildren())
            {
                SectorObjects.Add(new SectorObjectPoint(child, ReferenceGameHook));
            }
        }

        #region Drawing
        private Point _ToScreenSpace(float x, float y)
        {
            float yUnitWidth = (float)pnlMapCanvas.Height / GridSize / UnitsPerCell;
            float xUnitWidth = (float)pnlMapCanvas.Width / GridSize / UnitsPerCell;

            var relativeX = x - (CameraX);
            var relativeY = -y - (CameraY);

            var offsetX = relativeX + UnitsPerCell * (GridSize / 2);
            var offsetY = relativeY + UnitsPerCell * (GridSize / 2);

            var scaledX = offsetX * xUnitWidth;
            var scaledY = offsetY * yUnitWidth;


            return new Point((int)scaledX, (int)scaledY);

        }

        private bool _IsDrawing = false;
        public void Draw()
        {
            if (_IsDrawing) return;
            _IsDrawing = true;
            _Canvas.Clear(Color.Silver);
            _DrawGrid();
            _DrawObjects();
            _IsDrawing = false;
        }

        private void _DrawGrid()
        {
            var pen = new Pen(Color.Gray, 1);
            float ySpacing = (float)pnlMapCanvas.Height / GridSize;
            float xSpacing = (float)pnlMapCanvas.Width / GridSize;
            for (int i = 0; i <= GridSize; i++)
            {
                _Canvas.DrawLine(pen, new Point(0, (int)(ySpacing * i)), new Point(pnlMapCanvas.Width - 1, (int)(ySpacing * i)));
            }
            for (int i = 0; i <= GridSize; i++)
            {
                _Canvas.DrawLine(pen, new Point((int)(xSpacing * i), 0), new Point((int)(xSpacing * i), pnlMapCanvas.Height - 1));
            }

            var cameraPosition = _ToScreenSpace(CameraX, CameraY);
            pen = new Pen(Color.Black, 2);
            _Canvas.DrawLine(pen, 0, cameraPosition.Y, pnlMapCanvas.Width - 1, cameraPosition.Y);
            _Canvas.DrawLine(pen, cameraPosition.X, 0, cameraPosition.X, pnlMapCanvas.Height - 1);
        }

        private void _DrawObjects()
        {
            const int objectWidth = 20 / 2;
            foreach (var sectorObject in SectorObjects)
            {
                var pen = new SolidBrush(GameHook.GetRaceColor(sectorObject.Race));
                var pos = _ToScreenSpace(sectorObject.X, sectorObject.Y);
                pos.X -= objectWidth;
                pos.Y -= objectWidth;
                _Canvas.FillRectangle(pen, new Rectangle(pos, new Size(objectWidth, objectWidth)));
            }
        }
        #endregion

        private int _Scale = 10;
        private void _Rescale(int newScale)
        {
            const int resetNumber = 10;
            _Scale = newScale;
            GridFactor = resetNumber + _Scale % resetNumber;
            UnitsPerCell = 100000 * (int)Math.Pow(2, Math.Floor((double)(_Scale) / resetNumber));
        }

        private void pnlMapCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && _Scale > 1)
            {
                _Rescale(_Scale - 1);
            }
            else if (e.Delta < 0)
            {
                _Rescale(_Scale + 1);
            }
            else
            {
                return;
            }

            Draw();
        }

        private void pnlMapCanvas_Resize(object sender, EventArgs e)
        {
            _Canvas = pnlMapCanvas.CreateGraphics();
            Draw();
        }
    }
}
