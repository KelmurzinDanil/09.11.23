using System;

namespace _09._11._23
{
    internal class DestantionAccount
    {
        public enum AccountType
        {
            Current,
            Savings
        }

        private int accountNumber;
        private decimal balance;
        private AccountType type;

        public DestantionAccount(decimal balance, AccountType type)
        {
            this.accountNumber = GenerationNomberAccount();
            this.balance = balance;
            this.type = type;
        }
        public DestantionAccount(decimal balance)
        {
            this.accountNumber = GenerationNomberAccount();
            this.balance = balance;
        }
        public DestantionAccount(AccountType type)
        {
            this.accountNumber = GenerationNomberAccount();
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

        public void Transfer(decimal amount, BankAccount destinationAccount)
        {
            if (balance >= amount)
            {
                Withdraw(amount);
                destinationAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine($"Вы не можете столько перевести, у вас на счету {balance}");
            }
        }
        public int GenerationNomberAccount()
        {
            return accountNumber++;
        }

        public string GetAccountInfo()
        {
            return $"Тип - {type}, номер - {accountNumber}, баланс - {balance}";
        }
    }
}
