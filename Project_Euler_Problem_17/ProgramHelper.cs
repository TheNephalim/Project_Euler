using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Euler_Problem_17 {
    /// <summary>
    /// <para>Came up with the following solution.  However, feel like a total idiot.</para>
    /// <para>
    /// Found this solution, after I solved the problem on Stack overflow.
    /// http://stackoverflow.com/questions/5620571/project-euler-problem-17-python
    /// </para>
    /// <para>Regardless, the solution works, but needs to be refactored.</para>
    /// </summary>
    internal static class ProgramHelper {
        private static readonly string[] ones = new string[] {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"};
        private static readonly string[] teens = new string[] { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static readonly string[] tens = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        public static int Process() {
            int count = 0;

            count += ProcessOnes();
            count += ProcessTeens();
            count += ProcessTens();
            count += ProcessHundreds();
            count += ProcessThousands();

            return count;
        }

        private static int ProcessOnes() {
            int count = 0;
            string counting = string.Empty;

            for(int i = 0; i < 10; i++) {
                counting += ones[i];
            }

            count = counting.Length;

            return count;
        }

        private static int ProcessTeens() {
            int count = 0;
            string counting = string.Empty;

            for (int i = 0; i < 9; i++) {
                counting += teens[i];
            }

            count = counting.Length;

            return count;
        }

        private static int ProcessTens() {
            int count = 0;
            int tensIndex = 0;
            string counting = string.Empty;

            for (int i = 20; i < 100; i++) {
                if (IsAMultipleOfTen(i)) {
                    tensIndex = (i / 10) - 2;
                    counting += tens[tensIndex];
                } else {
                    int onesIndex =  (i % 10) - 1;
                    string number = string.Format("{0}{1}", tens[tensIndex], ones[onesIndex]);
                    counting += number;
                }
            }

            count = counting.Length;

            return count;
        }

        private static int ProcessHundreds() {
            int count = 0;
            int tensIndex = 0;
            string remainderNumber = string.Empty;
            string counting = string.Empty;

            for (int i = 100; i <= 999; i++) {
                if (IsAMultipleOfHundred(i)) {
                    int onesIndex = (i / 100) - 1;
                    counting += string.Format("{0}hundred", ones[onesIndex]);
                } else {
                    int hundreds = (i - (i % 100));
                    int hundredsIndex = (hundreds / 100) - 1;
                    int remainder = (i % 100);

                    if (remainder <= 10) {
                        remainderNumber = GetOnesNumber(remainder);
                    } else if (remainder > 10 && remainder < 20) {
                        remainderNumber = GetTeensNumber(remainder);
                    } else {
                        remainderNumber = GetTensNumber(remainder);
                    }

                    counting += string.Format("{0}hundredand{1}", ones[hundredsIndex], remainderNumber);
                }
            }

            return counting.Length;
        }

        private static string GetTeensNumber(int remainder) {
            int teensIndex = (remainder % 10) - 1;
            return teens[teensIndex];
        }

        private static string GetOnesNumber(int remainder) {
            int onesIndex = remainder - 1;
            return ones[onesIndex];
        }

        private static int ProcessThousands() {
            return "onethousand".Length;
        }

        private static bool IsAMultipleOfTen(int i) {
            return ((i % 10) == 0);
        }

        private static bool IsAMultipleOfHundred(int i) {
            return ((i % 100) == 0);
        }

        private static string GetTensNumber(int i) {
            int tensIndex = 0;
            string counting = string.Empty;

            if (IsAMultipleOfTen(i)) {
                tensIndex = (i / 10) - 2;
                counting += tens[tensIndex];
            } else {
                int onesIndex = (i % 10) - 1;
                tensIndex = (i / 10) - 2;
                string number = string.Format("{0}{1}", tens[tensIndex], ones[onesIndex]);
                counting += number;
            }

            return counting;
        }
    }
}
