namespace PageNavigate;

public partial class MainPage : ContentPage
{

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
			await Navigation.PushAsync(new PageNavigate.HelloXamlPage());
		};
		Content = button;
	}

}

