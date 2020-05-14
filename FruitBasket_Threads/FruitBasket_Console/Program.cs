using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FruitBasket_DLL;

namespace FruitBasket_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var randomSeed = new Random();
            var basket = new Basket(randomSeed);

            var playersDictionary = new Dictionary<int, Player>()
            {
                { 1, new RegularPlayer(randomSeed) },
                { 2, new NotebookPlayer(randomSeed) },
                { 3, new UberPlayer() },
                { 4, new CheaterPlayer(randomSeed) },
                { 5, new UberCheaterPlayer() }
            };

            Console.WriteLine($"Basket's weight is {basket.Weight} kg.");

            //
            //Creating players:

            Console.Write("Enter the number of players (from 2 to 8): ");

            string input = Console.ReadLine();
            int minPlayers = 2;
            int maxPlayers = 8;

            int numOfPlayers = InputValidation(input, minPlayers, maxPlayers);

            var playersList = new List<Player>();

            for (int i = 1; i <= numOfPlayers; i++)
            {
                Console.WriteLine($"Select the type of player {i}");
                Console.WriteLine("1 - Regular Player");
                Console.WriteLine("2 - Notebook Player");
                Console.WriteLine("3 - Uber-Player");
                Console.WriteLine("4 - Cheater");
                Console.WriteLine("5 - Uber-Cheater Player"); 

                int type = InputValidation(Console.ReadLine(), 1, 5);

                playersList.Add(playersDictionary[type]);
            }

            var totalTriesList = new List<List<int>>();

            playersList.ForEach(player => totalTriesList.Add(player.PersonalTries));

            //var tasksList = Enumerable.Select<Player, Task<int>>(playersList, player => Task.Factory.StartNew<int>());

            //var tasksList = new Task[playersList.Count];

            //for (int i = 0; i < tasksList.Length; i++)
            //{
            //    tasksList[i] = Task.Factory.StartNew<int>(playersList[i].Guess);
            //}

            var threadList = new Thread[playersList.Count];

            for (int i = 0; i < threadList.Length; i++)
            {
                threadList[i] = new Thread(() =>
                {
                    int newTry = playersList[i].Guess(Basket.MinWeight, Basket.MaxWeight, ref totalTriesList);

                    Console.WriteLine($"{playersList[i].TypeName} {playersList[i].Name} says {newTry}");

                    if (newTry == basket.Weight)
                    {
                        Console.WriteLine($"{playersList[i].TypeName} {playersList[i].Name} wins!");
                        Console.ReadKey();
                    }
                });

                //threadList[i].Name = $"Thread {i + 1}";
            }

            //foreach(var thread in threadList)
            //{
            //    thread.Start();
            //}

            //
            //Let the game begin!

            for (int tries = 1; tries <= 100; tries++)
            {
                Console.WriteLine($"Try #{tries}");

                //foreach (var player in playersList)
                //{
                //    int newTry = player.Guess(Basket.MinWeight, Basket.MaxWeight, ref totalTriesList);

                //    Console.WriteLine($"{player.TypeName} {player.Name} says {newTry}");

                //    if (newTry == basket.Weight)
                //    {
                //        Console.WriteLine($"{player.TypeName} {player.Name} wins!");
                //        Console.ReadKey();
                //        return;
                //    }
                //}

                foreach (var thread in threadList)
                {
                    thread.Start();
                }

                Console.WriteLine();
            }

            //
            //If nobody guessed correctly:


            //можно ли переделать через linq?
            var bestTriesList = new List<int>();

            foreach (Player player in playersList)
            {
                player.BestTry = player.PersonalTries.GetBestTry(basket.Weight);
                Console.WriteLine($"{player.TypeName} {player.Name}'s closest guess is {player.BestTry}");

                bestTriesList.Add(player.BestTry);
            }

            int totalBestTry = bestTriesList.GetBestTry(basket.Weight);

            foreach(Player player in playersList)
            {
                if (player.BestTry == totalBestTry)
                {
                    Console.WriteLine($"{player.TypeName} {player.Name} wins! Their closest guess is {player.BestTry}");
                }
            }

            Console.ReadKey();
        }

        public static int InputValidation(string input, int minValue, int maxValue)
        {
            int result;
            while (int.TryParse(input, out result) == false || minValue > result || maxValue < result)
            {
                Console.Write("Please try again: ");
                input = Console.ReadLine();
            }

            return result;
        }
    }
}
