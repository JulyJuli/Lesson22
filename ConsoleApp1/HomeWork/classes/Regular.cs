using System;
using System.Collections.Generic;

namespace Game.classes
{
    public class Regular : Player
    {
        public Regular(string name) : base(name)
        {
        }

        public override int GetNumber(List<int> attempts)
        {
            return new Random().Next(MIN_VALUE, MAX_VALUE);
        }
    }
}