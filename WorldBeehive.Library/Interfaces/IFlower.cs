using System.Drawing;
using WorldBeehive.Library.Enums;

namespace WorldBeehive.Library.Interfaces
{
    public interface IFlower : ILivingBeing
    {
        int FlowerID { get; set; }
        Rectangle FlowerLocation { get; set; }
        FlowerLifeCycleEnum FlowerStage { get; set; }
        int FlowerPollenContainer { get; set; }
        Bitmap FlowerImageStage { get; set; }

        double MinimumCountsToDisplayFlower { get; set; }
        int CountsToDisplayFlower { get; set; }
        bool FlowerIsOnDisplay { get; set; }
        Rectangle FlowerPollenArea { get; set; }
    }
}
