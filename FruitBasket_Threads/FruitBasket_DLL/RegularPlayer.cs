using System;
using System.Collections.Generic;

namespace FruitBasket_DLL
{
    public class RegularPlayer : Player //выбирает рандомно
    {
        public override string TypeName => "Regular Player";
        private Random GuessSeed { get; set; }

        public RegularPlayer(Random randomSeed)
        {
            GuessSeed = randomSeed;
            PersonalTries = new List<int>();
        }

        public override int Guess(int minValue, int maxValue, ref List<List<int>> totalTriesList)
        {
            int result = GuessSeed.Next(minValue, maxValue);

            PersonalTries.Add(result);

            return result;
        }
    }
}
