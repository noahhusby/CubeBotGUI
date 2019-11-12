namespace CubeBotGUI
{
    partial class CubeBotWindow
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
            this.read_f1 = new System.Windows.Forms.Button();
            this.time_label = new System.Windows.Forms.Label();
            this.cubeview = new System.Windows.Forms.PictureBox();
            this.log_box = new System.Windows.Forms.TextBox();
            this.viewwhereweread = new System.Windows.Forms.Button();
            this.timelabel = new System.Windows.Forms.Label();
            this.timetextbox = new System.Windows.Forms.TextBox();
            this.stop_button = new System.Windows.Forms.Button();
            this.liveimage = new System.Windows.Forms.PictureBox();
            this.restart = new System.Windows.Forms.Button();
            this.resetbutton = new System.Windows.Forms.Button();
            this.cubestring_box = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cubeview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveimage)).BeginInit();
            this.SuspendLayout();
            // 
            // read_f1
            // 
            this.read_f1.Location = new System.Drawing.Point(24, 606);
            this.read_f1.Margin = new System.Windows.Forms.Padding(2);
            this.read_f1.Name = "read_f1";
            this.read_f1.Size = new System.Drawing.Size(582, 44);
            this.read_f1.TabIndex = 0;
            this.read_f1.Text = "Solve My Cube";
            this.read_f1.UseVisualStyleBackColor = true;
            this.read_f1.Click += new System.EventHandler(this.read_f1_Click);
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(102, 216);
            this.time_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(0, 13);
            this.time_label.TabIndex = 1;
            // 
            // cubeview
            // 
            this.cubeview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cubeview.Location = new System.Drawing.Point(24, 29);
            this.cubeview.Name = "cubeview";
            this.cubeview.Size = new System.Drawing.Size(349, 282);
            this.cubeview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cubeview.TabIndex = 2;
            this.cubeview.TabStop = false;
            // 
            // log_box
            // 
            this.log_box.Location = new System.Drawing.Point(619, 12);
            this.log_box.Multiline = true;
            this.log_box.Name = "log_box";
            this.log_box.ReadOnly = true;
            this.log_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log_box.Size = new System.Drawing.Size(343, 217);
            this.log_box.TabIndex = 3;
            // 
            // viewwhereweread
            // 
            this.viewwhereweread.Location = new System.Drawing.Point(619, 235);
            this.viewwhereweread.Name = "viewwhereweread";
            this.viewwhereweread.Size = new System.Drawing.Size(197, 23);
            this.viewwhereweread.TabIndex = 4;
            this.viewwhereweread.Text = "View Camera";
            this.viewwhereweread.UseVisualStyleBackColor = true;
            this.viewwhereweread.Click += new System.EventHandler(this.viewwhereweread_Click);
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.Location = new System.Drawing.Point(868, 239);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(33, 13);
            this.timelabel.TabIndex = 5;
            this.timelabel.Text = "Time:";
            // 
            // timetextbox
            // 
            this.timetextbox.Location = new System.Drawing.Point(907, 236);
            this.timetextbox.Name = "timetextbox";
            this.timetextbox.Size = new System.Drawing.Size(55, 20);
            this.timetextbox.TabIndex = 6;
            this.timetextbox.Text = "1";
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(380, 137);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(40, 23);
            this.stop_button.TabIndex = 7;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // liveimage
            // 
            this.liveimage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.liveimage.Location = new System.Drawing.Point(380, 29);
            this.liveimage.Name = "liveimage";
            this.liveimage.Size = new System.Drawing.Size(134, 102);
            this.liveimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.liveimage.TabIndex = 8;
            this.liveimage.TabStop = false;
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(426, 137);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(88, 23);
            this.restart.TabIndex = 9;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // resetbutton
            // 
            this.resetbutton.Location = new System.Drawing.Point(829, 627);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(133, 23);
            this.resetbutton.TabIndex = 10;
            this.resetbutton.Text = "Reset Images and Tool";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // cubestring_box
            // 
            this.cubestring_box.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cubestring_box.Location = new System.Drawing.Point(619, 265);
            this.cubestring_box.Name = "cubestring_box";
            this.cubestring_box.Size = new System.Drawing.Size(343, 20);
            this.cubestring_box.TabIndex = 11;
            this.cubestring_box.Text = "Manually enter cubestring";
            this.cubestring_box.Click += new System.EventHandler(this.cubestring_box_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(974, 661);
            this.Controls.Add(this.cubestring_box);
            this.Controls.Add(this.resetbutton);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.liveimage);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.timetextbox);
            this.Controls.Add(this.timelabel);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button read_f1;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.PictureBox cubeview;
        private System.Windows.Forms.TextBox log_box;
        private System.Windows.Forms.Button viewwhereweread;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.TextBox timetextbox;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.PictureBox liveimage;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.TextBox cubestring_box;
    }
}

