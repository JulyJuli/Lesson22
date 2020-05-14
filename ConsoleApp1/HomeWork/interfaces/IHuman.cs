using System.Collections.Generic;

namespace Game.interfaces
{
    public interface IHuman
    {
        public string Name { get; }

        public int GetNumber(List<int> attempts);
    }
}