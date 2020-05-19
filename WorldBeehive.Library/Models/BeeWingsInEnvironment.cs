using System.Collections.Generic;
using WorldBeehive.Library.Enums;

namespace WorldBeehive.Library.Models
{
    public class BeeWingsInEnvironment
    {
        public BeeEnvironmentEnum BeeEnvironmentType { get; set; }
        public List<BeeWingMovementCycle> BeeWings { get; set; }
    }
}
