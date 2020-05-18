using System;
using System.Collections.Generic;

namespace Basket
{
     public abstract class BasePlayer
    {       
        protected const int MinBoudary=40;
        protected const int MaxBoudary=140;
        public abstract int GuessedNumber { get; set; }
        protected static readonly List<int> allGuessings=new List<int>(); 
        protected abstract string PlayerType { get; }
        public abstract void  GuessNumber();
        public void PrintCurrentResult()
        {
            Console.WriteLine($"{PlayerType} guessed {GuessedNumber}");
        }

        public override string ToString()
        {
            return $"\t{PlayerType} won the GAME!!!";
        }
    }
}
