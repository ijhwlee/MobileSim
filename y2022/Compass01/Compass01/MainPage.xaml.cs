namespace Compass01;

public partial class MainPage : ContentPage
{
	int count = 0;
	ICompass compass = Compass.Default;
	private CompassViewModel compassViewModel;

	public MainPage()
	{
		compassViewModel = new CompassViewModel();
		this.BindingContext = compassViewModel;
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count % 2 == 0)
		{
			CounterBtn.Text = $"Clicked {count} time";
			if(compass.IsSupported)
			{
				if(!compass.IsMonitoring)
				{
					compass.ReadingChanged += Compass_ReadingChanged;
					compass.Start(SensorSpeed.Default);
				}
			}
			else
			{
                CompassLabel.Text = "Sensor is not suported in this Device";
            }
        }
		else
		{
			CounterBtn.Text = $"Clicked {count} times";
            if (compass.IsSupported)
            {
                if (compass.IsMonitoring)
                {
                    compass.Stop();
                    compass.ReadingChanged -= Compass_ReadingChanged;
                }
            }
        }

        SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
	{
		var data = e.Reading;
		compassViewModel.Heading = data.HeadingMagneticNorth;
		CompassLabel.Text = data.ToString();
	}
}

