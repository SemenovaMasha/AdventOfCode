using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_23.Coprocessor_Conflagration
{
    class Part2
    {
        void f()
        //static void Main(string[] args)
        {

            Dictionary<char, long> vars1 = new Dictionary<char, long>();

            for (char c = 'a'; c <= 'h'; c++)
            {
                vars1.Add(c, 0);
            }
            vars1['a'] = 1;
            vars1['b'] = 81;
            vars1['c'] = vars1['b'];
            vars1['b'] *= 100;
            vars1['b'] += 100000;
            vars1['c'] = vars1['b'];
            vars1['c'] += 17000;

            while (true)
            {
                vars1['f'] = 1;
                vars1['d'] = 2;
                //vars1['d'] = 108090;

                do
                {
                    vars1['e'] = 2;

                //print(vars1);
                    do
                    {
                        vars1['g'] = vars1['d'];
                        vars1['g'] *= vars1['e'];
                        vars1['g'] -= vars1['b'];
                        if (vars1['g'] == 0)
                        {
                            vars1['f'] = 0;
                            print(vars1);
                            goto gr;
                        }
                        vars1['e']++;
                        vars1['g'] = vars1['e'];
                        vars1['g'] -= vars1['b'];
                    } while (vars1['g'] != 0);

                    vars1['d']++;
                    vars1['g'] = vars1['d'];
                    vars1['g'] -= vars1['b'];

                } while (vars1['g'] != 0);
                //g=0,d=108100

                gr:
                if (vars1['f'] == 0)
                    vars1['h']++;
                vars1['g'] = vars1['b'];
                vars1['g'] -= vars1['c'];
                if (vars1['g'] == 0)
                {
                    Console.WriteLine("end");
                    print(vars1);
                }
                vars1['b'] += 17;
            }
            Console.WriteLine("hmm");
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
