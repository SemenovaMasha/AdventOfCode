using System;
using System.Collections.Generic;
using System.IO;

namespace Day_8.I_heard_you_like_registers
{
    class Program
    {
        static Dictionary<string, int> values = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            string[] rows = File.ReadAllLines("input.txt");

            int max=0;
            for (int i = 0; i < rows.Length; i++)
            {
                string variable = rows[i].Split(' ')[0];
                string operation = rows[i].Split(' ')[1];
                int amount= Convert.ToInt32(rows[i].Split(' ')[2]);

                string conditionVariable = rows[i].Split(' ')[4];
                string conditionOperation = rows[i].Split(' ')[5];
                int conditionAmount = Convert.ToInt32(rows[i].Split(' ')[6]);

                if (!values.ContainsKey(variable))
                    values.Add(variable, 0);

                bool condition = false;

                if (!values.ContainsKey(conditionVariable))
                    values.Add(conditionVariable, 0);

                switch (conditionOperation)
                {
                    case "<":
                        if (values[conditionVariable] < conditionAmount)
                            condition = true;
                        break;
                    case ">":
                        if (values[conditionVariable] > conditionAmount)
                            condition = true;
                        break;
                    case "<=":
                        if (values[conditionVariable] <= conditionAmount)
                            condition = true;
                        break;
                    case ">=":
                        if (values[conditionVariable] >= conditionAmount)
                            condition = true;
                        break;
                    case "==":
                        if (values[conditionVariable] == conditionAmount)
                            condition = true;
                        break;
                    case "!=":
                        if (values[conditionVariable] != conditionAmount)
                            condition = true;
                        break;
                }
                if (condition)
                {
                    if (operation == "dec")
                        amount *= -1;
                    values[variable] += amount;
                }
                //foreach(var pair in values)
                //{
                //    //Console.Write(pair.Key + " = " + pair.Value + "; ");
                //    max = pair.Value;
                //}
                //Console.WriteLine();

                if (values[variable] > max)
                    max = values[variable];
            }
            
            //foreach (var pair in values)
            //{
            //    if (pair.Value > max)
            //        max = pair.Value;
            //}
            Console.WriteLine(max);
        }
    }
}