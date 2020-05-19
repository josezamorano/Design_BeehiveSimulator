using System;
using System.Drawing;
using WorldBeehive.Common.Interfaces;

namespace WorldBeehive.Common.ObjectInteraction
{
    public class InteractionManager : IInteractionManager
    {
        public bool ObjectAIsBeyondObjectB(Rectangle objectALimits, Rectangle objectBLimits)
        {
            var objectAPointX = objectALimits.X;
            var objectAPointY = objectALimits.Y;
            var objectAPointX1 = objectALimits.Width + objectAPointX;
            var objectAPointY1 = objectALimits.Height + objectAPointY;

            var objectBPointX = objectBLimits.X;
            var objectBPointY = objectBLimits.Y;
            var objectBPointX1 = objectBLimits.Width + objectBPointX;
            var objectBPointY1 = objectBLimits.Height + objectBPointY;

            //UP
            if (objectBPointX <= objectAPointX && objectAPointX1 <= objectBPointX1 &&
                objectAPointY <= objectBPointY && objectAPointY1 <= objectBPointY1)
            {
                return true;
            }
            //UP DIAGONAL RIGHT
            if (objectBPointX <= objectAPointX && objectAPointX1 >= objectBPointX1 &&
                objectAPointY <= objectBPointY && objectAPointY1 <= objectBPointY1)
            {
                return true;
            }
            //RIGHT
            if (objectBPointX <= objectAPointX && objectAPointX1 >= objectBPointX1 &&
                objectAPointY >= objectBPointY && objectAPointY1 <= objectBPointY1)
            {
                return true;
            }
            //RIGHT DIAGONAL DOWN
            if (objectBPointX <= objectAPointX && objectAPointX1 >= objectBPointX1 &&
                objectAPointY >= objectBPointY && objectAPointY1 >= objectBPointY1)
            {
                return true;
            }
            //DOWN
            if (objectBPointX <= objectAPointX && objectAPointX1 <= objectBPointX1 &&
                objectAPointY >= objectBPointY && objectAPointY1 >= objectBPointY1)
            {
                return true;
            }
            //LEFT DIAGONAL DOWN
            if (objectBPointX >= objectAPointX && objectAPointX1 <= objectBPointX1 &&
                objectAPointY >= objectBPointY && objectAPointY1 >= objectBPointY1)
            {
                return true;
            }
            //LEFT
            if (objectBPointX >= objectAPointX && objectAPointX1 <= objectBPointX1 &&
                objectAPointY >= objectBPointY && objectAPointY1 <= objectBPointY1)
            {
                return true;
            }
            //LEFT DIAGONAL UP
            if (objectBPointX >= objectAPointX && objectAPointX1 <= objectBPointX1 &&
                objectAPointY <= objectBPointY && objectAPointY1 <= objectBPointY1)
            {
                return true;
            }
            return false;
        }

        public bool ObjectAIntersectsObjectB(Rectangle objectALimits, Rectangle objectBLimits)
        {
            var resultingRectangle = Rectangle.Intersect(objectALimits, objectBLimits);
            if (!resultingRectangle.IsEmpty)
            {
                if (objectALimits.Y == objectBLimits.Y && objectALimits.X == objectBLimits.X)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetDistanceBetweenObjectAandObjectB(Rectangle objectALimits, Rectangle objectBLimits)
        {
            var Y_DistanceAbsoluteValue = Math.Abs(objectALimits.Y - objectBLimits.Y);
            var X_DistanceAbsoluteValue = Math.Abs(objectALimits.X - objectBLimits.X);
            var total = Y_DistanceAbsoluteValue + X_DistanceAbsoluteValue;
            return total;
        }

        public Rectangle GetNewLocationPoint(Rectangle originalLocationPoint, Point newLocationPoint)
        {
            var newPointX = originalLocationPoint.X + newLocationPoint.X;
            var newPointY = originalLocationPoint.Y + newLocationPoint.Y;
            var width = originalLocationPoint.Width;
            var height = originalLocationPoint.Height;
            return new Rectangle(newPointX, newPointY, width, height);
        }
    }
}
