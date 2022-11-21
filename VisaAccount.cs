using System;
namespace Accounts
{
    public class VisaAccount:Account, ITransaction
    {
    private double creditLimit;
        private static double INTEREST_RATE = 0.1995;
        private const int MONTH = 12;
        public VisaAccount(double balance = 0, double creditLimit = 1200) : base("VS-", balance)
        {
            this.creditLimit = creditLimit;
        }
        public void Pay(double amount, Person person)
        {
            base.Deposit(amount, person);
            TransactionEventArgs e = new TransactionEventArgs(person.Name, amount, true);
            OnTransactionOccur(person, e);
        }
        public void Purchase(double amount, Person person)
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
            if (amount > this.Balance)
            {
                TransactionEventArgs i = new TransactionEventArgs(person.Name, amount, false);
                OnTransactionOccur(person, i);
                throw new AccountException(ExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);

            }
            Pay(-amount, person);
        }
        public override void PrepareMonthlyStatement()
        {
            double interest = LowestBalance * (INTEREST_RATE / MONTH);
            this.Balance -= interest;
            this.transactions.Clear();
        }
        public void Withdraw(double amount, Person person)
        {
        }
    }
}

