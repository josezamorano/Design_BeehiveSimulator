using System.Collections.Generic;
using System.Linq;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;
using WorldBeehive.Library.Models;

namespace WorldBeehive.Library.ModuleBee
{
    public class BeeWingsMovementInvoker : IBeeWingsMovementInvoker
    {
        private List<BeeWingsInEnvironment> beeWingsInEnvironments;
        IBeeWingsMovementCycle _beeWingsMovementCycle;
        public BeeWingsMovementInvoker(IBeeWingsMovementCycle beeWingsMovementCycle)
        {
            _beeWingsMovementCycle = beeWingsMovementCycle;
            CreateBeeWings();
        }

        private void CreateBeeWings()
        {
            beeWingsInEnvironments = new List<BeeWingsInEnvironment>()
            {
                new BeeWingsInEnvironment
                {
                    BeeEnvironmentType = BeeEnvironmentEnum.Indoors,
                    BeeWings = _beeWingsMovementCycle.GetBeeBigWingAnimationImages()
                },
                new BeeWingsInEnvironment
                {
                    BeeEnvironmentType = BeeEnvironmentEnum.OuterWorld,
                    BeeWings = _beeWingsMovementCycle.GetBeeSmallWingAnimationImages()
                }
            };
        }

        public BeeWingMovementCycle GetBeeSelectedWingAnimation(int index, BeeEnvironmentEnum beeEnvironment)
        {
            var selectedWings = GetBeeWingsMovementCycles(beeEnvironment);
            var selectedWingImage = selectedWings[index];
            return selectedWingImage;
        }

        public int GetTotalBeeAmimationWingFrames(BeeEnvironmentEnum beeEnvironment)
        {
            var allWings = GetBeeWingsMovementCycles(beeEnvironment);
            return allWings.Count;
        }

        #region Private Helpers
        private List<BeeWingMovementCycle> GetBeeWingsMovementCycles(BeeEnvironmentEnum beeEnvironment)
        {
            var selectedWingMovementCycle = beeWingsInEnvironments.Where(a => a.BeeEnvironmentType == beeEnvironment).FirstOrDefault();
            return selectedWingMovementCycle.BeeWings;
        }
        #endregion

    }
}
