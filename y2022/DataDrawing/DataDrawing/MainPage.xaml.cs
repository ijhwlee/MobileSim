using Microsoft.Maui.Devices.Sensors;
using System.Numerics;

namespace DataDrawing;

public partial class MainPage : ContentPage
{
	IAccelerometer accelerometer = Accelerometer.Default;
	public MainPage()
	{
		InitializeComponent();
		myCanvas.ClearData();
	}

	private void StartButton_Clicked(object sender, EventArgs e)
	{
		if(accelerometer.IsSupported)
		{
			if(!accelerometer.IsMonitoring)
			{
				accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
				accelerometer.Start(SensorSpeed.UI);
				StartButton.IsEnabled = false;
				StopButton.IsEnabled = true;
			}
		}
	}

	private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
	{
		Vector3 value = e.Reading.Acceleration;
		myCanvas.AddData(value);
		myCanvas.Invalidate();
		AccValue.Text = String.Format("({0:N2}, {1:N2}, {2:N2})", value.X, value.Y, value.Z);
	}

	private void StopButton_Clicked(object sender, EventArgs e)
	{
		if(accelerometer.IsSupported)
		{
			if(accelerometer.IsMonitoring)
			{
				accelerometer.Stop();
				accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
				StartButton.IsEnabled = true;
				StopButton.IsEnabled = false;
			}
		}
	}
}

