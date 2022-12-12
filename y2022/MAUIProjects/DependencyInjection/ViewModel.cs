using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection;

public class ViewModel
{
  public string LabelText { get; set; } = "Hello Dependency Injection in MAUI";
  public string LabelSize { get; set; } = "24";
  public Color LabelColor { get; set; } = Colors.Red;
}
