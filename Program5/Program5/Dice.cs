using System;

namespace Program5
{
    class Dice
    {
        private static Random random = new Random();

        public int Throw()
        {
            return random.Next(1, 7); // random 1-6
        }
    }
}
