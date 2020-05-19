using System.Drawing;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.MovementStrategy.BehaviorTypes
{
    public class TargetedMovementBehavior : ITargetedMovementBehavior
    {
        public MovementDirectionEnum Execute(Point? hLocationPoint=null, Point? tLocationPoint=null)
        {
            if (hLocationPoint != null && tLocationPoint != null)
            {
                var hunterLocationPoint = (Point)hLocationPoint;
                Point targetLocationPoint = (Point)tLocationPoint;
                if (targetLocationPoint.X < hunterLocationPoint.X && targetLocationPoint.Y < hunterLocationPoint.Y)
                {
                    return MovementDirectionEnum.DiagonalLeftUp;
                }
                if (targetLocationPoint.X == hunterLocationPoint.X && targetLocationPoint.Y < hunterLocationPoint.Y)
                {
                    return MovementDirectionEnum.Up;
                }
                if (targetLocationPoint.X > hunterLocationPoint.X && targetLocationPoint.Y < hunterLocationPoint.Y)
                {
                    return MovementDirectionEnum.DiagonalRightUp;
                }
                if (targetLocationPoint.X > hunterLocationPoint.X && targetLocationPoint.Y == hunterLocationPoint.Y)
                {
                    return MovementDirectionEnum.Right;
                }

                if (targetLocationPoint.X > hunterLocationPoint.X && targetLocationPoint.Y > hunterLocationPoint.Y)
                {
                    return MovementDirectionEnum.DiagonalRightDown;
                }
                if (targetLocationPoint.X == hunterLocationPoint.X && targetLocationPoint.Y > hunterLocationPoint.Y)
                {
                    return MovementDirectionEnum.Down;
                }
                if (targetLocationPoint.X < hunterLocationPoint.X && targetLocationPoint.Y > hunterLocationPoint.Y)
                {
                    return MovementDirectionEnum.DiagonalLeftDown;
                }
                if (targetLocationPoint.X < hunterLocationPoint.X && targetLocationPoint.Y == hunterLocationPoint.Y)
                {
                    return MovementDirectionEnum.Left;
                }
            }
            return MovementDirectionEnum.Static;
        }
    }
}
