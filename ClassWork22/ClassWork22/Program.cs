using System;
using System.Threading;

namespace ClassWork22
{
   public class Program
    {
        readonly object locker = new object();

       // readonly object locker = new object();

       // bool isDone;
        public static void Main(string[] args)
        {
            var testExample = new Program();

            var threads = new Thread[10];

            for(int i=0;i<threads.Length;i++)
            {
                threads[i] = new Thread(testExample.PrintNumbers);
                threads[i].Name = "Thread" + i;
            }

            foreach(var thread in threads)
            {
                thread.Start();
            }

            //Thread.CurrentThread.Name = "Main";
            ////second thread
            //var secondThread = new Thread(testExample.PrintNumbers);
            //secondThread.Name = "Second thread";
            //secondThread.Start();

            //var thirdThread = new Thread(testExample.PrintNumbers);
            //thirdThread.Name = "Third thread";
            //thirdThread.Start();


            Console.ReadKey();
        }

        public void PrintNumbers()
        {
            //for(int i=0;i<10;i++)
            //{
            //    System.Console.WriteLine($"Value {i} was created by  { Thread.CurrentThread.Name}");
            //}

            lock(locker)
            {
                for (int i = 0; i < 15; i++)
                {
                    Console.WriteLine($"{i} Was printed by: {Thread.CurrentThread.Name}");
                }
                Console.WriteLine("========================================");
            }                
        }
    }
}
