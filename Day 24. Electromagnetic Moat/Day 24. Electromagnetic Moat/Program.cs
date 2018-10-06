using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_24.Electromagnetic_Moat
{
    class Program
    {
        static List<Component> components = new List<Component>();
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../input.txt");

            foreach(string line in lines)
            {
                string[] pinsStr = line.Split('/');
                Component newComponent = new Component(Convert.ToInt32(pinsStr[0]), Convert.ToInt32(pinsStr[1]));
                if (!containComponent(components, newComponent))
                    components.Add(newComponent);
                else Console.WriteLine(pinsStr);
            }

            int startPin = 0;

            maxWeight(new List<Component>(), 0, 0,"");

            Console.WriteLine(maxWe);
            Console.WriteLine(maxLenght);
        }
        static int maxLenght = 0;
        static int maxWe = 0;
        static void maxWeight(List<Component> currentList,int pinToConnect, int currentWeight,string currentS)
        {
            foreach(Component c in components)
            {
                if (c.containsPin(pinToConnect) && !containComponent(currentList, c))
                {
                    List<Component> newList = copyList(currentList);
                    newList.Add(c);
                    
                    maxWeight(newList, c.otherPin(pinToConnect), currentWeight + c.weight(),currentS+" "+c);

                    //Console.WriteLine(weightOfList(newList)+"! "+currentS );
                    //Console.WriteLine(currentS + " " + c + " " + currentWeight + " " + c.weight());
                    //Console.WriteLine(currentWeight + c.weight());
                    //Console.WriteLine(weightOfList(newList));
                    if (newList.Count>maxLenght|| newList.Count == maxLenght&&weightOfList(newList) > maxWe) {
                        maxLenght = newList.Count;
                        maxWe = weightOfList(newList); }
                }
            }
            
        }
        static int weightOfList(List<Component> list)
        {
            int weight = 0;
            foreach (Component c in list)
                weight += c.weight();
            return weight;
        }
        class Component {
            int port1;
            int port2;
            public Component(int p1,int p2)
            {
                port1 = p1;
                port2 = p2;
            }

            public bool equal(Component other)
            {
                return (this.port1 == other.port1 && this.port2 == other.port2) || (this.port2 == other.port1 && this.port1 == other.port2);
            }
            public bool containsPin(int pin)
            {
                return port1 == pin || port2 == pin;
            }
            public int otherPin(int pin)
            {
                if (port1 == pin) return port2;
                if (port2 == pin) return port1;
                throw new Exception("hmm");
                return -1;
            }
            public int weight()
            {
                return port1 + port2;
            }
            public override string ToString()
            {
                return port1 + "/" + port2;
            }
        }
        static bool containComponent(List<Component> list,Component comp)
        {
            foreach(Component c in list)
            {
                if (comp.equal(c)) return true;
            }
            return false;
        }

        static List<Component> copyList(List<Component> toCopy)
        {
            List<Component> newList = new List<Component>();
            foreach(Component c in toCopy)
            {
                newList.Add(c);
            }
            return newList;
        }
    }
}
