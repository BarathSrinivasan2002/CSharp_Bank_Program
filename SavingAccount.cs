using System;
namespace Accounts
{
    public class SavingAccount : Account, ITransaction
    {
        private static double COST_PER_TRANSACTION = 0.05;
        private static double INTEREST_RATE = 0.015;
        private const int MONTH = 12;
        public SavingAccount(double balance = 0) : base("SV-", balance)
        {
            Balance = balance;
        }
        public override void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
            TransactionEventArgs e = new TransactionEventArgs(person.Name, amount, true);
            OnTransactionOccur(person, e);
        }
        public void Withdraw(double amount, Person person)
        {
            if (!this.IsUser(person.Name))
            {
                TransactionEventArgs i = new TransactionEventArgs(person.Name, amount, false);
                OnTransactionOccur(person, i);
                throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }
            if (!person.IsAuthenticated)
            {
                TransactionEventArgs i = new TransactionEventArgs(person.Name, amount, false);
                OnTransactionOccur(person, i);
                throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);
            }
            if (this.Balance < amount)
            {
                TransactionEventArgs i = new TransactionEventArgs(person.Name, amount, false);
                OnTransactionOccur(person, i);
                throw new AccountException(ExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }
            Deposit(-amount, person);
        }
        public override void PrepareMonthlyStatement()
        {
            var serviceFee = this.transactions.Count * COST_PER_TRANSACTION;
            var interest = this.LowestBalance * (INTEREST_RATE / MONTH);
            this.Balance += interest - serviceFee;
            this.transactions.Clear();
        }
    }
}

