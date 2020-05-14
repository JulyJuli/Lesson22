namespace NewGame.Players
{
    public class UberCheaterPlayer : BasePlayer
    {
        private int currentGuess = MinBoundary;
        public UberCheaterPlayer()
        {
            TypeOfPlayer = TypeOfPlayer.uberCheater;
        }

        public override void GuessNumber()
        {
            while (allGuessedNumbers.Contains(currentGuess))
            {
                currentGuess++;
            }
            GuessingNumber = currentGuess;

            allGuessedNumbers.Add(currentGuess);
        }
    }
}
