using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_11.Hex_Ed
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = File.ReadAllLines("input.txt")[0];


            //while (s.Contains("nw,ne,") || s.Contains("nw,se,") || s.Contains("nw,s,") ||
            //    s.Contains("n,se,") || s.Contains("n,s,") || s.Contains("n,sw,") ||
            //    s.Contains("ne,s,") || s.Contains("ne,sw,") || s.Contains("ne,nw,") ||
            //    s.Contains("se,sw,") || s.Contains("se,nw,") || s.Contains("se,n,") ||
            //    s.Contains("s,nw,") || s.Contains("s,n,") || s.Contains("s,ne,") ||
            //    s.Contains("sw,n,") || s.Contains("sw,ne,") || s.Contains("sw,se,") )
            //{
            //    s = s.Replace("nw,ne,", "n,");
            //    s = s.Replace("nw,se,", "");
            //    s = s.Replace("nw,s,", "sw,");

            //    s = s.Replace("n,se,", "ne,");
            //    s = s.Replace("n,s,", "");
            //    s = s.Replace("n,sw,", "nw,");

            //    s = s.Replace("ne,s,", "se,");
            //    s = s.Replace("ne,sw,", "");
            //    s = s.Replace("ne,nw,", "n,");

            //    s = s.Replace("se,sw,", "s,");
            //    s = s.Replace("se,nw,", "");
            //    s = s.Replace("se,n,", "ne,");

            //    s = s.Replace("s,nw,", "sw,");
            //    s = s.Replace("s,n,", "");
            //    s = s.Replace("s,ne,", "se,");

            //    s = s.Replace("sw,n,", "nw,");
            //    s = s.Replace("sw,ne,", "");
            //    s = s.Replace("sw,se,", "s,");
            //}

            //List<string> steps = s.Split(',').OfType<string>().ToList();

            //while (true)
            //{
            //    bool find = false;
            //    if (steps.Contains("nw") && steps.Contains("ne"))
            //    {
            //        steps.Add("n");
            //        steps.Remove("nw");
            //        steps.Remove("ne");
            //        find = true;
            //    }
            //    if (steps.Contains("nw") && steps.Contains("se"))
            //    {
            //        steps.Remove("nw");
            //        steps.Remove("se");
            //        find = true;
            //    }
            //    if (steps.Contains("nw") && steps.Contains("s"))
            //    {
            //        steps.Add("sw");
            //        steps.Remove("nw");
            //        steps.Remove("s");
            //        find = true;
            //    }
            //    if (steps.Contains("n") && steps.Contains("se"))
            //    {
            //        steps.Add("ne");
            //        steps.Remove("n");
            //        steps.Remove("se");
            //        find = true;
            //    }
            //    if (steps.Contains("n") && steps.Contains("s"))
            //    {
            //        steps.Remove("n");
            //        steps.Remove("s");
            //        find = true;
            //    }
            //    if (steps.Contains("n") && steps.Contains("sw"))
            //    {
            //        steps.Add("nw");
            //        steps.Remove("n");
            //        steps.Remove("sw");
            //        find = true;
            //    }
            //    if (steps.Contains("ne") && steps.Contains("s"))
            //    {
            //        steps.Add("se");
            //        steps.Remove("ne");
            //        steps.Remove("s");
            //        find = true;
            //    }
            //    if (steps.Contains("ne") && steps.Contains("sw"))
            //    {
            //        steps.Remove("ne");
            //        steps.Remove("sw");
            //        find = true;
            //    }
            //    if (steps.Contains("ne") && steps.Contains("nw"))
            //    {
            //        steps.Add("n");
            //        steps.Remove("ne");
            //        steps.Remove("nw");
            //        find = true;
            //    }
            //    if (steps.Contains("se") && steps.Contains("sw"))
            //    {
            //        steps.Add("s");
            //        steps.Remove("se");
            //        steps.Remove("sw");
            //        find = true;
            //    }
            //    if (steps.Contains("se") && steps.Contains("nw"))
            //    {
            //        steps.Remove("se");
            //        steps.Remove("nw");
            //        find = true;
            //    }
            //    if (steps.Contains("se") && steps.Contains("n"))
            //    {
            //        steps.Add("ne");
            //        steps.Remove("se");
            //        steps.Remove("n");
            //        find = true;
            //    }
            //    if (steps.Contains("s") && steps.Contains("nw"))
            //    {
            //        steps.Add("sw");
            //        steps.Remove("s");
            //        steps.Remove("nw");
            //        find = true;
            //    }
            //    if (steps.Contains("s") && steps.Contains("n"))
            //    {
            //        steps.Remove("s");
            //        steps.Remove("n");
            //        find = true;
            //    }
            //    if (steps.Contains("s") && steps.Contains("ne"))
            //    {
            //        steps.Add("se");
            //        steps.Remove("s");
            //        steps.Remove("ne");
            //        find = true;
            //    }
            //    if (steps.Contains("sw") && steps.Contains("n"))
            //    {
            //        steps.Add("nw");
            //        steps.Remove("sw");
            //        steps.Remove("n");
            //        find = true;
            //    }
            //    if (steps.Contains("sw") && steps.Contains("ne"))
            //    {
            //        steps.Remove("sw");
            //        steps.Remove("ne");
            //        find = true;
            //    }
            //    if (steps.Contains("sw") && steps.Contains("se"))
            //    {
            //        steps.Add("s");
            //        steps.Remove("sw");
            //        steps.Remove("se");
            //        find = true;
            //    }
            //    if (!find) break;
            //}


            string[] stepsS = s.Split(',');
            List<string> stepsSFinal = new List<string>();


            int max = 0;
            for (int i = 0; i < stepsS.Length; i++)
            {
                //Console.WriteLine(stepsS[i]);
                if (stepsS[i] == "nw")
                {
                    if (stepsSFinal.Contains("se"))
                    {
                        stepsSFinal.Remove("se");
                    }
                    else
                    if (stepsSFinal.Contains("ne"))
                    {
                        stepsSFinal.Add("n");
                        stepsSFinal.Remove("ne");
                    }
                    else
                    if (stepsSFinal.Contains("s"))
                    {
                        stepsSFinal.Add("sw");
                        stepsSFinal.Remove("s");
                    }
                    else stepsSFinal.Add("nw");

                }
                else if (stepsS[i] == "n")
                {
                    if (stepsSFinal.Contains("s"))
                    {
                        stepsSFinal.Remove("s");
                    }
                    else
                    if (stepsSFinal.Contains("se"))
                    {
                        stepsSFinal.Add("ne");
                        stepsSFinal.Remove("se");
                    }
                    else
                    if (stepsSFinal.Contains("sw"))
                    {
                        stepsSFinal.Add("nw");
                        stepsSFinal.Remove("sw");
                    }
                    else stepsSFinal.Add("n");
                }
                else if (stepsS[i] == "ne")
                {
                    if (stepsSFinal.Contains("sw"))
                    {
                        stepsSFinal.Remove("sw");
                    }
                    else
                    if (stepsSFinal.Contains("s"))
                    {
                        stepsSFinal.Add("se");
                        stepsSFinal.Remove("s");
                    }
                    else
                    if (stepsSFinal.Contains("nw"))
                    {
                        stepsSFinal.Add("n");
                        stepsSFinal.Remove("nw");
                    }
                    else stepsSFinal.Add("ne");
                }
                else if (stepsS[i] == "se")
                {
                    if (stepsSFinal.Contains("nw"))
                    {
                        stepsSFinal.Remove("nw");
                    }
                    else
                    if (stepsSFinal.Contains("sw"))
                    {
                        stepsSFinal.Add("s");
                        stepsSFinal.Remove("sw");
                    }
                    else
                    if (stepsSFinal.Contains("n"))
                    {
                        stepsSFinal.Add("ne");
                        stepsSFinal.Remove("n");
                    }
                    else stepsSFinal.Add("se");
                }
                else if (stepsS[i] == "s")
                {
                    if (stepsSFinal.Contains("n"))
                    {
                        stepsSFinal.Remove("n");
                    }
                    else
                    if (stepsSFinal.Contains("nw"))
                    {
                        stepsSFinal.Add("sw");
                        stepsSFinal.Remove("nw");
                    }
                    else
                    if (stepsSFinal.Contains("ne"))
                    {
                        stepsSFinal.Add("se");
                        stepsSFinal.Remove("ne");
                    }
                    else stepsSFinal.Add("s");
                }
                else if (stepsS[i] == "sw")
                {
                    if (stepsSFinal.Contains("ne"))
                    {
                        stepsSFinal.Remove("ne");
                    }
                    else
                    if (stepsSFinal.Contains("n"))
                    {
                        stepsSFinal.Add("nw");
                        stepsSFinal.Remove("n");
                    }
                    else
                    if (stepsSFinal.Contains("se"))
                    {
                        stepsSFinal.Add("s");
                        stepsSFinal.Remove("se");
                    }
                    else stepsSFinal.Add("sw");
                }
                if (stepsSFinal.Count > max) max = stepsSFinal.Count;
                //print(stepsSFinal);
            }



            print(stepsSFinal);
            Console.WriteLine(stepsSFinal.Count);
            Console.WriteLine(max);

            //print(steps);
            //Console.WriteLine(steps.Count);
            Console.ReadKey();
        }
        static void print(List<string> a)
        {
            foreach (string s in a)
                Console.Write(s + "!");
            Console.WriteLine();
        }
    }
}