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


        RadioButton rb_sm;

        ParticleCountingSimpleMethod pc_sm      = null;
        ParticleCountingHistogramMethod pc_hm   = null;
        ParticleCountingCircularity pc_c        = null;

        public Form1()
        {
            InitializeComponent();
            ChangeText();
            average.Checked = true;
            kBox.Text = "1";
            lBox.Text = "1";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numberOfParticles.Text = "10";
            numberOfIntervals.Text = "3";
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
                int num = int.Parse(numberOfParticles.Text.Trim());
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

            } catch(FormatException)
            {
                MessageBox.Show("Number of particles must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch
            {

            }

            pc_sm = new ParticleCountingSimpleMethod();
            pc_hm = new ParticleCountingHistogramMethod();
            pc_c  = new ParticleCountingCircularity();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleMethod(object sender, EventArgs e)
        {
            if(gp == null)
            {
                MessageBox.Show("Generate particles!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pc_sm.SimpleMethod(gp.GetAreas(), rb_sm.Name);

            simpleMethod.Text = pc_sm.GetEstimate();

        }


        private void HistogramMethod(object sender, EventArgs e)
        {
            if (gp == null)
            {
                MessageBox.Show("Generate particles!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numberOfIntervals.Text.Trim() == "")
            {
                MessageBox.Show("Enter number of intervals.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try { 
                int num = int.Parse(numberOfIntervals.Text.Trim());
                if (num <= 0)
                {
                    MessageBox.Show("Number of intervals have to be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                pc_hm.HistogramMethod(num, gp.GetAreas());

                histogramMethodResult.Text = pc_hm.GetEstimate();

            } catch(FormatException)
            {
                MessageBox.Show("Number of particles has to be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void CircularityMethod(object sender, EventArgs e)
        {
            if (gp == null)
            {
                MessageBox.Show("Generate particles!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            double k = 0, l = 0;
            try
            {
                k = double.Parse(kBox.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("'k' parameter has to be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                l = double.Parse(lBox.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("'l' parameter has to be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pc_c.SetK(k);
            pc_c.SetL(l);

            pc_c.Circularity(gp.GetPerimeters(), gp.GetAreas());
            circularityResult.Text = pc_c.GetEstimate();
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

        private void AllCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                rb_sm = (RadioButton)sender;
                //Console.WriteLine(rb_sm.Name);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (bitmapForDrawing != null)
            {
                e.Graphics.DrawImage(bitmapForDrawing, 10, 10);
            }
        }

    }
}
