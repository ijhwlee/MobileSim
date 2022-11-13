using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBrightness01
{
    public interface InterfaceLightSensor
    {
        void TransferObject(MauiService service);
        void StartLightSensor();
        void StopLightSensor();
    }
}
