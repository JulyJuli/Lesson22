using System;
using System.Threading;


namespace Basket
{
    public class UsualPlayer : BasePlayer
    {
        protected override string PlayerType => "Usual Player";

        public override int GuessedNumber { get ; set ; }

        public override void GuessNumber()
        {
            //mutex.WaitOne();
                // Console.WriteLine("Current thread :" + Thread.CurrentThread.Name);
                var guessedNumber = new Random().Next(MinBoudary, MaxBoudary);
                allGuessings.Add(guessedNumber);
                GuessedNumber = guessedNumber;
                Console.WriteLine("Current thread :" + Thread.CurrentThread.Name + $" = {GuessedNumber}");
            //mutex.ReleaseMutex();
            }
        }
    }

