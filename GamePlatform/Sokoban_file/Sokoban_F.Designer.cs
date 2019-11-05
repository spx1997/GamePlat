namespace GamePlatform.Sokoban_file
{
    partial class Sokoban_F
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下一关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重玩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.排行榜RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem,
            this.排行榜RToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(355, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下一关ToolStripMenuItem,
            this.重玩ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.编辑地图ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.游戏ToolStripMenuItem.Text = "游戏（G）";
            // 
            // 下一关ToolStripMenuItem
            // 
            this.下一关ToolStripMenuItem.Name = "下一关ToolStripMenuItem";
            this.下一关ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.下一关ToolStripMenuItem.Text = "下 一  关";
            this.下一关ToolStripMenuItem.Click += new System.EventHandler(this.下一关ToolStripMenuItem_Click);
            // 
            // 重玩ToolStripMenuItem
            // 
            this.重玩ToolStripMenuItem.Name = "重玩ToolStripMenuItem";
            this.重玩ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.重玩ToolStripMenuItem.Text = "重   玩";
            this.重玩ToolStripMenuItem.Click += new System.EventHandler(this.下一关ToolStripMenuItem_Click);
            // 
            // 编辑地图ToolStripMenuItem
            // 
            this.编辑地图ToolStripMenuItem.Name = "编辑地图ToolStripMenuItem";
            this.编辑地图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.编辑地图ToolStripMenuItem.Text = "编辑地图";
            this.编辑地图ToolStripMenuItem.Click += new System.EventHandler(this.编辑地图ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退   出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(351, 348);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // 排行榜RToolStripMenuItem
            // 
            this.排行榜RToolStripMenuItem.Name = "排行榜RToolStripMenuItem";
            this.排行榜RToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.排行榜RToolStripMenuItem.Text = "排行榜（R）";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.帮助HToolStripMenuItem.Text = "帮助（H）";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // Sokoban_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 379);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Sokoban_F";
            this.Text = "推箱子";
            this.Load += new System.EventHandler(this.Sokoban_F_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Sokoban_F_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下一关ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重玩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排行榜RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
    }
}