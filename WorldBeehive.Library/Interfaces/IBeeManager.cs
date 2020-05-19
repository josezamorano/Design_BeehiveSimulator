using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WorldBeehive.Library.Enums;

namespace WorldBeehive.Library.Interfaces
{
    public interface IBeeManager
    {
        void SetBeehiveIndoorsDimmensions(Rectangle beehiveIndoorsDimmensions);
        void SetBeehiveIndoorsExitDoorDimmensions(Rectangle beehiveIndoorsExitDoorDimmensions);
        void SetBeePollenCollected(int collectedPollen);
        int GetBeePollenCollected();
        List<IBee> GetAllBees();
        int CountBees();
        void CreateBee();
        void PaintBeeIndoors(IBee bee, PaintEventArgs paintIndoorsEvent);
        void PaintBeeInOuterWorld(IBee bee, PaintEventArgs paintOuterWorldEvent);
        IBee SetNextBeeWingMovementCycle(IBee bee, BeeEnvironmentEnum beeEnvironment);
        bool RemoveBeeAtEndOFLifeCycle(IBee bee);
        void Move(IBee bee, Rectangle environmentDimmensions);
    }
}
