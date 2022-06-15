namespace WebApp_MVC.Models
{
    public class Catalog
    {
        public List<Good> Goods { get; set; }= new List<Good>();
        
        public void Add(Good item)
         {
            lock(Goods)//потокобезопасный, но медленный способ 
            {
                Goods.Add(item);
            }
            var itemMail = new EmailService(email: "*@gmail.com", subject: "", msg: "товар создан");
            lock (itemMail)//потокобезопасный, но медленный способ 
            {
                itemMail.SendEmailCustom();
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
