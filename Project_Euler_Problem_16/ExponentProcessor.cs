using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Project_Euler_Problem_16 {
    internal class ExponentProcessor {
        internal static int Process(int baseNumber, int originalPower) {
            int sum = 0;
            BigInteger answerInt = PowerOfBase(baseNumber, originalPower);
            char[] charInt = answerInt.ToString().ToCharArray();

            foreach(char number in charInt) {
                sum = sum + Convert.ToInt32(number.ToString());
            }


            return sum;
        }

        internal static BigInteger PowerOfBase(int baseNumber, int originalPower) {
            BigInteger answer = 1;
            BigInteger accumulatedPower = baseNumber;
            int remainingMultiplicity = originalPower;

            while (remainingMultiplicity > 0) {
                if ((remainingMultiplicity % 2) != 0) {
                    answer = answer * accumulatedPower;
                    remainingMultiplicity--;
                } else {
                    while ((remainingMultiplicity % 2) == 0) {
                        remainingMultiplicity = (remainingMultiplicity / 2);
                        accumulatedPower = (accumulatedPower * accumulatedPower);
                    }
                }
            }

            return answer;
        }
    }
}
