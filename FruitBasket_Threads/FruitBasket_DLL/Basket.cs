using System;

namespace FruitBasket_DLL
{
    public class Basket
    {
        public static int MinWeight => 40;
        public static int MaxWeight => 140;
        public int Weight { get; set; }
        //private Random WeightSeed { get; set; }

        public Basket(Random randomSeed)
        {
            Weight = randomSeed.Next(MinWeight, MaxWeight);
        }

        //public int GetWeight(int minWeight, int maxWeight)
        //{
        //    Weight = WeightSeed.Next(minWeight, maxWeight);

        //    return Weight;
        //}
    }
}
