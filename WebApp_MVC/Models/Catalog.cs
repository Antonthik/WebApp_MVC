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
            var itemMail = new EmailService(email: "asp2022gb@rodion-m.ru", emailTo: "ganseanderson@gmail.com", subject: "22", msg: "товар создан");
            itemMail.SendEmailCustom();
        

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
