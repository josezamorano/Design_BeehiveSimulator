using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WorldBeehive.Common.Interfaces;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.ModuleWorld.Mediators
{
    public class WorldMediator : IWorldMediator
    {
        private int maxFlowerNumber;
        private int _worldInitialPointX = 0;
        private int _worldInitialPointY = 0;
        private int _worldWidth;
        private int _worldHeight;

        private int _worldBoundariesInitialPointX = 10;
        private int _worldBoundariesInitialPointY = 10;
        private int _worldBoundariesWidth;
        private int _worldBoundariesHeight;
        private Rectangle _worldDimmensions;
        private Rectangle _worldBoundariesDimmensions;
        private Rectangle _beehiveWorldEntranceDimmensions;

        private List<IBee> _allBeesInTheOuterWorld =new  List<IBee>();
        private IBeeCommon _beeCommon;
        private IBeeManager _beeManager;
        private IFlowerManager _flowerManager;
        private ILandscapeManager _landscapeManager;
        private IInteractionManager _interactionManager;
        
        public WorldMediator(
            IBeeCommon beeCommon,
            IBeeManager beeManager,
            IFlowerManager flowerManager, 
            ILandscapeManager landscapeManager,
            IInteractionManager interactionManager)
        {
            _beeCommon = beeCommon;
            _beeManager = beeManager;
            _flowerManager = flowerManager;
            _landscapeManager = landscapeManager;
            _interactionManager = interactionManager;
        }

        public void SetWorldDimmensions(int width, int height)
        {
            _worldWidth = width;
            _worldHeight = height;
            _worldBoundariesWidth = _worldWidth - 40;
            _worldBoundariesHeight = _worldHeight - 60;

            _worldDimmensions = new Rectangle(_worldInitialPointX, _worldInitialPointY, _worldWidth, _worldHeight);
            _worldBoundariesDimmensions = new Rectangle(_worldBoundariesInitialPointX, _worldBoundariesInitialPointY, _worldBoundariesWidth, _worldBoundariesHeight);
            _landscapeManager.SetLandscapeDimmensions(_worldWidth, _worldHeight);
            _beehiveWorldEntranceDimmensions = _landscapeManager.GetBeehiveEntranceDoorDimmensions();
                
        }

        public void SetMaxFlowersNumber(int flowersCount)
        {
            maxFlowerNumber = flowersCount;
        }

        public void CreateNewFlowers()
        {
            while (maxFlowerNumber > _flowerManager.GetAllFlowers().Count)
            {
                _flowerManager.CreateFlower();
            }
        }

        public List<IFlower> GetAllFlowers()
        {
            var allFlowers = _flowerManager.GetAllFlowers();
            return allFlowers;
        }
        
        public void PaintLandscape( PaintEventArgs paintOuterWorldEventArgs)
        {
            _landscapeManager.PaintPrairie(paintOuterWorldEventArgs);
            _landscapeManager.PaintOuterWorldBoundaries(paintOuterWorldEventArgs, _worldBoundariesDimmensions);
        }

        public void PaintFlowers(PaintEventArgs paintOuterWorldEventArgs)
        {
            var allFlowers = GetAllFlowers();
            foreach (var flower in allFlowers)
            {
                _flowerManager.PaintFlower(flower, paintOuterWorldEventArgs);
            }
        }

        public void PaintBees(PaintEventArgs paintOuterWorldEventArgs)
        {
            foreach(var bee in _allBeesInTheOuterWorld)
            {
                if(!bee.BeeIsOnDisplayIndoors && bee.BeeIsOnDisplayOuterWorld)
                {
                    _beeManager.PaintBeeInOuterWorld(bee, paintOuterWorldEventArgs);
                }
            }
        }

        public void UpdateAllFlowersLifeCycle()
        {
            var allFlowers = _flowerManager.GetAllFlowers();
            foreach (var flower in allFlowers)
            {
                if (flower.FlowerIsOnDisplay)
                {
                    _flowerManager.SetNextFlowerLifeCycle(flower);
                    if (_flowerManager.RemoveFlowerAtEndOFLifeCycle(flower))
                    {
                        return;
                    }
                }
            }
        }

        public void ReceiveBeeFromBeehive(IBee beeInTheOuterWorld)
        {
            _allBeesInTheOuterWorld.Add(beeInTheOuterWorld);
        }

        public List<IBee> GetAllBeesInOuterWorld()
        {
            return _allBeesInTheOuterWorld;
        }

        public void MoveBeeInTheWorld()
        {
            foreach(var bee in _allBeesInTheOuterWorld)
            {
                _beeManager.Move(bee, _worldBoundariesDimmensions);
            }
        }

        public void RemoveBeeFromOuterWorld()
        {
            foreach (var bee in _allBeesInTheOuterWorld)
            {
               if(bee.BeeIsOnDisplayIndoors && _beeCommon.BeeIsIndoors(bee.BeeEnvironmentBehavior))
                {
                    _allBeesInTheOuterWorld.Remove(bee);
                    return;
                }
            }
        }
    }
}
