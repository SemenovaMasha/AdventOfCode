using System;
using System.Collections.Generic;
using System.IO;

namespace Day_13.Packet_Scanners
{
    class Program
    {
        static bool[][] prevFirewalls;
        static void Main(string[] args)
        {
            string[] str = File.ReadAllLines("input.txt");

            bool[][] firewalls = new bool[Convert.ToInt32(str[str.Length - 1].Split(':')[0]) + 1][];
            bool[] up = new bool[firewalls.GetLength(0)];

            prevFirewalls = new bool[firewalls.GetLength(0)][];
            prevUp= new bool[firewalls.GetLength(0)];
            for (int i = 0; i < str.Length; i++)
            {
                int index = Convert.ToInt32(str[i].Split(':')[0]);
                int count = Convert.ToInt32(str[i].Split(' ')[1]);
                firewalls[index] = new bool[count];
                prevFirewalls[index] = new bool[count];
                firewalls[index][0] = true;
            }

            int sum = 0;

            Console.WriteLine(firewalls.GetLength(0));            

            int delay = 0;
            bool saved = false;

            copy(firewalls,up,prevFirewalls,prevUp);
            //Array.Copy(up, prevUp, firewalls.GetLength(0));
            

            while (!saved)
            {

                //Array.Copy(prevFirewalls,firewalls,  firewalls.GetLength(0));
                //Array.Copy(prevUp,up,  firewalls.GetLength(0));

                copy( prevFirewalls, prevUp,firewalls, up);

                //Console.WriteLine("State after delaying:");
                //print(prevFirewalls);
                //Console.WriteLine("sprev");
                //print(prevFirewalls);

                sum = 0;
                //for (int i = 0; i < firewalls.GetLength(0); i++)
                //{
                //    if (firewalls[i] != null)
                //    {
                //        for (int j = 0; j < firewalls[i].Length; j++) { firewalls[i][j] = false; }
                //        firewalls[i][0] = true;
                //    }
                //    up[i] = false;
                //}
                //for (int sec = 0; sec < delay; sec++)
                //{
                //}

                for (int sec = 0; sec < firewalls.GetLength(0); sec++)
                {
                    //print(firewalls);
                    if (firewalls[sec] != null && firewalls[sec][0])
                    {
                        sum += (sec+1 ) * firewalls[sec].Length;
                        break;
                    }

                    oneMoreSec(firewalls,up);
                }

                oneMoreSec(prevFirewalls,prevUp);

                if (sum == 0)
                {
                    saved = true;
                    Console.WriteLine("delay: " + delay + " sum: " + sum);
                }
                if (delay % 100 == 0)
                    Console.WriteLine("delay: " + delay + " sum: " + sum);

                delay++;
                //Console.WriteLine(delay);
                //print(prevFirewalls);
            }

            Console.ReadKey();
        }

        static void print(bool[][] prevFirewalls)
        {
            for (int i = 0; i < prevFirewalls.GetLength(0); i++)
            {
                Console.Write(i + " : ");
                if (prevFirewalls[i] != null)
                {
                    for (int j = 0; j < prevFirewalls[i].Length; j++)
                    {
                        Console.Write((prevFirewalls[i][j] ? "[S]" : "[ ]") + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static bool[] prevUp;

        static void oneMoreSec(bool[][] prevFirewalls, bool[] prevUp)
        {
            for (int i = 0; i < prevFirewalls.GetLength(0); i++)
            {
                if (prevFirewalls[i] != null)
                {
                    int j = 0;
                    for (; j < prevFirewalls[i].Length && !prevFirewalls[i][j]; j++) { }

                    prevFirewalls[i][j] = false;
                    if (prevUp[i])
                    {
                        if (j == 0)
                        {
                            prevFirewalls[i][j + 1] = true;
                            prevUp[i] = false;
                        }
                        else
                        {
                            prevFirewalls[i][j - 1] = true;
                        }
                    }
                    else
                    {
                        if (j == prevFirewalls[i].Length - 1)
                        {
                            prevFirewalls[i][j - 1] = true;
                            prevUp[i] = true;
                        }
                        else
                        {
                            prevFirewalls[i][j + 1] = true;
                        }
                    }
                }
            }
        }

        static void copy(bool[][] prevFirewalls, bool[] prevUp, bool[][] Firewalls, bool[] Up)
        {
            for (int i = 0; i < Firewalls.GetLength(0); i++)
            {
                if (Firewalls[i] != null)
                {
                    for (int j = 0; j < Firewalls[i].Length; j++)
                    {
                        Firewalls[i][j] = prevFirewalls[i][j];
                        Up[i] = prevUp[i];
                    }
                }
            }
        }
    }
}