using System;

namespace _09._11._23
{
    internal class BankTransaktion
    {
        private DateTime dateTransaktion;
        private decimal amount;
        public BankTransaktion(decimal amount)
        {
            this.amount = amount;
            dateTransaktion = DateTime.Now;
        }
        public DateTime TransaktionDate
        {
            get
            {
                return dateTransaktion;
            }
        }
        public decimal TransaktionAmount
        {
            get
            {
                return amount;
            }
        }

    }
}
