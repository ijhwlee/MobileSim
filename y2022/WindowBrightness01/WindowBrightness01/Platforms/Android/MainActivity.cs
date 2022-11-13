using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Hardware;
using Android.Hardware.Camera2;
using Android.OS;
using Android.Provider;

namespace WindowBrightness01;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public static SensorManager m_sensorManager;
    public static Android.Content.ContentResolver m_contentResolver;
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        m_sensorManager = (SensorManager)GetSystemService(Context.SensorService);
        askPermission(this);
        m_contentResolver = this.ContentResolver;
    }

    public void askPermission(Context c)
    {
        if(Build.VERSION.SdkInt >= BuildVersionCodes.M)
        {
            if(Settings.System.CanWrite(c))
            {

            }
            else
            {
                Intent i = new Intent(Settings.ActionManageWriteSettings);
                c.StartActivity(i);
            }
        }
    }
}
