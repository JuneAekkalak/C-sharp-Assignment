using System;

namespace Program5
{
    class DiceProgram
    {
        public static void Main()
        {
            int mark = 0, i = 1;
            Dice dic1 = new Dice();

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

