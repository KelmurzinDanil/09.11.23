using System;

namespace _09._11._23
{
    internal class BankAccount
    {
        public enum AccountType
        {
            Current,
            Savings
        }

        private int accountNumber;
        private decimal balance;
        private AccountType type;

        public BankAccount(decimal balance, AccountType type)
        {
            GenerationNomberAccount();
            this.balance = balance;
            this.type = type;
        }
        public BankAccount(decimal balance)
        {
            GenerationNomberAccount();
            this.balance = balance;
        }
        public BankAccount(AccountType type)
        {
            GenerationNomberAccount();
            this.type = type;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine($"Вы не можете столько снять, у вас на счету {balance}");
            }
        }

        public void Transfer(decimal amount, BankAccount destantionAccount)
        {
            if (balance >= amount)
            {
                Withdraw(amount);
                destantionAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine($"Вы не можете столько перевести, у вас на счету {balance}");
            }
        }
        public void GenerationNomberAccount()
        {
            accountNumber++;
        }

        public void GetAccountInfo()
        {
            Console.WriteLine($"Тип - {type}, номер - {accountNumber}, баланс - {balance}");
        }
    }
}
