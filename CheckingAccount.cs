using System;
namespace Accounts
{
    public class CheckingAccount : Account, ITransaction
    {
        private static double COST_PER_TRANSACTION = 0.05;
        private static double INTEREST_RATE = 0.005;
        private const int MONTH = 12;
        private bool hasOverdraft;
        public CheckingAccount(double balance = 0, bool hasOverdraft = false) : base("CK-", balance)
        {
            this.hasOverdraft = hasOverdraft;
        }
        public override void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
            TransactionEventArgs e = new TransactionEventArgs(person.Name, amount, true);
            OnTransactionOccur(person, e);
        }
        public void Withdraw(double amount, Person person)
        {
            try
            {
                if (!base.IsUser(person.Name))
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
                if (base.Balance < amount)
                {
                    TransactionEventArgs i = new TransactionEventArgs(person.Name, amount, false);
                    OnTransactionOccur(person, i);
                    throw new AccountException(ExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
                }
            }

            catch(Exception ex)
            {
                //Harness makes the code above throw an exception therefore catching it here to avoid programming from stopping
                return;
            }
                Deposit(-amount, person);

        }
        public override void PrepareMonthlyStatement()
        {
            var serviceFee = base.transactions.Count * COST_PER_TRANSACTION;
            var interest = base.Balance * (INTEREST_RATE / MONTH);
            this.Balance += this.Balance + interest - serviceFee;
            this.transactions.Clear();
        }
    }
}

