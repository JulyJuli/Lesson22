using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();
            var customers = new Thread[15];
            for(int i=0; i<customers.Length;i++)
            {
                customers[i] = new Thread(shop.EnterShop1);
                customers[i].Name = $"Thread {i}";
            }

            foreach (var thread in customers)
            {
                thread.Start();
            }

        //for(int i=0; i<customers.Length; i++)
        //{
        //    customers[i].Start($"Thread {i}");                
        //}
    }
    }
}
