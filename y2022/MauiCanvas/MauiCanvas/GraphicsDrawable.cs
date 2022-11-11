using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCanvas
{
    internal class GraphicsDrawable : IDrawable
    {
        Random rnd = new Random();
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            //throw new NotImplementedException();
            float r = (float)rnd.NextDouble();
            float g = (float)rnd.NextDouble();
            float b = (float)rnd.NextDouble();
            canvas.StrokeColor = new Color(r, g, b);
            canvas.StrokeSize = 6;
            // canvas.StrokeDashPattern = new float[] { 2, 2 };
            canvas.DrawLine(10, 10, 90, 100);
            canvas.FillColor = new Color(1-r, 1-g, 1 - b);
            canvas.FillRectangle(100, 10, 100, 100);
        }
    }
}
