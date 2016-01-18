using ParticleDetection.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParticleDetection
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Bitmap for canvas.
        /// </summary>
        Bitmap bitmapForDrawing;

        /// <summary>
        /// 
        /// </summary>
        GenerateParticles gp = null;

        public Form1()
        {
            InitializeComponent();
            ChangeText();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numberOfParticles.Text = "10";
        }

        /* ******************* Generate particles ******************** */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNewParticles(object sender, EventArgs e)
        {
            gp = new GenerateParticles();

            try
            {
                int num = int.Parse(numberOfParticles.Text);
                if (num <= 0)
                {
                    MessageBox.Show("Number of particles must be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] args = Environment.GetCommandLineArgs();
                if (args.Length == 2 && args[1].Equals("deadpoolmode")) //hiden mode will appear when you enter "deadpoolmode" as an argument from command line
                {
                    gp.Generate(num, true);
                }
                else
                {
                    gp.Generate(num, false);
                }
                    
                invalidateNewImage(gp.GetCanvas());

            } catch
            {
                MessageBox.Show("Number of particles must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // =========================== FORM CHANGES =============================

        /// <summary>
        /// Method repaints new image on canvas.
        /// </summary>
        /// <param name="newImage"></param>
        private void invalidateNewImage(Bitmap newImage)
        {
            bitmapForDrawing = newImage;
            this.Invalidate(); // invalidate form
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (bitmapForDrawing != null)
            {
                e.Graphics.DrawImage(bitmapForDrawing, 10, 10);
            }
        }







        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
