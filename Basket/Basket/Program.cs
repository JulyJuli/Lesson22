using System;
using System.Collections.Generic;
using System.Threading;


namespace Basket
{
    class Program
    {
        static void Main(string[] args)
        {
            object block = new object();          
           int numberAttempts = 100;
           int basketWeight = new Random().Next(40, 140);//
           Console.WriteLine($"BasketWeight is {basketWeight}\n");
           var firstGame = new Game();
           var playersList = new List<BasePlayer>()
            {
                new UsualPlayer(),
                new GamePlayer(),
                new UberPlayer(),
                new CheaterPlayer(),
                new UberCheaterPlayer()
            };

            bool isGuessed = false;
            int counter = 0;
            while (!isGuessed && numberAttempts > counter)
            {
                for (int j = 0; j < playersList.Count; j++)
                {
                    playersList[j].PrintCurrentResult();

                    var thr = new Thread(playersList[j].GuessNumber);

                    thr.Start();
                    lock (block)
                    {
                        if (playersList[j].GuessedNumber == basketWeight)
                        {
                            Console.WriteLine(playersList[j].ToString());
                            isGuessed = true;
                            return;
                        }
                    }

                    counter += playersList.Count;
                }
                Console.WriteLine("=================");
            }

            if (!isGuessed)
            {
                Console.WriteLine("Nobody guessed");
            }
          

        }
    }
}
