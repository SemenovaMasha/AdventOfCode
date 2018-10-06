using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_9.Stream_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = File.ReadAllLines("input.txt")[0];

            List<char> chars = str.ToCharArray().ToList();

            for (int i = 0; i < chars.Count - 1; i++)
            {
                if (chars[i] == '!')
                {
                    chars.RemoveAt(i);
                    chars.RemoveAt(i);
                    i--;
                }
            }

            print(chars);
            int removeCount = 0;
            for (int i = 0; i < chars.Count - 1; i++)
            {
                if (chars[i] == '<')
                {
                    int j = i;
                    for (; j < chars.Count && chars[j] != '>';)
                    {
                        chars.RemoveAt(j);
                        removeCount++;
                    }
                    removeCount--;
                    chars.RemoveAt(j);
                    i--;
                }
            }
            chars.RemoveAll(c=>c==',');

            var MyStack = new Stack<char>();
            int sum = 0;
            for (int i = 0; i < chars.Count ; i++)
            {
                if (chars[i] == '{')
                {
                    MyStack.Push('{');
                }
                else
                {
                    sum += MyStack.Count;
                    MyStack.Pop();
                }
            }

            print(chars);

            Console.WriteLine(removeCount);
            Console.ReadKey();
        }

        static void print(List<char> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                Console.Write(a[i]);
            }
            Console.WriteLine();
        }
    }
}