using System.Collections.Generic;

namespace FruitBasket_DLL
{
    public class UberCheaterPlayer : Player //идет по порядку, не повторяет чужих ошибок
    {
        public override string TypeName => "Uber-Cheater";
        private int TriesCounter = Basket.MinWeight;

        public UberCheaterPlayer()
        {
            PersonalTries = new List<int>();
        }

        public override int Guess(int minValue, int maxValue, ref List<List<int>> totalTriesList)
        {
            int result = TriesCounter;

            foreach (List<int> personalList in totalTriesList)
            {
                while (personalList.Contains(result))
                {
                    TriesCounter++;
                    result = TriesCounter;
                }
            }

            PersonalTries.Add(result);

            return result;
        }
    }
}
