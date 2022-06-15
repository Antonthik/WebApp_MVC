using MimeKit;
using System.Net.Mail;

namespace WebApp_MVC.Models
{
    public class EmailService
    {

        //public async Task SendEmailAsync(string email, string subject, string message)
        //{
        //    var emailMessage = new MimeMessage();
        //
        //    emailMessage.From.Add(new MailboxAddress("Администрация сайта", "login@yandex.ru"));
        //    emailMessage.To.Add(new MailboxAddress("", email));
        //    emailMessage.Subject = subject;
        //    emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        //    {
        //        Text = message
        //    };
        //
        //    using (var client = new SmtpClient())
        //    {
        //         client.Connect("smtp.yandex.ru", 25, false);
        //        await client.AuthenticateAsync("login@yandex.ru", "password");
        //        await client.SendAsync(emailMessage);
        //
        //        await client.DisconnectAsync(true);
        //    }
        //}
        //
        private string email { get; set; }
        private string subject { get; set; }
        private string msg { get; set; }
        public EmailService(string email, string subject, string msg)
        {
            this.email = email;
            this.subject = subject;
            this.msg = msg;
        }


        public void SendEmailCustom()
        {
           
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Моя компания", email)); //отправитель сообщения
                message.To.Add(new MailboxAddress("","mail@yandex.ru")); //адресат сообщения
                message.Subject = subject; //тема сообщения
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html){Text = msg};
                //message.Body = new BodyBuilder() { HtmlBody = "<div style=\"color: green;\">Сообщение от MailKit</div>" }.ToMessageBody(); //тело сообщения (так же в формате HTML)

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.beget.com", 25, false); //либо использум порт 465
                    client.Authenticate("", ""); //логин-пароль от аккаунта
                    client.Send(message);

                    client.Disconnect(true);
                    
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
