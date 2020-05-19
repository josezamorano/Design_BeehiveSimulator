using System.Drawing;
using WorldBeehive.Library.Enums;

namespace WorldBeehive.Library.Interfaces
{
    public interface ILinearMovementStrategy
    {
        Point GetNewLinearMovementPoint(MovementDirectionEnum movementDirection);
    }
}
