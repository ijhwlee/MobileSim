namespace MauiDITest
{
  public partial class MainPage : ContentPage
  {
    //private readonly IPlatformDiService _platformDiService;
    int count = 0;

    public MainPage(MainPageViewModel mainPageViewModel)
    {
      InitializeComponent();
      this.BindingContext = mainPageViewModel;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
      count++;

      if (count == 1)
        CounterBtn.Text = $"Clicked {count} time";
      else
        CounterBtn.Text = $"Clicked {count} times";

      SemanticScreenReader.Announce(CounterBtn.Text);
    }
  }
}