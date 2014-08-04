namespace Project_Euler_Problem_18 {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    internal class ProblemHelper {
        public static long Process(string path) {
            object[] pyramid = GetPyramid(path);
            IList<int> maxPath = GetPath(pyramid);
            int sum = maxPath.Sum();
            return 0;
        }

        private static object[] GetPyramid(string path) {
            ArrayList pyramid = new ArrayList();


            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read)){
                using (StreamReader reader = new StreamReader(stream)) {
                    while (!reader.EndOfStream) {
                        pyramid.Add(reader.ReadLine().Split(' '));
                    }
                }
            }

            object[] pyramidArray = pyramid.ToArray();
            return pyramidArray;
        }

        private static IList<int> GetPath(object[] pyramid) {
            int currentIndex = 0;
            int maxSum = 0;

            IList<int> currentPath = new List<int>();
            object[] row = (object[])pyramid[pyramid.Length - 1];
            object[] previousRow = null;

            for (int i = pyramid.Length - 2; i >= 0; i--) {
                //previousRow = row;
                //row = (object[])pyramid[i];
                //int currentMaxSum = maxSum;

                for (int j = 0; j < ((object[])pyramid[i]).Length; j++) {
                    ((object[])pyramid[i])[j] = Convert.ToDecimal(((object[])pyramid[i])[j]) + Math.Max(Convert.ToDecimal(((object[])pyramid[i+ 1])[j]), Convert.ToDecimal(((object[])pyramid[i + 1])[j + 1]));
                }

            }


            return currentPath;
        }
    }
}
