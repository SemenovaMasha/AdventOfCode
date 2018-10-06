using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_14.Disk_Defragmentation
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = File.ReadAllLines("input.txt")[0].TrimEnd(' ');

            string squares = "";
            for (int i = 0; i < 128; i++)
            {

                squares += HexStringToBinary(hash(input + "-" + i));

                squares += "\r\n";

            }
            //Console.WriteLine(squares);
            Console.WriteLine(squares.Where(c=>c=='1').Count());

            int[,] squa = new int[128, 128];
            squares.Replace("\r", "");
            string[] rows = squares.Split('\n');
            for(int i = 0; i <128; i++)
            {
                for(int j = 0; j < 128; j++)
                {
                    squa[i, j] = Convert.ToInt32(rows[i][j]+"")==1?-1:0;
                }
            }

            int nextRegion = 1;
            for(int i = 0; i < 128; i++)
            {
                for(int j = 0; j < 128; j++)
                {
                    if (squa[i, j] == -1)
                    {
                        fillRegion(squa, i, j, nextRegion);
                        nextRegion++;
                    }
                }
            }

            print(squa);

            Console.WriteLine(nextRegion-1);


            Console.ReadKey();
        }

        static void fillRegion(int [,]a,int i,int j,int regionNumber)
        {
            a[i, j] = regionNumber;
            if (i > 0 && a[i - 1, j] == -1)
            {
                fillRegion(a, i - 1, j, regionNumber);
            }
            if(i<127&&a[i+1,j]==-1)
                fillRegion(a, i + 1, j, regionNumber);

            if (j > 0 && a[i, j - 1] == -1)
            {
                fillRegion(a, i , j- 1, regionNumber);
            }

            if (j < 127 && a[i , j+ 1] == -1)
                fillRegion(a, i , j+ 1, regionNumber);

        }


        static int n = 256;
        static void print(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
        }
        static void print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        console.write(a[i, j] + " ");
            //    }
            //    console.writeline();
            //}
            Console.WriteLine();
        }

        static void reverseSubarray(int[] a, int startIndex, int lenght)
        {
            int[] oldArray = new int[lenght];
            int nextIndex = startIndex;
            for (int i = 0; i < lenght; i++)
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
        static string hash(string input)
        {
            int[] circle = new int[n];
            for (int i = 0; i < circle.Length; i++)
                circle[i] = i;

            int[] lenghts = new int[input.Length + 5];
            for (int i = 0; i < input.Length; i++)
            {
                lenghts[i] = (int)input[i];
            }
            lenghts[input.Length + 0] = 17;
            lenghts[input.Length + 1] = 31;
            lenghts[input.Length + 2] = 73;
            lenghts[input.Length + 3] = 47;
            lenghts[input.Length + 4] = 23;

            //print(lenghts);

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

            //print(circle);

            string hash = "";
            for (int i = 0; i < 16; i++)
            {
                int xor = 0;
                for (int j = i * 16; j < (i + 1) * 16; j++)
                {
                    xor ^= circle[j];
                }
                //hash += String.Format("0x{0:X}", xor)+" ";
                //hash += Convert.ToString(xor, 2).PadLeft(4, '0') + " ";
                hash += xor.ToString("x2");
            }
            return hash;
        }

        private static readonly Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string> {
    { '0', "0000" },
    { '1', "0001" },
    { '2', "0010" },
    { '3', "0011" },
    { '4', "0100" },
    { '5', "0101" },
    { '6', "0110" },
    { '7', "0111" },
    { '8', "1000" },
    { '9', "1001" },
    { 'a', "1010" },
    { 'b', "1011" },
    { 'c', "1100" },
    { 'd', "1101" },
    { 'e', "1110" },
    { 'f', "1111" }
};

        public static string HexStringToBinary(string hex)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in hex)
            {
                result.Append(hexCharacterToBinary[char.ToLower(c)]);
            }
            return result.ToString();
        }
    }
}