using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LightSensor02
{
    public class DataGraphicsView : GraphicsView
    {
        public GraphicsDrawable GraphicsDrawable = new GraphicsDrawable();
        public DataGraphicsView()
        {
            Drawable = GraphicsDrawable;
            this.GraphicsDrawable.maxData = 500;
        }
        public int MaxData
        {
            get => this.GraphicsDrawable.maxData;
            set => this.GraphicsDrawable.maxData = value;
        }
        public void ClearData()
        {
            this.GraphicsDrawable.drawData.Clear();
        }
        public void AddData(Vector3 v)
        {
            if(this.GraphicsDrawable.drawData.Count == this.GraphicsDrawable.maxData)
            {
                this.GraphicsDrawable.drawData.RemoveAt(0);
            }
            this.GraphicsDrawable.drawData.Add(v);
        }
        public void SetLightLevel(float level)
        {
            this.GraphicsDrawable.lightLevel = level;
        }
    }
}
