using System.Collections.Generic;

namespace NewGame.Players
{
    public class UberPlayer : BasePlayer
    {
        private int currentGuess = MinBoundary;

        public List<int> uberList = new List<int>();

        public UberPlayer()
        {
            TypeOfPlayer = TypeOfPlayer.uber;
        }

        public override void GuessNumber()
        {
            allGuessedNumbers.Add(currentGuess);
            currentGuess++;
            GuessingNumber = currentGuess;
        }
    }
}

