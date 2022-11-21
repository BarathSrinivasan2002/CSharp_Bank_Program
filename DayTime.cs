using System;
namespace Accounts
{
    public struct DayTime
    {
        private long minutes;

        public DayTime(long minute)
        {
            minutes = minute;
        }
        public static DayTime operator +(DayTime lhs, int minute)
        {
            long minutes = minute;
            DayTime newTime = new DayTime(lhs.minutes + minutes);
            return newTime;
        }
        public override string ToString()
        {
            int mins = (int)minutes;
            int years = 0;
            int months = 0;
            int day = 0;
            int hours = 0;

            years = mins / 518000;
            mins = mins % 518000;
            months = mins / 43000;
            mins = mins % 43000;
            day = mins/1440;
            mins = mins% 1440;
            hours = mins/60;
            mins = mins % 60;

            return years + "-" + months + "-" + day +" "+ hours+":"+mins;

        }

    }
}

