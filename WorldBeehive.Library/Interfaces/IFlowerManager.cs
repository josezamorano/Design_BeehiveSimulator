using System.Collections.Generic;
using System.Windows.Forms;

namespace WorldBeehive.Library.Interfaces
{
    public interface IFlowerManager
    {
        void CreateFlower();
        List<IFlower> GetAllFlowers();
        List<IFlower> GetBlossomingFlowers();
        void PaintFlower(IFlower flower, PaintEventArgs e);
        IFlower SetNextFlowerLifeCycle(IFlower flower);
        bool RemoveFlowerAtEndOFLifeCycle(IFlower flower);
    }
}
