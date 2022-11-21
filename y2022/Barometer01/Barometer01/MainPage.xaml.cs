namespace Barometer01;

public partial class MainPage : ContentPage
{
  public MainPage()
  {
    InitializeComponent();
  }

  private void StartBtn_Clicked(object sender, EventArgs e)
  {
    StartBtn.IsEnabled = false;
    StopBtn.IsEnabled = true;
  }

  private void StopBtn_Clicked(object sender, EventArgs e)
  {
    StopBtn.IsEnabled = false;
    StartBtn.IsEnabled = true;
  }
}

