using System;
using System.Collections.Generic;
using Game.Players;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{
    public class Program
    {
        readonly static object lockerOrdynary = new OrdynaryPlayer();
        readonly static object lockerNotepad = new PlayerNotepad();
        readonly static object lockeruberPlayer = new UberPlayer();
        readonly static object lockerUberCheater = new UberCheater();
        readonly static object lockerCheraterPlayer = new CheaterPlayer();

        public static Mutex mutex = new Mutex();

        int numberOfAttempts = 100;
        static int basketWeight = new Random().Next(40, 140);
        static void Main(string[] args)
        {
            Console.WriteLine($"Weight of basket {basketWeight}\n______________________");

            var test = new Program();
            lock (lockerOrdynary)
            {
                Task task1 = new Task(() => { test.GameProcess(); });
                task1.Start();
            }

            lock (lockerNotepad)
            {
                Task task2 = new Task(() => { test.GameProcess(); });
                task2.Start();
            }

            lock (lockeruberPlayer)
            {
                Task task3 = new Task(() => { test.GameProcess(); });
                task3.Start();
            }

            lock (lockerUberCheater)
            {
                Task task4 = new Task(() => { test.GameProcess(); });
                task4.Start();
            }

            lock (lockerCheraterPlayer)
            {
                Task task5 = new Task(() => { test.GameProcess(); });
                task5.Start();
            }

            //var numberOfAttempts = 100;
            //var basketWeight = new Random().Next(40, 140);
            //Console.WriteLine($"Weight of basket {basketWeight}\n______________________");
            //var playersList = new List<BasePlayer>()
            //{
            //    new OrdynaryPlayer(),
            //    new PlayerNotepad(),
            //    new UberPlayer(),
            //    new UberCheater(),
            //    new CheaterPlayer()
            //};
            //for (int i = 0; i < numberOfAttempts - playersList.Count - 1; i += playersList.Count)
            //{
            //    foreach (var player in playersList)
            //    {
            //        var guessedNumber = player.GuessesNumber();
            //        player.PrintResult(guessedNumber);
            //        if (guessedNumber == basketWeight)
            //        {
            //            Console.WriteLine(player.ToString());
            //        }
            //    }
            //    Console.WriteLine("-----------------------");

            //}
            Console.ReadKey();
        }
        public void GameProcess()
        {
            var playersList = new List<BasePlayer>()
            {
                new OrdynaryPlayer(),
                new PlayerNotepad(),
                new UberPlayer(),
                new UberCheater(),
                new CheaterPlayer()
            };

            mutex.WaitOne();

            for (int i = 0; i < numberOfAttempts - playersList.Count - 1; i += playersList.Count)
            {
                foreach (var player in playersList)
                {
                    var guessedNumber = player.GuessesNumber();
                    player.PrintResult(guessedNumber);
                    if (guessedNumber == basketWeight)
                    {
                        Console.WriteLine(player.ToString());
                    }
                }
                Console.WriteLine("-----------------------");

            }
           

        }

    }


}
