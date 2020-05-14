using System.Collections.Generic;

namespace Games.Players
{
    public class UberCheaterPlayer : BasePlayer
    {

        private int currentCount = MinBoudary;

        protected override string PlayerType =>"Anton";
        public override int GuessNumber(List<int> guess)
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
            return currentCount;
        }
    }
}