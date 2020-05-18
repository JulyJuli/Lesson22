
namespace Game.Players
{
    public class UberCheater:BasePlayer
    {
        private int currenrCount = MinWeigth;
        protected override string PlayerType => "Uber Cheater";
        public override int GuessesNumber()
        {
            var counter = 1;
            while (allGuessings.Contains(currenrCount))
            {
                if (counter < 6)
                {
                    counter++;
                    currenrCount++;
                }
            }
            allGuessings.Add(currenrCount);
            return currenrCount;
        }
    }
}
