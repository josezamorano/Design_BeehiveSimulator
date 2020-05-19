using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WorldBeehive.Common.Interfaces;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.ModuleBeehive
{
    public class BeehiveManager : IBeehiveManager
    {
        private int _beehiveIndoorsImageLocationPointX = 0;
        private int _beehiveIndoorsImageLocationPointY = 0;
        private int _beehiveIndoorsImageWidth = 300;
        private int _beehiveIndoorsImageHeight = 300;

        private int _beehiveSpaceLocationX = 30;
        private int _beehiveSpaceLocationY = 40;
        private int _beehiveSpaceIndoorsWidth = 250;
        private int _beehiveSpaceIndoorsHeight = 250;

        private int _exitDoorCornerAX = 200;
        private int _exitDoorCornerAY = 215;
        private int _exitDoorWidth = 10;
        private int _exitDoorHeight = 40;

        private int _beeMaternityTotalBirths;
        private int _beeMaternityPollenRequirementPerBirth = 100;
        private int _beeMaternityPollenCollector = 0;
        private Rectangle _beehiveSkyDimmensions;

        IBeeCommon _beeCommon;
        IBeeManager _beeManager;
        IImageDrawing _imageDrawing;
        IShapeDrawing _shapeDrawing;

        public BeehiveManager(IBeeCommon beeCommon, IBeeManager beeManager, IShapeDrawing shapeDrawing, IImageDrawing imageDrawing)
        {
            _beeCommon = beeCommon;
            _beeManager = beeManager;
            _imageDrawing = imageDrawing;
            _shapeDrawing = shapeDrawing;
        }

        public void SetBeehiveSkyDimmensions(Rectangle skyDimmensions)
        {
            _beehiveSkyDimmensions = skyDimmensions;
        }
        public void SetBeeMaternityTotalBirths(int totalBeeBirths)
        {
            _beeMaternityTotalBirths = totalBeeBirths;
        }
        public int GetTotalMaternityPollenCollected()
        {
            var allPollen = _beeMaternityPollenCollector;
            return allPollen;
        }

        public List<IBee> GetAllBees()
        {
            var allBees = _beeManager.GetAllBees();
            return allBees;
        }

        public void AddPollenToMaternityPollenCollector()
        {
            var allBees = GetAllBees();
            foreach(var bee in allBees)
            {
                if(bee.BeeIsOnDisplayIndoors && _beeCommon.BeeIsIndoors(bee.BeeEnvironmentBehavior))
                {
                    if (bee.BeePollenCollected > 0)
                    {
                        _beeMaternityPollenCollector += bee.BeePollenCollected;
                        bee.BeePollenCollected = 0;
                    }
                }
            }
        }

        public void ProcessBeeBirthInMaternity()
        {
            //inside here we compare the amount of pollen we need to create one bee
            // and the maximum number of bees to create.
            //if there is enough pollen and we have not reached the maximum of bees allowed
            //we create one more bee otherwise we just accumulate pollen
            var allBees = GetAllBees().Count;
            if (_beeMaternityPollenCollector >= _beeMaternityPollenRequirementPerBirth &&
                 allBees < _beeMaternityTotalBirths)
            {
                _beeManager.CreateBee();
                _beeMaternityPollenCollector -= _beeMaternityPollenRequirementPerBirth;
            }
        }

        public void SetBeehiveIndoorsDimmensions()
        {
            var beehiveIndoorsDimmensions = new Rectangle(_beehiveSpaceLocationX, _beehiveSpaceLocationY, _beehiveSpaceIndoorsWidth, _beehiveSpaceIndoorsHeight);
            _beeManager.SetBeehiveIndoorsDimmensions(beehiveIndoorsDimmensions);
        }

        public void SetBeehiveIndoorsExitDoorDimmensions()
        {
            var beehiveIndoorsExitDoorDimmensions = GetBeehiveIndoorsExitDoorDimmensions();
            _beeManager.SetBeehiveIndoorsExitDoorDimmensions(beehiveIndoorsExitDoorDimmensions);
        }

        public Rectangle GetBeehiveIndoorsDimmensions()
        {
            var beehiveIndoorsDimmensions = new Rectangle(_beehiveSpaceLocationX, _beehiveSpaceLocationY, _beehiveSpaceIndoorsWidth, _beehiveSpaceIndoorsHeight);
            return beehiveIndoorsDimmensions;
        }

        public Rectangle GetBeehiveIndoorsExitDoorDimmensions()
        {
            var beehiveIndoorsExitDoorDimmensions = new Rectangle(_exitDoorCornerAX, _exitDoorCornerAY, _exitDoorWidth, _exitDoorHeight);
            return beehiveIndoorsExitDoorDimmensions;
        }

        public void PaintBeehiveIndoors(PaintEventArgs e)
        {
            Rectangle sky = _beehiveSkyDimmensions;
            _shapeDrawing.PaintRectangleSolid(Brushes.LightBlue, e, sky);

            Rectangle beeHiveImageDimmensions = new Rectangle(_beehiveIndoorsImageLocationPointX, _beehiveIndoorsImageLocationPointY, _beehiveIndoorsImageWidth, _beehiveIndoorsImageHeight);
            Bitmap insideHive = WorldBeehive.Library.Properties.Resource.Hive_inside;
            _imageDrawing.PaintImage(insideHive, e, beeHiveImageDimmensions);
            
            Pen penRed = new Pen(Color.Red);
            Rectangle beeHiveSpaceMargins = new Rectangle(_beehiveSpaceLocationX, _beehiveSpaceLocationY, _beehiveSpaceIndoorsWidth, _beehiveSpaceIndoorsHeight);
            _shapeDrawing.PaintRectangleShape(penRed, e, beeHiveSpaceMargins);

            Pen penRed2 = new Pen(Color.Red);
            Rectangle beehiveExit = new Rectangle(_exitDoorCornerAX, _exitDoorCornerAY, _exitDoorWidth, _exitDoorHeight);
            _shapeDrawing.PaintRectangleShape(penRed2, e, beehiveExit);
        }
    }
}
