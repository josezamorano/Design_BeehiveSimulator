using System.Drawing;
using WorldBeehive.Library.Enums;

namespace WorldBeehive.Library.Interfaces
{
    public interface IBee : ILivingBeing
    {
        int BeeId { get; set; }
        int BeeIndexWingAnimation { get; set; }

        bool BeeIsOnDisplayIndoors { get; set; }
        MovementDirectionEnum BeeIndoorsMovementDirection { get; set; }
        Rectangle BeeIndoorsSize { get; set; }
        Bitmap BeeIndoorsWingAnimationImage { get; set; }
        
        bool BeeIsOnDisplayOuterWorld { get; set; }
        MovementDirectionEnum BeeOuterWorldMovementDirection { get; set; }
        Rectangle BeeInOuterWorldSize { get; set; }
        Bitmap BeeOuterWorldWingAnimationImage { get; set; }

        int BeeTargetFlowerID { get; set; }

        int BeeLifeCycleTotalCount { get; set; }
        BeeEnvironmentBehaviorEnum BeeEnvironmentBehavior { get; set; }
        int NextBeeMovementCycle { get; set; }
        int BeeIterationMovementCycleCounter { get; set; }
        int NextBeeBehaviorType { get; set; }
        int BeeIterationBehaviorTypeCounter { get; set; }

        int BeePollenCarryingCapacity { get; set; }
        int BeePollenCollected { get; set; }

    }
}
