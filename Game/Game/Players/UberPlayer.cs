

namespace Game.Players
{
    public class UberPlayer:BasePlayer
    {
        private int currentGuess = MinWeigth;
        protected override string PlayerType => "Uber Player";
        public override int GuessesNumber()
        {
            allGuessings.Add(currentGuess);
            return currentGuess++;
        }
    }
}
