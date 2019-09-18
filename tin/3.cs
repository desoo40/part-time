using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpDev
{
    class Program
    {
        const int minutesInWeek = 10080;
        const int hoursInDay = 24;
        const int minInHour = 60;


        static void Main(string[] args)
        { 
            var inStr = Console.ReadLine();

            var currDayList = inStr.Split(' ').ToList();

            var currInMins = CalcMins(currDayList);

            var reminders = Convert.ToInt32(Console.ReadLine());

            var closerRes = 10081;
            var output = "";

            if (reminders == 1)
            {
                Console.WriteLine(Console.ReadLine());
                return;
            }

            for (int i = 0; i < reminders; i++)
            {
                inStr = Console.ReadLine();

                var tmp = inStr.Split(' ').ToList();
                var tmpInMins = CalcMins(tmp);

                var tmpTimeDistanse = tmp[0] == "0" ? CalcForEveryDay(currDayList, tmp) : CalcTimeDistanse(currInMins, tmpInMins);

                if (tmpTimeDistanse == 0)
                {
                    Console.WriteLine(inStr);
                    return;
                }

                if (tmpTimeDistanse < closerRes)
                {
                    closerRes = tmpTimeDistanse;
                    output = inStr;
                }
            }

            Console.WriteLine(output);
        }

        private static int CalcForEveryDay(List<string> currDayList, List<string> tmp)
        {
            var currHour = Convert.ToInt32(currDayList[1]);
            var currMin = Convert.ToInt32(currDayList[2]);

            var tmpHour = Convert.ToInt32(tmp[1]);
            var tmprMin = Convert.ToInt32(tmp[2]);

            var currInMins = currHour * minInHour + currMin;
            var tmpInMins = currHour * minInHour + currMin;

            if (tmpInMins == currInMins)
                return 0;

            if (tmpInMins > currInMins)
                return tmpInMins - currInMins;

            return hoursInDay * minInHour - currInMins + tmpInMins;
        }

        private static int CalcTimeDistanse(int curr, int tmpInMins)
        {
            if (tmpInMins == curr)
                return 0;

            if (tmpInMins > curr)
                return tmpInMins - curr;

            return minutesInWeek - curr + tmpInMins;
        }

        private static int CalcMins(List<string> currDayList)
        {
            var currDay = Convert.ToInt32(currDayList[0]);
            var currHour = Convert.ToInt32(currDayList[1]);
            var currMin = Convert.ToInt32(currDayList[2]);

            return (currDay - 1) * hoursInDay * minInHour + currHour * minInHour + currMin;

        }
    }
}
