using Foundation;

namespace MauiDITest
{
  [Register("AppDelegate")]
  public class AppDelegate : MauiUIApplicationDelegate
  {
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
  }
}