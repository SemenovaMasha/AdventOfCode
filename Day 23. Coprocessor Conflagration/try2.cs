using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_23.Coprocessor_Conflagration
{
    class try2
    {
        //void f()
        static void Main(string[] args)
        {

            //Dictionary<char, long> vars1 = new Dictionary<char, long>();

            //for (char c = 'a'; c <= 'h'; c++)
            //{
            //    vars1.Add(c, 0);
            //}
            //vars1['a'] = 1;
            //vars1['b'] = 81;
            //vars1['c'] = vars1['b'];
            //vars1['b'] *= 100;
            //vars1['b'] += 100000;
            //vars1['c'] = vars1['b'];
            //vars1['c'] += 17000;

            //while (true)
            //{
            //}



            int b = 108100;

            int h = 0;
            while (b != 125100)
            {
                for(int d = 2; d <= Math.Sqrt(b); d++)
                {
                    if (b % d == 0)
                    {
                        h++;
                        Console.WriteLine(b+" / "+d);

                        break;
                    }
                }
                b += 17;
            }
            Console.WriteLine(h);
        }
    }
}
