namespace GamePlatform.Snake_file
{
    partial class Snake_F
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuGame = new System.Windows.Forms.ToolStripMenuItem();
            this.MemuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MemuPause = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.速度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加快ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.减速ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排行榜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfood = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_food = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "级别：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "分数：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuGame,
            this.速度ToolStripMenuItem,
            this.排行榜ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(676, 25);
            this.menuStrip1.TabIndex = 4;
            // 
            // MenuGame
            // 
            this.MenuGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MemuStart,
            this.保存ToolStripMenuItem,
            this.MemuPause,
            this.MenuExit});
            this.MenuGame.Name = "MenuGame";
            this.MenuGame.Size = new System.Drawing.Size(77, 21);
            this.MenuGame.Text = "游戏（G）";
            // 
            // MemuStart
            // 
            this.MemuStart.Name = "MemuStart";
            this.MemuStart.Size = new System.Drawing.Size(100, 22);
            this.MemuStart.Text = "开始";
            this.MemuStart.Click += new System.EventHandler(this.MemuStart_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.save_Click);
            // 
            // MemuPause
            // 
            this.MemuPause.Enabled = false;
            this.MemuPause.Name = "MemuPause";
            this.MemuPause.Size = new System.Drawing.Size(100, 22);
            this.MemuPause.Text = "暂停";
            this.MemuPause.Click += new System.EventHandler(this.MemuPause_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Enabled = false;
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(100, 22);
            this.MenuExit.Text = "退出";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // 速度ToolStripMenuItem
            // 
            this.速度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加快ToolStripMenuItem,
            this.减速ToolStripMenuItem});
            this.速度ToolStripMenuItem.Name = "速度ToolStripMenuItem";
            this.速度ToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.速度ToolStripMenuItem.Text = "速度（S）";
            // 
            // 加快ToolStripMenuItem
            // 
            this.加快ToolStripMenuItem.Name = "加快ToolStripMenuItem";
            this.加快ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.加快ToolStripMenuItem.Text = "加快";
            this.加快ToolStripMenuItem.Click += new System.EventHandler(this.加快ToolStripMenuItem_Click);
            // 
            // 减速ToolStripMenuItem
            // 
            this.减速ToolStripMenuItem.Name = "减速ToolStripMenuItem";
            this.减速ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.减速ToolStripMenuItem.Text = "减速";
            this.减速ToolStripMenuItem.Click += new System.EventHandler(this.减速ToolStripMenuItem_Click);
            // 
            // 排行榜ToolStripMenuItem
            // 
            this.排行榜ToolStripMenuItem.Name = "排行榜ToolStripMenuItem";
            this.排行榜ToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.排行榜ToolStripMenuItem.Text = "排行榜（R）";
            this.排行榜ToolStripMenuItem.Click += new System.EventHandler(this.排行榜ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助ToolStripMenuItem.Text = "帮助(H)";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "当前用户：";
            // 
            // txtemail
            // 
            this.txtemail.AutoSize = true;
            this.txtemail.Location = new System.Drawing.Point(80, 48);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(41, 12);
            this.txtemail.TabIndex = 8;
            this.txtemail.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "当前食物：";
            // 
            // txtfood
            // 
            this.txtfood.AutoSize = true;
            this.txtfood.Location = new System.Drawing.Point(522, 181);
            this.txtfood.Name = "txtfood";
            this.txtfood.Size = new System.Drawing.Size(11, 12);
            this.txtfood.TabIndex = 10;
            this.txtfood.Text = " ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_food);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(499, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 252);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "个人信息";
            // 
            // label_food
            // 
            this.label_food.AutoSize = true;
            this.label_food.Location = new System.Drawing.Point(80, 177);
            this.label_food.Name = "label_food";
            this.label_food.Size = new System.Drawing.Size(41, 12);
            this.label_food.TabIndex = 10;
            this.label_food.Text = "label5";
            // 
            // Snake_F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 427);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtfood);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Snake_F";
            this.Text = "贪吃蛇";
            this.Load += new System.EventHandler(this.Snake_F_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Snake_F_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuGame;
        private System.Windows.Forms.ToolStripMenuItem MemuStart;
        private System.Windows.Forms.ToolStripMenuItem MemuPause;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem 速度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加快ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 减速ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtemail;
        private System.Windows.Forms.ToolStripMenuItem 排行榜ToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtfood;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_food;
    }
}