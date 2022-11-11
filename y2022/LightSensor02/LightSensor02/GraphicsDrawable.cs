using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LightSensor02
{
    public class GraphicsDrawable : IDrawable
    {
        public ArrayList drawData = new();
        public int maxData = 200;
        public float lightLevel=0;
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            DrawLightCircle(canvas);
        }
        public void DrawLightCircle(ICanvas canvas)
        {
            canvas.FillColor = new Color(1.0f, 0.0f, 0);
            canvas.FillCircle(200, 200, lightLevel);
        }
    }
}
