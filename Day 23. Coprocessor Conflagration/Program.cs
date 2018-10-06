using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_23.Coprocessor_Conflagration
{
    class Program
    {
        void f()
        //static void Main(string[] args)
        {
            string[] stringComs = File.ReadAllLines("../../input.txt");

            long nextCom1 = 0;

            Dictionary<char, long> vars1 = new Dictionary<char, long>();
            
            for(char c = 'a'; c <= 'h'; c++)
            {
                vars1.Add(c, 0);
            }
            vars1['a'] = 1;

            int steps = 0;
            int mulCount = 0;
            while (nextCom1 >= 0 && nextCom1 < stringComs.Length)
            {
                Console.WriteLine("Command: " + stringComs[nextCom1]);

                steps++;
                string[] arg1 = stringComs[nextCom1].Split(' ');

                char X1 = char.Parse(arg1[1]);
                if (!vars1.ContainsKey(X1))
                {
                    vars1.Add(X1, 0);
                    if (X1 == '1')
                        vars1['1'] = 1;
                }

                long Y1 = 0;
                if (arg1.Length > 2)
                {
                    try
                    {
                        Y1 = int.Parse(arg1[2]);
                    }
                    catch (Exception exx)
                    {
                        char tmp = char.Parse(arg1[2]);

                        if (!vars1.ContainsKey(tmp))
                            vars1.Add(tmp, 0);
                        Y1 = vars1[tmp];
                    }
                }
                nextCom1++;

                switch (arg1[0])
                {
                    case "set":
                        vars1[X1] = Y1;
                        break;

                    case "sub":
                        vars1[X1] -= Y1;
                        break;

                    case "mul":
                        vars1[X1] *= Y1;
                        mulCount++;
                        break;

                    case "jnz":
                        if (vars1[X1] != 0)
                        {
                            nextCom1--;
                            nextCom1 += Y1;
                        }
                        break;
                }
                print(vars1);

                if (steps % 100000 == 0)
                {
                    Console.WriteLine("steps: " + steps);
                    Console.WriteLine("h = " + vars1['h']);
                }
            }
            Console.WriteLine(mulCount);
        }
        static void print(Dictionary<char, long> d)
        {
            foreach (var pair in d)
            {
                Console.Write(pair.Key + "=" + pair.Value + " ");
            }
            Console.WriteLine();
        }
    }

}
