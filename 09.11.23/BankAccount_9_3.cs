using System;
using System.Collections.Generic;
using System.IO;

namespace _09._11._23
{
    internal class BankAccount_9_3
    {
        public enum AccountType
        {
            Current,
            Savings
        }

        private int accountNumber;
        private decimal balance;
        private AccountType type;
        private Queue<BankTransaktion> storeTransaktions = new Queue<BankTransaktion>();

        public BankAccount_9_3(decimal balance, AccountType type)
        {
            GenerationNomberAccount();
            this.balance = balance;
            this.type = type;
        }
        public BankAccount_9_3(decimal balance)
        {
            GenerationNomberAccount();
            this.balance = balance;
        }
        public BankAccount_9_3(AccountType type)
        {
            GenerationNomberAccount();
            this.type = type;
        }
        public Queue<BankTransaktion> StoreTransaktion
        {
            get
            {
                return storeTransaktions;
            }
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
            storeTransaktions.Enqueue(new BankTransaktion(amount));
        }

        public void Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                storeTransaktions.Enqueue(new BankTransaktion(amount));
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
                storeTransaktions.Enqueue(new BankTransaktion(amount));
            }
            else
            {
                Console.WriteLine($"Вы не можете столько перевести, у вас на счету {balance}");
            }
        }
        public void Dispose()
        {
            Queue<BankTransaktion> transaktion = StoreTransaktion;
            string filePath = "ТумаковБанк.txt";
            using (StreamWriter writer = new StreamWriter(filePath,true))
            {
                for (int i = 0; i < transaktion.Count; i++)
                {
                    BankTransaktion transactionBank = transaktion.Dequeue();
                    writer.WriteLine($"Пополнение/Снятие/Перевод {transactionBank.TransaktionDate}, {transactionBank.TransaktionAmount} рублей");
                }
            }
            GC.SuppressFinalize(this);
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






