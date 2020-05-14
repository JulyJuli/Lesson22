using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Games.Players;

namespace Games
{
    public class Program
    {
        readonly static object lockerNotepad = new NotepadPlayer();
        readonly static object lockerUsual = new UsualPlayer();
        readonly static object lockerUber = new UberPlayer();
        readonly static object lockerCheater = new CheaterPlayer();
        readonly static object lockerUB = new UberCheaterPlayer();

        readonly Mutex mutex = new Mutex();

        public static int basketWeight = new Random().Next(40, 140);

        public static void Main(string[] args)
        {
            Console.WriteLine($"Basket weight: {basketWeight}\n\n");

            var test = new Program();
            lock (lockerNotepad)
            {
                Task task1 = new Task(() =>
                  {
                      test.GuesedPlayer();

                  });
                task1.Start();
            }

            lock (lockerUsual)
            {
                Task task2 = Task.Run(() =>
                {
                    test.GuesedPlayer();
                });
                task2.Wait();
            }

            lock (lockerUber)
            {
                Task task3 = Task.Run(() =>
                {
                    test.GuesedPlayer();
                });
                task3.Wait();
            }

            lock (lockerCheater)
            {
                Task task4 = Task.Run(() =>
                {
                    test.GuesedPlayer();
                });
                task4.Wait();
            }

            lock (lockerUB)
            {
                Task task5 = Task.Run(() =>
                {
                    test.GuesedPlayer();
                });
                task5.Wait();
            }

        }

        public void GuesedPlayer()
        {

            int numberOfAttempts = 100;
            var guess = new List<int>();
            var playersList = new List<BasePlayer>()
            {
                new NotepadPlayer(),
                new UsualPlayer(),
                new UberPlayer(),
                new CheaterPlayer(),
                new UberCheaterPlayer()
            };

            mutex.WaitOne();
            {
                for (int i = 0; i < numberOfAttempts - playersList.Count - 1; i += playersList.Count)
                {
                    foreach (var player in playersList)
                    {

                        var newGuessed = basketWeight + 1;
                        var newGuessedfrst = basketWeight - 1;


                        var guessedNumber = player.GuessNumber(guess);
                        player.PrintCurrentResult(guessedNumber);

                        {
                            if (guessedNumber == basketWeight)
                            {
                                Console.WriteLine(player.ToString());
                                Console.ReadLine();
                                {
                                    if (guessedNumber != basketWeight)
                                    {

                                        {
                                            if (newGuessed == guessedNumber || newGuessedfrst == guessedNumber)
                                            {
                                                Console.WriteLine(player.InfoPlayer());
                                                Console.ReadLine();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("NO ONE GUESSED THE WEIGHT BASKET");
                                            }
                                        }
                                    }

                                }
                            }

                        }
                    }
                    Console.WriteLine("-----------------------------");
                }
            }
            mutex.ReleaseMutex();
            Console.ReadLine();
        }

    }
}