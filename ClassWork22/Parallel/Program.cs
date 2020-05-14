using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parallellll
{
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Thread.CurrentThread.Name = "Main";
    //        Console.WriteLine("Simple array");

    //        for (int i = 0; i < 10; i++)
    //        {
    //            Console.WriteLine($"Index {i} was printed by {Thread.CurrentThread.Name}");
    //        }
    //            Console.WriteLine("======================================");

    //            Console.WriteLine("Parallel processing");

    //        Parallel.For(0, 10, count =>
    //         {
    //             Console.WriteLine($"Index {count} was printed by {Thread.CurrentThread.Name}");
    //             Thread.Sleep(500);
    //         });

    //    }
    //}


    public class Program
    {
        public static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokensourse = new CancellationTokenSource();
            CancellationToken token = cancellationTokensourse.Token;

            var task = new Task(() =>
              {
                  for (int i = 0; ; i++)
                  {
                      if (token.IsCancellationRequested)
                      {
                          return;
                      }
                      Console.WriteLine($"index {i}");
                      Thread.Sleep(1000);
                  }
              });
            task.Start();
            Console.WriteLine("For interrupting press K");
            string key = Console.ReadLine();

            if (key == "K")
            {
                cancellationTokensourse.Cancel();
            }

            Console.Read();
        }
    }
}
