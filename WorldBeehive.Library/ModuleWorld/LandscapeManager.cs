using System.Drawing;
using System.Windows.Forms;
using WorldBeehive.Common.Interfaces;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.ModuleWorld
{
    public class LandscapeManager: ILandscapeManager
    {
        private int _initialPointX = 0;
        private int _initialPointY = 0;
        private int _widthWorldForm;
        private int _heightWorldForm;

        private IImageDrawing _imageDrawing;
        private IShapeDrawing _shapeDrawing;

        private int _hiveInWorldLocationX = 647;
        private int _hiveInWorldLocationY = 29;
        private int _hiveInWorldWidth = 75;
        private int _hiveInWorldHeight = 75;

        private int _hiveInWorldEntranceDoorLocationX = 700;
        private int _hiveInWorldEntranceDoorLocationY = 85;
        private int _hiveInWorlEntranceDoordWidth = 5;
        private int _hiveInWorlEntranceDoordHeight = 10;


        public LandscapeManager( IShapeDrawing shapeDrawing, IImageDrawing imageDrawing)
        {
          _shapeDrawing =shapeDrawing;
            _imageDrawing = imageDrawing;
        }

        public void SetLandscapeDimmensions(int widthForm, int heightForm)
        {
            _widthWorldForm = widthForm;
            _heightWorldForm = heightForm;
        }

        public Rectangle GetLandscapeDimmensions()
        {
            var initialPointX = 0;
            var initialPointY = _heightWorldForm / 2;
            return new Rectangle(initialPointX, initialPointY, _widthWorldForm, _heightWorldForm);
        }

        public Rectangle GetBeehiveEntranceDoorDimmensions()
        {
            return new Rectangle(_hiveInWorldEntranceDoorLocationX, _hiveInWorldEntranceDoorLocationY, _hiveInWorldWidth, _hiveInWorldHeight);
        }

        public void PaintOuterWorldBoundaries(PaintEventArgs paintOuterWorldEventArgs, Rectangle outerWorldDimmensions)
        {
            Pen penRed = new System.Drawing.Pen(Color.Red, 1);
            _shapeDrawing.PaintRectangleShape(penRed, paintOuterWorldEventArgs, outerWorldDimmensions);
        }

        public void PaintPrairie(PaintEventArgs paintOuterWorldEventArgs)
        {
            int middleHeightPoint = _heightWorldForm / 2;

           var sky = SetSky(_widthWorldForm, middleHeightPoint);
            _shapeDrawing.PaintRectangleSolid(Brushes.LightBlue, paintOuterWorldEventArgs, sky);

            var sun = SetSun();
            _shapeDrawing.PaintCircle(Brushes.Yellow, paintOuterWorldEventArgs, sun);

            Pen penGreen = new System.Drawing.Pen(Color.DarkOliveGreen, 5);
            Point initialPoint = new Point(683, 0);
            Point endingPoint = new Point(683, 30);
            _shapeDrawing.PaintLine(penGreen, paintOuterWorldEventArgs, initialPoint, endingPoint);

            Bitmap hiveInNature = WorldBeehive.Library.Properties.Resource.Hive_outside;
            var hiveLocation = SetHiveLocation();
            _imageDrawing.PaintImage(hiveInNature, paintOuterWorldEventArgs, hiveLocation);
            Rectangle hiveEntranceDoor = SetHiveEntranceDoorLocation();
            Pen penRed = new System.Drawing.Pen(Color.Red, 1);
            _shapeDrawing.PaintRectangleShape(penRed, paintOuterWorldEventArgs, hiveEntranceDoor);

            var prairie = SetPrairie(_widthWorldForm, middleHeightPoint);
            _shapeDrawing.PaintRectangleSolid(Brushes.Green, paintOuterWorldEventArgs, prairie);
        }

        #region Private Methods
        private Rectangle SetSky(int widthForm, int locationPoint)
        {
            Point initialLocationPoint = new Point(_initialPointX, _initialPointY);
            Size skySize = new Size(widthForm, locationPoint);
            Rectangle sky = new Rectangle(initialLocationPoint, skySize);
            return sky;
        }

        private Rectangle SetSun()
        {
            Point sunLocationPoint = new Point(50, 35);
            Size sunSize = new Size(70, 70);
            Rectangle sun = new Rectangle(sunLocationPoint, sunSize);
            return sun;
        }

        private Rectangle SetPrairie(int width, int locationPoint)
        {
            Point middleLocationPoint = new Point(_initialPointX, locationPoint);
            var prairieSize = new Size(width, locationPoint);
            Rectangle prairie = new Rectangle(middleLocationPoint, prairieSize);
            return prairie;
        }

        private Rectangle SetHiveLocation()
        {
            Point hiveLocationPoint = new Point(_hiveInWorldLocationX, _hiveInWorldLocationY);
            Size hiveSize = new Size(_hiveInWorldWidth, _hiveInWorldHeight);
            Rectangle locationHive = new Rectangle(hiveLocationPoint, hiveSize);
            return locationHive;
        }

        private Rectangle SetHiveEntranceDoorLocation()
        {
            Point hiveEnranceDoorLocationPoint = new Point(_hiveInWorldEntranceDoorLocationX, _hiveInWorldEntranceDoorLocationY);
            Size hiveEntranceDoorSize = new Size(_hiveInWorlEntranceDoordWidth, _hiveInWorlEntranceDoordHeight);
            Rectangle locationEnranceDoorHive = new Rectangle(hiveEnranceDoorLocationPoint, hiveEntranceDoorSize);
            return locationEnranceDoorHive;
        }
        #endregion
    }
}
