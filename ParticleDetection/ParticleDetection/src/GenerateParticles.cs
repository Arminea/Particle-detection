using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleDetection.src
{
    class GenerateParticles
    {
        private int[,] centers;

        private int[] diameters;

        private int num;

        private Bitmap canvas;

        private bool surprise;

        private const int CANVAS_SIZE = 512;

        private const int DIAMETER_MIN = 15;

        private const int DIAMETER_MAX = 25;

        private Random rnd;

        public GenerateParticles()
        {

        }

        public void Generate(int num, bool surprise)
        {
            this.num = num;
            this.surprise = surprise;
            rnd = new Random();
            canvas = new Bitmap(CANVAS_SIZE, CANVAS_SIZE);
            
            centers = new int[num, num];
            diameters = new int[num];
            RandomValues();

            DrawRectangle();
            DrawParticles();
        }
        
        private void DrawRectangle()
        {
            using (Graphics graph = Graphics.FromImage(canvas))
            {
                Rectangle ImageSize = new Rectangle(0, 0, CANVAS_SIZE, CANVAS_SIZE);
                graph.FillRectangle(Brushes.Black, ImageSize);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DrawParticles()
        {
            for (int index = 0; index < num; index++)
            {
                DrawParticle(centers[0, index], centers[1, index], diameters[index]);
            }
        }

        /// <summary>
        /// Method draws a red elipse on canvas.
        /// </summary>
        /// <param name="x">x axis value</param>
        /// <param name="y">y axis value</param>
        /// <param name="diameter">diameter</param>
        private void DrawParticle(int x, int y, int diameter)
        {
            using (Graphics graph = Graphics.FromImage(canvas))
            {
                Rectangle redCircle = new Rectangle(x, y, diameter, diameter);
                graph.FillEllipse(Brushes.Red, redCircle);

                if(surprise == true && diameter == 25)
                {
                    Rectangle blackCircle = new Rectangle(x + 2, y + 2, diameter - 4, diameter - 4);
                    graph.FillEllipse(Brushes.Black, blackCircle);

                    Rectangle whiteCircle = new Rectangle(x + 7, y + 7, diameter - 14, diameter - 14);
                    graph.FillEllipse(Brushes.White, whiteCircle);

                    Rectangle redLine = new Rectangle(x + 11, y, 3, diameter);
                    graph.FillRectangle(Brushes.Red, redLine);
                }
                
            }
        }

        /// <summary>
        /// Method fills arrays of centes and diameters.
        /// </summary>
        private void RandomValues()
        {
            for(int index = 0; index < num; index++)
            {
                centers[0, index] = RandomCenter();
                centers[1, index] = RandomCenter();
                diameters[index] = RandomDiameter();
            }
        }

        /// <summary>
        /// Method generates random number which represents <i>x</i> or <i>y</i> axis value of particle.
        /// Canvas is a square.
        /// </summary>
        /// <returns><i>x</i> or <i>y</i> axis value </returns>
        private int RandomCenter()
        {
            return rnd.Next(DIAMETER_MAX + 1, CANVAS_SIZE - DIAMETER_MAX);
        }

        /// <summary>
        /// Method generates random number which represents diameter of particle.
        /// </summary>
        /// <returns>diameter of particle</returns>
        private int RandomDiameter()
        {
            return rnd.Next(DIAMETER_MIN, DIAMETER_MAX+1);
        }


        /* ********************* GETTERS *********************** */

        /// <summary>
        /// Returns an array of particles centers.
        /// </summary>
        /// <returns>centers</returns>
        public int[,] GetCenters()
        {
            return centers;
        }

        /// <summary>
        /// Returns an array of particles diameters.
        /// </summary>
        /// <returns>diameters</returns>
        public int[] GetDiameters()
        {
            return diameters;
        }

        /// <summary>
        /// Returns a canvas.
        /// </summary>
        /// <returns>canvas</returns>
        public Bitmap GetCanvas()
        {
            return canvas;
        }

        /* ********************* SETTERS *********************** */

    }
}
