using System.Drawing;
using System.Windows.Forms;
using WorldBeehive.Common.Interfaces;

namespace WorldBeehive.Common.Graphics
{
    public class ShapeDrawing : IShapeDrawing
    {
        public void PaintRectangleSolid(Brush brushColor, PaintEventArgs e, Rectangle surfaceDimmensions)
        {
            e.Graphics.FillRectangle(brushColor, surfaceDimmensions);
        }

        public void PaintRectangleShape(Pen penTool, PaintEventArgs e, Rectangle surfaceDimmensions)
        {
            e.Graphics.DrawRectangle(penTool, surfaceDimmensions);
        }

        public void PaintCircle(Brush brushColor, PaintEventArgs e, Rectangle surfaceDimmensions)
        {
            e.Graphics.FillEllipse(brushColor, surfaceDimmensions);
        }

        public void PaintLine(Pen penTool, PaintEventArgs e, Point initialPoint, Point endingPoint)
        {
            e.Graphics.DrawLine(penTool, initialPoint, endingPoint);
        }
    }
}
