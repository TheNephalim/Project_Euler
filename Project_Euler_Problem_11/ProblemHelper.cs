using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Euler_Problem_11 {
    internal static class ProblemHelper {
        /// <summary>
        /// Process the matrix
        /// </summary>
        /// <param name="path">The file path of the matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="height">The heigh of the matrix</param>
        /// <param name="distance">The length of each sequence to get</param>
        /// <returns>A max product</returns>
        public static long Process(string path, int width, int height, int distance) {
            object[] matrix = Matrices.MatrixHelper.LoadMatrixFromFile(path);
            ArrayList values = NavigateMatrix(matrix, width, height, distance);
            long value = ProcessValues(values);
            return value;
        }

        /// <summary>
        /// Process all of the values retrieved from the matrix.
        /// </summary>
        /// <param name="values">All possible 4 number sequences from grid.</param>
        /// <returns>The maximum product of the values contained in the sequence.</returns>
        private static long ProcessValues(ArrayList values) {
            IList<long> products = new List<long>();

            //  Iterate over all of the sequecnes
            for (int i = 0; i < values.Count; i++) {
                string[] value = (string[])values[i];

                long product = 1;

                //  iterate over all of the values in the sequence and multiply to get the product.
                for (int j = 0; j < value.Length; j++) {
                    product *= Convert.ToInt32(value[j]);
                }

                products.Add(product);
            }

            //  Return the maximum product value from the list.
            return products.Max();
        }

        /// <summary>
        /// <para>
        /// Navigate through the matrix to retrieve all possible number sequences of a particular length.
        /// </para>
        /// <para>
        /// We will iterate right to left, top to bottom. As a result, we only need to go vertically, diagonally to the upper-right and lower-right, and horizontally.
        /// </para>
        /// </summary>
        /// <param name="matrix">The matrix as an object array.</param>
        /// <param name="width">The width of the array</param>
        /// <param name="height">The height of the array.</param>
        /// <param name="distance">The length of the number sequence.</param>
        /// <returns>All possible number sequences.</returns>
        private static ArrayList NavigateMatrix(object[] matrix, int width, int height, int distance) {
            ArrayList values = new ArrayList();

            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    if (CanGoUp(i, distance)) {
                        GetVertical(matrix, values, j, i, distance);

                        if (CanGoUpperRightDiagonal(j, i, distance, width, height)) {
                            GetRightUpperDiagonal(matrix, values, j, i, distance);
                        }
                    }

                    if (CanGoDown(i, height, distance)) {
                        if (CanGoLowerRightDiagonal(j, i, distance, width, height)) {
                            GetRightLowerDiagonal(matrix, values, j, i, distance);
                        }
                    }
                }
            }

            return values;
        }

        /// <summary>
        /// Get all possible diagonal number sequences diagonally (upper-right).  To get the equation it is helpful to this of the matrix as a cartegian plane.  
        /// I used the equation of a line y= mx + b to get the x and y coordinate.  I had to do some adjusting as the line's equation changes as you move through
        /// the plane.
        /// </summary>
        /// <param name="matrix">The matrix as an object array.</param>
        /// <param name="values">The list of values retrieved from the matrix so far.</param>
        /// <param name="currentX">The current X location on the matrix.</param>
        /// <param name="currentY">The current Y location in the matrix.</param>
        /// <param name="distance">The length of the number sequence.</param>
        private static void GetRightUpperDiagonal(object[] matrix, ArrayList values, int currentX, int currentY, int distance) {
            string[] value = new string[distance];

            for (int i = 0; i < distance ; i++) {
                int y = currentY - i;
                int x = ((3 + currentX) - y) + (currentY - distance + 1);

                value[i] = ((string[])matrix[y])[x];
            }

            values.Add(value);
        }

        /// <summary>
        /// Get all possible diagonal number sequences diagonally (lower-right).  To get the equation it is helpful to this of the matrix as a cartegian plane.  
        /// I used the equation of a line y= mx + b to get the x and y coordinate.  I had to do some adjusting as the line's equation changes as you move through
        /// </summary>
        /// <param name="matrix">The matrix as an object array.</param>
        /// <param name="values">The list of values retrieved from the matrix so far.</param>
        /// <param name="currentX">The current X location on the matrix.</param>
        /// <param name="currentY">The current Y location in the matrix.</param>
        /// <param name="distance">The length of the number sequence.</param>
        private static void GetRightLowerDiagonal(object[] matrix, ArrayList values, int currentX, int currentY, int distance) {
            string[] value = new string[distance];


            for (int i = 0; i < distance; i++) {

                int x = (currentX + i);
                int y = x - currentX + currentY;

                if (x <= 20) {
                    value[i] = ((string[])matrix[y])[x];
                }
            }

            values.Add(value);
        }

        /// <summary>
        /// Get the horizonal number sequences as you move through the matrix.
        /// </summary>
        /// <param name="matrix">The matrix as an object array.</param>
        /// <param name="values">The list of values retrieved from the matrix so far.</param>
        /// <param name="currentX">The current X location on the matrix.</param>
        /// <param name="currentY">The current Y location in the matrix.</param>
        /// <param name="distance">The length of the number sequence.</param>
        private static void GetHorizontal(object[] matrix, ArrayList values, int currentX, int currentY, int distance) {
            string[] value = new string[distance];

            for (int i = distance; i > 0; i--) {
                value[distance - i] = ((string[])matrix[currentY])[currentX - i + 1];
            }

            values.Add(value);
        }

        /// <summary>
        /// Get the vertical number sequences as you move through the matrix.
        /// </summary>
        /// <param name="matrix">The matrix as an object array.</param>
        /// <param name="values">The list of values retrieved from the matrix so far.</param>
        /// <param name="currentX">The current X location on the matrix.</param>
        /// <param name="currentY">The current Y location in the matrix.</param>
        /// <param name="distance">The length of the number sequence.</param>
        private static void GetVertical(object[] matrix, ArrayList values, int currentX, int currentY, int distance) {
            string[] value = new string[distance];

            for (int i = distance; i > 0; i--) {
                value[distance - i] = ((string[])matrix[currentY - i + 1])[currentX];
            }

            values.Add(value);
        }

        /// <summary>
        /// Determine if the number sequence you are retrieving will stay within the bounds of the array to the right.
        /// </summary>
        /// <param name="currentX">The current X location in the matrix.</param>
        /// <param name="width">The width of the matrix.</param>
        /// <param name="distance">The length of the number sequence.</param>
        /// <returns>A true-false value indicating whether you can go to the right.</returns>
        private static bool CanGoRight(int currentX, int width, int distance) {
            return ((currentX + distance) <= width);
        }


        /// <summary>
        /// Determine if the number sequence you are retrieving will stay within the bounds of the array vetically.
        /// </summary>
        /// <param name="currentX">The current X location in the matrix.</param>
        /// <param name="width">The width of the matrix.</param>
        /// <param name="distance">The length of the number sequence.</param>
        /// <returns>A true-false value indicating whether you can go to the right.</returns>
        private static bool CanGoUp(int currentY, int distance) {
            return ((currentY - distance + 1) >= 0);
        }

        /// <summary>
        /// Determine if the number sequence you are retrieving will stay within the bounds of the array to the right and to the bottom.
        /// </summary>
        /// <param name="currentX">The current X location in the matrix.</param>
        /// <param name="width">The width of the matrix.</param>
        /// <param name="distance">The length of the number sequence.</param>
        /// <returns>A true-false value indicating whether you can go to the right.</returns>
        private static bool CanGoLowerRightDiagonal(int currentX, int currentY, int distance, int width, int height) {
            return (((currentX + distance) <= width) && (currentY + distance <= height));
        }

        /// <summary>
        /// Determine if the number sequence you are retrieving will stay within the bounds of the array vertically and to the right.
        /// </summary>
        /// <param name="currentX">The current X location in the matrix.</param>
        /// <param name="width">The width of the matrix.</param>
        /// <param name="distance">The length of the number sequence.</param>
        /// <returns>A true-false value indicating whether you can go to the right.</returns>
        private static bool CanGoUpperRightDiagonal(int currentX, int currentY, int distance, int width, int height) {
            return (((currentX + distance) <= width) && ((currentY - distance + 1) >= 0));
        }

        /// <summary>
        /// Determine if the number sequence you are retrieving will stay within the bounds of the array to the bottom.
        /// </summary>
        /// <param name="currentX">The current X location in the matrix.</param>
        /// <param name="width">The width of the matrix.</param>
        /// <param name="distance">The length of the number sequence.</param>
        /// <returns>A true-false value indicating whether you can go to the right.</returns>
        private static bool CanGoDown(int currentY, int height, int distance) {
            return ((currentY + distance) <= (height - distance));
        }
    }
}
