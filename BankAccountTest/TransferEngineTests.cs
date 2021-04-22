using System;
using BankAccount;
using Xunit;

namespace BankAccountTest
{
    public class TransferEngineTests
    {
        private class FakeBankAccount : IBankAccount
        {
            private double _balance;
            public int DebitCounter { get; private set; }
            public int CreditCounter { get; private set; }

            public double Balance => _balance;

            public FakeBankAccount(double initBalance)
            {
                DebitCounter = 0;
                CreditCounter = 0;
                _balance = initBalance;
            }
            public void Credit(double amount)
            {
                CreditCounter++;
                _balance += amount;
            }

            public void Debit(double amount)
            {
                DebitCounter++;
                _balance -= amount;
            }
        }

        private readonly TransferEngine _transferEngine;
        public TransferEngineTests()
        {

            var debitAccount = new FakeBankAccount(100);
            var creditAccount = new FakeBankAccount(0);

            _transferEngine = new TransferEngine(debitAccount, creditAccount);

        }


        [Fact]
        public void Check_If_Credit_And_Debit_Functions_Are_Used_On_Proper_Account()
        {
            _transferEngine.TransferMoney(10);
            Assert.Equal(0, (_transferEngine.DebitAccount as FakeBankAccount).CreditCounter);
            Assert.Equal(1, (_transferEngine.CreditAccount as FakeBankAccount).CreditCounter);
            Assert.Equal(1, (_transferEngine.DebitAccount as FakeBankAccount).DebitCounter);
            Assert.Equal(0, (_transferEngine.CreditAccount as FakeBankAccount).DebitCounter);
            //(_transferEngine.DebitAccount as FakeBankAccount).CreditCounter
        }


        [Fact]
        public void Check_Balance_After_Operation()
        {
            var result = _transferEngine.TransferMoney(10);
            Assert.Equal(90d, result.Item1);
            Assert.Equal(10d, result.Item2);
            //var item = (double, double)
            //item.Item1, item.Item2;
        }

    }
}
