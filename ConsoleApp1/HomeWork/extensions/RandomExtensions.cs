using System;

namespace Game.extensions
{
    public static class RandomExtensions
    {
        public static void Shuffle<T> (this Random rng, T[] array)
        {
            int arrayLength = array.Length;
            while (arrayLength > 1) 
            {
                int rngNext = rng.Next(arrayLength--);
                T temp = array[arrayLength];
                array[arrayLength] = array[rngNext];
                array[rngNext] = temp;
            }
        }
    }
}