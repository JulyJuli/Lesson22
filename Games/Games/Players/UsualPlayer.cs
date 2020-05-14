using System;
using System.Collections.Generic;

namespace Games.Players
{
    public class UsualPlayer : BasePlayer
    {
        protected override string PlayerType => "Dima";
        public override int GuessNumber(List<int> guess)
        {

            var guessedNumber = new Random().Next(maxValue: MaxBoudary, minValue: MinBoudary);
            return guessedNumber;
        }
    }
}