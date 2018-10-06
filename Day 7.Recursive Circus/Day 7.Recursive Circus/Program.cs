using System;
using System.Collections.Generic;
using System.IO;

namespace Day_7.Recursive_Circus
{
    class Program
    {
        static List<string> programs = new List<string>();
        static List<int> programWeights = new List<int>();
        static List<List<string>> innerPrograms = new List<List<string>>();
        static void Main(string[] args)
        {
            string[] rows = File.ReadAllLines("input.txt");
            int sum = 0;

            for (int i = 0; i < rows.Length; i++)
            {
                string programName = rows[i].Split(' ')[0];
                List<string> inners = new List<string>();


                string weig = rows[i].Split(')')[0];
                weig = weig.Split('(')[1];

                if (rows[i].Split('>').Length > 1)
                {
                    string rightPart = rows[i].Split('>')[1].Replace(" ", "");

                    string[] tmp = rightPart.Split(',');

                    foreach (string s in tmp)
                    {
                        inners.Add(s);
                    }

                }
                programs.Add(programName);
                innerPrograms.Add(inners);
                programWeights.Add(Convert.ToInt32(weig));
            }


            int k = 0;

            //while (programs.Count > 1)
            //{
            //    removeInners(programs[l]);
            //    k++;

            //    l = l == programs.Count - 1 ? 0 : l + 1;
            //}
            Console.WriteLine(sum + "end");
            //print();


            int index = programs.IndexOf("tknk");
            //foreach (string s in innerPrograms[index])
            //{
            //    Console.WriteLine("sum " + s + " : " + sumOfInners(s));
            //}
            sumOfInners("hlhomy");

            Console.WriteLine("sum apjxafk" + " : " + sumOfInners("apjxafk"));
            Console.WriteLine("sum jngcap" + " : " + sumOfInners("jngcap"));


            //Console.ReadKey();
        }
        static int l = 0;

        static public void removeInners(string program)
        {
            int progIndex = programs.IndexOf(program);
            if (innerPrograms[progIndex].Count == 0)
            {

            }
            else
            {
                l = 0;
                for (int i = 0; i < innerPrograms[progIndex].Count;)
                {
                    //print();
                    string toRemove = innerPrograms[progIndex][0];
                    removeInners(innerPrograms[progIndex][0]);
                    int ind = programs.IndexOf(toRemove);
                    programs.Remove(toRemove);
                    innerPrograms.RemoveAt(ind);
                    programWeights.RemoveAt(ind);
                    progIndex = programs.IndexOf(program);
                    innerPrograms[programs.IndexOf(program)].RemoveAt(0);
                }
            }
        }

        static public int sumOfInners(string program)
        {
            int progIndex = programs.IndexOf(program);
            if (innerPrograms[progIndex].Count == 0)
            {
                return programWeights[progIndex];
            }
            else
            {
                int sum = 0;

                int toCompare = 0;
                string sMaybe = innerPrograms[progIndex][0];
                string toPrint = "";

                bool found = false;
                foreach (string s in innerPrograms[progIndex])
                {
                    int sumTmp= sumOfInners(s);
                    toPrint += "sum " + s + " : " + sumTmp + "\r\n";
                    sum += sumTmp;
                    //Console.WriteLine("program " + s + " : " + sumTmp);

                    if (sumTmp!=toCompare&&toCompare!=0)
                    {
                        Console.WriteLine("progran " + s+" or "+ sMaybe+" : " +sum);
                        //Console.WriteLine(toPrint);
                        found = true;

                    }

                    toCompare = sumTmp;
                    sMaybe = s;
                }
                if(found)
                    Console.WriteLine(toPrint);
                return programWeights[progIndex] + sum;
            }
        }

        static public void print()
        {
            Console.WriteLine(programs.Count);
            for (int l = 0; l < programs.Count; l++)
            {
                Console.Write(programs[l] + " ");
                for (int j = 0; j < innerPrograms[l].Count; j++)
                    Console.Write(innerPrograms[l][j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();

        }
    }
}