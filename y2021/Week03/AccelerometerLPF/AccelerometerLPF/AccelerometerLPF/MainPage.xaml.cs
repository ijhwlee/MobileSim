using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace AccelerometerLPF
{
    public partial class MainPage : ContentPage
    {
        int upperMultiple = 1000;
        int number = 0;
        int count = 0;
        List<Vector3> accValues = null;
        public MainPage()
        {
            InitializeComponent();
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            if (Accelerometer.IsMonitoring)
                return;
            number = int.Parse(avgNumber.Text);
            accValues = new List<Vector3>(number);
            count = 0;
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Start(SensorSpeed.UI);
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            if (count >= number)
            {
                Vector3 avg = average();
                accValue.Text = String.Format("ax = {0,6:F3}, ay = {1,6:F3}, az = {2,6:F3}",
                    avg.X, avg.Y, avg.Z);
                count++;
                int index = count % number;
                accValues[index] = e.Reading.Acceleration;
                if (count/number > upperMultiple)
                {
                    count = number + count % number;
                }
            }
            else
            {
                accValues.Add(e.Reading.Acceleration);
                count++;
            }
        }

        private void StopButton_Clicked(object sender, EventArgs e)
        {
            if (!Accelerometer.IsMonitoring)
                return;
            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
            Accelerometer.Stop();
        }
        private Vector3 average()
        {
            Vector3 avg = new Vector3(0, 0, 0);
            for(int i = 0; i<accValues.Count; i++)
            {
                avg += accValues[i];
            }
            avg /= accValues.Count;
            return avg;
        }
    }
}
