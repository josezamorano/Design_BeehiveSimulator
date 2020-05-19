using System.Drawing;
using WorldBeehive.Library.Enums;

namespace WorldBeehive.Library.Interfaces
{
    public interface IBeeCommon
    {
        bool BeeBehaviorIsTargeted(BeeEnvironmentBehaviorEnum beeEnvironmentBehavior);
        bool BeeBehaviorIsRandom(BeeEnvironmentBehaviorEnum beeEnvironmentBehavior);
        bool BeeIsIndoors(BeeEnvironmentBehaviorEnum selectedEnvironmentBehavior);
        bool BeeIsInOuterWorld(BeeEnvironmentBehaviorEnum selectedEnvironmentBehavior);
        MovementDirectionEnum GetSelectedMovement(BeeEnvironmentBehaviorEnum selectedBehavior, Point? hunterLocationPoint = null, Point? targetLocationPoint = null);
    }
}
