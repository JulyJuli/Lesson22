using System;
using System.Net;
using System.Threading.Tasks;

namespace Threads
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task<string> task = Task.Factory.StartNew<string>(() =>
            {
                using (var wc = new WebClient())
                {
                    return wc.DownloadString("https://habr.com/ru/post/113586/");
                }
            }
            );

            var secondRun = Task.Run<string>(() =>
              {
                  using (var wc = new WebClient())
                  {
                      return wc.DownloadString("https://habr.com/ru/post/113586/");
                  }
              }
            );

            var thirdRun = new Task<string>(() =>
              {
                  using (var wc = new WebClient())
                  {
                      return wc.DownloadString("https://habr.com/ru/post/113586/");
                  }
              }
            );
            thirdRun.RunSynchronously();

            PrintNumbers();

            System.Console.WriteLine(secondRun.Result);

            Console.ReadKey();
        }

        public static void PrintNumbers()
        {
            for (int i = 0; i < 100; i++)
            {
                System.Console.WriteLine(i);
            }
        }
    }
}
