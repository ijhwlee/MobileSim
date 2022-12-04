namespace PhoneUsage
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();
    }

    private void DialerBtn_Clicked(object sender, EventArgs e)
    {
      if (PhoneDialer.Default.IsSupported)
        PhoneDialer.Default.Open("000-000-0000");
    }
  }
}