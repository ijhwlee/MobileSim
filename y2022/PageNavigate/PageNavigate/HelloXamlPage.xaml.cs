namespace PageNavigate;

public partial class HelloXamlPage : ContentPage
{
	IDispatcherTimer timer;
	bool timerOn = false;
	public HelloXamlPage()
	{
		InitializeComponent();
		LabelHello.TranslationY = 300;
		SetTimer();
	}

	private void ToggleRotate_Clicked(object sender, EventArgs e)
	{
		timerOn = !timerOn;
		if (timerOn)
		{
			timer.Start();
			ToggleRotate.BackgroundColor = Colors.Red;
			ToggleRotate.Text= "Stop Rotate";
		}
		else
		{
			timer.Stop();
      ToggleRotate.BackgroundColor = Colors.Blue;
      ToggleRotate.Text = "Start Rotate";
    }
  }
	private void SetTimer()
	{
    timer = Dispatcher.CreateTimer();
    timer.Interval = TimeSpan.FromMilliseconds(100);
    timer.Tick += Timer_Tick;
  }

  private void Timer_Tick(object sender, EventArgs e)
  {
		LabelHello.Rotation = LabelHello.Rotation + 10;
  }
}