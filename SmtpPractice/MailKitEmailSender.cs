using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace SmtpPractice;

public class MailKitEmailSender : IEmailSender, IDisposable
{
    private SmtpClient _smtpClient = new();

    public void Send(string toEmail,string subject,string htmlBody)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("asp2022pd011@rodion-m.ru"));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html)
        {
            Text = htmlBody
        };
        
        EnsureConnectedAndAuthenticated();
        _smtpClient.Send(email);
        _smtpClient.Disconnect(true);
    }

    private void EnsureConnectedAndAuthenticated()
    {
        if(!_smtpClient.IsConnected)
        {
            _smtpClient.Connect("smtp.beget.com", 25);
        }
        if(!_smtpClient.IsAuthenticated)
        {
            _smtpClient.Authenticate("asp2022pd011@rodion-m.ru", "6WU4x2be");
        }
    }

    public void Dispose()
    {
        _smtpClient.Disconnect(true);
        _smtpClient.Dispose();
    }
}