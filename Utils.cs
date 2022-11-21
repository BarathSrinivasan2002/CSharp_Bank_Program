using System;
namespace Accounts
{
    public static class Utils
    {
        static DayTime _time = new DayTime(1_048_000_000);
        static Random random = new Random();
        public static DayTime Time
        {
            get => _time += random.Next(1000);
        }
        public static DayTime Now
        {
            get => _time += 0;
        }

        public readonly static Dictionary<AccountType, string> ACCOUNT_TYPES =
            new Dictionary<AccountType, string>
        {
        { AccountType.Checking , "CK" },
        { AccountType.Saving , "SV" },
        { AccountType.Visa , "VS" }
        };

    }

}

