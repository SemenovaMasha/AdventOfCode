using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_21.Fractal_Art
{
    public class Class1
    {
        public Class1() 
        {
        }

        void p()
        //static void Main(string[] args)
        {
            Pattern inputPattern = new Pattern(new List<string> {
            ".#.",
            "..#",
            "###"
        });

            List<Rule> rules = new List<Rule>();
            var rulesRegex = new Regex(@"(.+) => (.+)");
            foreach (var line in File.ReadAllLines("../../input.txt"))
            {
                var groups = rulesRegex.Match(line).Groups;
                rules.Add(new Rule(groups[1].Value, groups[2].Value));
            }

            for (int z = 0; z < 10; z++)
            {
                var newPattern = Slice(inputPattern, inputPattern.Length() % 2 == 0 ? 2 : 3);
                newPattern = Increase(newPattern, rules);

                inputPattern.print();
                inputPattern = Join(newPattern);
                Console.WriteLine();
            }

            Console.WriteLine( inputPattern.Count(true));
        }

        public static Pattern Join(List<List<Pattern>> patterns)
        {
            Pattern newPattern = new Pattern();

            int newSize = -1;

            for (var y = 0; y < patterns.Count; y++)
            {
                for (var x = 0; x < patterns[y].Count; x++)
                {
                    for (var i = 0; i < patterns[y][x].Content.Count; i++)
                    {
                        if (newSize == -1 && y == 0)
                        {
                            if (newPattern.Content.Count <= i)
                                newPattern.Content.Add("");

                            newPattern.Content[i] += patterns[y][x].Content[i];
                        }
                        else if (newSize == -1)
                        {
                            newSize = newPattern.Content.Count;
                            if (newPattern.Content.Count <= i + y * newSize)
                                newPattern.Content.Add("");

                            newPattern.Content[i + y * newSize] += patterns[y][x].Content[i];
                        }
                        else
                        {
                            if (newPattern.Content.Count <= i + y * newSize)
                                newPattern.Content.Add("");

                            newPattern.Content[i + y * newSize] += patterns[y][x].Content[i];
                        }

                    }
                }
            }

            return newPattern;
        }

        public static List<List<Pattern>> Increase(List<List<Pattern>> patterns, List<Rule> rules)
        {
            foreach (var patternSub in patterns)
            {
                for (var i = 0; i < patternSub.Count; i++)
                {
                    var pattern = patternSub[i];
                    foreach (var rule in rules)
                    {
                        if (rule.Matches(pattern))
                        {
                            patternSub[i] = rule.To;
                            break;
                        }
                    }
                }
            }

            return patterns;
        }

        public static List<List<Pattern>> Slice(Pattern input, int size)
        {
            List<List<Pattern>> newPattern = new List<List<Pattern>>();

            for (int y = 0; y < input.Length() / size; y++)
            {
                newPattern.Add(new List<Pattern>());
                for (int x = 0; x < input.Length() / size; x++)
                {
                    newPattern[y].Add(new Pattern(size));
                }
            }

            for (int y = 0; y < input.Length(); y++)
            {
                for (int x = 0; x < input.Length() / size; x++)
                {
                    newPattern[y / size][x].Content[y % size] = input.Content[y].Substring(x * size, size);
                }
            }

            return newPattern;
        }
    }
    public class Pattern
    {
        public List<string> Content { get; set; }

        public Pattern(List<string> content)
        {
            Content = content;
        }

        public Pattern(int size) : this()
        {
            for (int i = 0; i < size; i++)
            {
                Content.Add(new string(' ', size));
            }
        }

        public Pattern()
        {
            Content = new List<string>();
        }

        public int Length()
        {
            return Content[0].Length;
        }

        public static bool operator ==(Pattern first, Pattern second)
        {
            if (first.Length() != second.Length())
                return false;

            for (var i = 0; i < first.Content.Count; i++)
            {
                if (first.Content[i] != second.Content[i])
                    return false;
            }

            return true;
        }

        public static bool operator !=(Pattern first, Pattern second)
        {
            return !(first == second);
        }

        public int Count(bool on)
        {
            return Content.Sum(line => line.Count(c => on && c == '#' || !on && c == '.'));
        }
        public void print()
        {
            for (int i = 0; i < Content.Count; i++)
            {
                Console.WriteLine(Content[i]);
            }

        }
    }
    public class Rule
    {
        public List<Pattern> Froms { get; set; }
        public Pattern To { get; set; }

        public Rule(Pattern from, Pattern to)
        {
            To = to;

            GenerateFroms(from);
        }

        public Rule(string from, string to)
        {
            Pattern fromPattern = new Pattern();
            Froms = new List<Pattern>();
            To = new Pattern();

            foreach (var line in from.Split('/'))
            {
                fromPattern.Content.Add(line);
            }
            foreach (var line in to.Split('/'))
            {
                To.Content.Add(line);
            }

            GenerateFroms(fromPattern);
        }

        private void GenerateFroms(Pattern from)
        {
            Froms.Add(Rotate(from));
            for (int z = 0; z < 3; z++)
            {
                Froms.Add(Rotate(Froms.Last()));
            }

            from = FlipY(from);
            Froms.Add(Rotate(from));
            for (int z = 0; z < 3; z++)
            {
                Froms.Add(Rotate(Froms.Last()));
            }

            from = FlipX(from);
            Froms.Add(Rotate(from));
            for (int z = 0; z < 3; z++)
            {
                Froms.Add(Rotate(Froms.Last()));
            }

            from = FlipY(from);
            Froms.Add(Rotate(from));
            for (int z = 0; z < 3; z++)
            {
                Froms.Add(Rotate(Froms.Last()));
            }

            from = FlipX(from);
            Froms.Add(Rotate(from));
            for (int z = 0; z < 3; z++)
            {
                Froms.Add(Rotate(Froms.Last()));
            }
        }

        private Pattern FlipY(Pattern pattern)
        {
            Pattern newPattern = new Pattern(pattern.Length());

            for (int i = 0; i < newPattern.Length(); i++)
            {
                newPattern.Content[i] = pattern.Content[i];
            }

            newPattern.Content.Reverse();

            return newPattern;
        }

        private Pattern FlipX(Pattern pattern)
        {
            Pattern newPattern = new Pattern(pattern.Length());

            for (int i = 0; i < newPattern.Length(); i++)
            {
                newPattern.Content[i] = pattern.Content[i];
                newPattern.Content[i].Reverse();
            }

            return newPattern;
        }

        private Pattern Rotate(Pattern from)
        {
            var pattern = new Pattern(from.Length());


            for (var i = from.Content.Count - 1; i >= 0; i--)
            {
                for (var j = 0; j < from.Content[i].Length; j++)
                {
                    var sb = new StringBuilder(pattern.Content[j]);
                    sb[from.Content.Count - 1 - i] = from.Content[i][j];
                    pattern.Content[j] = sb.ToString();
                }
            }

            return pattern;
        }

        public bool Matches(Pattern input)
        {
            return Froms.Any(pattern => input == pattern);
        }
    }
}
