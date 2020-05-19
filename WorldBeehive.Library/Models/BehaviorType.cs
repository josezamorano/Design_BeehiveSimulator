using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.Models
{
    public class BehaviorType
    {
        public BeeEnvironmentBehaviorEnum BehaviorTypeEnum { get; set; }
        public IBehaviorCommand BehaviorTypeName{ get; set; }
    }
}
