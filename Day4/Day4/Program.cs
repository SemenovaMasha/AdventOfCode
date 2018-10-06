using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rows = File.ReadAllLines("input.txt");
            int sum = 0;

            for (int i = 0; i < rows.Length; i++)
            {
                string[] values = rows[i].Split(new char[] { ' ', '\t' }).Where(str => str != "" && str != null && str != " " && str.Length != 0).ToArray();
                
                bool valid = true;
                for (int j = 0; j < values.Length; j++)
                {
                    bool hasAnagram = false;
                    for(int comp=0;comp < values.Length; comp++)
                    {
                        if (comp != j)
                        {
                            if (areAnagrams(values[j], values[comp])){
                                hasAnagram = true;
                                break;
                            }
                        }
                    }
                    if (hasAnagram)
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid) sum++;
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }
        static bool areAnagrams(string s1, string s2)
        {
            char[] chars1 = s1.ToCharArray();
            char[] chars2 = s2.ToCharArray();

            bool equal = chars1.Except(chars2).Count() == 0 && chars2.Except(chars1).Count() == 0;

            return equal;
        }
    }

}