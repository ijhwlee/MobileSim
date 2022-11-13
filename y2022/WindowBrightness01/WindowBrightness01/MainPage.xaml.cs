namespace WindowBrightness01;

public partial class MainPage : ContentPage
{
    InterfaceLightSensor m_interfaceLightSensor;
    MauiService m_mauiService;
	public MainPage(InterfaceLightSensor interfaceLightSensor)
	{
		InitializeComponent();
        m_interfaceLightSensor= interfaceLightSensor;
        LightLevel.Text = "Stop Brightness Monitoring";
        m_mauiService = new MauiService(LightLevel);
	}

    private void StartBtn_Clicked(object sender, EventArgs e)
    {
        m_interfaceLightSensor.TransferObject(m_mauiService);
        StartBtn.IsEnabled= false;
        StopBtn.IsEnabled = true;
        m_interfaceLightSensor.StartLightSensor();
    }

    private void StopBtn_Clicked(object sender, EventArgs e)
    {
        StartBtn.IsEnabled = true;
        StopBtn.IsEnabled = false;
        m_interfaceLightSensor.StopLightSensor();
        LightLevel.Text = "Stop Brightness Monitoring";
    }
}

