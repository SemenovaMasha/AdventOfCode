using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_25.The_Halting_Problem
{
    class Program
    {
        static List<bool> tape = new List<bool>();
        static void Main(string[] args)
        {
            tape.Add(false);
            int cursor = 0;

            char currentState = 'A';

            for(int step = 0; step < 12368930; step++)
            {
                switch (currentState)
                {
                    case 'A':
                        if (!tape[cursor])
                        {
                            tape[cursor] = true;
                            cursor = moveRight(cursor);
                            currentState = 'B';
                        }
                        else
                        {
                            tape[cursor] = false;
                            cursor = moveRight(cursor);
                            currentState = 'C';
                        }
                        break;
                    case 'B':
                        if (!tape[cursor])
                        {
                            tape[cursor] = false;
                            cursor = moveLeft(cursor);
                            currentState = 'A';
                        }
                        else
                        {
                            tape[cursor] = false;
                            cursor = moveRight(cursor);
                            currentState = 'D';
                        }
                        break;
                    case 'C':
                        if (!tape[cursor])
                        {
                            tape[cursor] = true;
                            cursor = moveRight(cursor);
                            currentState = 'D';
                        }
                        else
                        {
                            tape[cursor] = true;
                            cursor = moveRight(cursor);
                            currentState = 'A';
                        }
                        break;
                    case 'D':
                        if (!tape[cursor])
                        {
                            tape[cursor] = true;
                            cursor = moveLeft(cursor);
                            currentState = 'E';
                        }
                        else
                        {
                            tape[cursor] = false;
                            cursor = moveLeft(cursor);
                            currentState = 'D';
                        }
                        break;
                    case 'E':
                        if (!tape[cursor])
                        {
                            tape[cursor] = true;
                            cursor = moveRight(cursor);
                            currentState = 'F';
                        }
                        else
                        {
                            tape[cursor] = true;
                            cursor = moveLeft(cursor);
                            currentState = 'B';
                        }
                        break;
                    case 'F':
                        if (!tape[cursor])
                        {
                            tape[cursor] = true;
                            cursor = moveRight(cursor);
                            currentState = 'A';
                        }
                        else
                        {
                            tape[cursor] = true;
                            cursor = moveRight(cursor);
                            currentState = 'E';
                        }
                        break;
                }
                if (step % 10000 == 0)
                    Console.WriteLine(step);
            }
                print();

            int count = 0;
            foreach (bool b in tape)
            {
                if (b) count++;
            }
            Console.WriteLine(count);

        }
        static int moveRight(int oldCursor)
        {
            oldCursor++;
            if (oldCursor == tape.Count) tape.Add(false);
            return oldCursor;
        }
        static int moveLeft(int oldCursor)
        {
            oldCursor--;
            if (oldCursor == -1)
            {
                tape.Insert(0, false);
                oldCursor = 0;
            }
            return oldCursor;
        }
        static void print()
        {
            foreach(bool b in tape)
            {
                Console.Write(b ? "1 " : "0 ");
            }
            Console.WriteLine();
        }
    }
}
