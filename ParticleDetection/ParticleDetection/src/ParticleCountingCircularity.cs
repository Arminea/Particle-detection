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

        /// <summary>
        /// 'k' parameter.
        /// </summary>
        private double kParam = 1;

        /// <summary>
        /// 'l' parameter.
        /// </summary>
        private double lParam = 1;

        /// <summary>
        /// Circularity.
        /// </summary>
        private const double CIRCULARITY = 4 * Math.PI;


        public void Circularity(int[] perimeters, int[] areas)
        {
            // volume - parameter of circularity
            double[] vol = CountVolume(perimeters, areas);

            double Aref = FindAref(vol, areas);

            double[] w = CountMultiplicity(areas, Aref);

            int[] ST = NumberOfSingleParticlesInStain(vol, w);

            estimate = CountEstimate(ST);
        }

        /// <summary>
        /// Method counts an estimate of number of particles in image.
        /// </summary>
        /// <param name="ST">numbers of single particles in stain</param>
        /// <returns>estimate of number of particles in image</returns>
        private double CountEstimate(int[] ST)
        {
            double estimate = 0;

            foreach(int st in ST)
            {
                estimate += st;
            }

            return estimate;
        }
        
        /// <summary>
        /// Counts multiplicity of single particles in stain.
        /// Parameters 'k' and 'l' tune the system.
        /// </summary>
        /// <param name="vol">volumes</param>
        /// <param name="w">multiplicities</param>
        /// <returns>estimates of single particles in stain</returns>
        private int[] NumberOfSingleParticlesInStain(double[] vol, double[] w)
        {
            int[] ST = new int[vol.Length];

            for(int i = 0; i < vol.Length; i++)
            {
                ST[i] = (int) Math.Round((kParam * vol[i] + lParam* w[i]) / (kParam+lParam));
            }

            return ST;
        }

        /// <summary>
        /// Returns multiplicity of particles.
        /// </summary>
        /// <param name="areas">areas</param>
        /// <param name="aref">reference area</param>
        /// <returns>multiplicities</returns>
        private double[] CountMultiplicity(int[] areas, double Aref)
        {
            double[] w = new double[areas.Length];

            for(int i = 0; i < areas.Length; i++)
            {
                w[i] = (double) (areas[i] / Aref);
            }

            return w;
        }

        /// <summary>
        /// Returns reference area.
        /// </summary>
        /// <param name="vol">volumes</param>
        /// <returns>reference area</returns>
        private double FindAref(double[] vol, int[] areas)
        {
            double Aref = 0;
            int m = 0;
            for(int i = 0; i< vol.Length; i++)
            {
                if (Math.Round(vol[i]) == 1)
                {
                    Aref += areas[i];
                    m++;
                }
            }

            Aref = Aref / (double) m;
            return Aref;
        }

        /// <summary>
        /// Returns volumes of particles.
        /// </summary>
        /// <param name="perimeters">perimeters</param>
        /// <param name="areas">areas</param>
        /// <returns>volumes</returns>
        private double[] CountVolume(int[] perimeters, int[] areas)
        {
            double[] vol = new double[areas.Length];

            for (int i = 0; i < vol.Length; i++)
            {
                vol[i] = Math.Pow(perimeters[i], 2) / (areas[i] * CIRCULARITY);
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

        /// <summary>
        /// Sets a new value of k parameter.
        /// </summary>
        /// <param name="newK">new k parameter</param>
        public void SetK(double newK)
        {
            this.kParam = newK;
        }

        /// <summary>
        /// Sets a new value of l parameter.
        /// </summary>
        /// <param name="newL">new l parameter</param>
        public void SetL(double newL)
        {
            this.lParam = newL;
        }
    }
}
