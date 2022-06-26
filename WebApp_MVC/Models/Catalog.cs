namespace WebApp_MVC.Models
{
    public class Catalog
    {
        public List<Good> Goods { get; set; }= new List<Good>();
        
        public void Add(Good item,CancellationToken canselToken)
        {
            canselToken.ThrowIfCancellationRequested();//прерывание выполнения запроса
            try
            {
                lock (Goods)//потокобезопасный, но медленный способ 
                {
                    Goods.Add(item);
                }
                var itemMail = new EmailService(email: "asp2022gb@rodion-m.ru", emailTo: "ganseanderson@gmail.com", subject: "22", msg: "товар создан");
                itemMail.SendEmailCustom();
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("Операция отменена.");
            }

        }
        public void Clear()
         {
            lock (Goods)//потокобезопасный, но медленный способ 
            {
                Goods.Clear();
            }
         }


    }
}
