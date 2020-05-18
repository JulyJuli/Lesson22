using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson22
{
    class Program
    {       
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name="Main";
            Console.WriteLine("Single array");
            for(int i=0; i<10; i++)
            {
                Console.WriteLine($"index {i} printed by {Thread.CurrentThread.Name}");
             }  
           Console.WriteLine( "----------------------------");
            Console.WriteLine("Parallel processing");
            Parallel.For(0, 10, count =>
              {
                  Console.WriteLine($"Index {count} was printed by {Thread.CurrentThread.ManagedThreadId}");

                  Thread.Sleep(500);
              });
           
        }
    }
}
