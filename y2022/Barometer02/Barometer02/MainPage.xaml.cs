using System.Runtime.CompilerServices;

namespace Barometer02
{
  public partial class MainPage : ContentPage
  {
    IBarometer barometer = Barometer.Default;
    // physical constants
    const double P0 = 1013.25;
    const double rho = 1.225;
    const double g = 9.80665;
    // https://en.wikipedia.org/wiki/Atmospheric_pressure
    // empirical formula
    // p = p0*(1-L*h/T0)^(g*M/R0*L)
    // h = T0/L*(1-(p/p0)^(R0*L/(g*L)))
    const double L = 0.00976;
    const double T0 = 288.16;
    const double M = 0.02896968;
    const double R0 = 8.314462618;

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
      double pressure = e.Reading.PressureInHectopascals;
      valueLabel.Text = String.Format("Pressure : {0:0.00} hPa", pressure);
      heightLabel.Text = String.Format("Altitude : {0:0.00} m", GetAltitude(pressure));
      altitudeLabel.Text = String.Format("Empirical : {0:0.00} m", GetEmpiricalAltitude(pressure));
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
    private double GetAltitude(double pressure)
    {
      // P + rho *g * h = P0, P0 = 1013.25hPa, rho = 1.225 kg/m^3, g = 9.80665 m/s^2, h = (P0-P)/(rho*g)
      double h = (P0-pressure) / (rho * g) *100; // P is measured in hPa, so multiply 100 to get Pa result
      return h;
    }
    private double GetEmpiricalAltitude(double pressure)
    {
      // empirical formula
      // p = p0*(1-L*h/T0)^(g*M/R0*L)
      // h = T0/L*(1-(p/p0)^(R0*L/(g*L)))
      double h = T0/L*(1-Math.Pow(pressure/P0, R0*L/(g*M)));
      return h;
    }
  }
}
