using System.Collections.Generic;

namespace FruitBasket_DLL
{
    public abstract class Player
    {
        public abstract string TypeName { get; }
        public string Name { get; set; }
        public List<int> PersonalTries { get; set; }
        public int BestTry { get; set; }

        public abstract int Guess(int minValue, int maxValue, ref List<List<int>> totalTriesList);
    }
}
