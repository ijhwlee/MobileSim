namespace PhoneUsage
{
  public partial class MainPage : ContentPage
  {

    public MainPage()
    {
      InitializeComponent();
    }

    private void PhoneBtn_Clicked(object sender, EventArgs e)
    {
      if (PhoneDialer.Default.IsSupported)
        PhoneDialer.Default.Open(EditorNumber.Text.Trim());
    }
  }
}