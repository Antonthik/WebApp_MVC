using WebApp_MVC.DomainEvents;
namespace WebApp_MVC.DomainEvents
{
    /// <summary>
    /// Менеджер регистрации и вызова событий
    /// </summary>
    public static class DomainEventsManadger
    {
        private static Dictionary<Type, List<Delegate>> _handlers=new();

        internal static void Register<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод регистрации события
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler"></param>
        public static void Register<T>(Action<T> eventHandler)
            where T : IDomainEvent
        {
            if (_handlers.ContainsKey(typeof(T)))
            {
                _handlers[typeof(T)].Add(eventHandler);
            }
            else
            {
                _handlers[typeof(T)]=new List<Delegate>() {eventHandler};

            }
            
        }

        /// <summary>
        /// Метод пуска действия по событию
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainEvent"></param>
        public static void Raise<T>(T domainEvent)
            where T : IDomainEvent
        {
            foreach (Delegate handler in _handlers[domainEvent.GetType()])
            {
                var action = (Action<T>)handler;
                action(domainEvent);
            }
        }
    }
}
