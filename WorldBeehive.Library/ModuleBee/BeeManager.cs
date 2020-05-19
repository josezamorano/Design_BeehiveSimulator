using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WorldBeehive.Common.Interfaces;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;
using WorldBeehive.Library.Models;

namespace WorldBeehive.Library.ModuleBee
{
    public class BeeManager : IBeeManager
    {
        private List<IBee> bees = new List<IBee>();
        private Random rand = new Random();
        
        private Rectangle _beehiveIndoorsDimmensions;
        private Rectangle _beehiveExitDoorDimmensions;

        private int _widthBeeIndoors = 50;
        private int _heightBeeIndoors = 50;

        private int _hiveInWorldEntranceDoorLocationX = 700;
        private int _hiveInWorldEntranceDoorLocationY = 85;
        private int _widthBeeWorld = 10;
        private int _heightBeeWorld = 10;

        private int _minBeeLifeCycle = 30000;
        private int _maxBeeLifeCycle = 90000;
        private int _minNextMovementIteration = 15;
        private int _maxNextMovementIteration = 45;
        private int _minNextBehaviorIteration = 70;
        private int _maxNextBehaviorIteration = 100;

        private int _beeMinimumPollenCarryingCapacity = 20;
        private int _beeMaximumPollenCarryingCapacity = 60;

        private int _beePollenCollected = 0;
        IBeeCommon _beeCommon;
        IBeeBehaviorResolver _beeBehaviorResolver;
        IBeeWingsMovementInvoker _beeWingsMovementInvoker;
        IImageDrawing _imageDrawing;
        IMovementBehaviorCommandInvoker _movementBehaviorCommandInvoker;
        ILifeFactory _lifeFactory;
        IInteractionManager _interactionManager;
        ILinearMovementStrategy _linearMovementStrategy;
        IMovementSelector _movementSelector;
        ICommonUtilities _utilitiesResolver;
        public BeeManager(
            IBeeCommon beeCommon,
            IBeeBehaviorResolver beeBehaviorResolver,
            IBeeWingsMovementInvoker beeWingsMovementInvoker,
            IImageDrawing imageDrawing,
            IMovementBehaviorCommandInvoker movementBehaviorCommandInvoker,
            ILifeFactory lifeFactory,
            IInteractionManager interactionManager,
            ILinearMovementStrategy linearMovementStrategy,
            IMovementSelector movementSelector,
            ICommonUtilities utilitiesResolver
            )
        {
             _beeCommon = beeCommon;
            _beeBehaviorResolver = beeBehaviorResolver;
            _beeWingsMovementInvoker = beeWingsMovementInvoker;
            _movementBehaviorCommandInvoker = movementBehaviorCommandInvoker;
            _imageDrawing = imageDrawing;
            _lifeFactory = lifeFactory;
            _interactionManager = interactionManager;
            _linearMovementStrategy = linearMovementStrategy;
            _movementSelector = movementSelector;
            _utilitiesResolver = utilitiesResolver;
        }
        
        public void SetBeehiveIndoorsDimmensions(Rectangle beehiveIndoorsDimmensions)
        {
            _beehiveIndoorsDimmensions = beehiveIndoorsDimmensions;
        }

        public void SetBeehiveIndoorsExitDoorDimmensions(Rectangle beehiveIndoorsExitDoorDimmensions)
        {
            _beehiveExitDoorDimmensions = beehiveIndoorsExitDoorDimmensions;
            _beeBehaviorResolver.SetBeehiveExitDoorDimmensions(beehiveIndoorsExitDoorDimmensions);
        }

        public void SetBeePollenCollected(int collectedPollen)
        {
            _beePollenCollected = collectedPollen;
        }

        public int GetBeePollenCollected()
        {
            return _beePollenCollected;
        }

        public List<IBee> GetAllBees()
        {
            return bees;
        }

        public int CountBees()
        {
            var result = GetAllBees().Count;
            return result;
        }
        
        //Create a Bee
        //paint Bee
        //update lifecycle Bee
        //remove Bee
        public void CreateBee()
        {
            IBee bee = (IBee)_lifeFactory.CreateLivingBeing(LivingEntityEnum.Bee);
            List<int> availableIds = bees.Select(a => a.BeeId).ToList();
            bee.BeeId = _utilitiesResolver.GetMinimumNumberFromASequenceOfNumbers (availableIds);
            bee.BeeLifeCycleTotalCount = rand.Next(_minBeeLifeCycle, _maxBeeLifeCycle);

            int selectedIndex = GetRandomWingIndex(BeeEnvironmentEnum.Indoors);
            BeeWingMovementCycle beeWingAnimationInfo = _beeWingsMovementInvoker.GetBeeSelectedWingAnimation(selectedIndex,BeeEnvironmentEnum.Indoors);
            bee.BeeIndexWingAnimation = beeWingAnimationInfo.BeeWingMovementIndex;

            bee.BeeIsOnDisplayIndoors = true;
            bee.BeeIndoorsWingAnimationImage = beeWingAnimationInfo.BeeWingMovementImage;
            var beeRandomLocationPoint = GetIndoorsRandomLocationPoint();
            var beeIndoorSize = new Size(_widthBeeIndoors, _heightBeeIndoors);
            bee.BeeIndoorsSize = new Rectangle(beeRandomLocationPoint, beeIndoorSize);

            bee.BeeEnvironmentBehavior = _movementBehaviorCommandInvoker.SelectBehaviorRandomly(BeeEnvironmentEnum.Indoors);
            Point exitDoorLocationPoint = new Point(_beehiveExitDoorDimmensions.X, _beehiveExitDoorDimmensions.Y);
            bee.BeeIndoorsMovementDirection = _beeCommon.GetSelectedMovement(bee.BeeEnvironmentBehavior, beeRandomLocationPoint, exitDoorLocationPoint);
            
            bee.BeeIsOnDisplayOuterWorld = false;
            BeeWingMovementCycle BeeWingsInOuterWorld = _beeWingsMovementInvoker.GetBeeSelectedWingAnimation(selectedIndex, BeeEnvironmentEnum.OuterWorld);
            bee.BeeOuterWorldWingAnimationImage = BeeWingsInOuterWorld.BeeWingMovementImage;
            var beehiveWorldEntranceLocationPoint = new Point(_hiveInWorldEntranceDoorLocationX, _hiveInWorldEntranceDoorLocationY);
            var beeWorldSize = new Size(_widthBeeWorld, _heightBeeWorld);
            bee.BeeInOuterWorldSize = new Rectangle(beehiveWorldEntranceLocationPoint, beeWorldSize);
            bee.BeeOuterWorldMovementDirection = MovementDirectionEnum.Static;
            
            bee.NextBeeMovementCycle = rand.Next(_minNextMovementIteration,_maxNextMovementIteration);
            bee.BeeIterationMovementCycleCounter = 0;
            bee.NextBeeBehaviorType = rand.Next(_minNextBehaviorIteration,_maxNextBehaviorIteration);
            bee.BeeIterationBehaviorTypeCounter = 0;

            bee.BeeTargetFlowerID = -1;
            bee.BeePollenCarryingCapacity = rand.Next(_beeMinimumPollenCarryingCapacity,_beeMaximumPollenCarryingCapacity);
            bee.BeePollenCollected = 0;
            bees.Add(bee);
        }

        public void PaintBeeIndoors(IBee bee, PaintEventArgs paintIndoorsEvent)
        { 
           _imageDrawing.PaintImage(bee.BeeIndoorsWingAnimationImage, paintIndoorsEvent, bee.BeeIndoorsSize);
        }

        public void PaintBeeInOuterWorld(IBee bee, PaintEventArgs paintOuterWorldEvent)
        {
           _imageDrawing.PaintImage(bee.BeeOuterWorldWingAnimationImage, paintOuterWorldEvent, bee.BeeInOuterWorldSize);
        }
        
        public IBee SetNextBeeWingMovementCycle(IBee bee, BeeEnvironmentEnum beeEnvironment)
        {
            var nextIndex = bee.BeeIndexWingAnimation + 1;
            if (nextIndex == _beeWingsMovementInvoker.GetTotalBeeAmimationWingFrames(beeEnvironment))
            {
                nextIndex = 0;
            }
            BeeWingMovementCycle nextBeeWingMovement = _beeWingsMovementInvoker.GetBeeSelectedWingAnimation(nextIndex,beeEnvironment);
            bee.BeeIndexWingAnimation = nextBeeWingMovement.BeeWingMovementIndex;
            if (_beeCommon.BeeIsIndoors(bee.BeeEnvironmentBehavior))
            {
                bee.BeeIndoorsWingAnimationImage = nextBeeWingMovement.BeeWingMovementImage;
            }
            if (_beeCommon.BeeIsInOuterWorld(bee.BeeEnvironmentBehavior))
            {
                bee.BeeOuterWorldWingAnimationImage = nextBeeWingMovement.BeeWingMovementImage;
            }
            return bee;
        }
        
        public bool RemoveBeeAtEndOFLifeCycle(IBee bee)
        {
            var selectedBee = UpdateBeeLifeCycle(bee);
            if(selectedBee.BeeIsOnDisplayIndoors && selectedBee.BeeLifeCycleTotalCount <= 0)
            {
                bees.Remove(selectedBee);
                return true;
            }
            return false;
        }

        public void Move(IBee bee, Rectangle environmentDimmensions)
        {   
            //Random Behavior
            if (_beeCommon.BeeBehaviorIsRandom(bee.BeeEnvironmentBehavior))
            { 
                bee = _beeBehaviorResolver.UpdateBeeInfo_OnRandomMovement(bee, environmentDimmensions);
            }
            //targeted Behavior
            if (_beeCommon.BeeBehaviorIsTargeted(bee.BeeEnvironmentBehavior))
            {
                bee = _beeBehaviorResolver.UpdateBeeInfo_OnTargetedMovement(bee);
            }
            //Move Bee Indoors
            if (_beeCommon.BeeIsIndoors(bee.BeeEnvironmentBehavior))
            {
                Point newLocationPoint = _linearMovementStrategy.GetNewLinearMovementPoint(bee.BeeIndoorsMovementDirection);
                bee.BeeIndoorsSize = _interactionManager.GetNewLocationPoint(bee.BeeIndoorsSize, newLocationPoint);
            }
            //Move Bee Outer World
            if (_beeCommon.BeeIsInOuterWorld(bee.BeeEnvironmentBehavior))
            {
                Point newLocationPoint = _linearMovementStrategy.GetNewLinearMovementPoint(bee.BeeOuterWorldMovementDirection);
                bee.BeeInOuterWorldSize = _interactionManager.GetNewLocationPoint(bee.BeeInOuterWorldSize, newLocationPoint);
            }
        }

        #region Private Helpers
        private Point GetIndoorsRandomLocationPoint()
        {
            var locationPointX = rand.Next(_beehiveIndoorsDimmensions.X, _beehiveIndoorsDimmensions.Width - _widthBeeIndoors);
            var locationPointY = rand.Next(_beehiveIndoorsDimmensions.Y, _beehiveIndoorsDimmensions.Height - _heightBeeIndoors);
            return new Point(locationPointX, locationPointY);
        }

        private int GetRandomWingIndex(BeeEnvironmentEnum beeEnvironment)
        {
            int totalWingsFrames = _beeWingsMovementInvoker.GetTotalBeeAmimationWingFrames(beeEnvironment);
            int randomWingIndex = rand.Next(0, totalWingsFrames);
            return randomWingIndex;
        }

        private IBee UpdateBeeLifeCycle(IBee bee)
        {
            bee.BeeLifeCycleTotalCount--;
            return bee;
        }
        #endregion
    }
}
