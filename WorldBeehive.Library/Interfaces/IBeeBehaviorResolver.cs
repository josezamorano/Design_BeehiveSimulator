using System.Drawing;

namespace WorldBeehive.Library.Interfaces
{
    public interface IBeeBehaviorResolver
    {
        void SetBeehiveExitDoorDimmensions(Rectangle beehiveExitDoorDimmensions);
        IBee UpdateBeeInfo_OnRandomMovement(IBee bee, Rectangle environmentDimmensions);
        IBee UpdateBeeInfo_OnTargetedMovement(IBee bee);
    }
}
