using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            while (true)
            {
                Console.WriteLine("Account\n===========");
                Console.WriteLine("1. Deposit\n2. Withdraw\n3. Check Balance\n4. Exit");
                Console.Write("Select number: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            double depositAmount;
                            Console.Write("Enter money to deposit: ");
                            double.TryParse(Console.ReadLine(), out depositAmount);
                            account.Deposit(depositAmount);
                            break;

                        case 2:
                            double withdrawAmount;
                            Console.Write("Enter money to withdraw: ");
                            double.TryParse(Console.ReadLine(), out withdrawAmount);
                            if (account.Withdraw(withdrawAmount))
                            {
                                Console.WriteLine($"Account balance is: {account.GetBalance()}");
                            }
                            else
                            {
                                Console.WriteLine("Cannot withdraw because money will be less than 100");
                            }
                            break;

                        case 3:
                            Console.WriteLine($"Account balance is: {account.GetBalance()}");
                            break;

                        case 4:
                            Console.WriteLine("Exiting the program...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }

    class BankAccount
    {
        private double balance = 100;

        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"Account balance is: {balance}");
        }

        public bool Withdraw(double amount)
        {
            if (balance - amount >= 100 && amount <= balance)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        public double GetBalance()
        {
            return balance;
        }
    }
}
