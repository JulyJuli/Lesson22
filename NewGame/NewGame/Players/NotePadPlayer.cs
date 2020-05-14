using System;
using System.Collections.Generic;

namespace NewGame.Players
{
    public class NotepadPlayer : BasePlayer
    {
        private readonly List<int> passedGuessings;

        public NotepadPlayer()
        {
            TypeOfPlayer = TypeOfPlayer.notepad;
            passedGuessings = new List<int>();
        }

        public override void GuessNumber(/*int r*/)
        {
            int randNumber;

            bool IsFaund = false;

            do
            {
                randNumber = new Random().Next(maxValue: MaxBoundary, minValue: MinBoundary);

                for (int i = 0; i < passedGuessings.Count; i++)
                {
                    IsFaund = false;
                    if (randNumber == passedGuessings[i])
                    {
                        IsFaund = true;
                    }
                }
            }
            while (IsFaund == true);

            GuessingNumber = randNumber;

            passedGuessings.Add(randNumber);

            allGuessedNumbers.Add(randNumber);
        }
    }
}
