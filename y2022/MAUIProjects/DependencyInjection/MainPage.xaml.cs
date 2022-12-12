namespace DependencyInjection;

public partial class MainPage : ContentPage
{

	public MainPage(ViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

}

