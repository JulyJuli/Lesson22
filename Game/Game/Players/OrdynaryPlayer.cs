using System;


namespace Game.Players
{
    class OrdynaryPlayer:BasePlayer
    {
        protected override string PlayerType => "Ordynary Player";
        public override int GuessesNumber()
        {
            var guessedNumder = new Random().Next(maxValue: MaxWeight, minValue: MinWeigth);
            allGuessings.Add(guessedNumder);
            return guessedNumder;
        }
    }
}
