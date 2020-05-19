using System.Collections.Generic;
using System.Windows.Forms;

namespace WorldBeehive.Library.Interfaces
{
    public interface IWorldMediator
    {
        void SetWorldDimmensions(int width, int height);
        void SetMaxFlowersNumber(int flowersCount);
        void CreateNewFlowers();
        List<IFlower> GetAllFlowers();
        void PaintLandscape(PaintEventArgs paintOuterWorldEventArgs);
        void PaintFlowers(PaintEventArgs paintOuterWorldEventArgs);
        void PaintBees(PaintEventArgs paintOuterWorldEventArgs);
        void UpdateAllFlowersLifeCycle();
        void ReceiveBeeFromBeehive(IBee beeInTheOuterWorld);
        List<IBee> GetAllBeesInOuterWorld();
        void MoveBeeInTheWorld();
        void RemoveBeeFromOuterWorld();
    }
}
