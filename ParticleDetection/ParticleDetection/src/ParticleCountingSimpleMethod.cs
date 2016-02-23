using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleDetection.src
{
    /// <summary>
    /// Class for demonstrating a simple method for counting particles.
    /// </summary>
    class ParticleCountingSimpleMethod
    {
        /// <summary>
        /// Estimate of simple method.
        /// </summary>
        public double estimate = 0.0;

        /// <summary>
        /// Method counts an estimate of number of particles in image.
        /// </summary>
        /// <param name="areas">areas</param>
        /// <param name="buttonName">name of selected button</param>
        public void SimpleMethod(int[] areas, string buttonName)
        {
            if(estimate != 0)
                estimate = 0; // set estimate to zero

            double Aref = FindAref(areas, buttonName);
            
            foreach (int j in areas)
            {
                estimate += (double) j / Aref;
            }

        }

        /// <summary>
        /// Returns the reference area. 
        /// </summary>
        /// <param name="areas">areas</param>
        /// <param name="buttonName">name of selected button</param>
        /// <returns>reference area</returns>
        private double FindAref(int[] areas, string buttonName)
        {
            double Aref = 0;

            Array.Sort(areas);

            if (buttonName.Equals("average"))
            {
                foreach (int i in areas)
                {
                    Aref += i;
                }
                Aref = Aref / areas.Length; // average
            }
            else if (buttonName.Equals("median"))
            {
                if (areas.Length % 2 == 0)
                {
                    int index = areas.Length / 2;
                    Aref = (double)((areas[index - 1] + areas[index]) / 2); // median
                }
                else
                {
                    int index = areas.Length / 2;
                    Aref = (double)areas[index]; // median
                }
            }
            else if (buttonName.Equals("firstQuartile"))
            {
                int index = areas.Length / 4;
                if (index % 2 == 0)
                    Aref = (double) ((areas[index - 1] + areas[index]) / 2);
                else
                    Aref = (double) areas[index];
            }
            else if (buttonName.Equals("thirdQuartile"))
            {
                int index = areas.Length / 4;
                if (index % 2 == 0)
                    Aref = (double)((areas[index + index*2 - 1] + areas[index + index*2]) / 2);
                else
                    Aref = (double)areas[index + index*2];
            }

            return Aref;
        }

        // ********************** GETTERS ******************************

        /// <summary>
        /// Return an estimate of number of particles in image.
        /// </summary>
        /// <returns></returns>
        public string GetEstimate()
        {
            return estimate.ToString("R");
        }
        
    }

    
}
