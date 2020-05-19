using System.Drawing;
using WorldBeehive.Library.Enums;

namespace WorldBeehive.Library.Interfaces
{
    public interface IBehaviorCommand
    {
        MovementDirectionEnum Execute(Point? hLocationPoint = null, Point? tLocationPoint = null);
    }
}
