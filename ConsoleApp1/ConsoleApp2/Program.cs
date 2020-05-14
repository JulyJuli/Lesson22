using System;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task<string> task = Task.Factory.StartNew<string>(() =>
            {
                using (var wc = new WebClient())
                {
                    return wc.DownloadString("https://www.google.com/");
                }
            });

            var taskTwo = new Task<string>(() =>
            {
                using (var wc = new WebClient())
                {
                    return wc.DownloadString("https://www.google.com/");
                }
            });

            taskTwo.RunSynchronously();

            PrintNum();

            Console.WriteLine(task.Result);
        }

        public static void PrintNum()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
