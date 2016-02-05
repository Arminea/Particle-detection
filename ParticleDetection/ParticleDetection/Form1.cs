using ParticleDetection.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        /// Instance for particle generating.
        /// </summary>
        GenerateParticles gp = null;

        /// <summary>
        /// Max image width.
        /// </summary>
        private const int MAX_WIDTH = 512;

        /// <summary>
        /// Max image height.
        /// </summary>
        private const int MAX_HEIGHT = 512;

        /// <summary>
        /// Radio button for simple method modification.
        /// </summary>
        RadioButton rb_sm;

        ParticlesParameters particleParams      = null;
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

        /// <summary>
        /// Init all instances.
        /// </summary>
        /// <param name="bmp"></param>
        private void Init(Bitmap bmp)
        {
            pc_sm = new ParticleCountingSimpleMethod();
            pc_hm = new ParticleCountingHistogramMethod();
            pc_c = new ParticleCountingCircularity();

            particleParams = new ParticlesParameters(bmp);

            totalOfParticles.Text = particleParams.GetNumberOfParticles();
        }

        /// <summary>
        /// Handler for button <i>Generate particles</i>. Generates particles and returns an image.
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
                    invalidateNewImage(gp.GetSurpriseCanvas());
                }
                else
                {
                    gp.Generate(num, false);
                    invalidateNewImage(gp.GetCanvas());
                }
                    

            } catch(FormatException)
            {
                MessageBox.Show("Number of particles must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Init(gp.GetCanvas());
        }

        /// <summary>
        /// Handler for button <i>Simple method</i>. 
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

            pc_sm.SimpleMethod(particleParams.GetAreas(), rb_sm.Name);

            simpleMethod.Text = pc_sm.GetEstimate();

        }

        /// <summary>
        /// Handler for button <i>Histogram method</i>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                pc_hm.HistogramMethod(num, particleParams.GetAreas());

                histogramMethodResult.Text = pc_hm.GetEstimate();

            } catch(FormatException)
            {
                MessageBox.Show("Number of particles has to be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Handler for button <i>Circularity</i>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            pc_c.Circularity(particleParams.GetPerimeters(), particleParams.GetAreas());
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

        /// <summary>
        /// Radio buttons handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                rb_sm = (RadioButton)sender;
            }
        }

        /// <summary>
        /// Renders new image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (bitmapForDrawing != null)
            {
                e.Graphics.DrawImage(bitmapForDrawing, 10, 10);
            }
        }

        /// <summary>
        /// Saves generated image. Just bmp format. Number of generated particles will be add to the end of filename.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveImage(object sender, EventArgs e)
        {
           
            if (bitmapForDrawing != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Images (*.bmp)|*.bmp";
                saveFileDialog.DefaultExt = "bmp";
                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK) {
                    string directory = Path.GetDirectoryName(saveFileDialog.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);

                    string filePath = directory + "\\" + fileName + "_" + numberOfParticles.Text + ".bmp";

                    if (filePath.Trim() != null)
                    {
                        bitmapForDrawing.Save(filePath);
                        MessageBox.Show("Image saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            } else
            {
                MessageBox.Show("There is no image for saving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        /// <summary>
        /// Loads image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadImage(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.bmp)|*.bmp";
            DialogResult result = openFileDialog.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                
                using (Bitmap imageCheck = (Bitmap)Bitmap.FromFile(filename))
                {
                    if (imageCheck.Width > MAX_WIDTH || imageCheck.Height > MAX_HEIGHT)
                    {
                        MessageBox.Show("The image is too big.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (bitmapForDrawing != null)
                    {
                        bitmapForDrawing.Dispose();
                        bitmapForDrawing = null;
                    }
                    
                    string[] splitFilename = System.IO.Path.GetFileNameWithoutExtension(filename).Split('_');
                    try {
                        if(splitFilename.Length < 2)
                        {
                            MessageBox.Show("There is no number of particles in the filename. Check the input image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Int32.Parse(splitFilename[1]);
                    } catch(Exception)
                    {
                        MessageBox.Show("Filename is in wrong format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    numberOfParticles.Text = splitFilename[1];
                    bitmapForDrawing = (Bitmap)imageCheck.Clone(); // clone object of opened image into bitmap
                    invalidateNewImage(bitmapForDrawing);

                    Init(bitmapForDrawing);
                }
            }
        }
    }
}
