namespace Matrices {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class MatrixHelper {
        public static object[] LoadMatrixFromFile(string path) {
            return GetMatrix(path);
        }

        public static object[] GetMatrix(string path) {
            ArrayList matrixList = new ArrayList();

            ProcessFile(path, matrixList);

            object[] matrixArray = matrixList.ToArray();

            return matrixArray;
        }

        private static void ProcessFile(string path, ArrayList matrixList) {
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                using (StreamReader reader = new StreamReader(stream)) {
                    while (!reader.EndOfStream) {
                        string[] matrixLine = reader.ReadLine().Split(' ');
                        matrixList.Add(matrixLine);
                    }
                }
            }
        }

    }
}
