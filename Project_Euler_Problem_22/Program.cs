namespace Project_Euler_22 {
    using System;
    using System.Diagnostics;

    public class Program {
        public static void Main(string[] args) {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = NameProcessor.Process("names.txt");
            stopWatch.Stop();
            
            Console.WriteLine(result);
            Console.WriteLine(stopWatch.ElapsedMilliseconds);
        }
    }
}
