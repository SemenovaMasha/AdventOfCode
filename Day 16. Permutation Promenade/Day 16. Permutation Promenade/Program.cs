using System;
using System.IO;
using System.Linq;

namespace Day_16.Permutation_Promenade
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 16;

            string programs = "";
            for (int i = 0; i < n; i++)
                programs += (char)('a' + i);

            string[] moves = File.ReadAllLines("input.txt")[0].Split(',');

            char[] progs = programs.ToCharArray();

            Console.WriteLine(progs);
            int[,] movesCode = new int[moves.Length, 3];

            for (int k = 0; k < moves.Length; k++)
            {
                string move = moves[k];
                //Console.WriteLine(move );
                if (move.StartsWith("s"))
                {
                    int x = int.Parse(move.Substring(1));

                    //string toStart = progs.Substring(progs.Length-x);
                    char[] toStart = new char[x];

                    for (int j = 0; j < x; j++)
                    {
                        toStart[j] = progs[progs.Length - x + j];
                    }

                    for (int j = progs.Length - 1; j >= x; j--)
                    {
                        progs[j] = progs[j - x];
                    }

                    for (int j = 0; j < x; j++)
                    {
                        progs[j] = toStart[j];
                    }

                    //Code
                    movesCode[k, 0] = 0;
                    movesCode[k, 1] = x;

                }
                else if (move.StartsWith("x"))
                {
                    string[] argss = move.Substring(1).Split('/');
                    int A = int.Parse(argss[0]);
                    int B = int.Parse(argss[1]);

                    char tmp = progs[A];
                    progs[A] = progs[B];
                    progs[B] = tmp;

                    //Code
                    movesCode[k, 0] = 1;
                    movesCode[k, 1] = A;
                    movesCode[k, 2] = B;
                }
                else if (move.StartsWith("p"))
                {
                    string[] argss = move.Substring(1).Split('/');
                    char A = char.Parse(argss[0]);
                    char B = char.Parse(argss[1]);

                    for (int j = 0; j < n; j++)
                    {
                        if (progs[j] == A)
                            progs[j] = B;
                        else
                        if (progs[j] == B)
                            progs[j] = A;
                    }

                    //Code
                    movesCode[k, 0] = 2;
                    movesCode[k, 1] = A;
                    movesCode[k, 2] = B;
                }


            }
            
            Console.WriteLine(progs);
            for (int l = 1; l < 40; l++)
            {
                for (int k = 0; k < moves.Length; k++)
                {
                    if (movesCode[k,0]==0)
                    {
                        int x = movesCode[k, 1];

                        char[] toStart = new char[x];

                        for (int j = 0; j < x; j++)
                        {
                            toStart[j] = progs[progs.Length - x + j];
                        }

                        for (int j = progs.Length - 1; j >= x; j--)
                        {
                            progs[j] = progs[j - x];
                        }

                        for (int j = 0; j < x; j++)
                        {
                            progs[j] = toStart[j];
                        }

                    }
                    else if (movesCode[k, 0] == 1)
                    {
                        int A = movesCode[k, 1];
                        int B = movesCode[k, 2];

                        char tmp = progs[A];
                        progs[A] = progs[B];
                        progs[B] = tmp;
                    }
                    else if (movesCode[k, 0] == 2)
                    {
                        char A = (char)movesCode[k, 1];
                        char B = (char)movesCode[k, 2];

                        for (int j = 0; j < n; j++)
                        {
                            if (progs[j] == A)
                                progs[j] = B;
                            else
                            if (progs[j] == B)
                                progs[j] = A;
                        }
                    }
                }
                if (l % 10000 == 0)
                {
                    Console.WriteLine(l);
                    Console.WriteLine(progs);
                }

                string ttt = "";
                for (int i = 0; i < n; i++)
                    ttt += progs[i];
                Console.WriteLine(ttt);

                if (ttt.Equals("abcdefghijklmnop"))
                {
                    Console.WriteLine(l);
                    break;
                }
            }
            Console.WriteLine(progs);

        }

    }
}