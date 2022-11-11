namespace LightSensor02;

public partial class MainPage : ContentPage
{
    InterfaceTransLabel m_interfaceTransLabel;
    bool labelTransferred = false;
    UpdateService m_service= null;
    public MainPage(InterfaceTransLabel interfaceTransLabel)
	{
		InitializeComponent();
        m_interfaceTransLabel = interfaceTransLabel;
        m_service = new UpdateService(lightLabel);
        m_service.Canvas = myCanvas;
	}

    private void StartBtn_Clicked(object sender, EventArgs e)
	{
        if(!labelTransferred)
        {
            m_interfaceTransLabel.TransLightLabel(lightLabel, m_service);
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

