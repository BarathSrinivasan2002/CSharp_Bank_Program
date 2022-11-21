using System;
namespace Accounts
{
    public class TransactionEventArgs : LoginEventArgs
    {
        public double Amount { get; }

        public TransactionEventArgs(string personName, double amount, bool success) : base(personName, success)
        {
            Amount = amount;

        }
    }
}

