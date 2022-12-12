using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiDITest;

public class MainPageViewModel : INotifyPropertyChanged
{
  private readonly IPlatformDiService _platformDiService;
  private string sayYourPlatformNameValue = "Click the 'Reveal platform' button";
  private Command _sayYourPlatformNameCommand;

  public event PropertyChangedEventHandler PropertyChanged;

  public MainPageViewModel(IPlatformDiService platformDiService) 
  { 
    _platformDiService = platformDiService;
  }

  public void OnPropertyChanged(string propertyName)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
  public string SayYourPlatformNameValue
  {
    get => sayYourPlatformNameValue;
    set
    {
      sayYourPlatformNameValue = value;
      OnPropertyChanged(nameof(this.SayYourPlatformNameValue));
    }
  }
  public Command SayYourPlatformNameCommand => _sayYourPlatformNameCommand ??=
    new Command( () => { this.SayYourPlatformNameValue = _platformDiService.SayYourPlatformName(); });
}
