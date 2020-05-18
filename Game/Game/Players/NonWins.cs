using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Players
{
    public class NonWins:BasePlayer
    {
        protected override string PlayerType => "Non Wins";

        
        public override int GuessesNumber()
        {

            int closest = allGuessings.OrderBy(item => Math.Abs(value: - item)).First();
            return closest;
        }
    }
}
