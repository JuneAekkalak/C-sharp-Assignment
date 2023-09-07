using System;

namespace Program5
{
    class dice
    {
        private static Random random = new Random();

        public int Throw()
        {
            return random.Next(1, 7); // random 1-6
        }
    }
    class DiceProgram
    {
        public static void Main()
        {
            int mark = 0, i = 1;
            dice dic1 = new dice();

            while (mark != 1)
            {
                mark = dic1.Throw();
                Console.WriteLine($"{i} Mark of Dice: {mark}");
                System.Threading.Thread.Sleep(10);
                i++;
            }

            Console.WriteLine($"Throw of dice = 1 is: {i - 1} times");
            Console.ReadLine();
        }
    }
}
