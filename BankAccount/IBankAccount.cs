using System;
namespace BankAccount
{
    public interface IBankAccount
    {
        public void Credit(double amount);
        public void Debit(double amount);
        public double Balance { get; }
    }
}
