using System;
using System.Threading;

namespace Shop
{
   public class Shop
    {
        //readonly Semaphore semaphore = new Semaphore(3, 3);
        readonly Mutex mutex = new Mutex();
        public void EnterShop()
        {
            // semaphore.WaitOne();
            mutex.WaitOne();
            
            Console.WriteLine($"The thread entered the shop: {Thread.CurrentThread.Name}");
            Thread.Sleep(1000);
            Console.WriteLine($"The thread {Thread.CurrentThread.Name} left the shop");
            //semaphore.Release();
            mutex.ReleaseMutex();
        }

        public void EnterShop1(object param)
        {
            var threadName = (string)param;
            //semaphore.WaitOne();
            mutex.WaitOne();

            Console.WriteLine($"The thread entered the shop: {threadName}");
            Thread.Sleep(1000);
            Console.WriteLine($"The thread {threadName} left the shop");
            //semaphore.Release();
            mutex.ReleaseMutex();
        }
    }
}
