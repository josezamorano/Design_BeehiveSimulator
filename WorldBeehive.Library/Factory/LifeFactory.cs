using WorldBeehive.Library.DependencyInjection;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.Factory
{
    public class LifeFactory : ILifeFactory
    {
        public ILivingBeing CreateLivingBeing(LivingEntityEnum livingEntity)
        {
            switch (livingEntity)
            {
                case LivingEntityEnum.Flower:
                    return ContainerConfig.GetInstance<IFlower>();

                case LivingEntityEnum.Bee:
                    return ContainerConfig.GetInstance<IBee>();
            }
            return null;
        }
    }
}
