using System;
using System.Collections.Generic;

namespace FruitBasket_DLL
{
    public class NotebookPlayer : Player //выбирает рандомно, не повторяет своих ошибок
    {
        public override string TypeName => "Notebook Player";
        private Random GuessSeed { get; set; }

        public NotebookPlayer(Random randomSeed)
        {
            GuessSeed = randomSeed;
            PersonalTries = new List<int>();
        }

        public override int Guess(int minValue, int maxValue, ref List<List<int>> totalTriesList)
        {
            int result = GuessSeed.Next(minValue, maxValue);

            while (PersonalTries.Contains(result))
            {
                result = GuessSeed.Next(minValue, maxValue);
            }

            PersonalTries.Add(result);

            return result;
        }
    }
}
