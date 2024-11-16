using System;

namespace System_Exceptions_Example
{
    internal class Bank
    {
        public void Withdraw(int balance,int amount)
        {
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            else if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Withdrawal amount must be positive");
            }
            else if(amount == 0)
            {
                throw new ArgumentException("Amount cannot be zero");
            }
            else
            {
                Console.WriteLine("Amount withdrawn is " + amount);
                Console.WriteLine("Balance is" +(balance - amount));
            }
        }
        static void Main(string[] args)
        {
            Bank b = new Bank();
            try
            {
                b.Withdraw(500,0);   
            }catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Finally block executed");
            }
            Console.WriteLine("End of program");
        }
    }
}
