using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace katabench
{
    public class kata
    {

        public static int DeadAntCount(string ants)
        {

            if (ants == null || ants == "")
            {
                return 0;
            }

            int a = 0; // Just body part counters and a live ant counter.
            int n = 0;
            int t = 0;
            int ant = 0;

            int x = 1;
            int y = 0;
            int z = 0;

            /* 

               These 3 variables work as follows: 

               X works as a counter to tell me where in the foreach I am.

               Y is a flag that retains the current position of the last A. If an A is found then Y takes the value of X in that position.
               so that in the next letter we can check if (Y + 1 = X), which would mean there's an N right after an A.

               Z is a flag just like Y, but for N. It retains the same functionality, but it makes an N so we can confirm a T after an N.

               With this I can tell when there's a sucession of A -> N -> T, then count a full live ant. 


               */


            foreach (char c in ants)
            {
                x++;

                if (c == 'a')
                {

                    a++;
                    y = x;

                }
                else if (c == 'n')
                {

                    n++;

                    if (y + 1 == x)
                    {
                        z = x;
                    }

                }
                else if (c == 't')
                {

                    t++;

                    if (z + 1 == x)
                    {
                        ant++;
                        y = 0;
                        z = 0;
                    }
                }
            }

            if (a > n && a > t)       // Finds the body part with the largest number and returns that number minus the live ants.
            {                 // If nothing goes through then we have the same number of parts for each, so we return any.
                a = a - ant;
                return a;
            }
            else if (n > a && n > t)
            {
                n = n - ant;
                return n;
            }
            else if (t > a && t > n)
            {
                t = t - ant;
                return t;
            }
            else
            {
                a = a - ant;
                return a;
            }
        }
    }

    public class Kata2
    {
        public static int DeadAntCount(string ants)
        {
            ants = ants?.Replace("ant", "") ?? "";
            return Math.Max(ants.Count(c => c == 'a'), Math.Max(ants.Count(c => c == 'n'), ants.Count(c => c == 't')));
        }
    }

    public class Kata3
    {
        public static int DeadAntCount(string ants)
        {
            int count = 0;
            if (ants == null)
                return count;
            ants = Regex.Replace(ants, "ant", "");
            int[] ant = new[] { ants.Count(a => a == 'a'), ants.Count(a => a == 'n'), ants.Count(a => a == 't') };
            count = ant.Max();
            return count;
        }
    }

    public class Kata4
    {
        public static int DeadAntCount(string ants)
        {
            var req = ants?.Replace("ant", "").Where(char.IsLetter);
            return (req ?? "").Any() ? req.GroupBy(c => c).Max(g => g.Count()) : 0;
        }
    }

    public class Kata5
    {
        public static int DeadAntCount(string ants)
        {

            if (ants == null)
                return 0;

            for (int i = 0; i < ants.Length - 2; i++)
            {
                if (ants.IndexOf("ant", i, 3) != -1)
                {
                    ants = ants.Remove(i, 3);
                    i--;
                }
            }

            int countA = 0;
            int countN = 0;
            int countT = 0;

            for (int i = 0; i < ants.Length; i++)
            {
                switch (ants[i])
                {
                    case 'a':
                        countA++;
                        break;
                    case 'n':
                        countN++;
                        break;
                    case 't':
                        countT++;
                        break;
                }
            }

            return Math.Max(countA, Math.Max(countN, countT));

        }
    }

    public class Kata6
    {
        public static int DeadAntCount(string ants)
        {
            ants = ants?.Replace("ant", "");

            if (string.IsNullOrWhiteSpace(ants))
            {
                return 0;
            }

            var enumerable = ants.Where(x => x.Equals('a') || x.Equals('n') || x.Equals('t'));
            var list = enumerable.ToList();
            if (list.Count == 0)
            {
                return 0;
            }
            return enumerable
                .GroupBy(x => x)
                .Max(g => g.Count());

        }
    }

}
