using System;


namespace Game.Players
{
    public class CheaterPlayer:BasePlayer
    {
        protected override string PlayerType => "Cheater Player";
        public override int GuessesNumber()
        {
            var randNumber = new Random().Next(maxValue: MaxWeight, minValue: MinWeigth);
            var counter = 1;
            while (allGuessings.Contains(randNumber))
            {
                if (counter < 6)
                {
                    counter++;
                    randNumber = new Random().Next(maxValue: MaxWeight, minValue: MinWeigth);
                }
            }
            allGuessings.Add(randNumber);
            return randNumber;
        }
    }
}
