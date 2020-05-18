using System;
using System.Net;
using System.Threading.Tasks;

namespace TPLExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Factory.StartNew<string>(() =>
               {
                   using (var wc = new WebClient())
                   {
                       return wc.DownloadString("https://www.google.com/");
                   }
               });

            var secondRun = Task.Run<string>(() =>
              {
                  using (var wc = new WebClient())
                  {
                      return wc.DownloadString("https://www.google.com/");
                  }

              });

            var thirdRun = new Task<string>(() =>
              {
                  using (var wc = new WebClient())
                  {
                      return wc.DownloadString("https://www.google.com/");

                  }
              });
            thirdRun.RunSynchronously();

            Console.WriteLine(task.Result);
            PrintNumbers();
            Console.WriteLine(task.Result);
        }

        public static  void PrintNumbers()
        {
            for (int i=0; i<100; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
