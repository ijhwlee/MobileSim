using Android.Hardware;
using Android.Provider;
using Android.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowBrightness01
{
    public class LightSensor : MauiAppCompatActivity, InterfaceLightSensor, ISensorEventListener2
    {
        static SensorManager m_sensorManager = null;
        static Sensor m_sensor = null;
        static MauiService m_mauiService;
        
        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            //throw new NotImplementedException();
        }

        public void OnFlushCompleted(Sensor sensor)
        {
            //throw new NotImplementedException();
        }

        public void OnSensorChanged(SensorEvent e)
        {
            //throw new NotImplementedException();
            int level = (int)e.Values[0];
            if (level > 255)
                level = 255;
            Android.Content.ContentResolver cr = MainActivity.m_contentResolver;
            Android.Provider.Settings.System.PutInt(cr, Settings.System.ScreenBrightness, level);
            m_mauiService.SetLightLevel(level);
        }

        public void StartLightSensor()
        {
            //throw new NotImplementedException();
            if(m_sensorManager == null)
            {
                m_sensorManager = MainActivity.m_sensorManager;
                m_sensor = m_sensorManager.GetDefaultSensor(SensorType.Light);
            }
            m_sensorManager.RegisterListener(this, m_sensor, SensorDelay.Ui);
        }

        public void StopLightSensor()
        {
            //throw new NotImplementedException();
            m_sensorManager.UnregisterListener(this);
        }

        public void TransferObject(MauiService service)
        {
            //throw new NotImplementedException();
            m_mauiService= service;
        }
    }
}
