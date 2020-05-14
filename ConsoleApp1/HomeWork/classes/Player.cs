using System.Collections.Generic;
using Game.interfaces;

namespace Game.classes
{
    public abstract class Player : IHuman
    {
        private protected const int MIN_VALUE = 40;
        private protected const int MAX_VALUE = 140;
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public virtual int GetNumber(List<int> attempts)
        {
            return 0;
        }

        public override string ToString()
        {
            return $"Name = {Name}";
        }
    }
}