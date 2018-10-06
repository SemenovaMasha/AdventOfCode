using System;
using System.IO;
using System.Linq;

namespace Day_10.Knot_Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] inputStrings = File.ReadAllLines("input.txt")[0].Replace(" ", "").Split(',');
            //int[] input = new int[inputStrings.Length];
            //for (int i = 0; i < input.Length; i++)
            //    input[i] = Convert.ToInt32(inputStrings[i]);

            //int[] circle = new int[n];
            //for (int i = 0; i < circle.Length; i++)
            //    circle[i] = i;

            //int currentPosition = 0;
            //int skipSize = 0;

            //for (int k = 0; k < input.Length; k++)
            //{
            //    reverseSubarray(circle, currentPosition, input[k]);

            //    currentPosition += input[k] + skipSize;
            //    while (currentPosition >= circle.Length)
            //        currentPosition -= circle.Length;
            //    skipSize++;
            //}

            //print(circle);
            //Console.WriteLine(circle[0]*circle[1]);

            int[] circle = new int[n];
            for (int i = 0; i < circle.Length; i++)
                circle[i] = i;

            string input = File.ReadAllLines("input.txt")[0].TrimEnd(' ');

            int[] lenghts = new int[input.Length+5];
            for(int i = 0; i < input.Length; i++)
            {
                lenghts[i] = (int)input[i];
            }
            lenghts[input.Length + 0] = 17;
            lenghts[input.Length + 1] = 31;
            lenghts[input.Length + 2] = 73;
            lenghts[input.Length + 3] = 47;
            lenghts[input.Length + 4] = 23;

            print(lenghts);

            int currentPosition = 0;
            int skipSize = 0;

            for (int round = 0; round < 64; round++)
            {
                for (int k = 0; k < lenghts.Length; k++)
                {
                    reverseSubarray(circle, currentPosition, lenghts[k]);

                    currentPosition += lenghts[k] + skipSize;
                    while (currentPosition >= circle.Length)
                        currentPosition -= circle.Length;
                    skipSize++;
                }

            }

            print(circle);

            string hash = "";
            for (int i = 0; i < 16; i++)
            {
                int xor = 0;
                for (int j = i * 16; j < (i + 1) * 16; j++)
                {
                    xor ^= circle[j];
                }
                //hash += String.Format("0x{0:X}", xor)+" ";
                hash += xor.ToString("x2") ;
            }

            Console.WriteLine(hash.ToLower());
            Console.ReadKey();
        }

        static int n = 256;
        static void print(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
        }

        static void reverseSubarray(int[] a, int startIndex, int lenght)
        {
            int[] oldArray = new int[lenght];
            int nextIndex = startIndex;
            for(int i = 0; i < lenght; i++)
            {
                oldArray[i] = a[nextIndex];
                nextIndex = nextIndex == a.Length - 1 ? 0 : nextIndex + 1;
            }
            nextIndex = startIndex;
            
            for (int i = 0; i < lenght; i++)
            {
                a[nextIndex] = oldArray[lenght - i - 1];
                nextIndex = nextIndex == a.Length - 1 ? 0 : nextIndex + 1;
            }
        }
    }
}