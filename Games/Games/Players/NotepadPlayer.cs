using System;
using System.Collections.Generic;

namespace Games.Players
{
    public class NotepadPlayer : BasePlayer
    {
        private readonly List<int> passedGuessing;
        public NotepadPlayer() 
        {
            passedGuessing = new List<int>();
        }
        protected override string PlayerType => "Valeriia";

        public override int GuessNumber(List<int> guess)
        {
            var randNumber = new Random().Next(maxValue: MaxBoudary, minValue: MinBoudary);
            int counter = 1;
            while (passedGuessing.Contains(randNumber))
            {
                if (counter < 6)
                {
                    counter++;
                    randNumber = new Random().Next(maxValue: MaxBoudary, minValue: MinBoudary);
                }
            }
            return randNumber;
        }
    }
}