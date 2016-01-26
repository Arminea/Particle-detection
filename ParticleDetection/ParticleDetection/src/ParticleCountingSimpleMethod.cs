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
        public void SimpleMethod(int[] areas)
        {
            if(estimate != 0)
                estimate = 0; // set estimate to zero

            double Aref = 0;
            foreach (int i in areas)
            {
                Aref += i;
            }
            Aref = Aref / areas.Length; // the reference area - average area

            foreach (int j in areas)
            {
                estimate += (double) j / Aref;
            }

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
