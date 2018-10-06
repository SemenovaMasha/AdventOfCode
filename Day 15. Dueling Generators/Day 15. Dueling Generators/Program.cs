using System;

namespace Day_15.Dueling_Generators
{
    class Program
    {
        static void Main(string[] args)
        {
            long factorA = 16807;
            long factorB = 48271;

            long divider = 2147483647;

            long startA = 634;
            long startB = 301;

            int sum = 0;

            for (int i = 0; i < 5000000; i++)
            {
                startA = startA * factorA % divider;
                while (startA%4!=0)
                startA = startA * factorA % divider;

                startB = startB * factorB % divider;
                while (startB%8!=0)
                startB = startB * factorB % divider;

                //Console.WriteLine(startA + " " + startB);
                //Console.WriteLine(Convert.ToString(startA, 2).PadLeft(32, '0'));

                if (Convert.ToString(startA, 2).PadLeft(32, '0').Substring(16, 16).Equals(Convert.ToString(startB, 2).PadLeft(32, '0').Substring(16, 16)))
                {
                    sum++;

                    //Console.WriteLine(startA + " " + startB);
                    //Console.WriteLine(Convert.ToString(startA, 2).PadLeft(32, '0')+" "+ Convert.ToString(startB, 2).PadLeft(32, '0'));
                    //Console.WriteLine(i);
                }

                if (i % 1000000 == 0)
                    Console.WriteLine(i);

            }
            Console.WriteLine(sum);
        }
    }
}