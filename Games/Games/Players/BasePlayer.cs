using System;
using System.Collections.Generic;
using System.Threading;

namespace Games
{
    public class BasePlayer
    {

        protected const int MinBoudary = 40;
        protected const int MaxBoudary = 140;
        protected readonly List<int> allGuessings;
        public BasePlayer()
        {
            allGuessings = new List<int>();
        }
        protected virtual string PlayerType { get; set; }

        public virtual int GuessNumber(List<int> guess)
        {
            return 0;
        }

        public void PrintCurrentResult(int guessedNumber)
        {
            Console.WriteLine($"{PlayerType} guessed {guessedNumber}");
        }
        public virtual string InfoPlayer()
        {

            return $"Closer the weight basket: {PlayerType} ";
        }
        public override string ToString()
        {

            return $"Guessed the weight basket: {PlayerType}";
        }

    }
}