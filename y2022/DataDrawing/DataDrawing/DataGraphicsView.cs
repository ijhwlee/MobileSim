using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataDrawing
{
    internal class DataGraphicsView : GraphicsView
    {
        public DataDrawable DataDrawable = new DataDrawable();
        public DataGraphicsView()
        {
            Drawable = DataDrawable;
        }
        public void ClearData()
        {
            this.DataDrawable.width = (float)this.WidthRequest;
            this.DataDrawable.height = (float)this.HeightRequest;
            this.DataDrawable.maxData = (int)(0.9 * this.WidthRequest);
            //Console.WriteLine("w:{0:N1}, h:{1:N1}", this.DataDrawable.width, this.DataDrawable.height);
            this.DataDrawable.drawData.Clear();
        }
        public void AddData(Vector3 data)
        {
            if(this.DataDrawable.drawData.Count == this.DataDrawable.maxData)
            {
                this.DataDrawable.drawData.RemoveAt(0);
            }
            this.DataDrawable.drawData.Add(data);
        }
    }
}
