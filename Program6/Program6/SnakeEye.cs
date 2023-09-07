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
    internal class SnakeeyesProgram
    {
        public static void Main()
        {
            int rolls = 0;
            dice dic1 = new dice();
            dice dic2 = new dice();

            while (true)
            {
                int result1 = dic1.Throw();
                int result2 = dic2.Throw();
                Console.WriteLine($"Throw {rolls + 1}: Dice 1: {result1}, Dice 2: {result2}");

                if (result1 == 1 && result2 == 1)
                {
                    Console.WriteLine($"Snake Eyes succeeds after {rolls + 1} Throw!");
                    break;
                }

                System.Threading.Thread.Sleep(10);
                rolls++;
            }

            Console.ReadLine();
        }
    }
}
