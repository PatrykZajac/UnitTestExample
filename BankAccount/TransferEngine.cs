using System;
namespace BankAccount
{
    public class TransferEngine
    {
        private readonly IBankAccount _debitAccount;
        private readonly IBankAccount _creditAccount;

        public IBankAccount CreditAccount => _creditAccount;
        public IBankAccount DebitAccount => _debitAccount;

        public TransferEngine(IBankAccount DebitAccount, IBankAccount CreditAccount)
        {
            _debitAccount = DebitAccount;
            _creditAccount = CreditAccount;
        }


        public (double, double) TransferMoney(double amount)
        {
            if(_debitAccount == null)
            {
                throw new NullReferenceException("Debit Account can't be null");
            }
            if (_creditAccount == null)
            {
                throw new NullReferenceException("Credit Account can't be null");
            }

            _debitAccount.Debit(amount);
            _creditAccount.Credit(amount);

            return (_debitAccount.Balance, _creditAccount.Balance);
        }
    }
}
