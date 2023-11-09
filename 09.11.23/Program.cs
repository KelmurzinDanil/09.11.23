using System;
using System.Collections.Generic;

namespace _09._11._23
{
    internal class Program
    {
        static decimal DecimalNumber() // Проверка на число
        {
            bool flag = true;
            decimal number;
            do
            {
                Console.WriteLine("Введите число:");
                bool isNumber = decimal.TryParse(Console.ReadLine(), out number);
                if (isNumber)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести число");
                }
            }
            while (flag);

            return number;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("9.1");

            BankAccount account = new BankAccount(1000000);
            BankAccount account2 = new BankAccount(10006768, BankAccount.AccountType.Current);
            BankAccount account3 = new BankAccount(BankAccount.AccountType.Savings);
            account.GetAccountInfo();
            account2.GetAccountInfo();
            account3.GetAccountInfo();
            BankAccount destantionAccount = new BankAccount(12304);
            Console.WriteLine("Введите цифру: 1 - снять деньги, 2 - положить на счет, 3 - перевести на другой счет ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите сумму");
            decimal amount = DecimalNumber();
            switch (a)
            {
                case 1:
                    account.Withdraw(amount);
                    account.GetAccountInfo();
                    break;
                case 2:
                    account.Deposit(amount);
                    account.GetAccountInfo();
                    break;
                case 3:
                    account.Transfer(amount, destantionAccount);
                    account.GetAccountInfo();
                    destantionAccount.GetAccountInfo();
                    break;
                default:
                    Console.WriteLine("Такой операции не существует");
                    break;
            }

            Console.WriteLine("9.2");

            BankAccount_9_2 account_9_2 = new BankAccount_9_2(1200000);
            account_9_2.Withdraw(1232);
            account_9_2.Deposit(3234);
            account_9_2.Transfer(990, destantionAccount);
            Queue<BankTransaktion> transaktion = account_9_2.StoreTransaktion;
            for (int i = 0; i < transaktion.Count; i++)
            {
                BankTransaktion transactionBank = transaktion.Dequeue();
                Console.WriteLine($"Пополнение/Снятие/Перевод {transactionBank.TransaktionDate}, {transactionBank.TransaktionAmount} рублей");

            }

            Console.WriteLine("9.3");

            BankAccount_9_3 account_9_3 = new BankAccount_9_3(120303);
            account_9_3.Withdraw(5432);
            account_9_3.Deposit(3738);
            account_9_3.Transfer(930, destantionAccount);
            account_9_3.Dispose();

            Console.WriteLine("9.4");

            List<Song> song = new List<Song>();
            Song song1 = new Song();
            song1.Name("Лампабикт");
            song1.Author("Крылья");
            song.Add(song1);
            Song song2 = new Song();
            song2.Name("Мой Июль");
            song2.Author("Грязь");
            song.Add(song2);
            Song song3 = new Song();
            song3.Name();
            song3.Author();
            song.Add(song3);
            foreach (Song s in song)
            {
                s.PrintSong();
            }
            song1.Equals(song2); // сравнение

            

            Console.ReadKey();
        }
    }
}
