using System.Drawing;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.ViewModels
{
    public class Bee : IBee
    {
        public int BeeId { get; set; }
        public int BeeIndexWingAnimation { get; set; }

        public bool BeeIsOnDisplayIndoors { get; set; }
        public MovementDirectionEnum BeeIndoorsMovementDirection { get; set; }
        public Rectangle BeeIndoorsSize { get; set; }
        public Bitmap BeeIndoorsWingAnimationImage { get; set; }

        public bool BeeIsOnDisplayOuterWorld { get; set; }
        public MovementDirectionEnum BeeOuterWorldMovementDirection { get; set; }
        public Rectangle BeeInOuterWorldSize { get; set; }
        public Bitmap BeeOuterWorldWingAnimationImage { get; set; }

        public int BeeTargetFlowerID { get; set; }
        
        public int BeeLifeCycleTotalCount { get; set; }
        public BeeEnvironmentBehaviorEnum BeeEnvironmentBehavior { get; set; }
        public int NextBeeMovementCycle { get; set; }
        public int BeeIterationMovementCycleCounter { get; set; }
        public int NextBeeBehaviorType { get; set; }
        public int BeeIterationBehaviorTypeCounter { get; set; }

        public int BeePollenCarryingCapacity { get; set; }
        public int BeePollenCollected { get; set; }
    }
}
