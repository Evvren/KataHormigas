using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Security.Cryptography;


namespace katabench
{
    public class BenchmarkHormiga
    {
        string ants = "...ant...ant..nat.ant.t..ant...ant..ant..ant.anant..t";

        [Benchmark]
        public int Counter()
        {
            return kata.DeadAntCount(ants);
        }

        [Benchmark]
        public int Counter2()
        {
            return Kata2.DeadAntCount(ants);
        }


        [Benchmark]
        public int Counter3()
        {
            return Kata3.DeadAntCount(ants);
        }

        [Benchmark]
        public int Counter4()
        {
            return Kata4.DeadAntCount(ants);
        }

        [Benchmark]
        public int Counter5()
        {
            return Kata5.DeadAntCount(ants);
        }

        [Benchmark]
        public int Counter6()
        {
            return Kata6.DeadAntCount(ants);
        }



        public class Program
        {
            public static void Main(string[] args)
            {
                var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
            }
        }
    }
}