using WebApp_MVC.Models;

namespace WebApp_MVC.DomainEvents
{
    /// <summary>
    /// Событие, которое вызываем
    /// </summary>
    public class ProductAdded:IDomainEvent
    {
        public Good  good { get; }
        public ProductAdded(Good good)
        {
            this.good = good;
        }


    }
}
