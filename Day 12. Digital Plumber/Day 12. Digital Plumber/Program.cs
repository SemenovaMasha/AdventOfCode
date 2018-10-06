using System;
using System.Collections.Generic;
using System.IO;

namespace Day_12.Digital_Plumber
{
    class Program
    {
        static List<int>[] connections;
        static bool[] inGroup;
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            connections = new List<int>[lines.Length];
            inGroup = new bool[lines.Length];
            for (int i = 0; i < connections.Length; i++)
            {
                string right = lines[i].Replace(" ", "").Split('>')[1];
                string[] connectPrograms = right.Split(',');
                connections[i] = new List<int>();
                for (int j = 0; j < connectPrograms.Length; j++)
                {
                    connections[i].Add(Convert.ToInt32(connectPrograms[j]));
                }
            }
            int groupCount = 0;
            int connects = 0;
            for (int i = 0; i < connections.Length; i++)
            {
                if (!inGroup[i])
                {
                    groupCount++;
                    programsConnect0 = new List<int>();
                    addAllConnections(i);
                    print();

                    Console.WriteLine(programsConnect0.Count);
                    connects += programsConnect0.Count;
                }

            }
            Console.WriteLine(groupCount);
            Console.WriteLine(connects);



        }
        static List<int> programsConnect0 = new List<int>();
        static void addAllConnections(int IDtoconnect)
        {
            if (!programsConnect0.Contains(IDtoconnect))
            {
                inGroup[IDtoconnect] = true;
                programsConnect0.Add(IDtoconnect);
                foreach (int id in connections[IDtoconnect])
                    addAllConnections(id);
            }
        }
        static void print()
        {
            foreach (int k in programsConnect0)
                Console.Write(k + " ");
            Console.WriteLine();
        }
    }
}