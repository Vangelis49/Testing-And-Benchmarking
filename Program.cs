﻿using System;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestVersion_1 testVersion_1 = new TestVersion_1();
            Benchmark benchmark = new Benchmark();

            Console.WriteLine("\nInput for First Version: \n");
            testVersion_1.Test_V_1();

            Console.WriteLine("\nInput for Second Version: \n");
            testVersion_1.Test_V_2();

            Console.WriteLine("\nInput for Third Version: \n");
            testVersion_1.Test_V_3();

            
            Console.WriteLine("\nTesting of Route and Time Silmilarity generated by All three Versions:\n");
            testVersion_1.ComparePaths();
            testVersion_1.CompareTime();

            Console.WriteLine("\nCalculation of Total Run Time of all the Three Versions (Benchmarking):\n");
            benchmark.RunTest();
            benchmark.OutputResults();
        }
    }
}
