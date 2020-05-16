using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson22_Practice
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            //var shop = new Shop();

            //var customers = new Thread[15];

            //for(int i = 0; i < customers.Length; i++)
            //{
            //    customers[i] = new Thread(shop.EnterShop);
            //    customers[i].Name = "Thread " + i;
            //}

            //foreach(var thread in customers)
            //{
            //    thread.Start();
            //}

            //

            //Task<string> task = Task.Factory.StartNew<string>(() =>
            //{
            //    using (var wc = new WebClient())
            //    {
            //        return wc.DownloadString("http://smokeymoisha.info/");
            //    }
            //});

            //var secondRun = Task.Run<string>(() =>
            //{
            //    using (var wc = new WebClient())
            //    {
            //        return wc.DownloadString("http://smokeymoisha.info/");
            //    }
            //});

            //var thirdRun = new Task<string>(() =>
            //{
            //    using (var wc = new WebClient())
            //    {
            //        return wc.DownloadString("http://smokeymoisha.info/");
            //    }
            //});

            //thirdRun.RunSynchronously();

            //PrintNumbers();

            //Console.WriteLine(task.Result);

            //

            //Thread.CurrentThread.Name = "Main";

            //Console.WriteLine("Simple array");

            //for(int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"Index {i} was printed by {Thread.CurrentThread.Name}");
            //    Thread.Sleep(500);
            //}

            //Console.WriteLine("============================");

            //Console.WriteLine("Parallel processing");

            //Parallel.For(0, 10, count =>
            //{
            //    Console.WriteLine($"Index {count} was printed by {Thread.CurrentThread.ManagedThreadId}");
            //    Thread.Sleep(500);
            //});

            //

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            var task = new Task(() =>
            {
                for (int i = 0; ; i++)
                {
                    if (token.IsCancellationRequested) { return; }

                    Console.WriteLine($"Index {i}");
                    Thread.Sleep(1000);
                }
            });

            task.Start();

            Console.WriteLine("For interrupting press K");

            string key = Console.ReadLine();

            if (key == "K")
            {
                cancellationTokenSource.Cancel();
            }

            Console.Read();

        }

        //public static void PrintNumbers()
        //{
        //    for(int i = 0; i < 100; i++)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}

        //public class Shop
        //{
        //    readonly Mutex mutex = new Mutex();

        //    public void EnterShop()
        //    {
        //        mutex.WaitOne();

        //        Console.WriteLine($"The thread entered the shop: {Thread.CurrentThread.Name}");
        //        Thread.Sleep(1000);
        //        Console.WriteLine($"The thread {Thread.CurrentThread.Name} left the shop");

        //        mutex.ReleaseMutex();
        //    }
        //}
    }
}
