using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBrightness01
{
    public class MauiService
    {
        Label m_lightLevel;
        public MauiService(Label lightLevel) 
        {
            m_lightLevel = lightLevel;
        }
        public void SetLightLevel(int level)
        {
            m_lightLevel.Text = String.Format("Brightness : {0,3}", level);
        }
    }
}
