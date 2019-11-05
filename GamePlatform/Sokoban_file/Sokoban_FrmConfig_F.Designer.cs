namespace GamePlatform.Sokoban_file
{
    partial class Sokoban_FrmConfig_F
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sokoban_FrmConfig_F));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtn_New = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_Wall = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_Box = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_Destination = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_Passageway = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_Worker = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 357);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtn_New,
            this.toolStripBtn_Save,
            this.toolStripBtn_Wall,
            this.toolStripBtn_Box,
            this.toolStripBtn_Destination,
            this.toolStripBtn_Passageway,
            this.toolStripBtn_Worker});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(363, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtn_New
            // 
            this.toolStripBtn_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtn_New.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtn_New.Image")));
            this.toolStripBtn_New.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtn_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_New.Name = "toolStripBtn_New";
            this.toolStripBtn_New.Size = new System.Drawing.Size(35, 36);
            this.toolStripBtn_New.Text = "toolStripButton1";
            this.toolStripBtn_New.ToolTipText = "新建";
            this.toolStripBtn_New.Click += new System.EventHandler(this.toolStripBtn_New_Click);
            // 
            // toolStripBtn_Save
            // 
            this.toolStripBtn_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtn_Save.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtn_Save.Image")));
            this.toolStripBtn_Save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtn_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_Save.Name = "toolStripBtn_Save";
            this.toolStripBtn_Save.Size = new System.Drawing.Size(34, 36);
            this.toolStripBtn_Save.Text = "toolStripButton1";
            this.toolStripBtn_Save.ToolTipText = "保存";
            this.toolStripBtn_Save.Click += new System.EventHandler(this.toolStripBtn_Save_Click);
            // 
            // toolStripBtn_Wall
            // 
            this.toolStripBtn_Wall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtn_Wall.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtn_Wall.Image")));
            this.toolStripBtn_Wall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtn_Wall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_Wall.Name = "toolStripBtn_Wall";
            this.toolStripBtn_Wall.Size = new System.Drawing.Size(36, 36);
            this.toolStripBtn_Wall.Text = "toolStripButton_Wall";
            this.toolStripBtn_Wall.ToolTipText = "围墙";
            this.toolStripBtn_Wall.Click += new System.EventHandler(this.toolStripBtn_Wall_Click);
            // 
            // toolStripBtn_Box
            // 
            this.toolStripBtn_Box.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtn_Box.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtn_Box.Image")));
            this.toolStripBtn_Box.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtn_Box.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_Box.Name = "toolStripBtn_Box";
            this.toolStripBtn_Box.Size = new System.Drawing.Size(32, 36);
            this.toolStripBtn_Box.ToolTipText = "箱子";
            this.toolStripBtn_Box.Click += new System.EventHandler(this.toolStripBtn_Box_Click);
            // 
            // toolStripBtn_Destination
            // 
            this.toolStripBtn_Destination.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtn_Destination.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtn_Destination.Image")));
            this.toolStripBtn_Destination.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtn_Destination.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_Destination.Name = "toolStripBtn_Destination";
            this.toolStripBtn_Destination.Size = new System.Drawing.Size(36, 36);
            this.toolStripBtn_Destination.Text = "toolStripButton3";
            this.toolStripBtn_Destination.ToolTipText = "目的地";
            this.toolStripBtn_Destination.Click += new System.EventHandler(this.toolStripBtn_Destination_Click);
            // 
            // toolStripBtn_Passageway
            // 
            this.toolStripBtn_Passageway.BackColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripBtn_Passageway.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtn_Passageway.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtn_Passageway.Image")));
            this.toolStripBtn_Passageway.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtn_Passageway.ImageTransparentColor = System.Drawing.Color.Thistle;
            this.toolStripBtn_Passageway.Name = "toolStripBtn_Passageway";
            this.toolStripBtn_Passageway.Size = new System.Drawing.Size(36, 36);
            this.toolStripBtn_Passageway.Text = "toolStripButton4";
            this.toolStripBtn_Passageway.ToolTipText = "通道";
            this.toolStripBtn_Passageway.Click += new System.EventHandler(this.toolStripBtn_Passageway_Click);
            // 
            // toolStripBtn_Worker
            // 
            this.toolStripBtn_Worker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtn_Worker.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtn_Worker.Image")));
            this.toolStripBtn_Worker.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtn_Worker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_Worker.Name = "toolStripBtn_Worker";
            this.toolStripBtn_Worker.Size = new System.Drawing.Size(31, 36);
            this.toolStripBtn_Worker.Text = "toolStripButton5";
            this.toolStripBtn_Worker.ToolTipText = "工人";
            this.toolStripBtn_Worker.Click += new System.EventHandler(this.toolStripBtn_Worker_Click);
            // 
            // Sokoban_FrmConfig_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 402);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Sokoban_FrmConfig_F";
            this.Text = "Sokoban_FrmConfig_F";
            this.Load += new System.EventHandler(this.Sokoban_FrmConfig_F_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtn_New;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Save;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Wall;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Box;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Destination;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Passageway;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Worker;
    }
}