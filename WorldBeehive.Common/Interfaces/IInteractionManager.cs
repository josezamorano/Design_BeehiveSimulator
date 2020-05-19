using System.Drawing;

namespace WorldBeehive.Common.Interfaces
{
    public interface IInteractionManager
    {
        bool ObjectAIsBeyondObjectB(Rectangle objectALimits, Rectangle objectBLimits);
        bool ObjectAIntersectsObjectB(Rectangle objectALimits, Rectangle objectBLimits);
        int GetDistanceBetweenObjectAandObjectB(Rectangle objectALimits, Rectangle objectBLimits);
        Rectangle GetNewLocationPoint(Rectangle originalLocationPoint, Point newLocationPoint);
    }
}
