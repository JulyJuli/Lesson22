using System;

namespace NewGame.Players
{
    public class UsualPlayer : BasePlayer
    {
        public UsualPlayer()
        {
            TypeOfPlayer = TypeOfPlayer.usual;
        }

        public override void GuessNumber()
        {
            Random r=new Random();
            var randNumber=r.Next(maxValue: MaxBoundary, minValue: MinBoundary);
            GuessingNumber = randNumber;
            allGuessedNumbers.Add(randNumber);
        }
    }
}

