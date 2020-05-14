using System;
using System.Threading;

namespace Practiece_22
{
   public class Program
    {
       public static void Main(string[] args)
        {
            var shop = new Shop();

            var customers = new Thread[15];
            for(int i=0;i<customers.Length;i++)
            {
                customers[i] = new Thread(shop.EnterShop);
               // customers[i].Name = $"Thread {i}";
            }

            for (int i = 0; i < customers.Length; i++)
            {
                customers[i].Start($"Thread {i}");
            }

            Console.ReadKey();
        }
    }

    public class Shop
    {
        readonly Mutex semaphore = new Mutex();
        public void EnterShop(object param)
        {
            var thredName = (string)param;
            semaphore.WaitOne();
            Console.WriteLine($"The thread entered the shop: {Thread.CurrentThread.Name}");
            Thread.Sleep(1000);
            Console.WriteLine($"The thread {Thread.CurrentThread.Name} left the shop");

             semaphore.ReleaseMutex();
        }
    }
}
