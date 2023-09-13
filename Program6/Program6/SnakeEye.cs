using System;

class Dice
{
    private Random random = new Random();

    public int Throw() => random.Next(1, 7);
}

class SnakeeyesProgram
{
    public static void Main()
    {
        int toss = 0;
        Dice dic1 = new Dice();
        Dice dic2 = new Dice();

        while (true)
        {
            int result1 = dic1.Throw();
            int result2 = dic2.Throw();
            Console.WriteLine($"Throw {toss + 1}: Dice 1: {result1}, Dice 2: {result2}");

            if (result1 == 1 && result2 == 1)
            {
                Console.WriteLine($"Snake Eyes succeeds after {toss + 1} Throw!");
                break;
            }

            System.Threading.Thread.Sleep(10);
            toss++;
        }

        Console.ReadLine();
    }
}
