using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace SmtpPractice;

public class SmtpEmailSender : IEmailSender, IDisposable
{
    private readonly SmtpClient _smtpClient = new();
    private readonly SmtpConfig _smtpConfig;
    private ILogger<SmtpEmailSender> _logger;

    public SmtpEmailSender(IOptionsSnapshot<SmtpConfig> options, ILogger<SmtpEmailSender> logger)
    {
        _logger = logger;
        _smtpConfig = options.Value;
    }

    public void Send(string toEmail, string subject, string htmlBody)
    {
        _logger.LogInformation("Отправка сообщения");
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_smtpConfig.UserName));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html)
        {
            Text = htmlBody
        };
        EnsureConnectedAndAuthenticated();
    }

    private void EnsureConnectedAndAuthenticated()
    {
        if (!_smtpClient.IsConnected)
        {
            _smtpClient.Connect(_smtpConfig.Host, _smtpConfig.Port);
        }

        if (!_smtpClient.IsAuthenticated)
        {
            _smtpClient.Authenticate(_smtpConfig.UserName, _smtpConfig.Password);
        }
    }

    public void Dispose()
    {
        _smtpClient.Disconnect(true);
        _smtpClient.Dispose();
    }
}