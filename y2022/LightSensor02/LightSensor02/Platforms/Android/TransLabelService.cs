using Android.Content;
using Android.Hardware;
using Android.Runtime;
using Android.App;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.OS;

namespace LightSensor02
{
    public class TransLabelService : MauiAppCompatActivity, InterfaceTransLabel, ISensorEventListener
    {
        static Label m_label;
        static SensorManager m_sensorManager;
        static Sensor m_sensor;
        static UpdateService m_service;
        public TransLabelService()
        { 
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            //throw new NotImplementedException();
        }

        public void OnSensorChanged(SensorEvent e)
        {
            m_label.Text = String.Format("Light Values : {0, 10:F3}", e.Values[0]);
            m_service.invalidate();
        }

        public void StartSensor()
        {
            //throw new NotImplementedException();
            m_sensorManager.RegisterListener(this, m_sensor, SensorDelay.Game);
        }

        public void StopSensor()
        {
            m_sensorManager.UnregisterListener(this);
        }

        public void TransLightLabel(Label label, UpdateService service)
        {
            m_sensorManager = MainActivity.m_sensorManager;
            m_sensor = m_sensorManager.GetDefaultSensor(SensorType.Light);
            m_label = label;
            m_service= service;
        }

    }
}
