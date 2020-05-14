using System;
using System.Threading;

namespace ConsoleApp1
{
    public class Shop
    {
        readonly Semaphore sem = new Semaphore(3,3);

        public void EnterShop(object param)
        {
            var name = (string) param;

            sem.WaitOne();
            Console.WriteLine($"Thread enter - {name}");
            Thread.Sleep(1000);
            Console.WriteLine($"Thread out - {name}");

            sem.Release();
        }
    }

    public class Program
    {
        // public bool isDone;
        //
        // readonly object locker = new object();
        public static void Main(string[] args)
        {
            var shop = new Shop();

            var customers = new Thread[15];

            for (int i = 0; i < customers.Length; i++)
            {
                customers[i] = new Thread(shop.EnterShop){};
            }

            for (int i = 0; i < customers.Length; i++)
            {
                customers[i].Start(i.ToString());
            }

            // var test = new Program();
            //
            // var threads = new Thread[10];
            //
            // for (int i = 0; i < threads.Length; i++)
            // {
            //     threads[i] = new Thread(test.PrintNumbers){Name = i.ToString()};
            // }
            //
            // foreach (var thread in threads)
            // {
            //     thread.Start();
            // }

            // Thread.CurrentThread.Name = "Main";
            // Console.WriteLine($"1) - {Thread.CurrentThread.Name}");

            // var threadStart = new ThreadStart();
            // var thread = new Thread(() => Console.WriteLine("Hi there"));
            // var second = new Thread(test.Done) {Name = "New thread"};
            // second.Start();
            //
            // test.Done();
        }

        // public void PrintNumbers()
        // {
        //     lock (locker)
        //     {
        //         for (int i = 0; i < 15; i++)
        //         {
        //             Console.WriteLine($"Thread - {Thread.CurrentThread.Name}, value - {i}");
        //         }
        //
        //         Console.WriteLine(new string('-', 25));
        //     }
        // }

        // public void Done()
        // {
        //     lock (locker)
        //     {
        //         if (!isDone)
        //         {
        //             Console.WriteLine($"Thread done - {Thread.CurrentThread.Name}");
        //             isDone = true;
        //         }
        //     }
        // }
    }
}
