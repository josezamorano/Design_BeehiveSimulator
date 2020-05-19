using WorldBeehive.Library.Enums;

namespace WorldBeehive.Library.Interfaces
{
    public interface ILifeFactory
    {
        ILivingBeing CreateLivingBeing(LivingEntityEnum livingEntity);
    }
}
