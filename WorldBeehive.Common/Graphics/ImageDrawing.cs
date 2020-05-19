using System.Drawing;
using System.Windows.Forms;
using WorldBeehive.Common.Interfaces;

namespace WorldBeehive.Common.Graphics
{
    public class ImageDrawing : IImageDrawing
    {
        public void PaintImage(Bitmap image, PaintEventArgs e, Rectangle locationImage)
        {
            e.Graphics.DrawImage(image, locationImage);

            //NOTE: Uncomment when debugging only
            using (Pen pen = new Pen(Color.Red))
            {
                e.Graphics.DrawRectangle(pen, locationImage);
            }

        }
    }
}
