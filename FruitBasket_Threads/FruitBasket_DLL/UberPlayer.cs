using System.Collections.Generic;

namespace FruitBasket_DLL
{
    public class UberPlayer : Player //идет по порядку (40, 41, 42...)
    {
        public override string TypeName => "Uber-Player";
        private int TriesCounter = Basket.MinWeight;

        public UberPlayer()
        {
            PersonalTries = new List<int>();
        }

        public override int Guess(int minValue, int maxValue, ref List<List<int>> totalTriesList)
        {
            int result = TriesCounter;
            TriesCounter++;

            PersonalTries.Add(result);

            return result;
        }
    }
}
