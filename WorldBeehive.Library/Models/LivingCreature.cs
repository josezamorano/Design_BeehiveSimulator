using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.ViewModels
{
    public class LivingCreature
    {
        public LivingEntityEnum LivingEntityCode { get; set; }
        public ILivingBeing LivingCreatureOject { get; set; }
    }
}