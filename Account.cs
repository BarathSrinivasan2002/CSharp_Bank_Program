using System;
namespace Accounts
{
    public abstract class Account
    {

        public readonly List<Person> users = new List<Person>();
        public readonly List<Transaction> transactions = new List<Transaction>();
        private static int LAST_NUMBER = 100_000;
        public EventHandler<EventArgs>? OnTransaction { get; set; }
        public string Number { get; protected set; }
        public double Balance { get; protected set; }
        public double LowestBalance { get; protected set; }
        public Account(string type, double balance)
        {
            Number = type + LAST_NUMBER.ToString();
            LAST_NUMBER++;
            Balance = balance;
            LowestBalance = balance;
          
        }
        public virtual void Deposit(double balance, Person person)
        {
            this.Balance = this.Balance + balance;
            this.LowestBalance = this.Balance;
            var transaction = new Transaction(Number, balance, person);
            //TransactionEventArgs e = new TransactionEventArgs(person.Name, balance, true);
            //OnTransactionOccur(person, e);
            transactions.Add(transaction);
        }
        public void AddUser(Person person)
        {
            users.Add(person);
        }
        public bool IsUser(string name)
        {
            foreach (var user in users)
            {
                if (user.Name == name)
                    return true;
            }
            return false;
        }
        public abstract void PrepareMonthlyStatement();
        public virtual void OnTransactionOccur(object? sender, EventArgs args)
        {
            OnTransaction?.Invoke(sender, args);
        }
        public override string ToString()
        {
            string result = Number;
            foreach (var user in users)
            {
                result += " "+user+", ";
            }

            result += ". Balance: $" + Balance.ToString("C");
            result += "- transactions (" + transactions.Count + ")";
            foreach (var trans in transactions)
            {
                result += "\n\t"+trans;
            }
            return result;
        }
    }
}

