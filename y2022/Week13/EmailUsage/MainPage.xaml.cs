using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmailUsage;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

  private async void SendEmail_Clicked(object sender, EventArgs e)
  {
    LabelMessage.Text = "";
    var email = new EmailAddressAttribute();
    //if(email.IsValid(EditorEmail.Text.Trim()))
    if (EmailIsValid(EditorEmail.Text.Trim()))
    {
      if (Email.Default.IsComposeSupported)
      {

        string subject = "Hello friends!";
        string body = "It was great to see you last weekend. I've attached a photo of our adventures together.";
        string[] recipients = new[] { EditorEmail.Text.Trim() };

        var message = new EmailMessage
        {
          Subject = subject,
          Body = body,
          BodyFormat = EmailBodyFormat.PlainText,
          To = new List<string>(recipients)
        };

        //string picturePath = Path.Combine(FileSystem.CacheDirectory, "memories.jpg");

        //message.Attachments.Add(new EmailAttachment(picturePath));

        await Email.Default.ComposeAsync(message);
      }
    }
    else
    {
      LabelMessage.Text = "전자메일주소가 올바르지 않습니다.";
      EditorEmail.Focus();
    }
  }
  public static bool EmailIsValid(string email)
  {
    string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

    if (Regex.IsMatch(email, expression))
    {
      if (Regex.Replace(email, expression, string.Empty).Length == 0)
      {
        return true;
      }
    }
    return false;
  }
}

