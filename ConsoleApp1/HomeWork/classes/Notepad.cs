using System.Collections.Generic;
using System.Linq;
using Game.interfaces;

namespace Game.classes
{
    public class Notepad : Player
    {
        private int[] _array;
        private IAbleToShuffle _arrayShuffle;

        public Notepad(string name, IAbleToShuffle arrayShuffle) : base(name)
        {
            _arrayShuffle = arrayShuffle;
            _array = _arrayShuffle.Shuffle(MIN_VALUE, MAX_VALUE);
        }

        public override int GetNumber(List<int> attempts)
        {
            var attempt = _array[0];
            _array = _array.Where(val => val != attempt).ToArray();
            
            return attempt;
        }
    }
}