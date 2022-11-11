namespace LightSensor01;

public partial class MainPage : ContentPage
{
    InterfaceTransLabel m_interfaceTransLabel;
    bool labelTransferred = false;
    public MainPage(InterfaceTransLabel interfaceTransLabel)
	{
		InitializeComponent();
        InterfaceTransLabel interfaceTransLabel1 = DependencyService.Get<InterfaceTransLabel>();

        m_interfaceTransLabel = interfaceTransLabel;

	}

	private void StartBtn_Clicked(object sender, EventArgs e)
	{
        if(!labelTransferred)
        {
            m_interfaceTransLabel.TransLightLabel(lightLabel);
            labelTransferred = true;   
        }
        StartBtn.IsEnabled = false;
        StopBtn.IsEnabled = true;
        m_interfaceTransLabel.StartSensor();
    }

    private void StopBtn_Clicked(object sender, EventArgs e)
	{
        StartBtn.IsEnabled = true;
        StopBtn.IsEnabled = false;
        m_interfaceTransLabel.StopSensor();
    }
}

