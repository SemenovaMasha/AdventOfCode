using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_22.Sporifica_Virus
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../input.txt");
            char[,] infected = new char[10000, 10000];

            int n = lines.Length;
            int currentI = infected.GetLength(0) / 2;
            int currentJ = infected.GetLength(1) / 2;

            //for (int i = 0; i < infected.GetLength(0); i++)
            //{
            //    for (int j = 0; j < infected.GetLength(1); j++)
            //    {
            //        infected[i, j] = '.';
            //    }
            //}
            

            for (int i = 0; i < lines.Length; i++)
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    infected[currentI - n / 2 + i, currentJ - n / 2 + j] = lines[i][j];
                    //if (lines[i][j] == '#')
                    //{
                    //    infected[currentI - n / 2 + i, currentJ - n / 2 + j] = true;
                    //}
                }
            }

            print(infected, 10);

            int infectionBurst = 0;

            int direction = 0;
            
            for(int action = 0; action < 10000000; action++)
            {
                switch(infected[currentI, currentJ])
                {
                    case '.':
                        direction = newDirection(direction, 1);
                        infected[currentI, currentJ] = 'W';
                        break;
                    case (char)0:
                        direction = newDirection(direction, 1);
                        infected[currentI, currentJ] = 'W';
                        break;
                    case 'W':
                        infectionBurst++;
                        infected[currentI, currentJ] = '#';
                        break;
                    case '#':
                        direction = newDirection(direction, 0);
                        infected[currentI, currentJ] = 'F';
                        break;
                    case 'F':
                        direction = newDirection(direction, 2);
                        infected[currentI, currentJ] = '.';
                        break;
                }
                switch (direction)
                {
                    case 0:
                        currentI--;
                        break;
                    case 1:
                        currentJ++;
                        break;
                    case 2:
                        currentI++;
                        break;
                    case 3:
                        currentJ--;
                        break;
                }
                //if (action % 1000000 == 0)
                //{
                //    Console.WriteLine(action);
                //    print(infected, 10);
                //}
            }
            print(infected, 10);
            Console.WriteLine(infectionBurst);

        }

        static void print(char [,] a,int radius)
        {
            for (int i = a.GetLength(0)/2-radius; i < a.GetLength(0) / 2 + radius; i++)
            {
                for (int j = a.GetLength(0) / 2 - radius; j < a.GetLength(0) / 2 + radius; j++)
                {
                    Console.Write(a[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int  newDirection(int oldDirection, int type)
        {
            //0-rigth, 1-left, 2-reverse
            if (type==0)
            {
                switch (oldDirection)
                {
                    case 0:
                        return 1;
                    case 1:
                        return 2;
                    case 2:
                        return 3;
                    case 3:
                        return 0;
                }
            }
            else if (type == 1)
            {
                switch (oldDirection)
                {
                    case 0:
                        return 3;
                    case 1:
                        return 0;
                    case 2:
                        return 1;
                    case 3:
                        return 2;
                }
            }
            else
            {
                switch (oldDirection)
                {
                    case 0:
                        return 2;
                    case 1:
                        return 3;
                    case 2:
                        return 0;
                    case 3:
                        return 1;
                }
            }
            return -1;
        }
    }
}
