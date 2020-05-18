using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        readonly object locker = new object();//критическая секция
        bool isDone;
        static void Main(string[] args)
        {
            var thread = new Thread(() => Console.WriteLine("Hi, thread!"));
            var testExample = new Program();
            Thread.CurrentThread.Name = "Main";
            var threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(testExample.PrintNumbers2);
                threads[i].Name = "Thread " + i;
            }

            //foreach (var i in threads)
            //{
            //    i.Start();
            //}

            //second thread
            //var secondThread = new Thread(PrintNumbers1);
            var secondThread = new Thread(testExample.PrintNumbers);
            //var secondThread = new Thread(testExample.PrintNumbers);
            secondThread.Name = "second thread";
            //secondThread.Start();

             var threadThread = new Thread(PrintNumbers1);
            //var threadThread = new Thread(testExample.PrintNumbers);
            threadThread.Name = "third thread";
            threadThread.Start();

            //PrintNumbers1();
            //testExample.PrintNumbers();
        }

        public static void PrintNumbers1()
        {
            Console.WriteLine("Current thread :" + Thread.CurrentThread.Name);

            for (int i = 0; i < 10; i++)
            {
                // Console.WriteLine(i);
                Console.WriteLine($"Value {i} was created by {Thread.CurrentThread.Name}");
            }
            Console.WriteLine($"Finish by {Thread.CurrentThread.Name}");
        }
        public void PrintNumbers()
        {
            //Console.WriteLine($"Current thread: " + Thread.CurrentThread.Name);

            lock (locker)//в один момент времени в текущую секцию может войти только один поток
                         //ячейка памяти
            {
                //    for (int i = 0; i < 10; i++)
                //    {
                if (!isDone)
                {
                    //isDone = true;
                    Console.WriteLine($"Was finished by: {Thread.CurrentThread.Name} ");

                    //Console.WriteLine($"Value {i} was finished {Thread.CurrentThread.Name}");
                    isDone = true;
                }
            }
        //}

        }

        public void PrintNumbers2()
        {
            lock (locker)
            {

                for (int i = 0; i < 15; i++)
                {
                    Console.WriteLine($"{i} Was printed by: {Thread.CurrentThread.Name} ");
                }
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}



