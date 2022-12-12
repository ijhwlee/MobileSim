using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiDITest;

public class PlatformDiService : IPlatformDiService
{
  public string SayYourPlatformName()
  {
    return "I am MacCatalyst";
  }
}
