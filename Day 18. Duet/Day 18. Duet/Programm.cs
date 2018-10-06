using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day_18.Duet
{
    class Programm
    {
        void st()
        //static void Main(string[] args)
        {
            string[] instructions = File.ReadAllLines("input.txt");

            var p0 = new Programm(0, instructions);
            var p1 = new Programm(1, instructions);

            p0.OtherQueue = p1.Queue;
            p1.OtherQueue = p0.Queue;

            do
            {
                p1.Run();
                p0.Run();
            } while (p1.Queue.Count != 0);


            File.WriteAllText("output.txt", s);
            Console.WriteLine(p1.SendCounter);

            Console.WriteLine("Steps1: " + p0.SendCounter);
            Console.WriteLine("Steps2: " + p1.SendCounter);
        }
        static string s = "";
        const string SND = "snd";
        const string SET = "set";
        const string ADD = "add";
        const string MUL = "mul";
        const string MOD = "mod";
        const string RCV = "rcv";
        const string JGZ = "jgz";

        private long curr = 0;
        private string[] instructions;
        private Dictionary<string, long> registers = new Dictionary<string, long>();

        public long SendCounter { get; set; }

        public Queue<long> Queue { get; }

        public Queue<long> OtherQueue { get; set; }

        public string Name { get; set; }

        public int Steps { get; set; }

        public Programm(int pValue, string[] instructions)
        {
            this.registers.Add("p", pValue);
            this.instructions = instructions;
            this.Queue = new Queue<long>();
            this.Name = pValue.ToString();
            this.Steps = 0;
        }

        public void Run()
        {
            string instruction = string.Empty;

            while (true)
            {
                //Console.WriteLine("Program {0}: {1}", this.Name, instructions[curr]);
                //s += this.Name + " " + instructions[curr] + "\r\n";
                Steps++;
                var tokens = instructions[curr].Split(' ');
                instruction = tokens[0];

                string register = tokens[1];

                if (!registers.ContainsKey(register))
                {
                    long literal;
                    if (!long.TryParse(register, out literal))
                    {
                        literal = 0;
                    }

                    registers.Add(register, literal);
                }

                long value = 0;
                if (tokens.Length > 2)
                {
                    if (registers.ContainsKey(tokens[2]))
                    {
                        value = registers[tokens[2]];
                    }
                    else
                    {
                        value = long.Parse(tokens[2]);
                    }
                }

                long offset = 1;
                switch (instruction)
                {
                    case SND:
                        this.OtherQueue.Enqueue(registers[register]);

                        Console.WriteLine("{0} send {1}", this.Name, registers[register]);
                        //s += this.Name + " send " + registers[register] + "\r\n";
                        this.SendCounter++;
                        break;
                    case SET:
                        registers[register] = value;
                        break;
                    case ADD:
                        registers[register] += value;
                        break;
                    case MUL:
                        registers[register] *= value;
                        break;
                    case MOD:
                        registers[register] %= value;
                        break;
                    case RCV:
                        if (this.Queue.Count > 0)
                        {
                            registers[register] = this.Queue.Dequeue();

                            Console.WriteLine("{0} receive {1}", this.Name, registers[register]);

                            s += this.Name + " receive " + registers[register] + "\r\n";
                            if (registers[register] == 1342)
                            {
                                foreach (var pair in registers)
                                {
                                    Console.WriteLine("{0} = {1}", pair.Key, pair.Value);

                                    s += pair.Key + " = " + pair.Value + "\r\n";
                                }

                            }
                        }
                        else
                        {
                            foreach (var pair in registers)
                            {
                                Console.WriteLine("{0} = {1}", pair.Key, pair.Value);

                                s += pair.Key + " = " + pair.Value + "\r\n";
                            }

                            return;
                        }
                        break;
                    case JGZ:
                        if (registers[register] > 0)
                        {
                            offset = value;
                        }
                        break;
                }

                curr += offset;
            }
        }
    }
}
