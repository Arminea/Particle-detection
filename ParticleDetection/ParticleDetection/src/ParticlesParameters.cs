using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ParticleDetection.src
{
    /// <summary>
    /// Class for particle detection in image. 
    /// </summary>
    class ParticlesParameters
    {
        /// <summary>
        /// Bitmap with generated particles.
        /// </summary>
        private Bitmap bitmap;

        /// <summary>
        /// Number of founded particles.
        /// </summary>
        private int numberOfParticles;

        /// <summary>
        /// Areas of particles.
        /// </summary>
        private List<int> areas;

        /// <summary>
        /// Perimeters of particles.
        /// </summary>
        private List<int> perimeters;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bitmap">bitmap</param>
        public ParticlesParameters(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            numberOfParticles = 0;

            areas = new List<int>();
            List<List<Point>> particles = CountAreas(bitmap);

            perimeters = new List<int>();
            CountPerimeters(bitmap, particles);

            //Debug();
        }

        /// <summary>
        /// Counts perimeters of particles in image.
        /// </summary>
        /// <param name="bitmap">bitmap</param>
        /// <param name="particles">list of particles points</param>
        private void CountPerimeters(Bitmap bitmap, List<List<Point>> particles)
        {
            Bitmap tempBitmap = new Bitmap(bitmap); // new object of bitmap, because we don't want to change the original one
            int[,] erosionMask = new int[,] { 
                                             { 1, 1, 1, }, 
                                             { 1, 1, 1, }, 
                                             { 1, 1, 1, }
                                            };

            foreach(List<Point> list in particles) // use morfological transformation on each particle
            {
                for (int p = 0; p < list.Count; p++)
                {
                    bool isErosion = true;
                    int currI = list.ElementAt(p).GetI();
                    int currJ = list.ElementAt(p).GetJ();
                    
                    for (int i = currI - 1; i < (currI + 2); i++) // do the thing!
                    {
                        for (int j = currJ - 1; j < (currJ + 2); j++)
                        {
                            if (tempBitmap.GetPixel(i, j).ToArgb() == Color.Black.ToArgb())
                            {
                                isErosion = false;
                                goto End;
                            }
                        }
                    }
                    End:

                    if (isErosion == true)
                        list[p] = null;
                }

                list.RemoveAll(delegate (Point p) { return p == null; }); // remove all null elements
                perimeters.Add(list.Count);
            }
        }
        
        /// <summary>
        /// Counts areas of particles in image.
        /// </summary>
        /// <param name="bitmap">bitmap</param>
        private List<List<Point>> CountAreas(Bitmap bitmap)
        {
            Bitmap tempBitmap = new Bitmap(bitmap); // new object of bitmap, because we don't want to change the original one
            List<List<Point>> particles = new List<List<Point>>();

            for (int i = 0; i < tempBitmap.Width; i++)
            {
                for(int j = 0; j < tempBitmap.Height; j++)
                {
                    Color clr = tempBitmap.GetPixel(i, j);

                    if (clr.ToArgb() == Color.Red.ToArgb()) // for every pixel we want to know if its' red
                    {
                        numberOfParticles++; // new particle was found
                        List<Point> points = SearchNearby(i, j, tempBitmap); // search around
                        areas.Add(points.Count);
                        particles.Add(points);
                    }
                }
            }
            Console.WriteLine("Nalezeno " + numberOfParticles + " castic.");
            return particles;
        }

        /// <summary>
        /// Method for searching for another red points nearby.
        /// </summary>
        /// <param name="i">i axis</param>
        /// <param name="j">j axis</param>
        /// <param name="tempBitmap">temp bitmap</param>
        /// <returns></returns>
        private List<Point> SearchNearby(int i, int j, Bitmap tempBitmap)
        {
            List<Point> points = new List<Point>();
            Stack<Point> stack = new Stack<Point>(); // stack of points

            points.Add(new Point(i, j));
            stack.Push(new Point(i, j));

            while (stack.Any())
            {
                Point currPoint = stack.Pop(); // get first from top of the stack
                int currI = currPoint.GetI();
                int currJ = currPoint.GetJ();
                tempBitmap.SetPixel(currI, currJ, Color.Black); // paint it black

                for (int x = currI - 1; x < (currI + 2); x++)
                {
                    for (int y = currJ - 1; y < (currJ + 2); y++)
                    {
                        if (currI == x && currJ == y)
                            continue;
                        
                        if (tempBitmap.GetPixel(x, y).ToArgb() == Color.Red.ToArgb() && IsInStack(x, y, stack) == false)
                        {
                            stack.Push(new Point(x, y));
                            points.Add(new Point(x, y));
                        }
                    }
                }
            }

            return points;
        }

        /// <summary>
        /// Is point already in the stack?
        /// </summary>
        /// <param name="x">x axis</param>
        /// <param name="y">y axis</param>
        /// <param name="stack">stack</param>
        /// <returns></returns>
        private bool IsInStack(int x, int y, Stack<Point> stack)
        {
            foreach(Point p in stack)
            {
                if (p.GetI() == x && p.GetJ() == y)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns array of areas.
        /// </summary>
        /// <returns></returns>
        public int[] GetAreas()
        {
            return areas.ToArray();
        }

        /// <summary>
        /// Returns array of perimeters.
        /// </summary>
        /// <returns></returns>
        public int[] GetPerimeters()
        {
            return perimeters.ToArray();
        }

        /// <summary>
        /// Returns number of founded particles.
        /// </summary>
        /// <returns>number of particles</returns>
        public String GetNumberOfParticles()
        {
            return numberOfParticles.ToString();
        }

        /// <summary>
        /// Debug perimeters and areas.
        /// </summary>
        private void Debug()
        {
            Console.WriteLine("Perimeters and areas");
            for (int i = 0; i < numberOfParticles; i++)
            {
                Console.WriteLine("Perimeter: " + perimeters.ElementAt(i) + ", area: " + areas.ElementAt(i));
            }
            Console.WriteLine("--------------------------------");
        }

        /// <summary>
        /// Debug list.
        /// </summary>
        /// <param name="list">list</param>
        private void DebugList(List<Point> list)
        {
            string s = "";
            foreach (Point p in list)
            {
                s += "<" + p.GetI() + "," + p.GetJ() + "> ";
            }
            Console.WriteLine(s);
        }

        /// <summary>
        /// Auxiliery class for storing points in stack.
        /// </summary>
        private class Point
        {
            /// <summary>
            /// i axis
            /// </summary>
            private int i;

            /// <summary>
            /// j axis
            /// </summary>
            private int j;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="i">i axis</param>
            /// <param name="j">j axis</param>
            public Point(int i, int j)
            {
                this.i = i;
                this.j = j;
            }

            /// <summary>
            /// Return i axis.
            /// </summary>
            /// <returns></returns>
            public int GetI()
            {
                return i;
            }

            /// <summary>
            /// Returns j axis.
            /// </summary>
            /// <returns></returns>
            public int GetJ()
            {
                return j;
            }
        }
    }
}
