using System;
namespace Accounts
{
    public struct Transaction
    {
        public string AccountNumber { get; }
        public double Amount { get; }
        public Person Originator { get; }
        public DayTime Time { get; }

        public Transaction(string accountNumber, double amount, Person person)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = Utils.Time;
        }
        public override string ToString()
        {
            double amount = Math.Abs(Amount);
            string Type = " deposited ";
            if (Amount < 0)
            {
                Type = " withdrawn ";
            }
            return AccountNumber +" "+amount.ToString("C")+Type+"by " + Originator.Name + " on " + Time;
        }

    }
}

