using System;

namespace NewGame.Players
{
    public class CheaterPlayer : BasePlayer
    {
        public CheaterPlayer()
        {
            TypeOfPlayer = TypeOfPlayer.cheater;
        }

        public override void GuessNumber()
        {
            int randNumber;
            bool IsFaund;

            do
            {
                IsFaund = false;
                randNumber = new Random().Next(maxValue: MaxBoundary, minValue: MinBoundary);

                for (int i = 0; i < allGuessedNumbers.Count; i++)
                {
                    if (randNumber == allGuessedNumbers[i])
                    {
                        IsFaund = true;
                    }
                }
            }
            while (IsFaund == true);

            GuessingNumber = randNumber;

            allGuessedNumbers.Add(randNumber);
        }
    }
}
