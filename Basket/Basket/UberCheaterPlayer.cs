using System;
using System.Threading;


namespace Basket
{
    public class UberCheaterPlayer : BasePlayer
    {
        private int currentCount = MinBoudary;

        protected override string PlayerType => "UberCheater Player";

        public override int GuessedNumber { get ; set; }

        public override void GuessNumber()
        {          
            var counter = 1;
            while (allGuessings.Contains(currentCount))
            {
                if (counter < 6)
                {
                    counter++;
                    currentCount++;
                }
            }
            allGuessings.Add(currentCount);
            GuessedNumber= currentCount;
            Console.WriteLine("Current thread :" + Thread.CurrentThread.Name + $" ={GuessedNumber}");
        }
    }
}
