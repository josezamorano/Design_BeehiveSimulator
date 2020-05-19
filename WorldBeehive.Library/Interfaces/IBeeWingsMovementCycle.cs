using System.Collections.Generic;
using WorldBeehive.Library.Models;

namespace WorldBeehive.Library.Interfaces
{
    public interface IBeeWingsMovementCycle
    {
        List<BeeWingMovementCycle> GetBeeBigWingAnimationImages();
        List<BeeWingMovementCycle> GetBeeSmallWingAnimationImages();
    }
}
