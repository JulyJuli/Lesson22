using System;
using System.Collections.Generic;
using System.Threading;

namespace Basket
{
    public class GamePlayer : BasePlayer
    {
        private readonly List<int> passedGuessings;
        public GamePlayer()
        {
            passedGuessings = new List<int>();
        }
        protected override string PlayerType => "Game Player";

        public override int GuessedNumber { get; set; }

        public override void GuessNumber()
        {
            //Console.WriteLine("Current thread :" + Thread.CurrentThread.Name);
            var randNumber = new Random().Next(MinBoudary,MaxBoudary);
            var counter = 1;
            while(passedGuessings.Contains(randNumber))
            {
                if(counter<6)
                {
                    counter++;
                    randNumber = new Random().Next(MinBoudary, MaxBoudary);
                }                
            }
            GuessedNumber = randNumber;
            passedGuessings.Add(randNumber);
            allGuessings.Add(randNumber);
            
            Console.WriteLine("Current thread :" + Thread.CurrentThread.Name + $" ={GuessedNumber}");
        }
    }
}
