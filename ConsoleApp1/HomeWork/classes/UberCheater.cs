using System.Collections.Generic;
using System.Linq;

namespace Game.classes
{
    public class UberCheater : Player
    {
        private int[] _array;
        public UberCheater(string name) : base(name)
        {
            _array = new int[MAX_VALUE - MIN_VALUE];
            for (int i = MIN_VALUE; i < MAX_VALUE; i++)
            {
                _array[i - MIN_VALUE] = i;
            }
        }

        public override int GetNumber(List<int> attempts)
        {
            foreach (var item in attempts)
            {
                _array = _array.Where(val => val != item).ToArray();
            }
            var attempt = _array[0];
            _array = _array.Where(val => val != attempt).ToArray();
            
            return attempt;
        }
    }
}