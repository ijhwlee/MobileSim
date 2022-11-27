namespace WebView01;

public partial class MainPage : ContentPage
{
  public MainPage()
  {
    InitializeComponent();
  }

  private async void OpenBtn_Clicked(object sender, EventArgs e)
  {
    try
    {
      //Uri uri = new Uri("https://www.inje.ac.kr");
      string url = targetURL.Text;
      if (IsValidUrl(url))
      {
        Uri uri = new Uri(url);
        await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
      }
      else
      {
        await DisplayAlert("Alert", $"{url} is not a valid address.", "OK");
      }
    }
    catch (Exception ex)
    {
      // An unexpected error occured. No browser may be installed on the device.
      Console.WriteLine(ex.Message);
    }
  }
  private bool IsValidUrl(string address)
  {
    return Uri.IsWellFormedUriString(address, UriKind.RelativeOrAbsolute);
  }

  private async void MapBtn_Clicked(object sender, EventArgs e)
  {
    var location = new Location(47.645160, -122.1306032);
    var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

    try
    {
      await Map.Default.OpenAsync(location, options);
    }
    catch (Exception ex)
    {
      // No map application available to open
      Console.WriteLine(ex.Message);
    }
  }
}
