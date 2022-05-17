using System;

namespace LudoApplication.GameItems
{
    public class Die
    {
        private int numberOfSides;

        public Die(int numberOfSides)
        {
            this.numberOfSides = numberOfSides;
        }

        public int NumberOfSides { get => numberOfSides; set => numberOfSides = value; }

        public int Roll()
        {
            Random random = new();
            return random.Next(1, numberOfSides + 1);
        }
    }
}
