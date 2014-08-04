// -----------------------------------------------------------------------
// <copyright file="ProblemHelper.cs" company="b">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Project_Euler_Problem_09 {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    internal class ProblemHelper {
        public static long Process() {
            int[,] value = GetBaseTriples();
            long product = GetProduct(value);

            return product;
        }

        private static long GetProduct(int[,] triple) {
            int a = triple[0, 0];
            int b = triple[0, 1];
            int c = triple[0, 2];

            return (a * b * c);
        }


        /// <summary>
        /// This operate on the following
        /// m > n;
        /// a = n^2 - m^2
        /// b = 2nm
        /// c = n^2 + m^2
        /// </summary>
        /// <returns></returns>
        private static int[,] GetBaseTriples() {
            ArrayList baseTriples = new ArrayList();
            int[,] value = new int[1,3];

            for (int n = 1; n < 1000; ++n) {
                for (int m = 2; m < 1000; ++m) {
                    int a = (int)Math.Pow(m, 2) - (int)Math.Pow(n, 2);
                    int b = 2 * m * n;
                    int c = (int)Math.Pow(n, 2) + (int)Math.Pow(m, 2);

                    if ((a + b + c).Equals(1000)) {
                        value[0, 0] = a;
                        value[0, 1] = b;
                        value[0, 2] = c;
                        return value;
                    }
                }
            }

            return new int[1,3] {{0,0,0}};
        }
    }
}
