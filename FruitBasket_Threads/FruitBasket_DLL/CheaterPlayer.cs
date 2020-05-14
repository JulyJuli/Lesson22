using System;
using System.Collections.Generic;

namespace FruitBasket_DLL
{
    public class CheaterPlayer : Player //выбирает рандомно, не повторяет чужих ошибок
    {
        public override string TypeName => "Cheater";
        private Random GuessSeed { get; set; }

        public CheaterPlayer(Random randomSeed)
        {
            GuessSeed = randomSeed;
            PersonalTries = new List<int>();
        }

        public override int Guess(int minValue, int maxValue, ref List<List<int>> totalTriesList)
        {
            int result = GuessSeed.Next(minValue, maxValue);

            foreach (List<int> personalList in totalTriesList)
            {
                while (personalList.Contains(result))
                {
                    result = GuessSeed.Next(minValue, maxValue);
                }
            }

            PersonalTries.Add(result);

            return result;
        }
    }
}
