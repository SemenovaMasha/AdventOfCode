using System;
using System.IO;
using System.Linq;

namespace Day_5.A_Maze_of_Twisty_Trampolines
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rows = File.ReadAllLines("input.txt");
            int sum = 0;

            int[] mas = new int[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                mas[i] = Convert.ToInt32(rows[i]);
            }
            int nextCoor = 0;

            while (nextCoor >= 0 && nextCoor < mas.Length)
            {
                if (mas[nextCoor] >= 3)
                {
                    mas[nextCoor]--;
                    nextCoor += mas[nextCoor] + 1;
                }
                else
                {
                    mas[nextCoor]++;
                    nextCoor += mas[nextCoor] - 1;
                }

                sum++;
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}