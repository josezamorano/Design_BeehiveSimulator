using WorldBeehive.Library.Enums;
using WorldBeehive.Library.ViewModels;

namespace WorldBeehive.Library.Interfaces
{
    public interface IFlowerLifeCycle
    {
        FlowerCycle GetSelectedFlowerCycle(FlowerLifeCycleEnum flowerLifeCycle);
        FlowerCycle GetNextFlowerCycle(FlowerLifeCycleEnum flowerLifeCycle);
    }
}
