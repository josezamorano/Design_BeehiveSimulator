using System.Collections.Generic;
using WorldBeehive.Library.Interfaces;
using WorldBeehive.Library.Models;

namespace WorldBeehive.Library.ModuleBee
{
    public class BeeWingsMovementCycle : IBeeWingsMovementCycle
    {
        private List<BeeWingMovementCycle> beeBigWingAnimationImages;
        private List<BeeWingMovementCycle> beeSmallWingAnimationImages;
        public BeeWingsMovementCycle()
        {
            CreateIndoorsBigWingsMovementCycle();
            CreateWorldSmallWingsMovementCycle();
        }
        
        public List<BeeWingMovementCycle> GetBeeBigWingAnimationImages()
        {
            return beeBigWingAnimationImages;
        }

        public List<BeeWingMovementCycle> GetBeeSmallWingAnimationImages()
        {
            return beeSmallWingAnimationImages; 
        }

        #region Private Helpers
        private void CreateIndoorsBigWingsMovementCycle()
        {
            beeBigWingAnimationImages = new List<BeeWingMovementCycle>()
            {
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=0,
                    BeeWingMovementImage = Properties.Resource.Bee_animation_1a
                },
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=1,
                    BeeWingMovementImage = Properties.Resource.Bee_animation_2a,
                },
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=2,
                    BeeWingMovementImage = Properties.Resource.Bee_animation_3a,
                },
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=3,
                    BeeWingMovementImage =  Properties.Resource.Bee_animation_4a,
                },
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=4,
                    BeeWingMovementImage =  Properties.Resource.Bee_animation_3a,
                },
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=5,
                    BeeWingMovementImage = Properties.Resource.Bee_animation_2a
                },
            };
        }

        private void CreateWorldSmallWingsMovementCycle()
        {
            beeSmallWingAnimationImages = new List<BeeWingMovementCycle>()
            {
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=0,
                    BeeWingMovementImage = Properties.Resource.Bee_animation_1
                },
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=1,
                    BeeWingMovementImage = Properties.Resource.Bee_animation_2,
                },
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=2,
                    BeeWingMovementImage = Properties.Resource.Bee_animation_3,
                },
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=3,
                    BeeWingMovementImage =  Properties.Resource.Bee_animation_4,
                },
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=4,
                    BeeWingMovementImage =  Properties.Resource.Bee_animation_3,
                },
                new BeeWingMovementCycle()
                {
                    BeeWingMovementIndex=5,
                    BeeWingMovementImage = Properties.Resource.Bee_animation_2
                },
            };
        }
        #endregion 
    }
}
