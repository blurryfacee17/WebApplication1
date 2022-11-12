namespace SmtpPractice;

public interface IEmailSender
{
    Task Send(string toEmail,string subject,string htmlBody);
}