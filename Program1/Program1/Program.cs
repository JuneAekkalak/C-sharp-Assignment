using System;

namespace ChangeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] money = { 1000, 500, 100, 50, 10, 5, 1 };
            int[] moneyAvailable = new int[money.Length];

            Console.WriteLine("Input จำนวน แบงค์และเหรียญแบบต่างๆ");
            InputMoneyAvailable(money, moneyAvailable);

            while (true)
            {
                try
                {
                    int amount = ReadValidAmount();
                    int[] change = new int[money.Length];
                    int remainingMoney = amount;
                    int balance = CalculateBalance(money, moneyAvailable);

                    if (amount > balance)
                    {
                        Console.WriteLine("ไม่สามารถทอนเงินได้ เนื่องจากเงินไม่พอ");
                    }
                    else
                    {
                        CalculateChange(money, moneyAvailable, change, ref remainingMoney);
                        if (remainingMoney == 0)
                        {
                            DisplayChange(money, change, moneyAvailable);
                        }
                        else
                        {
                            Console.WriteLine("ไม่สามารถทอนเงินได้ เนื่องจากไม่มีเศษ");
                        }
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("กรุณาใส่จำนวนเงินที่เป็นจำนวนเต็ม");
                }
            }
        }

        static int ReadValidAmount()
        {
            int amount;
            while (true)
            {
                Console.Write("ต้องการทอนเงิน (บาท): ");
                if (int.TryParse(Console.ReadLine(), out amount) && amount > 0)
                {
                    return amount;
                }
                Console.WriteLine("กรุณาใส่จำนวนเงินที่มากกว่า 0");
            }
        }

        static void InputMoneyAvailable(int[] money, int[] moneyAvailable)
        {
            for (int i = 0; i < money.Length; i++)
            {
                Console.Write($"{(money[i] >= 20 ? "แบงค์" : "เหรียญ")} {money[i]}: ");
                int.TryParse(Console.ReadLine(), out moneyAvailable[i]);
            }
        }

        static int CalculateBalance(int[] money, int[] moneyAvailable)
        {
            int balance = 0;
            for (int i = 0; i < money.Length; i++)
            {
                balance += money[i] * moneyAvailable[i];
            }
            return balance;
        }

        static void CalculateChange(int[] money, int[] moneyAvailable, int[] change, ref int remainingMoney)
        {
            for (int i = 0; i < money.Length; i++)
            {
                while (remainingMoney >= money[i] && moneyAvailable[i] > 0)
                {
                    change[i]++;
                    remainingMoney -= money[i];
                    moneyAvailable[i]--;
                }
            }
        }

        static void DisplayChange(int[] money, int[] change, int[] moneyAvailable)
        {
            Console.WriteLine("ทอนเงินได้ดังนี้:");
            for (int i = 0; i < money.Length; i++)
            {
                if (change[i] > 0)
                {
                    Console.WriteLine($"{(money[i] >= 20 ? "ใช้แบงค์" : "ใช้เหรียญ")} {money[i]}: {change[i]} เหลือ {moneyAvailable[i]} ");
                }
            }
        }
    }
}
