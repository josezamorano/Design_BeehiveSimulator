using WorldBeehive.Library.Enums;

namespace WorldBeehive.Library.Interfaces
{
    public interface IMovementBehaviorCommandInvoker
    {
        IBehaviorCommand GetSelectedBehavioralMovement(BeeEnvironmentBehaviorEnum indoorsBeeBehavior);
        BeeEnvironmentBehaviorEnum SelectBehaviorRandomly(BeeEnvironmentEnum beeEnvironment);
    }
}
