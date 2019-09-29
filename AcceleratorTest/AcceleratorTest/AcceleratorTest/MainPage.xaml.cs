using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace AcceleratorTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        SensorSpeed speed = SensorSpeed.UI;
        public MainPage()
        {
            InitializeComponent();
        }
        public void OnStartClicked(object sender, EventArgs e)
        {
            if (!Accelerometer.IsMonitoring)
                Accelerometer.Start(speed);
        }

        override protected void OnAppearing()
        {
            base.OnAppearing();
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
        }
        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            AccX.Text = data.Acceleration.X.ToString();
            AccY.Text = data.Acceleration.Y.ToString();
            AccZ.Text = data.Acceleration.Z.ToString();
        }

        public void OnStopClicked(object sender, EventArgs e)
        {
            if (Accelerometer.IsMonitoring)
                Accelerometer.Stop();
        }
    }
}
