using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21.Fractal_Art
{
    class Program
    {
        static Dictionary<string, string> replaces2 = new Dictionary<string, string>();
        static Dictionary<string, string> replaces3 = new Dictionary<string, string>();
        static char[,] pixels;
        static int N;
        //void f()
        static void Main(string[] args)
        {
            string[] repl = File.ReadAllLines("../../input.txt");


            for (int i = 0; i < repl.Length; i++)
            {
                string toReplac = repl[i].Split('=')[0].Replace(" ", "");
                if (toReplac.Split('/').Length == 2)
                {
                    replaces2.Add(toReplac, repl[i].Split('>')[1].Replace(" ", ""));
                }
                else
                {
                    replaces3.Add(toReplac, repl[i].Split('>')[1].Replace(" ", ""));
                }


            }

            pixels = new char[2201, 2201];
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                    pixels[i, j] = '0';
            pixels[0, 0] = '.';
            pixels[0, 1] = '#';
            pixels[0, 2] = '.';
            pixels[1, 0] = '.';
            pixels[1, 1] = '.';
            pixels[1, 2] = '#';
            pixels[2, 0] = '#';
            pixels[2, 1] = '#';
            pixels[2, 2] = '#';

            //pixels[3, 0] = '#';
            //pixels[3, 1] = '.';
            //pixels[3, 2] = '#';
            //pixels[3, 3] = '.';
            //pixels[0, 3] = '.';
            //pixels[1, 3] = '#';
            //pixels[2, 3] = '.';

            //print(pixels);

             N = 3;


            //for (int j = 0; j < pixels.GetLength(1); j++)
            //    pixels[j, 1] = '.';
            //for (int j = 0; j < pixels.GetLength(1); j++)
            //    pixels[4,j] = '.';
            //for (int j = 0; j < pixels.GetLength(1); j++)
            //    pixels[8, j] = '.';
            //for (int j = 0; j < pixels.GetLength(1); j++)
            //    pixels[16, j] = '.';
            //for (int j = 0; j < pixels.GetLength(1); j++)
            //    pixels[j, 16] = '.';
            //for (int j = 0; j < pixels.GetLength(1); j++)
            //    pixels[j, 7] = '.';


            //print(pixels);

            for (int iteration = 0; iteration < 18; iteration++)
            {
                if (N % 2 == 0)
                {
                    //Console.WriteLine("2!" + N);
                    int sq = N / 2;
                    moveRows2();
                    moveColumns2();
                    for (int squareI = 0; squareI < sq; squareI++)
                    {
                        for (int squareJ = 0; squareJ < sq; squareJ++)
                        {
                            //разделять тут, доьавять пустык столбцы
                            tryReplace2(squareI * 3, squareJ * 3);

                            //Console.WriteLine("aftertryReplace:");
                            //print(pixels);
                        }
                    }
                    N = N / 2 * 3;
                }
                else
                {
                    //Console.WriteLine("3!"+N);
                    int sq = N / 3;
                    moveRows3();
                    moveColumns3();
                    for (int squareI = 0; squareI < sq; squareI++)
                    {
                        for (int squareJ = 0; squareJ < sq; squareJ++)
                        {
                            //разделять тут, доьавять пустык столбцы
                            tryReplace3(squareI * 4, squareJ * 4);

                            //Console.WriteLine("aftertryReplace:");
                            //print(pixels);
                        }
                    }
                    N = N / 3 * 4;


                }
                //Console.WriteLine("aftertryReplace:");
                Console.WriteLine(iteration);
            }
            print(pixels);
            int sum = 0;
            for (int i = 0; i < 2201; i++)
                for (int j = 0; j < 2201; j++)
                    if (pixels[i, j] == '#') sum++;

            Console.WriteLine(sum);

            string ss = "";
            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    ss+=pixels[i, j];
                }
                ss += "\r\n";
            }
            File.WriteAllText("output.txt", ss);
            
        }
        static void moveRows2()
        {
            for (int k = 1; k <= 2201 / 3; k++)
            {
                for (int i = 2200; i >= k * 3; i--)
                {
                    for (int j = 0; j < 2201; j++)
                    {
                        pixels[i, j] = pixels[i - 1, j];
                    }
                }
                for (int j = 0; j < 2201; j++)
                {
                    pixels[k * 3 - 1, j] = '0';
                }
            }
        }
        static void moveRows3()
        {
            for (int k = 1; k <= 2201 / 4; k++)
            {
                for (int i = 2200; i >= k * 4; i--)
                {
                    for (int j = 0; j < 2201; j++)
                    {
                        pixels[i, j] = pixels[i - 1, j];
                    }
                }
                for (int j = 0; j < 2201; j++)
                {
                    pixels[k * 4 - 1, j] = '0';
                }
            }
        }
        static void moveColumns2()
        {
            for (int k = 1; k <= 2201 / 3; k++)
            {
                for (int j = 2200; j >= k * 3; j--)
                {
                    for (int i = 0; i < 2201; i++)
                    {
                        pixels[i, j] = pixels[i, j - 1];
                    }
                }
                for (int i = 0; i < 2201; i++)
                {
                    pixels[i, k * 3 - 1] = '0';
                }
            }
        }
        static void moveColumns3()
        {
            for (int k = 1; k <= 2201 / 4; k++)
            {
                for (int j = 2200; j >= k * 4; j--)
                {
                    for (int i = 0; i < 2201; i++)
                    {
                        pixels[i, j] = pixels[i, j - 1];
                    }
                }
                for (int i = 0; i < 2201; i++)
                {
                    pixels[i, k * 4 - 1] = '0';
                }
            }
        }

        static void print(char[,] pixels)
        {
            //for (int i = 0; i < pixels.GetLength(0); i++)
            //{
            //    for (int j = 0; j < pixels.GetLength(1); j++)
            //    {
            //        Console.Write(pixels[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    Console.Write(pixels[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        static void tryReplace2(int replaceI, int replaceJ)
        {
            for (int rot = 0; rot < 3; rot++)
            {
                string stringRep = getStringReplace2(replaceI, replaceJ);
                if (replaces2.ContainsKey(stringRep))
                {
                    replace2(replaceI, replaceJ, replaces2[stringRep]);
                    return;
                }

                flipUpDown2(replaceI, replaceJ);
                stringRep = getStringReplace2(replaceI, replaceJ);
                if (replaces2.ContainsKey(stringRep))
                {
                    replace2(replaceI, replaceJ, replaces2[stringRep]);
                    return;
                }
                flipUpDown2(replaceI, replaceJ);

                flipRightLeft2(replaceI, replaceJ);
                stringRep = getStringReplace2(replaceI, replaceJ);
                if (replaces2.ContainsKey(stringRep))
                {
                    replace2(replaceI, replaceJ, replaces2[stringRep]);
                    return;
                }
                flipRightLeft2(replaceI, replaceJ);

                //flipUpDown2(replaceI, replaceJ);
                //flipRightLeft2(replaceI, replaceJ);
                //stringRep = getStringReplace2(replaceI, replaceJ);
                //if (replaces2.ContainsKey(stringRep))
                //{
                //    replace2(replaceI, replaceJ, replaces2[stringRep]);
                //    return;
                //}
                //flipRightLeft2(replaceI, replaceJ);
                //flipUpDown2(replaceI, replaceJ);

                //flipRightLeft2(replaceI, replaceJ);
                //flipUpDown2(replaceI, replaceJ);
                //stringRep = getStringReplace2(replaceI, replaceJ);
                //if (replaces2.ContainsKey(stringRep))
                //{
                //    replace2(replaceI, replaceJ, replaces2[stringRep]);
                //    return;
                //}
                //flipUpDown2(replaceI, replaceJ);
                //flipRightLeft2(replaceI, replaceJ);

                rotate2(replaceI, replaceJ);
            }
            //Console.WriteLine("not found");
        }
        static string getStringReplace2(int replaceI, int replaceJ)
        {
            string result = "";
            result = "" + pixels[replaceI, replaceJ] + pixels[replaceI, replaceJ + 1] + "/" + pixels[replaceI + 1, replaceJ] + pixels[replaceI + 1, replaceJ + 1];
            return result;
        }
        static void rotate2(int replaceI, int replaceJ)
        {
            char tmp = pixels[replaceI, replaceJ];
            pixels[replaceI, replaceJ] = pixels[replaceI + 1, replaceJ];
            pixels[replaceI + 1, replaceJ] = pixels[replaceI + 1, replaceJ + 1];
            pixels[replaceI + 1, replaceJ + 1] = pixels[replaceI, replaceJ + 1];
            pixels[replaceI, replaceJ + 1] = tmp;
        }
        static void replace2(int replaceI, int replaceJ, string replaceString)
        {
            string[] rows = replaceString.Split('/');
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pixels[replaceI + i, replaceJ + j] = rows[i][j];
                }
            }
        }
        static void flipUpDown2(int replaceI, int replaceJ)
        {
            for (int j = 0; j < 2; j++)
            {
                char tmp = pixels[replaceI, replaceJ + j];
                pixels[replaceI, replaceJ + j] = pixels[replaceI + 1, replaceJ + j];
                pixels[replaceI + 1, replaceJ + j] = tmp;
            }
        }
        static void flipRightLeft2(int replaceI, int replaceJ)
        {
            for (int j = 0; j < 2; j++)
            {
                char tmp = pixels[replaceI + j, replaceJ];
                pixels[replaceI + j, replaceJ] = pixels[replaceI + j, replaceJ + 1];
                pixels[replaceI + j, replaceJ + 1] = tmp;
            }
        }


        static string getStringReplace3(int replaceI, int replaceJ)
        {
            string result = "";
            result = "" + pixels[replaceI, replaceJ] + pixels[replaceI, replaceJ + 1] + pixels[replaceI, replaceJ + 2] +
                "/" + pixels[replaceI + 1, replaceJ] + pixels[replaceI + 1, replaceJ + 1] + pixels[replaceI + 1, replaceJ + 2]+
            "/" + pixels[replaceI + 2, replaceJ] + pixels[replaceI + 2, replaceJ + 1] + pixels[replaceI + 2, replaceJ + 2];
            return result;
        }
        static void rotate3(int replaceI, int replaceJ)
        {
            char tmp = pixels[replaceI, replaceJ];
            pixels[replaceI, replaceJ] = pixels[replaceI + 1, replaceJ];
            pixels[replaceI+1, replaceJ] = pixels[replaceI + 2, replaceJ];
            pixels[replaceI + 2, replaceJ] = pixels[replaceI + 2, replaceJ + 1];
            pixels[replaceI + 2, replaceJ + 1] = pixels[replaceI + 2, replaceJ + 2];
            pixels[replaceI + 2, replaceJ + 2] = pixels[replaceI + 1, replaceJ + 2];
            pixels[replaceI + 1, replaceJ + 2] = pixels[replaceI, replaceJ + 2];
            pixels[replaceI, replaceJ  +2] = pixels[replaceI, replaceJ + 1];
            pixels[replaceI, replaceJ + 1] = tmp;
        }
        static void replace3(int replaceI, int replaceJ, string replaceString)
        {
            string[] rows = replaceString.Split('/');
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pixels[replaceI + i, replaceJ + j] = rows[i][j];
                }
            }
        }
        static void flipUpDown3(int replaceI, int replaceJ)
        {
            for (int j = 0; j < 3; j++)
            {
                char tmp = pixels[replaceI, replaceJ + j];
                pixels[replaceI, replaceJ + j] = pixels[replaceI + 2, replaceJ + j];
                pixels[replaceI + 2, replaceJ + j] = tmp;
            }
        }
        static void flipRightLeft3(int replaceI, int replaceJ)
        {
            for (int j = 0; j < 3; j++)
            {
                char tmp = pixels[replaceI + j, replaceJ];
                pixels[replaceI + j, replaceJ] = pixels[replaceI + j, replaceJ + 2];
                pixels[replaceI + j, replaceJ + 2] = tmp;
            }
        }

        static void tryReplace3(int replaceI, int replaceJ)
        {
            for (int rot = 0; rot < 7; rot++)
            {
                string stringRep = getStringReplace3(replaceI, replaceJ);
                if (replaces3.ContainsKey(stringRep))
                {
                    replace3(replaceI, replaceJ, replaces3[stringRep]);
                    return;
                }

                flipUpDown3(replaceI, replaceJ);
                stringRep = getStringReplace3(replaceI, replaceJ);
                if (replaces3.ContainsKey(stringRep))
                {
                    //Console.WriteLine("a55" + rot + "!" + stringRep);
                    //print(pixels);
                    replace3(replaceI, replaceJ, replaces3[stringRep]);
                    return;
                }
                flipUpDown3(replaceI, replaceJ);

                flipRightLeft3(replaceI, replaceJ);
                stringRep = getStringReplace3(replaceI, replaceJ);
                if (replaces3.ContainsKey(stringRep))
                {
                    //Console.WriteLine("a52" + rot + "!" + stringRep);
                    //print(pixels);
                    replace3(replaceI, replaceJ, replaces3[stringRep]);
                    return;
                }
                flipRightLeft3(replaceI, replaceJ);

                //flipUpDown3(replaceI, replaceJ);
                //flipRightLeft3(replaceI, replaceJ);
                //stringRep = getStringReplace3(replaceI, replaceJ);
                //if (replaces3.ContainsKey(stringRep))
                //{
                //    Console.WriteLine("a53" + rot + "!" + stringRep);
                //    print(pixels);
                //    replace3(replaceI, replaceJ, replaces3[stringRep]);
                //    return;
                //}
                //flipRightLeft3(replaceI, replaceJ);
                //flipUpDown3(replaceI, replaceJ);

                //flipRightLeft3(replaceI, replaceJ);
                //flipUpDown3(replaceI, replaceJ);
                //stringRep = getStringReplace3(replaceI, replaceJ);
                //if (replaces3.ContainsKey(stringRep))
                //{
                //    Console.WriteLine("a54" + rot + "!" + stringRep);
                //    print(pixels);
                //    replace3(replaceI, replaceJ, replaces3[stringRep]);
                //    return;
                //}
                //flipUpDown3(replaceI, replaceJ);
                //flipRightLeft3(replaceI, replaceJ);

                rotate3(replaceI, replaceJ);
            }
            //Console.WriteLine("not found");
        }
    }
}
