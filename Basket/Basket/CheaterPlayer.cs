using System;
using System.Threading;

namespace Basket
{
    public class CheaterPlayer : BasePlayer
    {       
        protected override string PlayerType => "Cheater Player";

        public override int GuessedNumber { get; set; }

        public override void GuessNumber()
        {
           // Console.WriteLine("Current thread :" + Thread.CurrentThread.Name);
            var randNumber = new Random().Next(MinBoudary, MaxBoudary);
            var counter = 1;
            while (allGuessings.Contains(randNumber))
            {
                if (counter < 6)
                {
                    counter++;
                    randNumber = new Random().Next(MinBoudary, MaxBoudary);
                }
            }            
            allGuessings.Add(randNumber);
            GuessedNumber= randNumber;
            Console.WriteLine("Current thread :" + Thread.CurrentThread.Name + $" ={GuessedNumber}");
        }
    }
}
