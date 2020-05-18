using System;
using System.Collections.Generic;
using System.Linq;


namespace Game.Players
{
    public abstract class BasePlayer
    {
        protected const int MinWeigth = 40;
        protected const int MaxWeight = 140;
        protected static readonly List<int> allGuessings= new List<int>();

        protected abstract string PlayerType { get; }
        public abstract int GuessesNumber();
        public void PrintResult(int guessedNumber)
        {
            Console.WriteLine($"{PlayerType} guessed {guessedNumber}");
        }
        public override string ToString()
        {
            return $"{PlayerType} wins!!!\n------------------|";
        }
    }
}
