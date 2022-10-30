using System.Numerics;

namespace Gyroscope01;

public partial class MainPage : ContentPage
{
	IGyroscope gyroscope = Gyroscope.Default;
	DateTime prevTime;
	DateTime currentTime;
	public MainPage()
	{
		InitializeComponent();
	}
	private void StartBtn_Clicked(object sender, EventArgs e)
	{
		if(gyroscope.IsSupported)
		{
			if(!gyroscope.IsMonitoring)
			{
				gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
				gyroscope.Start(SensorSpeed.UI);
				StartBtn.IsEnabled = false;
				StopBtn.IsEnabled = true;
				prevTime = DateTime.Now;
				currentTime = DateTime.Now;
			}
		}
	}
	private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
	{
        currentTime = DateTime.Now;
        long elapsedTicks = currentTime.Ticks - prevTime.Ticks;
        TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
		double delta = elapsedSpan.TotalSeconds;
		prevTime = currentTime;
        Vector3 dir = e.Reading.AngularVelocity;
		LabelGyroscope.Text = $"Angluar Velocity = [{dir.X*180/Math.PI:N1}, {dir.Y * 180 / Math.PI:N1}, {dir.Z * 180 / Math.PI:N1}]";
        LabelDelta.Text = $"Delta Time = {delta:N4} seconds";
    }

    private void StopBtn_Clicked(object sender, EventArgs e)
	{
        if (gyroscope.IsSupported)
        {
            if (gyroscope.IsMonitoring)
            {
				gyroscope.Stop();
                gyroscope.ReadingChanged -= Gyroscope_ReadingChanged;
                StartBtn.IsEnabled = true;
                StopBtn.IsEnabled = false;
            }
        }
    }
}

