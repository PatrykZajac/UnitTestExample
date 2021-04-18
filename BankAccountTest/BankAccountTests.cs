using System;
using Xunit;
using BankAccount;

namespace BankAccountTest
{
    public class BankAccountTests
    {
        public BankAccountTests()
        {
        }

        [Fact]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {

            throw new NotImplementedException();
        }

        [Fact]
        public void Credit_WhenAmountIsLessThenZero_ShouldThrowArgumentOutOfRange()
        {
            throw new NotImplementedException();
        }
    }
}
