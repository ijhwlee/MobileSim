namespace DependencyInjection;

public partial class App : Application
{
	public App(MainPage mainPage)
	{
		InitializeComponent();

		//MainPage = new AppShell();
    _ = new AppShell();
		MainPage = mainPage;
  }
}
