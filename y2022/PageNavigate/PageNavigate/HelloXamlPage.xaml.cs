namespace PageNavigate;

public partial class HelloXamlPage : ContentPage
{
	public HelloXamlPage()
	{
		InitializeComponent();
	}

	private void ToggleRoate_Clicked(object sender, EventArgs e)
	{
		LabelHello.Rotation = LabelHello.Rotation + 10;
	}
}