using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WorldBeehive.Library.Interfaces
{
    public interface IBeehiveMediator
    {
        void SetBeehiveIndoorsSkyDimmensions(Rectangle beehiveSkyDimmensions);
        List<IBee> GetAllBees();
        int GetAllPollenCollected();
        void SetMaxNumberOfBees(int totalBees);
        void CreateFirstBee();
        void ActivateBeeMaternity();
        void AddPollenToMaternityPollenCollector();
        void PaintAllBeesIndoors(Form beehiveForm, PaintEventArgs e);
        void UpdateBeesWingMotionCycle();
        void UpdateAllBeesLifeCycle();
        void MoveAllBeesIndoors();

        void PaintBeehiveIndoors(PaintEventArgs e);
    }
}
