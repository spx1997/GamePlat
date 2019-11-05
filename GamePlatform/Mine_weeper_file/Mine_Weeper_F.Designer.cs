namespace GamePlatform.Mine_weeper_file
{
    partial class Mine_Weeper_F
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mine_Weeper_F));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblMine = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.难度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中级ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.高级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排行榜RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblMine);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 42);
            this.panel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(286, -3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "标示出雷";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.Location = new System.Drawing.Point(190, 10);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(17, 16);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "0";
            // 
            // lblMine
            // 
            this.lblMine.AutoSize = true;
            this.lblMine.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMine.Location = new System.Drawing.Point(80, 12);
            this.lblMine.Name = "lblMine";
            this.lblMine.Size = new System.Drawing.Size(26, 16);
            this.lblMine.TabIndex = 0;
            this.lblMine.Text = "10";
            this.lblMine.Click += new System.EventHandler(this.lblMine_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏GToolStripMenuItem,
            this.难度ToolStripMenuItem,
            this.排行榜RToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(388, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏GToolStripMenuItem
            // 
            this.游戏GToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.游戏GToolStripMenuItem.Name = "游戏GToolStripMenuItem";
            this.游戏GToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.游戏GToolStripMenuItem.Text = "游戏（G）";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存ToolStripMenuItem.Text = "保存（S）";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.save_Click);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出EToolStripMenuItem.Text = "退出（E）";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.exit_Click);
            // 
            // 难度ToolStripMenuItem
            // 
            this.难度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.中级ToolStripMenuItem,
            this.中级ToolStripMenuItem1,
            this.高级ToolStripMenuItem});
            this.难度ToolStripMenuItem.Name = "难度ToolStripMenuItem";
            this.难度ToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.难度ToolStripMenuItem.Text = "难度（D）";
            // 
            // 中级ToolStripMenuItem
            // 
            this.中级ToolStripMenuItem.Name = "中级ToolStripMenuItem";
            this.中级ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.中级ToolStripMenuItem.Text = "低级（L）";
            this.中级ToolStripMenuItem.Click += new System.EventHandler(this.difficult_Click);
            // 
            // 中级ToolStripMenuItem1
            // 
            this.中级ToolStripMenuItem1.Name = "中级ToolStripMenuItem1";
            this.中级ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.中级ToolStripMenuItem1.Text = "中级（H）";
            this.中级ToolStripMenuItem1.Click += new System.EventHandler(this.difficult_Click);
            // 
            // 高级ToolStripMenuItem
            // 
            this.高级ToolStripMenuItem.Name = "高级ToolStripMenuItem";
            this.高级ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.高级ToolStripMenuItem.Text = "高级（M）";
            this.高级ToolStripMenuItem.Click += new System.EventHandler(this.difficult_Click);
            // 
            // 排行榜RToolStripMenuItem
            // 
            this.排行榜RToolStripMenuItem.Name = "排行榜RToolStripMenuItem";
            this.排行榜RToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.排行榜RToolStripMenuItem.Text = "排行榜（R）";
            this.排行榜RToolStripMenuItem.Click += new System.EventHandler(this.rank_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.帮助HToolStripMenuItem.Text = "帮助（H）";
            this.帮助HToolStripMenuItem.Click += new System.EventHandler(this.help_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(143, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "耗时：";
            // 
            // btnStart
            // 
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Location = new System.Drawing.Point(222, -3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(41, 42);
            this.btnStart.TabIndex = 3;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "剩余地雷数：";
            // 
            // Mine_Weeper_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 349);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mine_Weeper_F";
            this.Text = "扫雷游戏";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblMine;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 难度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中级ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 高级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排行榜RToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}