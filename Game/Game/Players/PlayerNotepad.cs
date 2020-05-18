using System;
using System.Collections.Generic;


namespace Game.Players
{
    public class PlayerNotepad:BasePlayer
    {
        private readonly List<int> passedGuessings;
        public PlayerNotepad()
        {
            passedGuessings = new List<int>();
        }
        protected override string PlayerType => "Player Notepad";
        public override int GuessesNumber()
        {
            var randNumber = new Random().Next(maxValue: MaxWeight, minValue: MinWeigth);
            var counter = 1;
            while (passedGuessings.Contains(randNumber))
            {
                if (counter < 6)
                {
                    counter++;
                    randNumber = new Random().Next(maxValue: MaxWeight, minValue: MinWeigth);
                }

            }
            passedGuessings.Add(randNumber);
            allGuessings.Add(randNumber);
            return randNumber;
        }
    }
}
