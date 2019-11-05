namespace GamePlatform.Type_file
{
    partial class Type_F
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
            this.timerlab = new System.Windows.Forms.Timer(this.components);
            this.timerrate = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMenuItemMain = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMenuItemStart = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMenuItemPause = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMenuItemLife = new System.Windows.Forms.ToolStripMenuItem();
            this.排行榜RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerlab
            // 
            this.timerlab.Enabled = true;
            this.timerlab.Tick += new System.EventHandler(this.timerlab_Tick);
            // 
            // timerrate
            // 
            this.timerrate.Enabled = true;
            this.timerrate.Tick += new System.EventHandler(this.timerrate_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMenuItemMain,
            this.排行榜RToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(499, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMenuItemMain
            // 
            this.TSMenuItemMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMenuItemStart,
            this.TSMenuItemPause,
            this.TSMenuItemLife,
            this.保存ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.TSMenuItemMain.Name = "TSMenuItemMain";
            this.TSMenuItemMain.Size = new System.Drawing.Size(77, 21);
            this.TSMenuItemMain.Text = "游戏（G）";
            // 
            // TSMenuItemStart
            // 
            this.TSMenuItemStart.Name = "TSMenuItemStart";
            this.TSMenuItemStart.Size = new System.Drawing.Size(169, 22);
            this.TSMenuItemStart.Text = "开始";
            this.TSMenuItemStart.Click += new System.EventHandler(this.TSMenuItemStart_Click);
            // 
            // TSMenuItemPause
            // 
            this.TSMenuItemPause.Name = "TSMenuItemPause";
            this.TSMenuItemPause.Size = new System.Drawing.Size(169, 22);
            this.TSMenuItemPause.Text = "暂停";
            this.TSMenuItemPause.Click += new System.EventHandler(this.TSMenuItemPause_Click);
            // 
            // TSMenuItemLife
            // 
            this.TSMenuItemLife.Name = "TSMenuItemLife";
            this.TSMenuItemLife.Size = new System.Drawing.Size(169, 22);
            this.TSMenuItemLife.Text = "积分10换1个生命";
            this.TSMenuItemLife.Click += new System.EventHandler(this.TSMenuItemLife_Click);
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
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // Type_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 461);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Type_F";
            this.Text = "打字游戏";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mainFrm_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerlab;
        private System.Windows.Forms.Timer timerrate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMenuItemMain;
        private System.Windows.Forms.ToolStripMenuItem TSMenuItemStart;
        private System.Windows.Forms.ToolStripMenuItem TSMenuItemPause;
        private System.Windows.Forms.ToolStripMenuItem TSMenuItemLife;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排行榜RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
    }
}