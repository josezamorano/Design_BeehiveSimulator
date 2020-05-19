using System.Drawing;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.ModuleBee
{
    public class BeeCommon: IBeeCommon
    {
        IMovementBehaviorCommandInvoker _movementBehaviorCommandInvoker;
        public BeeCommon(IMovementBehaviorCommandInvoker movementBehaviorCommandInvoker)
        {
            _movementBehaviorCommandInvoker = movementBehaviorCommandInvoker;
        }

        public bool BeeBehaviorIsTargeted(BeeEnvironmentBehaviorEnum beeEnvironmentBehavior)
        {
            var selectedEnvironmentBehavior = beeEnvironmentBehavior.ToString().ToLower();
            var targetedBehavior = BeeBehaviorEnum.Target.ToString().ToLower();
            var isTargeted = (selectedEnvironmentBehavior.Contains(targetedBehavior)) ? true : false;
            return isTargeted;
        }

        public bool BeeBehaviorIsRandom(BeeEnvironmentBehaviorEnum beeEnvironmentBehavior)
        {
            var selectedEnvironmentBehavior = beeEnvironmentBehavior.ToString().ToLower();
            var randomBehavior = BeeBehaviorEnum.Random.ToString().ToLower();
            var isRandom = (selectedEnvironmentBehavior.Contains(randomBehavior)) ? true : false;
            return isRandom;
        }

        public bool BeeIsIndoors(BeeEnvironmentBehaviorEnum selectedEnvironmentBehavior)
        {
            var indoors = BeeEnvironmentEnum.Indoors.ToString().ToLower();
            var isIndoors = (selectedEnvironmentBehavior.ToString().ToLower().Contains(indoors)) ? true : false;
            return isIndoors;
        }

        public bool BeeIsInOuterWorld(BeeEnvironmentBehaviorEnum selectedEnvironmentBehavior)
        {
            var outerWorld = BeeEnvironmentEnum.OuterWorld.ToString().ToLower();
            var isInTheWorld = (selectedEnvironmentBehavior.ToString().ToLower().Contains(outerWorld)) ? true : false;
            return isInTheWorld;
        }
        
        public MovementDirectionEnum GetSelectedMovement(BeeEnvironmentBehaviorEnum selectedBehavior, Point? hunterLocationPoint = null, Point? targetLocationPoint = null)
        {
            IBehaviorCommand behaviorCommand = _movementBehaviorCommandInvoker.GetSelectedBehavioralMovement(selectedBehavior);
            MovementDirectionEnum selectedMovement = behaviorCommand.Execute(hunterLocationPoint, targetLocationPoint);
            return selectedMovement;
        }
    }
}
