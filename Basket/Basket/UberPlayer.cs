using System;
using System.Threading;


namespace Basket
{
    public class UberPlayer : BasePlayer
    {
        private int currentGuess = MinBoudary;

        protected override string PlayerType => "Uber Player";

        public override int GuessedNumber { get; set; }

        public override void GuessNumber()
        {           
            allGuessings.Add(currentGuess);
            GuessedNumber= currentGuess++;
            Console.WriteLine("Current thread :" + Thread.CurrentThread.Name+ $" ={GuessedNumber}");
        }
    }
}
