using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Application_Exceptions
{
    class InsufficientFundsException :ApplicationException
    {
        public InsufficientFundsException(string message):base(message)
        { }
    }
    class InvalidAmountException : ApplicationException
    {
        public InvalidAmountException(string message) : base(message) { }
    }
    internal class BankAccount
    {
        private double _balance;
        public double Balance
        {
            get { return _balance; }
            set {
                
                _balance = value; }
        }
        public BankAccount(double balance)
        {
            Balance = balance;
        }
        public void Withdrawl(double amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientFundsException("Insufficient funds");
            }
            if (amount < 0)
            {
                throw new InvalidAmountException("Invalid amount");
            }
            Balance = Balance - amount;
            Console.WriteLine("Amount withdrawn is " + amount + " balance is " + Balance);
        }
        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new InvalidAmountException("Invalid amount");
            }
            Balance = Balance + amount;
            Console.WriteLine("Deposited " + amount + " Balance is " + Balance); 
        }
        public static void Main(string[] args)
        {
            BankAccount account = new BankAccount(20000);
            int b = 0;int a = 0;
            Console.WriteLine("1.Withdrawl\n2.Deposit");
            Console.WriteLine("Enter option");
            string option = Console.ReadLine();
            string pattern1 = @"^(1|2)$";
            bool match = Regex.IsMatch(option, pattern1);
            if (match)
            {
                a = Convert.ToInt32(option);
            }
            else
            {
                Console.WriteLine("Invalid option");
                return;
            }
            Console.WriteLine("Enter amount");
            string pattern2 = @"[0-9]+";
            string amount=Console.ReadLine();
            bool match2=Regex.IsMatch(amount, pattern2);
            if (match2)
            {
                 b = Convert.ToInt32(amount);
            }
            else
            {
                Console.WriteLine("Invalid amount");
                return;
            }

            try
            {
                switch (a)
                {
                    case 1: account.Withdrawl(b);
                        break;
                    case 2: account.Deposit(b);
                        break;
                }
                
                
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidAmountException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
