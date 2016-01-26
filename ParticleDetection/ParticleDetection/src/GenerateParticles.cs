using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleDetection.src
{
    /// <summary>
    /// 
    /// </summary>
    class GenerateParticles
    {
        /// <summary>
        /// Centers of particles.
        /// </summary>
        private int[,] centers;

        /// <summary>
        /// Diameters of particles.
        /// </summary>
        private int[] diameters;

        /// <summary>
        /// Perimeters of particles.
        /// </summary>
        private int[] perimeters;

        /// <summary>
        /// Areas of particles.
        /// </summary>
        private int[] areas;

        /// <summary>
        /// Number of generated particles.
        /// </summary>
        private int num;

        /// <summary>
        /// Bitmap canvas for drawing.
        /// </summary>
        private Bitmap canvas;

        /// <summary>
        /// Easter egg.
        /// </summary>
        private bool surprise;

        /// <summary>
        /// Canvas size.
        /// </summary>
        private const int CANVAS_SIZE = 512;

        /// <summary>
        /// Minimal diameter of particle.
        /// </summary>
        public const int DIAMETER_MIN = 10;

        /// <summary>
        /// Maximal diameter of particle.
        /// </summary>
        public const int DIAMETER_MAX = 25;

        /// <summary>
        /// Random.
        /// </summary>
        private Random rnd;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GenerateParticles()
        {

        }

        /// <summary>
        /// Method for launching all necessary steps.
        /// </summary>
        /// <param name="num">number of particles</param>
        /// <param name="surprise">easter egg</param>
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

            perimeters = new int[num];
            areas = new int[num];
            CountPerimeters();
            CountAreas();
            
        }

        /// <summary>
        /// Method counts perimeters of particles.
        /// </summary>
        private void CountPerimeters()
        {
            for (int i = 0; i < num; i++)
            {
                perimeters[i] = (int) (diameters[i] * Math.PI);
            }
        }

        /// <summary>
        /// Method counts areas of particles.
        /// </summary>
        private void CountAreas()
        {
            for (int i = 0; i < num; i++)
            {
                areas[i] = (int)((Math.PI * Math.Pow(diameters[i], 2)) /4);
            }
        }
        
        /// <summary>
        /// Method draws basic black rectangle on canvas.
        /// </summary>
        private void DrawRectangle()
        {
            using (Graphics graph = Graphics.FromImage(canvas))
            {
                Rectangle ImageSize = new Rectangle(0, 0, CANVAS_SIZE, CANVAS_SIZE);
                graph.FillRectangle(Brushes.Black, ImageSize);
            }
        }

        /// <summary>
        /// Method draws all particles.
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

        private void Debug()
        {
            Console.WriteLine("Perimeters and areas");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Perimeter: " + perimeters[i] + ", area: " + areas[i]);
            }
            Console.WriteLine("--------------------------------");
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
        /// Returns an array of particles perimeters.
        /// </summary>
        /// <returns>perimeters</returns>
        public int[] GetPerimeters()
        {
            return perimeters;
        }

        /// <summary>
        /// Return length of perimeters array.
        /// </summary>
        /// <returns></returns>
        public int GetPerimetersLength()
        {
            return perimeters.Length;
        }

        /// <summary>
        /// Returns an array od particles areas.
        /// </summary>
        /// <returns>areas</returns>
        public int[] GetAreas()
        {
            return areas;
        }

        /// <summary>
        /// Returns length of areas array.
        /// </summary>
        /// <returns></returns>
        public int GetAreasLength()
        {
            return areas.Length;
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
