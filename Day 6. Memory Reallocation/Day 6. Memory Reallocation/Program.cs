using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_6.Memory_Reallocation
{
    class Program
    {
        static void Main(string[] args)
        {
            string row = File.ReadAllText("input.txt");
            int sum = 0;

            List<string> history = new List<string>();            

            string [] bankS =row.Split(new char[] { ' ', '\t' }).Where(str => str != "" && str != null && str != " " && str.Length != 0).ToArray();

            int[] bank = new int[bankS.Length];

            for (int i = 0; i < bankS.Length; i++)
            {
                bank[i] = Convert.ToInt32(bankS[i]);
            }
            Console.WriteLine(getString(bank));
            while (true)
            {
                if (history.Contains(getString(bank)))
                    break;
                history.Add(getString(bank));

                int maxBank = 0;
                for (int i = 1; i < bank.Length; i++)
                {
                    if (bank[i] > bank[maxBank])
                        maxBank = i;
                }

                int nextBank = maxBank == bank.Length - 1 ? 0 : maxBank + 1;
                int leftToReallocate = bank[maxBank];
                bank[maxBank] = 0;

                while (leftToReallocate > 0)
                {
                    bank[nextBank]++;
                    nextBank = nextBank == bank.Length - 1 ? 0 : nextBank + 1;
                    leftToReallocate--;
                }

                sum++;


            }            Console.WriteLine(getString(bank));

            Console.WriteLine(sum);
            Console.ReadKey();
        }

        static string getString(int[] a)
        {
            string s = "";
            for (int i = 0; i < a.Length; i++)
                s += a[i] + " ";
            return s;
        }
    }
}