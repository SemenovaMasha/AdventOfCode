using System;
using System.IO;
using System.Linq;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rows = File.ReadAllLines("input.txt");
            int next = 2;

            int n = 12;
            int[,] array = new int[n,n];
            int div = n / 2;
            array[div, div] = 1;

            int sq = 2;

            int max= 500000;
            try
            {
                while (true)
                {
                    //up
                    for (int k = 0; k < sq; k++)
                    {
                        int sum = getSumAdj(array, n, div - k + sq / 2 - 1, div + sq / 2);
                        if (sum >= max) goto label;
                        array[div  - k + sq / 2 - 1, div  + sq / 2] = sum;
                    }
                    //left
                    for (int k = 0; k < sq; k++)
                    {
                        int sum = getSumAdj(array, n, div - sq / 2, div + sq / 2 - k - 1);
                        if (sum >= max) goto label;
                        array[div  - sq / 2, div  + sq / 2 - k - 1] = sum;
                    }
                    //down
                    for (int k = 0; k < sq; k++)
                    {
                        int sum = getSumAdj(array, n, div + k - sq / 2 + 1, div - sq / 2);
                        if (sum >= max) goto label;
                        array[div  + k - sq / 2 + 1, div - sq / 2] = sum;
                    }
                    //right
                    for (int k = 0; k < sq; k++)
                    {
                        int sum = getSumAdj(array, n, div + sq / 2, div - sq / 2 + k + 1);
                        if (sum >= max) goto label;
                        array[div  + sq / 2, div - sq / 2 + k + 1] = sum;
                    }
                    print(array, n);

                    sq += 2;
                }
                label: {

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            print(array, n);
            Console.ReadKey();
        }

        static void print(int[,] array, int n)
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write((array[i, j] + " ").PadLeft(8));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static int getSumAdj(int[,] array, int n,int i,int j)
        {
            return array[i - 1, j - 1] + array[i - 1, j] + array[i - 1, j + 1] + array[i, j + 1] + array[i + 1, j + 1] + array[i + 1, j] + array[i + 1, j - 1] + array[i , j - 1];
        }
    }
}