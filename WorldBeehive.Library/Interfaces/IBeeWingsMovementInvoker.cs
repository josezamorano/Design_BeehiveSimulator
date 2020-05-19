using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Models;

namespace WorldBeehive.Library.Interfaces
{
    public interface IBeeWingsMovementInvoker
    {
        BeeWingMovementCycle GetBeeSelectedWingAnimation(int index, BeeEnvironmentEnum beeEnvironment);
        int GetTotalBeeAmimationWingFrames(BeeEnvironmentEnum beeEnvironment);
    }
}
