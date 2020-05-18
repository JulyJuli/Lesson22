using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConcellationToken
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            var task=new Task(()=>
            {
                for (int i = 0; ; i++)
                {
                    if (token.IsCancellationRequested)

                    { return; }

                    Console.WriteLine($"Index {i}");
                    Thread.Sleep(1000);
                }
            });

            task.Start();
            Console.WriteLine("For interrupting press K");
            string key = Console.ReadLine();

            if(key=="K")
            {
                cancellationTokenSource.Cancel();
            }
            Console.Read();
        }
    }
}
