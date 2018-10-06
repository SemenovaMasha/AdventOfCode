using System;
using System.Collections.Generic;
using System.IO;

namespace Day_18.Duet
{
    class Program
    {
        //void s()
        static void Main(string[] args)
        {
            string[] stringComs = File.ReadAllLines("input.txt");

            long nextCom1 = 0;
            long nextCom2 = 0;

            Dictionary<char, long> vars1 = new Dictionary<char, long>();
            Dictionary<char, long> vars2 = new Dictionary<char, long>();
            vars1.Add('p', 0);
            vars2.Add('p', 1);

            Queue<long> to1 = new Queue<long>();
            Queue<long> to2 = new Queue<long>();

            int steps = 0;
            long sendMessages = 0;

            while (nextCom1 >= 0 && nextCom1 < stringComs.Length && nextCom2 >= 0 && nextCom2 < stringComs.Length)
            {
                bool deadlock = false;
                //Console.WriteLine("Command for 1: " + stringComs[nextCom1]);
                //Console.WriteLine("Command for 2: " + stringComs[nextCom2]);

                steps++;
                string[] arg1 = stringComs[nextCom1].Split(' ');
                string[] arg2 = stringComs[nextCom2].Split(' ');
                

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

                char X2 = char.Parse(arg2[1]);
                if (!vars2.ContainsKey(X2))
                {
                    vars2.Add(X2, 0);
                    if (X2 == '1')
                        vars2['1'] = 1;
                }

                long Y2 = 0;
                if (arg2.Length > 2)
                {
                    try
                    {
                        Y2 = int.Parse(arg2[2]);
                    }
                    catch (Exception exx)
                    {
                        char tmp = char.Parse(arg2[2]);

                        if (!vars2.ContainsKey(tmp))
                            vars2.Add(tmp, 0);
                        Y2 = vars2[tmp];
                    }
                }
                nextCom2++;
                switch (arg1[0])
                {
                    case "snd":
                        to2.Enqueue(vars1[X1]);
                        //Console.WriteLine("1 Send to 2: " + vars1[X1]);
                        break;

                    case "set":
                        vars1[X1] = Y1;
                        break;

                    case "add":
                        vars1[X1] += Y1;
                        break;

                    case "mul":
                        vars1[X1] *= Y1;
                        break;

                    case "mod":
                        vars1[X1] %= Y1;
                        break;

                    case "rcv":
                        if (to1.Count != 0)
                        {
                            long get1 = to1.Dequeue();
                            vars1[X1] = get1;
                            Console.WriteLine("1 Receives: " + get1);
                        }
                        else
                        {
                            nextCom1--;
                            deadlock = true;
                            Console.WriteLine("1 Waits...");
                            //return;
                        }
                        break;

                    case "jgz":
                        if (vars1[X1] > 0)
                        {
                            nextCom1--;
                            nextCom1 += Y1;
                        }
                        break;

                }
                switch (arg2[0])
                {
                    case "snd":
                        to1.Enqueue(vars2[X2]);
                        sendMessages++;
                        //Console.WriteLine("2 Send to 1: " + vars2[X2] + " (" + sendMessages + ")");
                        break;

                    case "set":
                        vars2[X2] = Y2;
                        break;

                    case "add":
                        vars2[X2] += Y2;
                        break;

                    case "mul":
                        vars2[X2] *= Y2;
                        break;

                    case "mod":
                        vars2[X2] %= Y2;
                        break;

                    case "rcv":
                        if (to2.Count != 0)
                        {
                            long get2 = to2.Dequeue();
                            vars2[X2] = get2;
                            Console.WriteLine("2 Receives: " + get2);
                        }
                        else
                        {
                            nextCom2--;
                            if (deadlock)
                            {
                                Console.WriteLine("Deadlock" + sendMessages);
                                return;
                            }
                        }

                        break;

                    case "jgz":
                        if (vars2[X2] > 0)
                        {
                            nextCom2--;
                            nextCom2 += Y2;
                        }
                        break;

                }
                //print(vars);                

                if (steps % 100000 == 0)
                    Console.WriteLine("sendMessages: " + sendMessages + " i: " + steps);
            }
            Console.WriteLine("Out"+sendMessages);
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
