using System.Drawing;
using WorldBeehive.Library.Enums;

namespace WorldBeehive.Library.ViewModels
{
    public class FlowerCycle
    {
        public FlowerLifeCycleEnum FlowerCycleStage { get; set; }
        public Bitmap FlowerCycleImage { get; set; }
        public Rectangle FlowerPollenArea { get; set; }
    }
}
