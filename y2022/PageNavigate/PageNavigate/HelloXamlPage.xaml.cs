namespace PageNavigate;

public partial class HelloXamlPage : ContentPage
{
	public HelloXamlPage()
	{
		InitializeComponent();
		LabelHello.TranslationY = 300;
	}

	private void ToggleRoate_Clicked(object sender, EventArgs e)
	{
		LabelHello.Rotation = LabelHello.Rotation + 10;
	}
}