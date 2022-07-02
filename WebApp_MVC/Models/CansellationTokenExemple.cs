using System.Threading;

namespace WebApp_MVC.Models
{
    /// <sumТmary>
    /// Тестирование техники прерывания запроса CansellationToken
    /// </summary>
    public class CansellationTokenExemple
    {
       public void DoHevyJob(CancellationToken canselToken)
        {
            var length = 1000000;
            for (int i = 0; i < length; i++)
            {
                if (canselToken.IsCancellationRequested)//Ожидаем запрос от пользователя на прерывание - первый вариант
                {
                    break;
                }
            }

           // canselToken.ThrowIfCancellationRequested();//Ожидаем запрос от пользователя на прерывание, с выбросом ошибки - второй вариант
        }
        
    }
}
    