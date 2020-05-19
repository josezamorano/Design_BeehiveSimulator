using System.Drawing;
using System.Windows.Forms;

namespace WorldBeehive.Common.Interfaces
{
    public interface IShapeDrawing
    {
        void PaintRectangleSolid(Brush brushColor, PaintEventArgs e, Rectangle surfaceDimmensions);
        void PaintRectangleShape(Pen penTool, PaintEventArgs e, Rectangle surfaceDimmensions);
        void PaintCircle(Brush brushColor, PaintEventArgs e, Rectangle surfaceDimmensions);
        void PaintLine(Pen penTool, PaintEventArgs e, Point initialPoint, Point endingPoint);
    }
}
