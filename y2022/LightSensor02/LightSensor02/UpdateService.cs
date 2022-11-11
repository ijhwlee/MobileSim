using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSensor02
{
    public class UpdateService
    {
        public DataGraphicsView m_canvas;
        Label m_lightLabel;
        public UpdateService(Label lightLabel)
        {
            m_lightLabel = lightLabel;  
        }
        public DataGraphicsView Canvas { set { m_canvas = value; }  get { return m_canvas; } }
        public void invalidate()
        {
            String value = m_lightLabel.Text;
            int found = value.IndexOf(": ");
            float level = float.Parse(value.Substring(found + 2));
            m_canvas.SetLightLevel(level);
            m_canvas.Invalidate();
        }
    }
}
