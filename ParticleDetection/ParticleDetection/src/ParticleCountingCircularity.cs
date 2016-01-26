using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleDetection.src
{
    /// <summary>
    /// Class for demonstrating a counting particles using circularity.
    /// </summary>
    class ParticleCountingCircularity
    {
        /// <summary>
        /// Estimate of histogram method.
        /// </summary>
        public double estimate = 0.0;

        private double kParam = 10;

        private double lParam = 5;

        private const double CIRCULARITY = 4 * Math.PI;


        public void Circularity(int[] perimeters, int[] areas)
        {
            double[] vol = CountVolume(perimeters, areas);


        }


        private double[] CountVolume(int[] perimeters, int[] areas)
        {
            double[] vol = new double[areas.Length];

            for (int i = 0; i < vol.Length; i++)
            {
                vol[i] = Math.Pow(perimeters[i], 2) / areas[i];
            }

            return vol;
        }


        /// <summary>
        /// Return an estimate of number of particles in image.
        /// </summary>
        /// <returns></returns>
        public string GetEstimate()
        {
            return estimate.ToString("R");
        }


        // *********************** SETTERS **********************

        public void SetK(double newK)
        {
            this.kParam = newK;
        }


        public void SetL(double newL)
        {
            this.lParam = newL;
        }
    }
}
