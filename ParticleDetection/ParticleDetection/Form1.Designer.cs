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
            this.simpleMethod = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.simpleMethodResult = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.firstQuartile = new System.Windows.Forms.RadioButton();
            this.thirdQuartile = new System.Windows.Forms.RadioButton();
            this.median = new System.Windows.Forms.RadioButton();
            this.average = new System.Windows.Forms.RadioButton();
            this.circularityResult = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lBox = new System.Windows.Forms.TextBox();
            this.kBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.histogramMethodResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numberOfIntervals = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.totalOfParticles = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 57);
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
            this.groupBox1.Location = new System.Drawing.Point(801, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 202);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Particles";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(37, 157);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 30);
            this.button4.TabIndex = 9;
            this.button4.Text = "Load image";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(37, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 30);
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
            // simpleMethod
            // 
            this.simpleMethod.AutoSize = true;
            this.simpleMethod.Cursor = System.Windows.Forms.Cursors.Default;
            this.simpleMethod.Location = new System.Drawing.Point(80, 157);
            this.simpleMethod.Name = "simpleMethod";
            this.simpleMethod.Size = new System.Drawing.Size(22, 13);
            this.simpleMethod.TabIndex = 4;
            this.simpleMethod.Tag = "vguzv";
            this.simpleMethod.Text = ". . .";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.Location = new System.Drawing.Point(37, 106);
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
            this.simpleMethodResult.Location = new System.Drawing.Point(34, 157);
            this.simpleMethodResult.Name = "simpleMethodResult";
            this.simpleMethodResult.Size = new System.Drawing.Size(40, 13);
            this.simpleMethodResult.TabIndex = 6;
            this.simpleMethodResult.Text = "Result:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.firstQuartile);
            this.groupBox2.Controls.Add(this.thirdQuartile);
            this.groupBox2.Controls.Add(this.median);
            this.groupBox2.Controls.Add(this.average);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.simpleMethod);
            this.groupBox2.Controls.Add(this.simpleMethodResult);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox2.Location = new System.Drawing.Point(545, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 184);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simple method";
            // 
            // firstQuartile
            // 
            this.firstQuartile.AutoSize = true;
            this.firstQuartile.Location = new System.Drawing.Point(22, 67);
            this.firstQuartile.Name = "firstQuartile";
            this.firstQuartile.Size = new System.Drawing.Size(81, 17);
            this.firstQuartile.TabIndex = 10;
            this.firstQuartile.TabStop = true;
            this.firstQuartile.Text = "First quartile";
            this.firstQuartile.UseVisualStyleBackColor = true;
            this.firstQuartile.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // thirdQuartile
            // 
            this.thirdQuartile.AutoSize = true;
            this.thirdQuartile.Location = new System.Drawing.Point(128, 67);
            this.thirdQuartile.Name = "thirdQuartile";
            this.thirdQuartile.Size = new System.Drawing.Size(86, 17);
            this.thirdQuartile.TabIndex = 9;
            this.thirdQuartile.TabStop = true;
            this.thirdQuartile.Text = "Third quartile";
            this.thirdQuartile.UseVisualStyleBackColor = true;
            this.thirdQuartile.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // median
            // 
            this.median.AutoSize = true;
            this.median.Location = new System.Drawing.Point(128, 35);
            this.median.Name = "median";
            this.median.Size = new System.Drawing.Size(60, 17);
            this.median.TabIndex = 8;
            this.median.TabStop = true;
            this.median.Text = "Median";
            this.median.UseVisualStyleBackColor = true;
            this.median.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // average
            // 
            this.average.AutoSize = true;
            this.average.Location = new System.Drawing.Point(22, 35);
            this.average.Name = "average";
            this.average.Size = new System.Drawing.Size(65, 17);
            this.average.TabIndex = 7;
            this.average.TabStop = true;
            this.average.Text = "Average";
            this.average.UseVisualStyleBackColor = true;
            this.average.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            // 
            // circularityResult
            // 
            this.circularityResult.AutoSize = true;
            this.circularityResult.Location = new System.Drawing.Point(60, 116);
            this.circularityResult.Name = "circularityResult";
            this.circularityResult.Size = new System.Drawing.Size(22, 13);
            this.circularityResult.TabIndex = 24;
            this.circularityResult.Text = ". . .";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Result:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(37, 64);
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
            this.label7.Location = new System.Drawing.Point(114, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "l:";
            // 
            // lBox
            // 
            this.lBox.Location = new System.Drawing.Point(130, 29);
            this.lBox.Name = "lBox";
            this.lBox.Size = new System.Drawing.Size(70, 20);
            this.lBox.TabIndex = 20;
            // 
            // kBox
            // 
            this.kBox.Location = new System.Drawing.Point(28, 29);
            this.kBox.Name = "kBox";
            this.kBox.Size = new System.Drawing.Size(70, 20);
            this.kBox.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "k:";
            // 
            // histogramMethodResult
            // 
            this.histogramMethodResult.AutoSize = true;
            this.histogramMethodResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.histogramMethodResult.Location = new System.Drawing.Point(58, 118);
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
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Result:";
            // 
            // numberOfIntervals
            // 
            this.numberOfIntervals.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numberOfIntervals.Location = new System.Drawing.Point(123, 34);
            this.numberOfIntervals.Name = "numberOfIntervals";
            this.numberOfIntervals.Size = new System.Drawing.Size(82, 20);
            this.numberOfIntervals.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Number of intervals:";
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button5.Location = new System.Drawing.Point(37, 73);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 30);
            this.button5.TabIndex = 7;
            this.button5.Text = "Histogram method";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.HistogramMethod);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.histogramMethodResult);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.numberOfIntervals);
            this.groupBox3.Location = new System.Drawing.Point(545, 213);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(241, 149);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Histogram method";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.circularityResult);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.kBox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.lBox);
            this.groupBox4.Location = new System.Drawing.Point(545, 376);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(241, 148);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Circularity";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.totalOfParticles);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(801, 244);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(241, 100);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detection results";
            // 
            // totalOfParticles
            // 
            this.totalOfParticles.AutoSize = true;
            this.totalOfParticles.Location = new System.Drawing.Point(124, 30);
            this.totalOfParticles.Name = "totalOfParticles";
            this.totalOfParticles.Size = new System.Drawing.Size(22, 13);
            this.totalOfParticles.TabIndex = 1;
            this.totalOfParticles.Text = ". . .";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of particles:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 536);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numberOfIntervals;
        private System.Windows.Forms.Label histogramMethodResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox lBox;
        private System.Windows.Forms.TextBox kBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label circularityResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton firstQuartile;
        private System.Windows.Forms.RadioButton thirdQuartile;
        private System.Windows.Forms.RadioButton median;
        private System.Windows.Forms.RadioButton average;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label totalOfParticles;
        private System.Windows.Forms.Label label1;
    }
}
