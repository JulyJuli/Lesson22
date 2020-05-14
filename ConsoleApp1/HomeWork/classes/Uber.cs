using System.Collections.Generic;

namespace Game.classes
{
    public class Uber : Player
    {
        private int startValue = MIN_VALUE;
        public Uber(string name) : base(name)
        {
        }
        
        public override int GetNumber(List<int> attempts)
        {
            return startValue++;
        }
    }
}