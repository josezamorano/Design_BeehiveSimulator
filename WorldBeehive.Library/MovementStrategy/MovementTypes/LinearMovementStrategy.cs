using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.MovementStrategy.MovementTypes
{
    public class LinearMovementStrategy : ILinearMovementStrategy
    {
        private Point locationPoint;

        public Point GetNewLinearMovementPoint(MovementDirectionEnum movementDirection)
        {
            switch (movementDirection)
            {
                case MovementDirectionEnum.Down:
                    locationPoint.X = 0;
                    locationPoint.Y = +1;
                    return locationPoint;

                case MovementDirectionEnum.Up:
                    locationPoint.X = 0;
                    locationPoint.Y = -1;
                    return locationPoint;

                case MovementDirectionEnum.Left:
                    locationPoint.X = -1;
                    locationPoint.Y = 0;
                    return locationPoint;

                case MovementDirectionEnum.Right:
                    locationPoint.X = +1;
                    locationPoint.Y = 0;
                    return locationPoint;

                case MovementDirectionEnum.DiagonalLeftUp:
                    locationPoint.X = -1;
                    locationPoint.Y = -1;
                    return locationPoint;

                case MovementDirectionEnum.DiagonalRightUp:
                    locationPoint.X = +1;
                    locationPoint.Y = -1;
                    return locationPoint;

                case MovementDirectionEnum.DiagonalRightDown:
                    locationPoint.X = +1;
                    locationPoint.Y = +1;
                    return locationPoint;

                case MovementDirectionEnum.DiagonalLeftDown:
                    locationPoint.X = -1;
                    locationPoint.Y = +1;
                    return locationPoint;

                case MovementDirectionEnum.Static:
                    locationPoint.X = 0;
                    locationPoint.Y = 0;
                    return locationPoint;

            }
            return locationPoint;
        }
    }
}
