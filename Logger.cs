using System;
namespace Accounts
{
    public static class Logger
    {
        public static List<string> loginEvents = new List<string>();
        public static List<string> transactionEvents = new List<string>();

        public static void LoginHandler(object? sender, EventArgs args)
        {
            LoginEventArgs? newArg = args as LoginEventArgs;
            if (newArg != null)
            {
                string LoginResult;
                if (newArg.Success)
                {
                    LoginResult = " logged in succesfully on ";
                }
                else
                {
                    LoginResult = " failed to login on ";
                }
                string LoginDetails = newArg.PersonName +LoginResult+Utils.Now;
                loginEvents.Add(LoginDetails);
            }
        }

        public static void TransactionHandler(object sender, EventArgs args)
        {
            TransactionEventArgs? newArg = args as TransactionEventArgs;
            if (newArg != null)
            {
                string Success;
                if (newArg.Success)
                {
                    Success = " successfully ";
                }
                else {

                    Success = " unsuccessfully ";
                }

                string TransType;
                if (newArg.Amount<0)
                {
                    TransType = " withdrew ";
                }
                else
                {

                    TransType = " deposited ";
                }

                string TransactionDetails = newArg.PersonName+TransType+Math.Abs(newArg.Amount).ToString("C")+Success+"on " + Utils.Now;
                transactionEvents.Add(TransactionDetails);
            }
        }

        public static void ShowLoginEvents()
        {
            Console.WriteLine("\nCurrent Time: "+Utils.Now);
            for (int i = 0; i < loginEvents.Count; i++) {
                Console.WriteLine((i+1)+". "+loginEvents[i]);
            }
        }

        public static void ShowTransactionEvents()
        {
            Console.WriteLine("\nCurrent Time: " + Utils.Now);
            for (int i = 0; i < transactionEvents.Count; i++)
            {
                Console.WriteLine((i+1) + ". " + transactionEvents[i]);
            }
        }
    }
}

