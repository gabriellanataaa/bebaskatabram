// EmailHelper.cs
using MimeKit;
using MailKit.Net.Smtp;
using System;

public class EmailHelper
{
    public void SendEmail(string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Your Name", "your.email@example.com"));
        message.To.Add(new MailboxAddress(to, to));
        message.Subject = subject;

        var builder = new BodyBuilder();
        builder.TextBody = body;

        message.Body = builder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            client.Connect("smtp.yourprovider.com", 587, false);

            // Jika server membutuhkan otentikasi
            client.Authenticate("your.email@example.com", "your-password");

            client.Send(message);
            client.Disconnect(true);
        }
    }
}
