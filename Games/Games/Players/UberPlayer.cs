using System.Collections.Generic;

namespace Games.Players
{
    public class UberPlayer : BasePlayer
    {
        private int currentGuess = MinBoudary;
        protected override string PlayerType => "Araz";
        public override int GuessNumber(List<int> guess)
        {
            return currentGuess++;
        }
    }
}
