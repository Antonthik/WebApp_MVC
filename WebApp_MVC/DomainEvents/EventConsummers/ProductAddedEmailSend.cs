using WebApp_MVC.Models;

namespace WebApp_MVC.DomainEvents.EventConsummers
{
    public  class ProductAddedEmailSend:BackgroundService
    {
        private readonly ILogger<ProductAddedEmailSend> _logger;
        //private readonly EmailService _sender;
        public ProductAddedEmailSend(ILogger<ProductAddedEmailSend> logger)
        {
            _logger = logger;
            //_sender = sender; 

            DomainEventsManadger.Register<ProductAdded>(ev => _ = SendMailNotification(ev));//регистрируем событие в менеджере событий, для отслеживания его исполнения
            DomainEventsManadger.Register<ProductAdded>(ev => _logger.LogInformation("Product added"));//еще одно событие регистрируем
        }



        private async Task SendMailNotification(ProductAdded ev)
        {
            try
            {
                var itemMail = new EmailService(email: "asp2022gb@rodion-m.ru", emailTo: "ganseanderson@gmail.com", subject: "22", msg: "товар создан");
                itemMail.SendEmailCustom();
            }
            catch (Exception e)
            {

              _logger.LogError(e, "Ошибка при отправке");
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");
            return Task.CompletedTask;
        }
    }


    //public static class ProductAddedEmailSend
    //{
    //
    //    static ProductAddedEmailSend()
    //    {
    //
    //        DomainEventsManadger.Register<ProductAdded>(ev => SendMailNotification(ev));//регистрируем событие в менеджере событий, для отслеживания его исполнения
    //    }
    //
    //
    //    private static void SendMailNotification(ProductAdded ev)
    //    {
    //        var itemMail = new EmailService(email: "asp2022gb@rodion-m.ru", emailTo: "ganseanderson@gmail.com", subject: "22", msg: "товар создан");
    //        itemMail.SendEmailCustom();
    //    }
    //}
}
