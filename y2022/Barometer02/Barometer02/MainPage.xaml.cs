using System.Runtime.CompilerServices;

namespace Barometer02
{
  public partial class MainPage : ContentPage
  {
    IBarometer barometer = Barometer.Default;
    public MainPage()
    {
      InitializeComponent();
    }

    private void StartBtn_Clicked(object sender, EventArgs e)
    {
      if (barometer.IsSupported)
      {
        if (!barometer.IsMonitoring)
        {
          barometer.ReadingChanged += Barometer_ReadingChanged;
          barometer.Start(SensorSpeed.UI);
          StartBtn.IsEnabled = false;
          StopBtn.IsEnabled = true;
        }
      }
      else
      {
        valueLabel.Text = "Barometr is not supported in this device.";
      }
    }

    private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
    {
      //throw new NotImplementedException();
      valueLabel.Text = String.Format("Pressure : {0:0.#} hPa", e.Reading.PressureInHectopascals);
    }

    private void StopBtn_Clicked(object sender, EventArgs e)
    {
      if (barometer.IsSupported)
      {
        if (barometer.IsMonitoring)
        {
          barometer.Stop();
          barometer.ReadingChanged -= Barometer_ReadingChanged;
          StopBtn.IsEnabled = false;
          StartBtn.IsEnabled = true;
        }
      }
    }
  }
}