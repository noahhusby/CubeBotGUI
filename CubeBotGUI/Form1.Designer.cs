namespace CubeBotGUI
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
            this.components = new System.ComponentModel.Container();
            this.read_f1 = new System.Windows.Forms.Button();
            this.time_label = new System.Windows.Forms.Label();
            this.cubeview = new System.Windows.Forms.PictureBox();
            this.log_box = new System.Windows.Forms.TextBox();
            this.viewwhereweread = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.liveimage = new System.Windows.Forms.PictureBox();
            this.restart = new System.Windows.Forms.Button();
            this.resetbutton = new System.Windows.Forms.Button();
            this.cubestring_box = new System.Windows.Forms.TextBox();
            this.solution_box = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimerTextBox = new System.Windows.Forms.TextBox();
            this.sol_label = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.string_label = new System.Windows.Forms.Label();
            this.lac_label = new System.Windows.Forms.Label();
            this.depth_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.speedmode_box = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cubeview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveimage)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // read_f1
            // 
            this.read_f1.Location = new System.Drawing.Point(14, 872);
            this.read_f1.Margin = new System.Windows.Forms.Padding(2);
            this.read_f1.Name = "read_f1";
            this.read_f1.Size = new System.Drawing.Size(1109, 55);
            this.read_f1.TabIndex = 0;
            this.read_f1.Text = "Solve My Cube";
            this.read_f1.UseVisualStyleBackColor = true;
            this.read_f1.Click += new System.EventHandler(this.read_f1_Click);
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(128, 270);
            this.time_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(0, 17);
            this.time_label.TabIndex = 1;
            // 
            // cubeview
            // 
            this.cubeview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cubeview.Location = new System.Drawing.Point(15, 134);
            this.cubeview.Margin = new System.Windows.Forms.Padding(4);
            this.cubeview.Name = "cubeview";
            this.cubeview.Size = new System.Drawing.Size(394, 206);
            this.cubeview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cubeview.TabIndex = 2;
            this.cubeview.TabStop = false;
            // 
            // log_box
            // 
            this.log_box.Location = new System.Drawing.Point(866, 134);
            this.log_box.Margin = new System.Windows.Forms.Padding(4);
            this.log_box.Multiline = true;
            this.log_box.Name = "log_box";
            this.log_box.ReadOnly = true;
            this.log_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log_box.Size = new System.Drawing.Size(428, 705);
            this.log_box.TabIndex = 3;
            this.log_box.TextChanged += new System.EventHandler(this.Log_box_TextChanged);
            // 
            // viewwhereweread
            // 
            this.viewwhereweread.Location = new System.Drawing.Point(16, 348);
            this.viewwhereweread.Margin = new System.Windows.Forms.Padding(4);
            this.viewwhereweread.Name = "viewwhereweread";
            this.viewwhereweread.Size = new System.Drawing.Size(395, 36);
            this.viewwhereweread.TabIndex = 4;
            this.viewwhereweread.Text = "View Camera";
            this.viewwhereweread.UseVisualStyleBackColor = true;
            this.viewwhereweread.Click += new System.EventHandler(this.viewwhereweread_Click);
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(14, 640);
            this.stop_button.Margin = new System.Windows.Forms.Padding(4);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(158, 39);
            this.stop_button.TabIndex = 7;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // liveimage
            // 
            this.liveimage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.liveimage.Location = new System.Drawing.Point(16, 409);
            this.liveimage.Margin = new System.Windows.Forms.Padding(4);
            this.liveimage.Name = "liveimage";
            this.liveimage.Size = new System.Drawing.Size(393, 223);
            this.liveimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.liveimage.TabIndex = 8;
            this.liveimage.TabStop = false;
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(179, 640);
            this.restart.Margin = new System.Windows.Forms.Padding(4);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(229, 39);
            this.restart.TabIndex = 9;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // resetbutton
            // 
            this.resetbutton.Location = new System.Drawing.Point(1129, 872);
            this.resetbutton.Margin = new System.Windows.Forms.Padding(4);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(166, 55);
            this.resetbutton.TabIndex = 10;
            this.resetbutton.Text = "Reset Images and Tool";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // cubestring_box
            // 
            this.cubestring_box.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cubestring_box.Location = new System.Drawing.Point(15, 815);
            this.cubestring_box.Margin = new System.Windows.Forms.Padding(4);
            this.cubestring_box.Name = "cubestring_box";
            this.cubestring_box.Size = new System.Drawing.Size(394, 22);
            this.cubestring_box.TabIndex = 11;
            this.cubestring_box.Text = "Manually enter cubestring";
            this.cubestring_box.Click += new System.EventHandler(this.cubestring_box_Click);
            // 
            // solution_box
            // 
            this.solution_box.Location = new System.Drawing.Point(436, 409);
            this.solution_box.Margin = new System.Windows.Forms.Padding(4);
            this.solution_box.Multiline = true;
            this.solution_box.Name = "solution_box";
            this.solution_box.ReadOnly = true;
            this.solution_box.Size = new System.Drawing.Size(399, 430);
            this.solution_box.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimerTextBox
            // 
            this.TimerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerTextBox.Location = new System.Drawing.Point(15, 705);
            this.TimerTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.TimerTextBox.Name = "TimerTextBox";
            this.TimerTextBox.Size = new System.Drawing.Size(394, 98);
            this.TimerTextBox.TabIndex = 13;
            this.TimerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sol_label
            // 
            this.sol_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sol_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sol_label.Location = new System.Drawing.Point(436, 380);
            this.sol_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sol_label.Name = "sol_label";
            this.sol_label.Size = new System.Drawing.Size(400, 24);
            this.sol_label.TabIndex = 14;
            this.sol_label.Text = "Cube Solution:";
            this.sol_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(15, 15);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(394, 92);
            this.panel3.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(389, 51);
            this.label3.TabIndex = 29;
            this.label3.Text = "CubeBot v1.0";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(95, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(411, 68);
            this.label2.TabIndex = 28;
            this.label2.Text = "By: iBoot32";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(866, 108);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 22);
            this.label7.TabIndex = 29;
            this.label7.Text = "Console:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.string_label);
            this.panel1.Controls.Add(this.lac_label);
            this.panel1.Controls.Add(this.depth_label);
            this.panel1.Location = new System.Drawing.Point(436, 134);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 206);
            this.panel1.TabIndex = 30;
            // 
            // string_label
            // 
            this.string_label.AutoSize = true;
            this.string_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.string_label.Location = new System.Drawing.Point(15, 111);
            this.string_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.string_label.Name = "string_label";
            this.string_label.Size = new System.Drawing.Size(178, 25);
            this.string_label.TabIndex = 33;
            this.string_label.Text = "Current String: N/A";
            // 
            // lac_label
            // 
            this.lac_label.AutoSize = true;
            this.lac_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lac_label.Location = new System.Drawing.Point(15, 68);
            this.lac_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lac_label.Name = "lac_label";
            this.lac_label.Size = new System.Drawing.Size(89, 25);
            this.lac_label.TabIndex = 31;
            this.lac_label.Text = "Loc: N/A";
            // 
            // depth_label
            // 
            this.depth_label.AutoSize = true;
            this.depth_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depth_label.Location = new System.Drawing.Point(15, 19);
            this.depth_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.depth_label.Name = "depth_label";
            this.depth_label.Size = new System.Drawing.Size(109, 25);
            this.depth_label.TabIndex = 30;
            this.depth_label.Text = "Depth: N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(436, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 22);
            this.label1.TabIndex = 31;
            this.label1.Text = "Statistics:";
            // 
            // speedmode_box
            // 
            this.speedmode_box.AutoSize = true;
            this.speedmode_box.Location = new System.Drawing.Point(16, 844);
            this.speedmode_box.Name = "speedmode_box";
            this.speedmode_box.Size = new System.Drawing.Size(167, 21);
            this.speedmode_box.TabIndex = 32;
            this.speedmode_box.Text = "Enable Speed-Mode?";
            this.speedmode_box.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 942);
            this.Controls.Add(this.speedmode_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.sol_label);
            this.Controls.Add(this.TimerTextBox);
            this.Controls.Add(this.solution_box);
            this.Controls.Add(this.cubestring_box);
            this.Controls.Add(this.resetbutton);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.liveimage);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.viewwhereweread);
            this.Controls.Add(this.log_box);
            this.Controls.Add(this.cubeview);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.read_f1);
            this.Enabled = false;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "CubeBotGUI";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.cubeview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveimage)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button read_f1;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.PictureBox cubeview;
        private System.Windows.Forms.TextBox log_box;
        private System.Windows.Forms.Button viewwhereweread;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.PictureBox liveimage;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.TextBox cubestring_box;
        private System.Windows.Forms.TextBox solution_box;
        private System.Windows.Forms.TextBox TimerTextBox;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label sol_label;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label string_label;
        private System.Windows.Forms.Label lac_label;
        private System.Windows.Forms.Label depth_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox speedmode_box;
    }
}

