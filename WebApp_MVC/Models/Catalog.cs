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
