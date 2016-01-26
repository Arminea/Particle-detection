using System;

namespace ParticleDetection
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfParticles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleMethod = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.simpleMethodResult = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lBox = new System.Windows.Forms.TextBox();
            this.kBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Quartile = new System.Windows.Forms.RadioButton();
            this.Average = new System.Windows.Forms.RadioButton();
            this.Median = new System.Windows.Forms.RadioButton();
            this.LowerLimit = new System.Windows.Forms.RadioButton();
            this.histogramMethodResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numberOfIntervals = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.histogram = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate particles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GenerateNewParticles);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numberOfParticles);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(545, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Particles";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(128, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 30);
            this.button4.TabIndex = 9;
            this.button4.Text = "Load image";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 30);
            this.button3.TabIndex = 8;
            this.button3.Text = "Save image";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of particles:";
            // 
            // numberOfParticles
            // 
            this.numberOfParticles.Location = new System.Drawing.Point(128, 22);
            this.numberOfParticles.Name = "numberOfParticles";
            this.numberOfParticles.Size = new System.Drawing.Size(82, 20);
            this.numberOfParticles.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(20, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 2);
            this.label1.TabIndex = 7;
            // 
            // simpleMethod
            // 
            this.simpleMethod.AutoSize = true;
            this.simpleMethod.Cursor = System.Windows.Forms.Cursors.Default;
            this.simpleMethod.Location = new System.Drawing.Point(80, 79);
            this.simpleMethod.Name = "simpleMethod";
            this.simpleMethod.Size = new System.Drawing.Size(22, 13);
            this.simpleMethod.TabIndex = 4;
            this.simpleMethod.Tag = "vguzv";
            this.simpleMethod.Text = ". . .";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.Location = new System.Drawing.Point(37, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Simple method";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SimpleMethod);
            // 
            // simpleMethodResult
            // 
            this.simpleMethodResult.AutoSize = true;
            this.simpleMethodResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.simpleMethodResult.Location = new System.Drawing.Point(34, 79);
            this.simpleMethodResult.Name = "simpleMethodResult";
            this.simpleMethodResult.Size = new System.Drawing.Size(40, 13);
            this.simpleMethodResult.TabIndex = 6;
            this.simpleMethodResult.Text = "Result:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lBox);
            this.groupBox2.Controls.Add(this.kBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Quartile);
            this.groupBox2.Controls.Add(this.Average);
            this.groupBox2.Controls.Add(this.Median);
            this.groupBox2.Controls.Add(this.LowerLimit);
            this.groupBox2.Controls.Add(this.histogramMethodResult);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numberOfIntervals);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.histogram);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.simpleMethod);
            this.groupBox2.Controls.Add(this.simpleMethodResult);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox2.Location = new System.Drawing.Point(545, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 404);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Counting methods";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(80, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = ". . .";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 378);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Result:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(37, 326);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(160, 30);
            this.button6.TabIndex = 22;
            this.button6.Text = "Circularity";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.CircularityMethod);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(134, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "l:";
            // 
            // lBox
            // 
            this.lBox.Location = new System.Drawing.Point(150, 291);
            this.lBox.Name = "lBox";
            this.lBox.Size = new System.Drawing.Size(70, 20);
            this.lBox.TabIndex = 20;
            // 
            // kBox
            // 
            this.kBox.Location = new System.Drawing.Point(48, 291);
            this.kBox.Name = "kBox";
            this.kBox.Size = new System.Drawing.Size(70, 20);
            this.kBox.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "k:";
            // 
            // Quartile
            // 
            this.Quartile.AutoSize = true;
            this.Quartile.Location = new System.Drawing.Point(136, 177);
            this.Quartile.Name = "Quartile";
            this.Quartile.Size = new System.Drawing.Size(61, 17);
            this.Quartile.TabIndex = 17;
            this.Quartile.TabStop = true;
            this.Quartile.Text = "Quartile";
            this.Quartile.UseVisualStyleBackColor = true;
            this.Quartile.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // Average
            // 
            this.Average.AutoSize = true;
            this.Average.Location = new System.Drawing.Point(37, 177);
            this.Average.Name = "Average";
            this.Average.Size = new System.Drawing.Size(65, 17);
            this.Average.TabIndex = 16;
            this.Average.TabStop = true;
            this.Average.Text = "Average";
            this.Average.UseVisualStyleBackColor = true;
            this.Average.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // Median
            // 
            this.Median.AutoSize = true;
            this.Median.Location = new System.Drawing.Point(137, 154);
            this.Median.Name = "Median";
            this.Median.Size = new System.Drawing.Size(60, 17);
            this.Median.TabIndex = 15;
            this.Median.TabStop = true;
            this.Median.Text = "Median";
            this.Median.UseVisualStyleBackColor = true;
            this.Median.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // LowerLimit
            // 
            this.LowerLimit.AutoSize = true;
            this.LowerLimit.Location = new System.Drawing.Point(37, 154);
            this.LowerLimit.Name = "LowerLimit";
            this.LowerLimit.Size = new System.Drawing.Size(74, 17);
            this.LowerLimit.TabIndex = 14;
            this.LowerLimit.TabStop = true;
            this.LowerLimit.Text = "Lower limit";
            this.LowerLimit.UseVisualStyleBackColor = true;
            this.LowerLimit.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // histogramMethodResult
            // 
            this.histogramMethodResult.AutoSize = true;
            this.histogramMethodResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.histogramMethodResult.Location = new System.Drawing.Point(80, 255);
            this.histogramMethodResult.Name = "histogramMethodResult";
            this.histogramMethodResult.Size = new System.Drawing.Size(22, 13);
            this.histogramMethodResult.TabIndex = 13;
            this.histogramMethodResult.Tag = "vguzv";
            this.histogramMethodResult.Text = ". . .";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Location = new System.Drawing.Point(34, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Result:";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(20, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 2);
            this.label4.TabIndex = 11;
            this.label4.Text = "label4";
            // 
            // numberOfIntervals
            // 
            this.numberOfIntervals.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numberOfIntervals.Location = new System.Drawing.Point(128, 124);
            this.numberOfIntervals.Name = "numberOfIntervals";
            this.numberOfIntervals.Size = new System.Drawing.Size(82, 20);
            this.numberOfIntervals.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Location = new System.Drawing.Point(17, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Number of intervals:";
            // 
            // histogram
            // 
            this.histogram.Image = global::ParticleDetection.Properties.Resources.H1;
            this.histogram.InitialImage = null;
            this.histogram.Location = new System.Drawing.Point(203, 210);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(30, 30);
            this.histogram.TabIndex = 8;
            this.histogram.TabStop = false;
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button5.Location = new System.Drawing.Point(37, 210);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 30);
            this.button5.TabIndex = 7;
            this.button5.Text = "Histogram method";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.HistogramMethod);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 555);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Particle detection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).EndInit();
            this.ResumeLayout(false);

        }
        
        private void ChangeText()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 2 && args[1].Equals("deadpoolmode"))
            {
                this.Text = "Particle detection - deadpool mode!";
            }
            else
            {
                this.Text = "Particle detection";
            }

            #endregion
        }
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox numberOfParticles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label simpleMethod;
        private System.Windows.Forms.Label simpleMethodResult;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox histogram;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numberOfIntervals;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label histogramMethodResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton Quartile;
        private System.Windows.Forms.RadioButton Average;
        private System.Windows.Forms.RadioButton Median;
        private System.Windows.Forms.RadioButton LowerLimit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox lBox;
        private System.Windows.Forms.TextBox kBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button6;
    }
}
