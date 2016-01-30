using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParticleDetection.src
{
    /// <summary>
    /// Class for demonstrating a histogram method for counting particles.
    /// </summary>
    class ParticleCountingHistogramMethod
    {
        /// <summary>
        /// Estimate of histogram method.
        /// </summary>
        public double estimate = 0.0;

        /// <summary>
        /// Auxiliary array.
        /// </summary>
        private List<Aux> auxArray;

        /// <summary>
        /// Method for pre-calculations. 
        /// </summary>
        /// <param name="numberOfintervals">number of intervals</param>
        /// <param name="areas">areas</param>
        public void HistogramMethod(int numberOfintervals, int[] areas)
        {
            if (estimate != 0)
                estimate = 0; // set estimate to zero

            int min = GetMin(areas);
            int max = GetMax(areas);
            double size = (max - min) / numberOfintervals;
            
            auxArray = new List<Aux>();

            foreach (int ar in areas)
            {
                bool matchFound = false;

                foreach (Aux aux in auxArray)
                {
                    if (aux.GetArea() == ar)
                    {
                        matchFound = true;
                        aux.UpdateFrequency();
                    }
                }

                if (matchFound == false)
                    auxArray.Add(new Aux(ar, 0, 1));
            }

            auxArray.Sort(); // sort array by areas
            
            foreach (Aux a in auxArray)
            {
                int interval = 0;
                if (size > 0.0)
                {
                    interval = (int)((a.GetArea() - min) / size);
                    if (interval == numberOfintervals)
                        interval--;
                }
                a.SetInterval(interval);
            }

            Debug();

            int maxInterval = GetMaxIndex(auxArray, numberOfintervals);
            //Console.WriteLine("maxInterval: " + maxInterval);
            double Aref = FindAref(auxArray, maxInterval);
            
            Counting(Aref, auxArray);
        }

        /// <summary>
        /// Counts the estimate of number of particles in image.
        /// </summary>
        /// <param name="Aref">reference area</param>
        /// <param name="auxArray">auxiliary array</param>
        private void Counting(double Aref, List<Aux> auxArray)
        {
            foreach (Aux a in auxArray)
            {
                if (a.GetArea() >= Aref)
                    estimate += (double)(a.GetFrequency() * (a.GetArea() / Aref));
            }
        }

        /// <summary>
        /// Returns the reference area.
        /// </summary>
        /// <param name="auxArray">auxiliary array</param>
        /// <param name="maxInterval">interval with max sum of areas</param>
        /// <returns></returns>
        private double FindAref(List<Aux> auxArray, int maxInterval)
        {
            double Aref = int.MaxValue;

            for (int j = 0; j < auxArray.Count; j++)
            {
                if (auxArray[j].GetInterval() == maxInterval && auxArray[j].GetArea() < Aref)
                    Aref = auxArray[j].GetArea(); // lower limit of max interval
            }
          
            Console.WriteLine(Aref);
            
            return Aref;
        }

        /// <summary>
        /// Method for getting the interval with the maximum sum of areas.
        /// </summary>
        /// <param name="auxArray">auxiliary array</param>
        /// <param name="numberOfintervals">number of intervals</param>
        /// <returns></returns>
        private int GetMaxIndex(List<Aux> auxArray, int numberOfintervals)
        {
            int[] sumOfParticlesInInterval = new int[auxArray.Count];
            int[] intervalnumber = new int[auxArray.Count];

            for (int i = 0; i < numberOfintervals; i++)
            {
                int sum = 0;
                foreach (Aux a in auxArray)
                {
                    if (a.GetInterval() == i)
                        sum++;
                }
                try
                {
                    sumOfParticlesInInterval[i] = sum;
                    intervalnumber[i] = i;
                } catch(IndexOutOfRangeException e)
                {
                    continue;
                }
                
            }
            
            int max = int.MinValue;
            int returnValue = 0;

            for (int s = 0; s < sumOfParticlesInInterval.Length; s++)
            {
                if (sumOfParticlesInInterval[s] > max)
                {
                    max = sumOfParticlesInInterval[s];
                    returnValue = s;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Returns minimum value from array.
        /// </summary>
        /// <param name="array">array</param>
        /// <returns>min value</returns>
        private int GetMin(int[] array)
        {
            int min = int.MaxValue;
            foreach (int a in array)
            {
                if (a < min)
                    min = a;
            }
            return min;
        }

        /// <summary>
        /// Returns maximum value from array.
        /// </summary>
        /// <param name="array">array</param>
        /// <returns>max value</returns>
        private int GetMax(int[] array)
        {
            int max = int.MinValue;
            foreach (int a in array)
            {
                if (a > max)
                    max = a;
            }
            return max;
        }

        /// <summary>
        /// Return an estimate of number of particles in image.
        /// </summary>
        /// <returns></returns>
        public string GetEstimate()
        {
            return estimate.ToString("R");
        }

        // ******************************* DEBUG *****************************
        private void Debug()
        {
            for (int i = 0; i < auxArray.Count; i++)
            {
                Console.WriteLine("Area " + auxArray.ElementAt(i).GetArea() + ": " + auxArray.ElementAt(i).GetInterval() + ", " + auxArray.ElementAt(i).GetFrequency());
            }
            Console.WriteLine("--------------");
        }

        /// <summary>
        /// Class of auxiliary object.
        /// </summary>
        private class Aux : IComparable<Aux>
        {
            /// <summary>
            /// Area of particle.
            /// </summary>
            int area;

            /// <summary>
            /// Interval of particle with this area.
            /// </summary>
            int interval;
            
            /// <summary>
            /// How much particles with this area are in image.
            /// </summary>
            int frequency;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="area">area</param>
            /// <param name="interval">interval</param>
            /// <param name="frequency">frequency</param>
            public Aux(int area, int interval, int frequency)
            {
                this.interval = interval;
                this.area = area;
                this.frequency = frequency;
            }

            /// <summary>
            /// Compare method for sorting list by area.
            /// </summary>
            /// <param name="a">area</param>
            /// <returns>value that specifies the relative ranking compared objects</returns>
            public int CompareTo(Aux a)
            {
                return this.area.CompareTo(a.area);
            }

            /// <summary>
            /// Increments value of frequency.
            /// </summary>
            public void UpdateFrequency()
            {
                frequency++;
            }

            // ********************** GETTERS *************************

            /// <summary>
            /// Returns an area.
            /// </summary>
            /// <returns>area</returns>
            public int GetArea()
            {
                return area;
            }

            /// <summary>
            /// Returns an interval.
            /// </summary>
            /// <returns>interval</returns>
            public int GetInterval()
            {
                return interval;
            }

            /// <summary>
            /// Return a frequency.
            /// </summary>
            /// <returns>frequency</returns>
            public int GetFrequency()
            {
                return frequency;
            }

            // ********************** SETTERS **************************

            /// <summary>
            /// Sets a new value of interval.
            /// </summary>
            /// <param name="newInterval">new interval</param>
            public void SetInterval(int newInterval)
            {
                this.interval = newInterval;
            }
        }
    }
}
