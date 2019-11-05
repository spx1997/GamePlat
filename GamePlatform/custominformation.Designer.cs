namespace GamePlatform
{
    partial class custominformation
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pic_charact = new System.Windows.Forms.PictureBox();
            this.cname = new System.Windows.Forms.Label();
            this.pic_grade = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_charact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_grade)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pic_grade);
            this.panel1.Controls.Add(this.cname);
            this.panel1.Controls.Add(this.pic_charact);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 207);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "等级：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "昵称：";
            // 
            // pic_charact
            // 
            this.pic_charact.Location = new System.Drawing.Point(46, 18);
            this.pic_charact.Name = "pic_charact";
            this.pic_charact.Size = new System.Drawing.Size(82, 85);
            this.pic_charact.TabIndex = 2;
            this.pic_charact.TabStop = false;
            // 
            // cname
            // 
            this.cname.AutoSize = true;
            this.cname.Location = new System.Drawing.Point(62, 119);
            this.cname.Name = "cname";
            this.cname.Size = new System.Drawing.Size(41, 12);
            this.cname.TabIndex = 3;
            this.cname.Text = "label3";
            // 
            // pic_grade
            // 
            this.pic_grade.Location = new System.Drawing.Point(62, 134);
            this.pic_grade.Name = "pic_grade";
            this.pic_grade.Size = new System.Drawing.Size(100, 33);
            this.pic_grade.TabIndex = 4;
            this.pic_grade.TabStop = false;
            // 
            // custominformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "custominformation";
            this.Size = new System.Drawing.Size(207, 247);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_charact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_grade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic_charact;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_grade;
        private System.Windows.Forms.Label cname;
    }
}
