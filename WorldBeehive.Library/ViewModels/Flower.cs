using System.Drawing;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.ViewModels
{
    public class Flower : IFlower
    {
        public int FlowerID { get; set; }
        public Rectangle FlowerLocation { get; set; }
        public FlowerLifeCycleEnum FlowerStage { get; set; }
        public int FlowerPollenContainer { get; set; }
        public Bitmap FlowerImageStage { get; set; }

        public double MinimumCountsToDisplayFlower { get; set; }
        public int CountsToDisplayFlower { get; set; }
        public bool FlowerIsOnDisplay { get; set; }
        public Rectangle FlowerPollenArea { get; set; }
       
    }
}
