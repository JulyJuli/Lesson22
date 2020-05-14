using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine("Usual array");
            // Thread.CurrentThread.Name = "main";
            //
            // for (int i = 0; i < 10; i++)
            // {
            //     Console.WriteLine($"Thread - {Thread.CurrentThread.Name}, num = {i}");
            //     Thread.Sleep(500);
            // }
            //
            // Console.WriteLine(new string('-', 25));
            // Console.WriteLine("TPL array");
            //
            // Parallel.For(0, 10, count =>
            // {
            //     Console.WriteLine($"Thread - {Thread.CurrentThread.ManagedThreadId}, num = {count}");
            //     Thread.Sleep(500);
            // });

            CancellationTokenSource tokenSourceCancel = new CancellationTokenSource();
            CancellationToken token = tokenSourceCancel.Token;

            var task = new Task(() =>
            {
                for (int i = 0; ; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    Console.WriteLine($"Index = {i}");
                    Thread.Sleep(200);
                }
            });

            task.Start();

            Console.WriteLine("Press any key!");
            string key = Console.ReadLine();

            if (key == "k")
            {
                tokenSourceCancel.Cancel();
            }

            Console.Read();
        }
    }
}
