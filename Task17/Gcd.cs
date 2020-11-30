using System;
using System.Collections.Generic;
using System.Text;

namespace Task17
{
    static class Gcd
    {
        public delegate int Algorithm(int x, int y);
        public static int EuclideanAlgorithm(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
        public static int BinaryAlgorithm(int a, int b)
        {
            int k = 1;
            while ((a != 0) && (b != 0))
            {
                while ((a % 2 == 0) && (b % 2 == 0))
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }
                while (a % 2 == 0) a /= 2;
                while (b % 2 == 0) b /= 2;
                if (a >= b) a -= b; else b -= a;
            }
            return b * k;
        }
        public static int CalculateGcd(Algorithm a, params int[] arg)
        {
            if (arg.Length < 2)
                return -1;

            int gcd = a(arg[0], arg[1]);
            for (int i = 2; i < arg.Length; i++)
                gcd = a(gcd, arg[i]);
            return gcd;
        }
    }
}
