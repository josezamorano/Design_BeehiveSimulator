using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;
using WorldBeehive.Library.ViewModels;
using WorldBeehive.Library.Properties;
using System.Linq;
using WorldBeehive.Common.Interfaces;

namespace WorldBeehive.Library.ModuleFlower
{
    public class FlowerManager : IFlowerManager
    {
        private List<IFlower> flowers = new List<IFlower>();
        private Random rand = new Random();
        private Rectangle _landscapeDimmensions;
       
        private int _defaultFlowerWidth = 95;
        private int _defaultFlowerHeight = 100;

        private int _minPollenCount = 1000;
        private int _maxPollenCount = 5000;

        private IImageDrawing _imageDrawing;
        private IFlowerLifeCycle _flowerLifeCycle;
        private ILandscapeManager _landscape;
        private ILifeFactory _lifeFactory;
        private IShapeDrawing _shapeDrawing;
        private ICommonUtilities _utilitiesResolver;
        public FlowerManager(
            IImageDrawing imageDrawing, 
            ILifeFactory lifeFactory, 
            ILandscapeManager landscape, 
            IFlowerLifeCycle flowerLifeCycle, 
            IShapeDrawing shapeDrawing, 
            ICommonUtilities utilitiesResolver)
        {
            _imageDrawing = imageDrawing;
            _flowerLifeCycle = flowerLifeCycle;
            _lifeFactory = lifeFactory;
            _landscape = landscape;
            _shapeDrawing = shapeDrawing;
            _utilitiesResolver = utilitiesResolver;
        }

        public List<IFlower> GetAllFlowers()
        {
            return flowers;
        }

        public List<IFlower> GetBlossomingFlowers()
        {
            List<IFlower> blossomingFlowersWithDefinedPollenArea = new List<IFlower>();
            for (var i = 0; i < flowers.Count; i++)
            {
                if (flowers[i].FlowerPollenArea.Width != 0 && flowers[i].FlowerPollenArea.Height != 0)
                {
                    blossomingFlowersWithDefinedPollenArea.Add(flowers[i]);
                }
            }
            return blossomingFlowersWithDefinedPollenArea;
        }


        //Create Flower
        //paint flower
        //update lifecycle Flower
        //remove flower
        public void CreateFlower()
        {
            _landscapeDimmensions = _landscape.GetLandscapeDimmensions();
            Point randomFlowerLocationPoint = GetRandomLocation(_landscapeDimmensions.Height, _landscapeDimmensions.Width);
            Size flowerSize = new Size(_defaultFlowerWidth, _defaultFlowerHeight);

            IFlower flower = (IFlower)_lifeFactory.CreateLivingBeing(Enums.LivingEntityEnum.Flower);
            List<int> availableIds = GetAllFlowers().Select(a => a.FlowerID).ToList();
            flower.FlowerID = _utilitiesResolver.GetMinimumNumberFromASequenceOfNumbers(availableIds);
            flower.FlowerLocation = new Rectangle(randomFlowerLocationPoint, flowerSize);
            flower.FlowerImageStage = Properties.Resource.plant01;
            flower.FlowerStage = FlowerLifeCycleEnum.Birth1;
            flower.FlowerPollenContainer = rand.Next(_minPollenCount, _maxPollenCount);
            flower.MinimumCountsToDisplayFlower = SetMinimumCounterToDisplayFlower();
            flower.CountsToDisplayFlower = 0;
            flower.FlowerIsOnDisplay = false;
            flower.FlowerPollenArea = new Rectangle(0, 0, 0, 0);
            flowers.Add(flower);
        }

        public void PaintFlower(IFlower flower, PaintEventArgs paintOuterWorldEventArgs)
        {
           
            if(CanFlowerDisplay(flower))
            {
                flower.FlowerIsOnDisplay = true;
                Bitmap flowerImage = flower.FlowerImageStage;
                _imageDrawing.PaintImage(flowerImage, paintOuterWorldEventArgs, flower.FlowerLocation);
                _shapeDrawing.PaintRectangleSolid(Brushes.Blue, paintOuterWorldEventArgs, flower.FlowerPollenArea);
            }
        }

        public IFlower SetNextFlowerLifeCycle(IFlower flower)
        {
            FlowerCycle nextFlowerCycle = _flowerLifeCycle.GetNextFlowerCycle(flower.FlowerStage);
            if (nextFlowerCycle == null)
            {
                flower.FlowerImageStage = Resource.plant21;
                flower.FlowerStage = FlowerLifeCycleEnum.Dissapeareance;
                return flower;
            }
            flower.FlowerImageStage = nextFlowerCycle.FlowerCycleImage;
            flower.FlowerStage = nextFlowerCycle.FlowerCycleStage;
            var locationX = flower.FlowerLocation.X + nextFlowerCycle.FlowerPollenArea.X;
            var locationY = flower.FlowerLocation.Y + nextFlowerCycle.FlowerPollenArea.Y;
            var width = nextFlowerCycle.FlowerPollenArea.Width;
            var height = nextFlowerCycle.FlowerPollenArea.Height;
            flower.FlowerPollenArea = new Rectangle(locationX,locationY ,width ,height); 

            return flower;
        }

        public bool RemoveFlowerAtEndOFLifeCycle(IFlower flower)
        {
            if (flower.FlowerStage == FlowerLifeCycleEnum.Dissapeareance)
            {
                flowers.Remove(flower);
                return true;
            }
            return false;
        }

        #region Helpers
        private List<int> GetMasterList()
        {
            var smallMinimunNumber = rand.Next(0, 50);
            var mediumMinimunNumber = rand.Next(300, 350);
            var largeMinimunNumber = rand.Next(600, 650);
            List<int> masterList = new List<int>() { smallMinimunNumber, mediumMinimunNumber, largeMinimunNumber };
            return masterList;
        }

        private int counter = 0;
        List<int> minimunNumbers = new List<int>();
        private double SetMinimumCounterToDisplayFlower()
        {
            if (counter == 0)
            {
                minimunNumbers = GetMasterList();
            }
            int maxIndexLevel = minimunNumbers.Count;
            var indexSelector = rand.Next(0, maxIndexLevel);
            var result = minimunNumbers[indexSelector];
            if (minimunNumbers.Count > 0)
            {
                minimunNumbers.RemoveAt(indexSelector);
                counter++;
            }
            if(minimunNumbers.Count == 0)
            {
                minimunNumbers = GetMasterList();
                counter = 0;
            }
            return result;
        }

        private Point GetRandomLocation(int worldHeight, int worldWidth)
        {
            var landscapeTopX = 0;
            var landscapeTopY = worldHeight / 2;
            var landscapeWidthBottomX = worldWidth - _defaultFlowerWidth;
            var landscapeHeightBottomY = worldHeight - _defaultFlowerHeight-50;

            var pointX = rand.Next(landscapeTopX, landscapeWidthBottomX);
            var pointY = rand.Next(landscapeTopY, landscapeHeightBottomY);
            return new Point(pointX, pointY);
        }

        private bool CanFlowerDisplay(IFlower flower)
        {
            flower.CountsToDisplayFlower++;
            var canDisplay = (flower.CountsToDisplayFlower >= flower.MinimumCountsToDisplayFlower);
            return canDisplay;
        }

        private int CountFlowers()
        {
            var result = GetAllFlowers().Count;
            return result;
        }
        #endregion
    }
}
