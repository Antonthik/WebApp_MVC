namespace WebApp_MVC.Models
{
    public class Good
    {
        private long Id_ { get; set; }
        private string Name_ { get; set; }
        private string Discription_ { get; set; }
        public Good(long id, string name, string discription)
        {
            Id_ = id;
            Name_ = name;
            Discription_ = discription;
        }


    }
}
