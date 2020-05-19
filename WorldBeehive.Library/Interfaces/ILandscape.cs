using System.Drawing;
using System.Windows.Forms;

namespace WorldBeehive.Library.Interfaces
{
    public interface ILandscapeManager
    {
        void SetLandscapeDimmensions(int widthForm, int heightForm);
        Rectangle GetLandscapeDimmensions();
        Rectangle GetBeehiveEntranceDoorDimmensions();
        void PaintOuterWorldBoundaries(PaintEventArgs paintOuterWorldEventArgs, Rectangle outerWorldDimmensions);
        void PaintPrairie(PaintEventArgs e);
    }
}
