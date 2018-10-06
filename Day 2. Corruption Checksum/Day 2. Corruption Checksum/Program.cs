using System;
using System.IO;
using System.Linq;

namespace Day_2.Corruption_Checksum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rows = File.ReadAllLines("input.txt");
            int sum = 0;
            for (int i = 0; i < rows.Length; i++)
            {
                string[] values = rows[i].Split(new char[] { ' ','\t' }).Where(str => str != "" && str != null && str != " " && str.Length != 0).ToArray();
                
                for (int j = 0; j < values.Length; j++)
                {
                    int number = Convert.ToInt32(values[j]);
                    for(int l=0;l < values.Length; l++)
                    {
                        if (l != j)
                        {
                            int d = Convert.ToInt32(values[l]);
                            if (number % d == 0)
                            {
                                sum += number/d;
                                goto alabel;
                            }

                        }
                    }
                }
                alabel:
                { }
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}