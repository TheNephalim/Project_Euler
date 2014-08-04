using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Euler_Problem_19 {
    internal class ProgramHelper {
        public static int Process(int dayOfMonth, int beginningYear, int endingYear) {
            int counts = GetNumberOfDaysOnADayOfMonth(dayOfMonth, beginningYear, endingYear);
            return counts;
        }

        public static int GetNumberOfDaysOnADayOfMonth(int dayOfMonth, int beginningYear, int endingYear) {
            int firstOfMonthCounter = 0;

            for (int year = beginningYear; year <= endingYear; year++) {
                for (int month = 1; month <= 12; month++) {
                    int dayOfWeek = GaussianAlgorithm(1, month, year);

                    if (dayOfWeek.Equals(0)) {
                        firstOfMonthCounter++;
                    }
                }
            }

            return firstOfMonthCounter;
        }

        /// <summary>
        ///  Y: year-1 for  January or February, 
        ///year   for  the rest of the year
        ///d: day (1 to 31)
        ///m: shifted month (March=1,...February=12), i.e. ((month + 9)% 12) + 1     
        ///y: last 2 digits of Y
        ///c: first 2 digits of Y
        ///w: day of week (0=Sunday,..6=Saturday)
        /// </summary>
        /// <returns>Day of week (0 = Sunday, 1 = Monday...6 = Saturday).</returns>
        private static int GaussianAlgorithm(int day, int month, int year) {
            if (month.Equals(1) || month.Equals(2)) {
                year = year - 1;
            }

            int dayOfWeek = 0;
            int shiftedMonth = GetShiftedMonth(month);
            double yearLastTwo = Convert.ToDouble(year.ToString().Substring(2,2));
            double yearFirstTwo = Convert.ToDouble(year.ToString().Substring(0,2));

            dayOfWeek = Convert.ToInt32(Math.Abs((day + Math.Floor((2.6 * shiftedMonth) - 0.2) + yearLastTwo + Math.Floor(yearLastTwo / 4) + Math.Floor(yearFirstTwo / 4) - (2 * yearFirstTwo))) % 7);

            return dayOfWeek;
        }

        private static int GetShiftedMonth(int month) {
            return ((month + 9) % 12) + 1;
        }
    }
}
