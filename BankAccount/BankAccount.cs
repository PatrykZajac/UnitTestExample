using System;
namespace BankAccount
{
    public class BankAccount : IBankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }

        public BankAccount(string customerName, double balance = 0d)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount can't be above balance");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount can't be below zero");
            }

            if (amount == 0)
            {
                throw new ArgumentOutOfRangeException("amount can't be zero");
            }

            m_balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount can't be below zero");
            }

            if (amount == 0)
            {
                throw new ArgumentOutOfRangeException("amount can't be zero");
            }

            m_balance += amount;
        }

        public double Balance
        {
            get { return m_balance; }
        }
    }
}
