namespace Project_Euler_22 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public static class FileHelper {
        public static string[] GetNames(string path) {
            string[] names = null;

            using (Stream nameStream = new FileStream(path, FileMode.Open)) {
                using (StreamReader nameStreamReader = new StreamReader(nameStream)) {
                    string namesText = nameStreamReader.ReadToEnd();
                    namesText = namesText.Replace("\"", string.Empty);

                    names = namesText.Split(',');
                }
            }

            return names;
        }
    }
}
