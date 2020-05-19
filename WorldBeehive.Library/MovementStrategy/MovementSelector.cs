using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.MovementStrategy
{
    public class MovementSelector : IMovementSelector
    {
        public MovementDirectionEnum GetOppositeMovement(MovementDirectionEnum direction)
        {
            switch (direction)
            {
                case MovementDirectionEnum.Down:
                    return MovementDirectionEnum.Up;

                case MovementDirectionEnum.Up:
                    return MovementDirectionEnum.Down;

                case MovementDirectionEnum.Left:
                    return MovementDirectionEnum.Right;

                case MovementDirectionEnum.Right:
                    return MovementDirectionEnum.Left;

                case MovementDirectionEnum.DiagonalLeftDown:
                    return MovementDirectionEnum.DiagonalRightUp;

                case MovementDirectionEnum.DiagonalLeftUp:
                    return MovementDirectionEnum.DiagonalRightDown;

                case MovementDirectionEnum.DiagonalRightUp:
                    return MovementDirectionEnum.DiagonalLeftDown;

                case MovementDirectionEnum.DiagonalRightDown:
                    return MovementDirectionEnum.DiagonalLeftUp;
            }
            return MovementDirectionEnum.Static;
        }
    }
}
