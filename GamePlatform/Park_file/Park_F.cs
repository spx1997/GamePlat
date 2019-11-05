using GamePlatform.Con_code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlatform.Park_file
{
    public partial class Park_F : Form
    {
        string game_name;
        string cemail;

        private int[,] a;                 //车位之间的通道信息
        private int[] c = new int[7];     //车位中的车辆颜色代号
        private int[] d = new int[7];     //车位中的初始时车辆颜色代号
        private int order = 1;                //用户当前玩的关号
        private int Total = 3;            //总关数
        ArrayList trace = new ArrayList();
        Point p1 = new Point(68, 275);
        Point p2 = new Point(68, 125);
        Point p3 = new Point(218, 35);
        Point p4 = new Point(368, 125);
        Point p5 = new Point(368, 275);
        Point p6 = new Point(218, 355);
        Point[] p;

        public Park_F(string cemail, string game_name)
        {
            InitializeComponent();
            this.game_name = game_name;
            this.cemail = cemail;


            CustomInfo cus = new CustomInfo();
            cus.GetSqlData(cemail);
            label_name.Text = cus.Cname;
            label_order.Text = order.ToString();
        }

        

        private void btnsave_Click(object sender,EventArgs e)
        {
            Data_Game_R Inser_data = new Data_Game_R();
            Inser_data.Email = cemail;
            Inser_data.Score = order;
            Data_Game_W Inser_data_m = new Data_Game_W();
            Inser_data_m.Insert_Data(game_name, Inser_data);
            MessageBox.Show("游戏分数保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhelp_Click(object sender, EventArgs e)
        {
            Park_Help_F park_help_f = new Park_file.Park_Help_F();
            park_help_f.Show();
        }
        private void btnrank_Click(object sender, EventArgs e)
        {
            Park_Rank_F park_rank_f = new Park_Rank_F(game_name);
            park_rank_f.Show();
        }
        private void Park_F_Load(object sender, EventArgs e)
        {
            a = new int[7, 7];
            p = new Point[7] { new Point(0, 0), p1, p2, p3, p4, p5, p6 };
            order = 1;                   //当前是第一关

        }

        private void pBox_Click(object sender, EventArgs e)//事件处理方法
        {
            PictureBox pBox = (PictureBox)sender;
            int j = Convert.ToInt16(pBox.Name.Substring(pBox.Name.Length - 1, 1));
            //计算所在车位
            int n = 0;
            for (int i = 1; i <= 6; i++)
            {
                if (c[i] == j) n = i;
            }
            for (int m = 1; m <= 6; m++)
            {
                if (c[m] == 0)//找出空车位m
                {
                    if (a[m, n] == 1 || a[n, m] == 1)//如果车位m, n之间有通道
                    {
                        pBox.Location = p[m];//汽车移到空车位m
                        c[m] = c[n]; c[n] = 0;
                    }
                    break;
                }
            }
            if (success())
            {
                order++;
                label_order.Text = order.ToString();
                //select_order(order);
                MessageBox.Show("成功了", "恭喜");
                this.Text = "停车场游戏";
                this.Invalidate();
                button1_Click(sender, e);
            }
        }
        private void Draw_Road()//画出车位之间通道
        {
            Graphics g = this.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.BlanchedAlmond);
            for (int i = 1; i <= 6; i++)
                for (int j = 1; j <= 6; j++)
                {
                    if (a[i, j] == 1)//第i和j停车位有通道
                    {
                        g.DrawLine(new Pen(Color.Blue, 14),
                            p[i].X + 40, p[i].Y + 15, p[j].X + 40, p[j].Y + 15);
                    }
                }
        }
        private void Draw_park()//画出停车位
        {
            Graphics g = this.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.BlanchedAlmond);
            Rectangle r;
            r = new Rectangle(60, 250, 80, 80);
            g.DrawEllipse(new Pen(Color.Blue, 14), r);
            g.FillEllipse(b, r);

            r = new Rectangle(60, 100, 80, 80);
            g.DrawEllipse(new Pen(Color.Red, 14), r);
            g.FillEllipse(b, r);

            r = new Rectangle(210, 10, 80, 80);
            g.DrawEllipse(new Pen(Color.Yellow, 14), r);
            g.FillEllipse(b, r);

            r = new Rectangle(360, 100, 80, 80);
            g.DrawEllipse(new Pen(Color.Green, 14), r);
            g.FillEllipse(b, r);

            r = new Rectangle(360, 250, 80, 80);
            g.DrawEllipse(new Pen(Color.HotPink, 14), r);
            g.FillEllipse(b, r);

            r = new Rectangle(210, 330, 80, 80);
            g.DrawEllipse(new Pen(Color.Black, 14), r);
            g.FillEllipse(b, r);
        }
        private void Park_F_Activated(object sender, EventArgs e)
        {
            if (order > Total) return;
            Draw_Road();//画出车位之间通道
            Draw_park();//画出停车位
        }
        private void button1_Click(object sender, EventArgs e)//开始游戏
        {
            int n;
            if (order > Total)
            {
                foreach (object c in this.Controls)
                    if (c is PictureBox)
                        ((PictureBox)c).Visible = false;
                MessageBox.Show("通关了！！", "恭喜");
               // button2.Enabled = false;
                return;
            }
            init_order(order);
            for (int i = 1; i <= 5; i++)
            {
                n = c[i];
                string name = "pictureBox" + n.ToString();
                PictureBox pBox = (PictureBox)this.Controls.Find(name, false)[0];
                pBox.Location = p[i];
                pBox.BorderStyle = BorderStyle.Fixed3D;
                //设置车辆图片可见性                
                pBox.Visible = true;
                //对图片添加单击事件处理程序
               if (order == 1 && 开始ToolStripMenuItem.Enabled == true)
                    pBox.Click += new EventHandler(pBox_Click);
            }
            Draw_Road();//画出车位之间通道
            Draw_park();//画出停车位
           // button1.Enabled = false;
           // button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)//提示路线
        {
            d.CopyTo(c, 0);
            trace.Clear();    //清空提示路线 
            Next(6);
            string path = "单击车位顺序";
            foreach (object i in trace)
            {
                switch ((int)i)
                {
                    case 1: path += ">" + "蓝"; break;
                    case 2: path += ">" + "红"; break;
                    case 3: path += ">" + "黄"; break;
                    case 4: path += ">" + "绿"; break;
                    case 5: path += ">" + "粉"; break;
                }
            }
            this.Text = path;
            d.CopyTo(c, 0);
           // button2.Enabled = false;
            button1_Click(sender, e);
        }

        void Next(int n)
        {
            if (success()) return;//||trace.Count>10
            for (int m = 1; m <= 6; m++)
            {
                int i = m + n;
                if (i > 6) i = i - 6;
                bool flag = false;
                int temp = 0;
                if (a[n, i] == 1 || a[i, n] == 1)
                {
                    temp = c[i];
                    c[n] = c[i];
                    c[i] = 0;
                    trace.Add(i);
                    flag = true;
                    Next(i);
                }
                if (success()) break;
                if (!success() && flag == true)
                {
                    c[i] = temp;
                    c[n] = 0;
                    trace.RemoveAt(trace.Count - 1);
                }
            }
        }
        private bool success()
        {
            //判断车位颜色和车辆颜色是否相一致
            if (c[1] == 1 && c[2] == 2 && c[3] == 3
                && c[4] == 4 && c[5] == 5 && c[6] == 0)
                return true;
            else
                return false;
        }

        void init_order(int n)          //对第n关的车停放位置和通道信息初始化
        {
            for (int i = 1; i <= 6; i++)         //清空车位之间通道
                for (int j = 1; j <= 6; j++)
                {
                    a[i, j] = 0;
                }
            switch (n)
            {
                case 1://*********第一局*********
                    a[1, 2] = 1; a[2, 3] = 1;
                    a[3, 4] = 1; a[4, 5] = 1;
                    a[5, 6] = 1; a[6, 1] = 1;
                    a[1, 4] = 1; a[2, 5] = 1;
                    a[3, 6] = 1;
                    c[1] = 2; c[2] = 3; c[3] = 5;
                    c[4] = 1; c[5] = 4; c[6] = 0;
                    break;
                case 2://*********第二局*********
                    a[1, 6] = 1; a[1, 5] = 1;
                    a[2, 3] = 1; a[2, 6] = 1;
                    a[3, 4] = 1; a[4, 6] = 1;
                    a[5, 6] = 1;
                    c[1] = 5; c[2] = 4; c[3] = 2;
                    c[4] = 3; c[5] = 1; c[6] = 0;
                    break;
                case 3://*********第3局*********
                    a[1, 3] = 1; a[1, 4] = 1;
                    a[2, 5] = 1; a[2, 6] = 1;
                    a[3, 5] = 1; a[3, 6] = 1;
                    a[4, 6] = 1;
                    c[1] = 3; c[2] = 4; c[3] = 5;
                    c[4] = 1; c[5] = 2; c[6] = 0;
                    break;
                default: return;
            }
            c.CopyTo(d, 0); //d保存每关开始时车位中的初始车辆颜色代号
        }

    }
}
