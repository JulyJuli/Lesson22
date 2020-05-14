using NewGame.Players;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NewGame
{
    class Program
    {
        readonly static object locker = new object();
        public static void Main(string[] args)
        {
            var fruitBasket = new FruitBasket();
            fruitBasket.PrintInfo();

            var playerList = new List<BasePlayer>()
            {
                new UsualPlayer(),
                new NotepadPlayer(),
                new UberPlayer(),
                new CheaterPlayer(),
                new UberCheaterPlayer()
            };

            bool notGuess = true;
            int numberOfAttempts = 20;
            int counter = 0;

            var playerThreads = new Thread[5];


            while (notGuess && counter < numberOfAttempts)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    playerThreads[i] = new Thread(playerList[i].GuessNumber);
                    playerThreads[i].Name = $"{i}";
                }

                for (int i = 0; i < playerList.Count; i++)
                {
                    playerThreads[i].Start();
                }
                foreach (var item in playerList)
                {
                    lock (locker)
                    {
                        var currentPlayer = new ProcessGuessing(item, item.GuessingNumber);
                        ProcessGuessing.allPlayersAndGuessings.Add(currentPlayer);

                        bool win = item.CheckGuessedNumbers(item.GuessingNumber);
                        item.PrintInfo(item.GuessingNumber);
                        
                        if (win == true)
                        {
                            item.WinMessage();
                            notGuess = false;
                            break;
                        }
                        counter++;
                    }
                }
                Console.WriteLine("======================================");
            }

            Console.WriteLine(ProcessGuessing.SearchWinner());

            Console.ReadKey();
        }
    }
}

