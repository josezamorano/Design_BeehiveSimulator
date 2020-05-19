using WorldBeehive.Library.Enums;

namespace WorldBeehive.Library.Interfaces
{
    public interface IMovementSelector
    {
        MovementDirectionEnum GetOppositeMovement(MovementDirectionEnum direction);
    }
}
