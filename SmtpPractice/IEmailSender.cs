﻿namespace SmtpPractice;

public interface IEmailSender
{
    void Send(string toEmail,string subject,string htmlBody);
}