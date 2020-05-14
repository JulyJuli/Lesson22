using NewGame.Players;
using System;
using System.Collections.Generic;

namespace NewGame
{
    class ProcessGuessing
    {
        public static List<ProcessGuessing> allPlayersAndGuessings = new List<ProcessGuessing>();

        public ProcessGuessing(BasePlayer player, int weight)
        {
            Player = player;
            Weight = weight;
        }

        public BasePlayer Player { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{Player.TypeOfPlayer} WIN {Weight}!!!!!";
        }

        public static void PrintList()
        {
            for (int i = 0; i < allPlayersAndGuessings.Count; i++)
            {
                Console.Write(allPlayersAndGuessings[i].Weight + " ");
            }
        }

        public static string SearchWinner()
        {
            ProcessGuessing searchWinner = ProcessGuessing.allPlayersAndGuessings[0];

            int min = Math.Abs(FruitBasket.Weight - ProcessGuessing.allPlayersAndGuessings[0].Weight);

            for (int i = 0; i < ProcessGuessing.allPlayersAndGuessings.Count; i++)
            {
                if (min > Math.Abs(FruitBasket.Weight - ProcessGuessing.allPlayersAndGuessings[i].Weight))
                {
                    min = Math.Abs(FruitBasket.Weight - ProcessGuessing.allPlayersAndGuessings[i].Weight);
                    searchWinner = ProcessGuessing.allPlayersAndGuessings[i];
                }
            }
            return $"The winner is: {searchWinner}";
        }
    }
}
