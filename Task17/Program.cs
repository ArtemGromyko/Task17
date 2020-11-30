using System;
using System.Diagnostics;
using System.Threading;

namespace Task17
{
    class Program
    {
        private static Stopwatch sw = new Stopwatch();
        public static void FirstThread()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is executing Gcd.CalculateGcd(Gcd.BinaryAlgorithm, 4, 16, 16, 8)");
            sw.Start();
            int x = Gcd.CalculateGcd(Gcd.BinaryAlgorithm, 4, 16, 16, 8);
            sw.Stop();
            sw.Reset();
            Console.WriteLine("x = " + x);
            Console.WriteLine(sw.Elapsed);
        }
        public static void SecondThread()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is executing Gcd.CalculateGcd(Gcd.EuclideanAlgorithm, 4, 16, 16, 8)");
            sw.Start();
            int y = Gcd.CalculateGcd(Gcd.EuclideanAlgorithm, 4, 16, 16, 8);
            sw.Stop();
            sw.Reset();
            Console.WriteLine("y = " + y);
            Console.WriteLine(sw.Elapsed);
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(FirstThread);
            Thread t2 = new Thread(SecondThread);
            t1.Start();
            t1.Join();
            t2.Start();
            t2.Join();
        }
    }
}
