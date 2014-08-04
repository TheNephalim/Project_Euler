namespace Project_Euler_Problem_05 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class ProblemHelper {
        public static long Process() {
            IList<long> value = GetValue();

            return value[0];
        }

        private static IList<long> GetValue() {
            int counter = 1;
            IList<long> values = new List<long>();

            while (true) {
                bool allFactors = true;
                for (int i = 1; i <= 20; ++i) {
                    if ((counter % i) != 0) {
                        allFactors = false;
                        break;
                    }
                }

                if (allFactors) {
                    values.Add(counter);
                    break;
                }

                counter++;
            }

            return values;
        }
    }
}
