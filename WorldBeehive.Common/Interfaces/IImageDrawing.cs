using System.Drawing;
using System.Windows.Forms;

namespace WorldBeehive.Common.Interfaces
{
    public interface IImageDrawing
    {
        void PaintImage(Bitmap image, PaintEventArgs e, Rectangle locationImage);
    }
}
