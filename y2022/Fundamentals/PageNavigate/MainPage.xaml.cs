namespace PageNavigate;

public partial class MainPage : ContentPage
{
	HelloXamlPage helloPage = new HelloXamlPage();
	public MainPage()
	{
		InitializeComponent();
		Button button = new Button
		{
			Text = "Navigate!",
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
		};
		button.Clicked += async (sender, args) =>
		{
			await Navigation.PushAsync(helloPage);
		};
		Content = button;
	}

}

