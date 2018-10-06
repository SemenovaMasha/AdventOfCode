using System;
using System.Collections.Generic;

namespace Day_17.Spinlock
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsNum = 329;

            int[] values = new int[50000002];

            int currentPos = 0;
            for(int i = 1; i < 50000001; i++)
            {
                //print(values);
                for (int step=0;step<stepsNum;step++)
                {
                    currentPos++;
                    if (currentPos == i) currentPos = 0;
                }
                if (currentPos == 0)
                    Console.WriteLine("currentposition: "+currentPos+" i: "+i);

                currentPos++;

                //for(int k = i+1; k > currentPos; k--)
                //{
                //    values[k] = values[k - 1];
                //}
                //values[currentPos] = i;

                if (i % 10000000 == 0)
                    Console.WriteLine(i);

            }


            //print(values);

            
            Console.WriteLine("df");
        }

        static void print(int[] a)
        {
            for (int i = 0; i <30; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
        }
    }
}