using System;
using System.Collections.Generic;
using System.IO;

namespace Day_20.Particle_Swarm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            List<Particle> particles = new List<Particle>();
            for (int i = 0; i < lines.Length; i++)
            {
                particles.Add(new Particle(lines[i]));
            }

            //int minAcc = 100;
            //int minI = -1;
            //for(int i = 0; i < lines.Length; i++)
            //{
            //    if ((particles[i].acc[0] * particles[i].acc[0] + particles[i].acc[1] * particles[i].acc[1] + particles[i].acc[2] * particles[i].acc[2]) < minAcc)
            //    {
            //        //minAcc = Math.Abs(particles[i].acc[0]) + Math.Abs(particles[i].acc[1]) + Math.Abs(particles[i].acc[2]);
            //        minAcc = particles[i].acc[0]* particles[i].acc[0] + particles[i].acc[1]* particles[i].acc[1] + particles[i].acc[2]* particles[i].acc[2];
            //        minI = i;
            //    }
            //}

            for (int k = 0; k < particles.Count-1; k++)
            {
                for (int i = 0; i < particles.Count - 1; i++)
                {
                    if (particles[i + 1].compareTo(particles[i]) > 0)
                    {
                        Particle tmp = particles[i];
                        particles[i] = particles[i + 1];
                        particles[i + 1] = tmp;
                    }
                }
            }

            //for (int k = 0; k < particles.Count ; k++)
            //{
            //    Console.WriteLine(particles[k].ToString());
            //}
                int p = 0;
            while (true )
            {
                p++;
                for (int i = 0; i < particles.Count; i++)
                {
                    particles[i].move();
                }
                for (int i = 0; i < particles.Count; i++)
                {
                    bool remove = false;
                    for (int j = i + 1; j < particles.Count; j++)
                    {
                        if (particles[i].compareCoor(particles[j]))
                        {
                            remove = true;
                            particles.RemoveAt(j);
                            j--;
                        }
                    }
                    if (remove)
                    {
                        particles.RemoveAt(i);
                        i--;
                    }
                }

                bool sort = true;
                int l = 0;
                for (int i = 0; i < particles.Count - 1; i++)
                {
                    if (particles[i + 1].compareCoord(particles[i]) < 0)
                    {
                        sort = false;
                        l++; if (p % 1000 == 0)
                            Console.WriteLine(particles[i + 1]+ "!"+ particles[i]);
                        break;
                    }
                }
                if (sort)
                    return;

                if(p%1000==0)
                Console.WriteLine("p=" + p + " l=" + l + " left: " + particles.Count);

            }





            Console.WriteLine("left: " + particles.Count);

            //Console.WriteLine("minAcc: "+minAcc);
            //Console.WriteLine("minI: " + minI);
            //Console.WriteLine("" + particles[minI].ToString());
        }

        class Particle
        {
            public long[] coordinates;
            public long[] speed;
            public int[] acc;
            
            public Particle(string descriptionString)
            {
                string[] coordinatesS = descriptionString.Split('<')[1].Split('>')[0].Split(',');
                string []speedS = descriptionString.Split('<')[2].Split('>')[0].Split(',');
                string []accS = descriptionString.Split('<')[3].Split('>')[0].Split(',');

                coordinates = new long[] { long.Parse(coordinatesS[0]), long.Parse(coordinatesS[1]), long.Parse(coordinatesS[2]) };
                speed = new long[] { long.Parse(speedS[0]), long.Parse(speedS[1]), long.Parse(speedS[2]) };
                acc = new int[] { Convert.ToInt32(accS[0]), Convert.ToInt32(accS[1]), Convert.ToInt32(accS[2]) };
            }

            public override string ToString()
            {
                return "p=<" + coordinates[0] + "," + coordinates[1] + "," + coordinates[2] + ">, " +
                    "v=<" + speed[0] + "," + speed[1] + "," + speed[2] + ">, " +
                    "a=<" + acc[0] + "," + acc[1] + "," + acc[2] + ">";
            }
            public void move()
            {
                for(int i = 0; i < 3; i++)
                {
                    speed[i] += acc[i];
                    coordinates[i] += speed[i];
                }
            }

            public bool compareCoor(Particle other)
            {
                return (other.coordinates[0] == this.coordinates[0] && other.coordinates[1] == this.coordinates[1] && other.coordinates[2] == this.coordinates[2]);
            }

            public int compareTo(Particle other)
            {
                int accThisSum = this.acc[0] * this.acc[0] + this.acc[1] * this.acc[1] + this.acc[2] * this.acc[2];
                int accOtherSum = other.acc[0] * other.acc[0] + other.acc[1] * other.acc[1] + other.acc[2] * other.acc[2];

                if (accThisSum > accOtherSum)
                    return 1;
                else if (accOtherSum > accThisSum)
                    return -1;

                long speedThisSum = this.speed[0] * this.speed[0] + this.speed[1] * this.speed[1] + this.speed[2] * this.speed[2];
                long speedOtherSum = other.speed[0] * other.speed[0] + other.speed[1] * other.speed[1] + other.speed[2] * other.speed[2];

                if (speedThisSum > speedOtherSum)
                    return 1;
                else if (speedOtherSum > speedThisSum)
                    return -1;

                long coordsThisSum = this.coordinates[0] * this.coordinates[0] + this.coordinates[1] * this.coordinates[1] + this.coordinates[2] * this.coordinates[2];
                long coordsOtherSum = other.coordinates[0] * other.coordinates[0] + other.coordinates[1] * other.coordinates[1] + other.coordinates[2] * other.coordinates[2];

                if (coordsThisSum > coordsOtherSum)
                    return 1;
                else if (coordsOtherSum > coordsThisSum)
                    return -1;
                else return 0;
            }

            public int compareCoord(Particle other)
            {
                long coordsThisSum = this.coordinates[0] * this.coordinates[0] + this.coordinates[1] * this.coordinates[1] + this.coordinates[2] * this.coordinates[2];
                long coordsOtherSum = other.coordinates[0] * other.coordinates[0] + other.coordinates[1] * other.coordinates[1] + other.coordinates[2] * other.coordinates[2];

                if (coordsThisSum > coordsOtherSum)
                    return 1;
                else if (coordsOtherSum > coordsThisSum)
                    return -1;
                else return 0;


            }

                }
    }
}