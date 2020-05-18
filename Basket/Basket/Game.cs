using System;
using System.Collections.Generic;
using System.Threading;


namespace Basket
{
    public class Game
    {
       private int numberAttempts = 100;
       private int basketWeight = new Random().Next(40, 140);//
                                                             //readonly Mutex mutex = new Mutex();
        object loker = new object();
        public List<Thread> allThreads;
        public Game()
        {
            allThreads = new List<Thread>();    
        }
        
        public void StartGame(List<BasePlayer>playersList,Thread[]threads)
        {
            // mutex.WaitOne();

            //var playersList = (List<BasePlayer>)param;

            //Console.WriteLine($"BasketWeight is {basketWeight}\n");
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }
            for (int i = 0; i < numberAttempts; i += playersList.Count)
                {

                    foreach (var player in playersList)
                    {
                    lock (loker)
                    {
                        //Console.WriteLine("Current thread :" + Thread.CurrentThread.Name);
                        player.GuessNumber();
                        player.PrintCurrentResult();
                        if (player.GuessedNumber == basketWeight)
                        {
                            Console.WriteLine(player.ToString());
                            return;
                        }
                    }
                    Console.WriteLine("=================");
                }
                //mutex.ReleaseMutex();
            }
        }
       
    }
}
