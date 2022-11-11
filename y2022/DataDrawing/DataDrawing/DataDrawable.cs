using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataDrawing
{
    internal class DataDrawable : IDrawable
    {
        public ArrayList drawData = new();
        public int maxData = 350;
        public float width;
        public float height;
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            DrawBox(canvas);
            if (drawData.Count == 0)
                return;
            DrawComponent(canvas, "X", Colors.Red);
            DrawComponent(canvas, "Y", Colors.Green);
            DrawComponent(canvas, "Z", Colors.Blue);
        }
        private void DrawBox(ICanvas canvas)
        {
            canvas.StrokeColor = Colors.White;
            canvas.StrokeSize = 1;
            canvas.DrawRectangle(0,0, width, height);
            canvas.DrawLine(0, height / 2, width, height / 2);
            canvas.StrokeColor = Colors.Yellow;
            canvas.DrawLine(0, height / 2 + 0.4f * height, width, height / 2 + 0.4f * height);
            canvas.DrawLine(0, height / 2 - 0.4f * height, width, height / 2 - 0.4f * height);
        }
        private void DrawComponent(ICanvas canvas, string component, Color c)
        {
            int cnt = drawData.Count;
            canvas.FillColor = c;
            for(int i=0; i<cnt; i++)
            {
                Vector3 data = (Vector3)drawData[i];
                float v = data.X;
                if (component == "X")
                    v = data.X;
                else if (component == "Y")
                    v = data.Y;
                else if (component == "Z")
                    v = data.Z;
                canvas.FillRectangle(i, height/2-0.4f*height * (v), 2, 2);
            }
        }
    }
}
