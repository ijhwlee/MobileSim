namespace WindowBrightness01;

public partial class App : Application
{
	public App(MainPage mainPage)
	{
		InitializeComponent();

		_ = new AppShell();
		MainPage = mainPage;
	}
}
