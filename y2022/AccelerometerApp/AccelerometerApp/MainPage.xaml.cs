using System.Numerics;

namespace AccelerometerApp;

public partial class MainPage : ContentPage
{
	IAccelerometer accelerometer=Accelerometer.Default;
	public MainPage()
	{
		InitializeComponent();
	}

	private void StartAcc_Clicked(object sender, EventArgs e)
	{
        if (accelerometer.IsSupported)
        {
            if (!accelerometer.IsMonitoring)
            {
                // Turn on accelerometer
                accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
                accelerometer.Start(SensorSpeed.UI);
                StartAcc.IsEnabled = false;
                StopAcc.IsEnabled = true;
            }
        }
    }

    private void StopAcc_Clicked(object sender, EventArgs e)
	{
        if (accelerometer.IsSupported)
        {
            if (accelerometer.IsMonitoring)
            {
                // Turn off accelerometer
                accelerometer.Stop();
                accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                StartAcc.IsEnabled = true;
                StopAcc.IsEnabled = false;
            }
        }

    }
    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        // Update UI Label with accelerometer state
        AccelLabel.TextColor = Colors.Green;
        Vector3 acc = e.Reading.Acceleration;
        AccelLabel.Text = $"Accel: X:{acc.X:N2}, Y:{acc.Y:N2}, Z:{acc.Z:N2}";
    }
}

