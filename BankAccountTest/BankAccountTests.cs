using System;
using Xunit;
using BankAccount;

namespace BankAccountTest
{
    public class BankAccountTests
    {
        private readonly IBankAccount _bankAccount;
        public BankAccountTests()
        {
            _bankAccount = new BankAccount.BankAccount("Test", 100);
        }

        [Fact]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            _bankAccount.Credit(10d);
            Assert.Equal(110, _bankAccount.Balance);
        }

        [Fact]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            _bankAccount.Debit(10d);
            Assert.Equal(90, _bankAccount.Balance);
        }

        [Fact]
        public void Credit_WhenAmountIsLessThenZero_ShouldThrowArgumentOutOfRange()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _bankAccount.Credit(-1d));
        }

        [Fact]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _bankAccount.Debit(-1));
        }

        [Fact]
        public void Credit_WhenAmountIsZero_ShouldThrowArgumentOutOfRange()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _bankAccount.Credit(0));
        }

        [Fact]
        public void Debit_WhenAmountIsZero_ShouldThrowArgumentOutOfRange()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _bankAccount.Debit(0));
        }

        [Fact]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _bankAccount.Debit(200));
        }

    }
}
