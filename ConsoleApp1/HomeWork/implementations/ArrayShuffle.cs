using System;
using Game.extensions;
using Game.interfaces;

namespace Game.implementations
{
    public class ArrayShuffle : IAbleToShuffle
    {
        public int[] Shuffle(int MIN_VALUE, int MAX_VALUE)
        {
            var _array = new int[MAX_VALUE - MIN_VALUE];
            for (int i = MIN_VALUE; i < MAX_VALUE; i++)
            {
                _array[i - MIN_VALUE] = i;
            }
            var rng = new Random();
            rng.Shuffle(_array);

            return _array;
        }
    }
}