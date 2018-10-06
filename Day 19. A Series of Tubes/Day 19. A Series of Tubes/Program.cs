using System;
using System.IO;

namespace Day_19.A_Series_of_Tubes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            char[,] map = new char[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }
            //0-up,1-right,2-down,3-left
            int direction = 2;

            int currentX = lines[0].IndexOf('|');
            int currentY = 0;

            string result = "";
            int l = 0;
            while (true )
            {

                Console.WriteLine(l + "direction - " + direction);
                char currentChar = map[currentY, currentX];
                if (Char.IsLetter(currentChar))
                {
                    result += currentChar;

                    if (!((map[currentY - 1, currentX] !=' ' && direction != 2) ||
                        (map[currentY, currentX + 1] != ' ' && direction != 3) ||
                        (map[currentY + 1, currentX] != ' ' && direction != 0) ||
                        (map[currentY, currentX - 1] != ' ' && direction != 1)))
                    {
                        Console.WriteLine("hop - " + result+" l - "+l);
                        return;
                    }
                }
                if (currentChar == '+')
                {

                    if (map[currentY - 1, currentX] != ' ' && direction != 2)
                    {
                        direction = 0;
                    }
                    else
                    if (map[currentY, currentX + 1] != ' ' && direction != 3)
                    {
                        direction = 1;
                    }
                    else
                    if (map[currentY + 1, currentX] != ' ' && direction != 0)
                    {
                        direction = 2;
                    }
                    else
                    if (map[currentY, currentX - 1] != ' ' && direction != 1)
                    {
                        direction = 3;
                    }
                }
                l++;
                switch (direction)
                {
                    case 0:
                        currentY--;
                        break;
                    case 1:
                        currentX++;
                        break;
                    case 2:
                        currentY++;
                        break;
                    case 3:
                        currentX--;
                        break;
                }
            }

            Console.WriteLine("hmm");
        }

    }
}
