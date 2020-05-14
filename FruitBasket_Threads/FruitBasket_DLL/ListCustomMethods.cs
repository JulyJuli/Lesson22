using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitBasket_DLL
{
    public static class ListCustomMethods
    {
        public static void AddPlayerToList(this List<Player> playersList, Player player)
        {
            Console.Write("Enter player's name: ");
            player.Name = Console.ReadLine();

            playersList.Add(player);

            Console.WriteLine();
        }

        public static int GetBestTry(this List<int> triesList, int basketWeight)
        {
            int result = triesList.Aggregate((x, y) => Math.Abs(x - basketWeight) < Math.Abs(y - basketWeight) ? x : y);

            return result;
        }
    }
}
