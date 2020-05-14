using System;
using System.Collections.Generic;
using System.Threading;
using Game.enums;
using Game.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Game.classes
{
    public class InitGame
    {
        private const int MIN_PLAYERS = 2;
        private const int MAX_PLAYERS = 8;
        private const int MAX_ATTEMPTS = 100;
        private const int MIN_VALUE = 40;
        private const int MAX_VALUE = 140;

        private static Mutex mut = new Mutex();

        private List<IHuman> players;
        private int linkPlayer;
        private List<int> attempts;
        private IHuman closestPlayer;
        private bool guessed;
        private int secretValue;
        private int closestNumber;
        private int difference;
        
        public InitGame()
        {
            Start();
        }

        private void Start()
        {
            Console.Clear();
            secretValue = new Random().Next(MIN_VALUE, MAX_VALUE);
            players = new List<IHuman>();
            attempts = new List<int>();
            linkPlayer = 0;
            guessed = false;
            
            GeneratePlayers(players);
            
            difference = MAX_VALUE - MIN_VALUE;
            closestNumber = 0;
            closestPlayer = players[linkPlayer];
            
            Console.WriteLine("Real basket weight = {0}\n", secretValue);
            Console.WriteLine("Players:\n");

            foreach (var player in players)
            {
                Console.WriteLine(player.ToString());
            }
            
            Console.Write("\nAttempts:\n");

            var playerThreads = new Thread[players.Count];

            for (int i = 0; i < playerThreads.Length; i++)
            {
                playerThreads[i] = new Thread(CheckAnswer){Name = "Thread player - " + players[i].Name};
            }

            for (int i = 0; i < playerThreads.Length; i++)
            {
                playerThreads[i].Start(i);
            }

        }

        public  void CheckAnswer(object param)
        {
            var index = (int) param;

            mut.WaitOne();

            var attempt = players[index].GetNumber(attempts);

            if (!guessed)
            {
                Console.WriteLine($"Player: {players[index].Name, -25}; Attempt: {attempt, -15}; Thread name: {Thread.CurrentThread.Name}");
            }

            if (attempt == secretValue)
            {
                guessed = true;
                closestPlayer = players[index];
            }

            if (!guessed && difference > Math.Abs(attempt - secretValue))
            {
                difference = Math.Abs(attempt - secretValue);
                closestNumber = attempt;
                closestPlayer = players[index];
            }

            attempts.Add(attempt);

            Thread.Sleep(30);

            mut.ReleaseMutex();

            if (attempts.Count < MAX_ATTEMPTS && !guessed)
            {
                CheckAnswer(index);
            }
            else if(linkPlayer++ == players.Count - 1)
            {
                Console.WriteLine(guessed
                    ? $"\nPlayer \"{closestPlayer.Name}\" guessed the weight of the basket({secretValue})!\n"
                    : $"\nNo one guessed the weight of the basket({secretValue}). The closest was \"{closestPlayer.Name}\" with a basket weight of {closestNumber}!\n");

                Console.WriteLine("Wont more? (y/n)");

                var key = Console.ReadKey(true).KeyChar;

                switch (key)
                {
                    case 'y':
                        Start();
                        break;

                    case 'n':
                        break;

                    default:
                        Start();
                        break;
                }
            }
        }
        
        private void GeneratePlayers(List<IHuman> players)
        {
            var services = new ServiceCollection();
           
            Startup startup = new Startup();
            startup.ConfigureServices(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var shuffleService = serviceProvider.GetService<IAbleToShuffle>();

            var playerCount = new Random().Next(MIN_PLAYERS, MAX_PLAYERS);

            for (int i = 0; i < playerCount; i++)
            {
                IHuman player;
                var playerTypeValues = Enum.GetValues(typeof(PlayerType));
                PlayerType randomPlayerType = (PlayerType)playerTypeValues.GetValue(new Random().Next(playerTypeValues.Length));
                
                switch (randomPlayerType)
                {
                    case PlayerType.Regular:
                        player = new Regular($"Regular Player {i}");
                        break;

                    case PlayerType.Notepad:
                        player = new Notepad($"Notepad Player {i}", shuffleService);
                        break;

                    case PlayerType.Uber:
                        player = new Uber($"Uber Player {i}");
                        break;
                
                    case PlayerType.Cheater:
                        player = new Cheater($"Cheater Player {i}", shuffleService);
                        break;
                    
                    case PlayerType.UberCheater:
                        player = new UberCheater($"Uber Cheater Player {i}");
                        break;

                    default:
                        player = new Regular($"Regular Player {i}");
                        break;
                }
                
                players.Add(player);
            }
        }
    }
}
