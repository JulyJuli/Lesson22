using System;

namespace NewGame
{
    public class FruitBasket
    {
        protected const int MinWeight = 40;
        protected const int MaxWeight = 140;

        public FruitBasket()
        {
            Weight = new Random().Next(MinWeight, MaxWeight);
        }

        public static int Weight { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $"The weight of the basket is: {Weight}\n";
        }
    }
}
