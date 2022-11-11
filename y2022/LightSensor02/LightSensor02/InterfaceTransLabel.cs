using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSensor02
{
    public interface InterfaceTransLabel
    {
        void TransLightLabel(Label label, UpdateService service);
        void StartSensor();
        void StopSensor();
    }
}
