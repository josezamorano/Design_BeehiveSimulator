using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.ModuleBeehive.Mediators
{
    public class BeehiveMediator : IBeehiveMediator
    {
        private Rectangle _beehiveIndoorsDimmensions;
        private Rectangle _beehiveIndoorsExitDoor;

        IBeeManager _beeManager;
        IBeehiveManager _beehiveManager;
        IWorldMediator _worldMediator;
        public BeehiveMediator(IBeeManager beeManager ,IBeehiveManager beehiveManager, IWorldMediator worldMediator)
        {
            _beeManager = beeManager;
            _beehiveManager = beehiveManager;
            _worldMediator = worldMediator;
            
            ProcessBeehive_Setup();
        }

        public void SetBeehiveIndoorsSkyDimmensions(Rectangle beehiveSkyDimmensions)
        {
            _beehiveManager.SetBeehiveSkyDimmensions(beehiveSkyDimmensions);
        }

        public int GetAllPollenCollected()
        {
            var allPollen = _beehiveManager.GetTotalMaternityPollenCollected();
            return allPollen;
        }

        public List<IBee> GetAllBees()
        {
            var allBees = _beehiveManager.GetAllBees();
            return allBees;
        }

        public void SetMaxNumberOfBees(int totalBees)
        {
            _beehiveManager.SetBeeMaternityTotalBirths(totalBees);
        }

        public void CreateFirstBee()
        {
            _beeManager.CreateBee();
        }

        public void ActivateBeeMaternity()
        {
            _beehiveManager.ProcessBeeBirthInMaternity();
        }

        public void AddPollenToMaternityPollenCollector()
        {
            _beehiveManager.AddPollenToMaternityPollenCollector();
        }

        public void PaintBeehiveIndoors( PaintEventArgs paintIndoorsEvent)
        {
             _beehiveManager.PaintBeehiveIndoors(paintIndoorsEvent);
        }

        public void PaintAllBeesIndoors(Form beehiveForm, PaintEventArgs paintIndoorsEvent)
        {
            foreach (var bee in _beeManager.GetAllBees())
            {
                if (bee.BeeIsOnDisplayIndoors && !bee.BeeIsOnDisplayOuterWorld)
                {
                    _beeManager.PaintBeeIndoors(bee, paintIndoorsEvent);
                }
            }
        }

        public void UpdateBeesWingMotionCycle()
        {
            var allBees = _beeManager.GetAllBees();
            foreach(var bee in allBees)
            {
                if(bee.BeeIsOnDisplayIndoors && !bee.BeeIsOnDisplayOuterWorld)
                {
                    _beeManager.SetNextBeeWingMovementCycle(bee,Enums.BeeEnvironmentEnum.Indoors);
                }
                if (!bee.BeeIsOnDisplayIndoors && bee.BeeIsOnDisplayOuterWorld)
                {
                    _beeManager.SetNextBeeWingMovementCycle(bee,Enums.BeeEnvironmentEnum.OuterWorld);
                }
            }
        }

        public void UpdateAllBeesLifeCycle()
        {
            foreach(var bee in _beeManager.GetAllBees())
            {
                if (_beeManager.RemoveBeeAtEndOFLifeCycle(bee))
                {
                    return;
                }
            }
        }

        public void MoveAllBeesIndoors()
        {
            foreach (var bee in _beeManager.GetAllBees())
            {
                if(bee.BeeIsOnDisplayIndoors && !bee.BeeIsOnDisplayOuterWorld)
                {
                    _beeManager.Move(bee, _beehiveIndoorsDimmensions);
                    if (HasBeeReachedBeehiveIndoorsExitDoor(bee))
                    {
                        _worldMediator.ReceiveBeeFromBeehive(bee);
                    }
                }
            }
        }

        #region Private Helpers
        private void ProcessBeehive_Setup()
        {
            _beehiveManager.SetBeehiveIndoorsDimmensions();
            _beehiveManager.SetBeehiveIndoorsExitDoorDimmensions();

            _beehiveIndoorsDimmensions = _beehiveManager.GetBeehiveIndoorsDimmensions();
            _beehiveIndoorsExitDoor = _beehiveManager.GetBeehiveIndoorsExitDoorDimmensions();
        }

        private bool HasBeeReachedBeehiveIndoorsExitDoor(IBee bee)
        {
            var result = (bee.BeeIsOnDisplayIndoors == false && bee.BeeIsOnDisplayOuterWorld == true) ? true : false;
            return result;
        }
        #endregion
    }
}
