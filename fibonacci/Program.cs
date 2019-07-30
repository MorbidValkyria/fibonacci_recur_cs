using System;
using System.Collections.Generic;
using System.Numerics;

/// <summary>
/// -------------------------------------------------------------------------------
/// Fibonacci Sequences using recursion and Dictionaries
/// My Algorithm calculates both positive and negative integers
/// 
/// Tested with ranges from -20000 to 20000 that worked
/// 
/// Ranges after -30000 to 30000 gave a stack-overflow exeption so, 
/// around (-20000 to 20000) should be the limit!
/// -------------------------------------------------------------------------------
/// </summary>

namespace fibonacci
{
    class Program
    {
        /*
            Main function (entry point)
        */
        static void Main(string[] args)
        {
            // Created a Dic to store previous results and easy up the computational process
            // (Which in recursion is something important) considering the amount of memory it eats.
            // The key is of type int and the value of type BigInteger which should have no upper
            // or lower bounds in terms of size. 
            Dictionary<int, BigInteger> fibDict = new Dictionary<int, BigInteger>();
            // Stored the fibs of 0 and 1 to serve as a starting point (and so the compiler desn't have to)
            fibDict.Add(0, 0);
            fibDict.Add(1, 1);

            Console.WriteLine(NewFib(20000, fibDict));
        }
        public static BigInteger NewFib(int n, Dictionary<int, BigInteger> fibDict)
        {
            BigInteger ans;
            // Calculates negative integers
            if (n < 0)
            {
                int sign =  n % 2 == 0 ? -1 : 1;
                ans = sign * NewFib(-n, fibDict);
                fibDict.Add(n, ans);
                return ans;
            }
            // If it already has calculated that fib numbers, just returns it
            // instead of doing the calculations all over again
            if (fibDict.ContainsKey(n)) return fibDict[n];

            // Calculates positive integers
            else
            {
                ans = NewFib(n-1, fibDict) + NewFib(n-2, fibDict);
                fibDict.Add(n, ans);
                return ans;
            }
        }
    }
}
