using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WorldBeehive.Library.Interfaces
{
    public interface IBeehiveManager
    {
        void SetBeehiveSkyDimmensions(Rectangle skyDimmensions);
        void SetBeeMaternityTotalBirths(int totalBeeBirths);
        int GetTotalMaternityPollenCollected();
        List<IBee> GetAllBees();
        void AddPollenToMaternityPollenCollector();
        void ProcessBeeBirthInMaternity();
        void SetBeehiveIndoorsDimmensions();
        void SetBeehiveIndoorsExitDoorDimmensions();
        Rectangle GetBeehiveIndoorsDimmensions();
        Rectangle GetBeehiveIndoorsExitDoorDimmensions();
        void PaintBeehiveIndoors(PaintEventArgs e);
    }
}
