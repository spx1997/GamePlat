using GamePlatform.Con_code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlatform.HuaRong_file
{
    public partial class HuaRong_F : Form
    {
        private readonly int[,] A = new int[7, 6];
        private readonly Button[] Bing = new Button[4];
        private readonly Button[] Jiang = new Button[4];
        private Point P1, P2;
        private int W = 80;
        private bool start = true;
        private int step;
        int Score=-1;

        string game_name;
        string cemail;

        public HuaRong_F(string cemail,string game_name)
        {
            InitializeComponent();
            this.cemail = cemail;
            this.game_name = game_name;

            CustomInfo cus = new CustomInfo();
            cus.GetSqlData(cemail);
            label_name.Text = cus.Cname;
        }
        /// <summary>
        ///   开始按钮
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (start)
            {
                int i, j;
                for (i = 0; i < 7; i++)
                    for (j = 0; j < 6; j++)
                        A[i, j] = 1;
                A[5, 2] = 0;
                A[5, 3] = 0; //出口
                panel1.Enabled = true;
                step = 0;
                label2.Text = step.ToString(); //步数
                AddControl();
                InitPosition();
            }
            start = false;
        }
        private void btnSave_Click(object sender,EventArgs e)
        {
            if (Score!=-1)
            {
                Data_Game_R Inser_data = new Data_Game_R();
                Inser_data.Email = cemail;
                Inser_data.Score = Score;
                Data_Game_W Inser_data_m = new Data_Game_W();
                Inser_data_m.Insert_Data(game_name, Inser_data);
                MessageBox.Show("游戏分数保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("游戏尚未结束，游戏分数保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            HuaRong_Help_F huarong_help_f = new HuaRong_Help_F();
            huarong_help_f.Show();
        }
        private void btnRank_Click(object sender, EventArgs e)
        {
            HuaRong_Rank_F huarong_rank_f = new HuaRong_Rank_F(game_name);
            huarong_rank_f.Show();
        }
        private void AddControl() //添加图像的方块的事件方法
        {
            Bing[0] = btnB1;
            Bing[1] = btnB2;
            Bing[2] = btnB3;
            Bing[3] = btnB4;
            for (int i = 0; i < 4; i++)
            {
                Bing[i].MouseDown += btnB_MouseDown;
                Bing[i].MouseUp += btnB_MouseUp;
            }
            Jiang[0] = btnzf; //张飞
            Jiang[1] = btnzy; //赵云
            Jiang[2] = btnmc; //马超
            Jiang[3] = btnhz; //黄忠
            for (int i = 0; i < 4; i++)
            {
                Jiang[i].MouseDown += btnJiang_MouseDown;
                Jiang[i].MouseUp += btnJiang_MouseUp;
            }
        }

        private void InitPosition() //头像方块起始位置
        {
            btnzy.Left = 0;
            btnzy.Top = 0;
            btncc.Left = 80;
            btncc.Top = 0;
            btnmc.Left = 240;
            btnmc.Top = 0;
            btnhz.Left = 240;
            btnhz.Top = 160;
            btngy.Left = 80;
            btngy.Top = 160;
            btnzf.Left = 0;
            btnzf.Top = 160;
            btnB2.Left = 80;
            btnB2.Top = 240;
            btnB3.Left = 160;
            btnB3.Top = 240;
            btnB1.Left = 0;
            btnB1.Top = 320;
            btnB4.Left = 240;
            btnB4.Top = 320;
        }

        /// <summary>
        ///   重置按钮
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            InitPosition();
            int i, j;
            for (i = 0; i < 7; i++)
                for (j = 0; j < 6; j++)
                    A[i, j] = 1;
            A[5, 2] = 0;
            A[5, 3] = 0;
            panel1.Enabled = true;
            step = 0;
            label2.Text = step.ToString(); //步数
        }

        private string Direct()
        {
            int dx, dy;
            string dir;
            dx = P2.X - P1.X;
            dy = P2.Y - P1.Y;
            if (Math.Abs(dx) > Math.Abs(dy)) //表示在水平方向上运动
            {
                if (dx > 0) dir = "Right";
                else dir = "Left";
            }
            else //表示在垂直方向上运动
            {
                if (dy > 0) dir = "Down";
                else dir = "Up";
            }
            return dir;
        }

        private void btnB_MouseDown(object sender, MouseEventArgs e)
        {
            P1.X = e.X;
            P1.Y = e.Y;
        }

        private void btnB_MouseUp(object sender, MouseEventArgs e) //兵
        {
            P2.X = e.X;
            P2.Y = e.Y;
            string dir = Direct();
            int R, C; //当前控件所在单元格的行和列
            R = ((Button)sender).Top / W + 1;
            C = ((Button)sender).Left / W + 1;
            switch (dir)
            {
                case "Right":
                    if (A[R, C + 1] == 0)
                    {
                        ((Button)sender).Left += W;
                        A[R, C] = 0;
                        A[R, C + 1] = 1;
                        step++;
                    }
                    break;
                case "Left":
                    if (A[R, C - 1] == 0)
                    {
                        ((Button)sender).Left -= W;
                        A[R, C] = 0;
                        A[R, C - 1] = 1;
                        step++;
                    }
                    break;
                case "Down":
                    if (A[R + 1, C] == 0)
                    {
                        ((Button)sender).Top += W;
                        A[R, C] = 0;
                        A[R + 1, C] = 1;
                        step++;
                    }
                    break;
                case "Up":
                    if (A[R - 1, C] == 0)
                    {
                        ((Button)sender).Top -= W;
                        A[R, C] = 0;
                        A[R - 1, C] = 1;
                        step++;
                    }
                    break;
            }
            label2.Text = step.ToString(); //步数
        }

        private void btnJiang_MouseDown(object sender, MouseEventArgs e)
        {
            P1.X = e.X;
            P1.Y = e.Y;
        }

        private void btnJiang_MouseUp(object sender, MouseEventArgs e) //4个将军
        {
            P2.X = e.X;
            P2.Y = e.Y;
            string dir = Direct();
            int R, C; //当前控件所在单元格的行和列
            R = ((Button)sender).Top / W + 1;
            C = ((Button)sender).Left / W + 1;
            switch (dir)
            {
                case "Right":
                    if (A[R, C + 1] == 0 && A[R + 1, C + 1] == 0)
                    {
                        ((Button)sender).Left += W;
                        A[R, C] = 0;
                        A[R, C + 1] = 1;
                        A[R + 1, C] = 0;
                        A[R + 1, C + 1] = 1;
                        step++;
                    }
                    break;
                case "Left":
                    if (A[R, C - 1] == 0 && A[R + 1, C - 1] == 0)
                    {
                        ((Button)sender).Left -= W;
                        A[R, C] = 0;
                        A[R, C - 1] = 1;
                        A[R + 1, C] = 0;
                        A[R + 1, C - 1] = 1;
                        step++;
                    }
                    break;
                case "Down":
                    if (A[R + 2, C] == 0)
                    {
                        ((Button)sender).Top += W;
                        A[R, C] = 0;
                        A[R + 2, C] = 1;
                        step++;
                    }
                    break;
                case "Up":
                    if (A[R - 1, C] == 0)
                    {
                        ((Button)sender).Top -= W;
                        A[R + 1, C] = 0;
                        A[R - 1, C] = 1;
                        step++;
                    }
                    break;
            }
            label2.Text = step.ToString(); //步数
        }

        private void btncc_MouseUp(object sender, MouseEventArgs e) //曹操
        {
            P2.X = e.X;
            P2.Y = e.Y;
            string dir = Direct();
            int R, C; //当前控件所在单元格的行和列
            R = ((Button)sender).Top / W + 1;
            C = ((Button)sender).Left / W + 1;
            switch (dir)
            {
                case "Right":
                    if (A[R, C + 2] == 0 && A[R + 1, C + 2] == 0)
                    {
                        ((Button)sender).Left += W;
                        A[R, C] = 0;
                        A[R, C + 2] = 1;
                        A[R + 1, C] = 0;
                        A[R + 1, C + 2] = 1;
                        step++;
                    }
                    break;
                case "Left":
                    if (A[R, C - 1] == 0 && A[R + 1, C - 1] == 0)
                    {
                        ((Button)sender).Left -= W;
                        A[R, C + 1] = 0;
                        A[R, C - 1] = 1;
                        A[R + 1, C + 1] = 0;
                        A[R + 1, C - 1] = 1;
                        step++;
                    }
                    break;
                case "Down":
                    if (A[R + 2, C] == 0 && A[R + 2, C + 1] == 0)
                    {
                        ((Button)sender).Top += W;
                        A[R, C] = 0;
                        A[R, C + 1] = 0;
                        A[R + 2, C] = 1;
                        A[R + 2, C + 1] = 1;
                        step++;
                    }
                    break;
                case "Up":
                    if (A[R - 1, C] == 0 && A[R - 1, C + 1] == 0)
                    {
                        ((Button)sender).Top -= W;
                        A[R + 1, C] = 0;
                        A[R - 1, C] = 1;
                        A[R + 1, C + 1] = 0;
                        A[R - 1, C + 1] = 1;
                        step++;
                    }
                    break;
            }
            label2.Text = step.ToString(); //步数
            Button B = ((Button)sender);
            if (B.Left == 80 && B.Top == 240)
            {
                MessageBox.Show("你胜利了！！");
                Score =Convert.ToInt16(10000 / step);
            }
        }

        private void btngy_MouseUp(object sender, MouseEventArgs e) //关羽
        {
            P2.X = e.X;
            P2.Y = e.Y;
            string dir = Direct();
            int R, C; //当前控件所在单元格的行和列
            R = ((Button)sender).Top / W + 1;
            C = ((Button)sender).Left / W + 1;
            switch (dir)
            {
                case "Right":
                    if (A[R, C + 2] == 0)
                    {
                        ((Button)sender).Left += W;
                        A[R, C] = 0;
                        A[R, C + 2] = 1;
                        step++;
                    }
                    break;
                case "Left":
                    if (A[R, C - 1] == 0)
                    {
                        ((Button)sender).Left -= W;
                        A[R, C + 1] = 0;
                        A[R, C - 1] = 1;
                        step++;
                    }
                    break;
                case "Down":
                    if (A[R + 1, C] == 0 && A[R + 1, C + 1] == 0)
                    {
                        ((Button)sender).Top += W;
                        A[R, C] = 0;
                        A[R + 1, C] = 1;
                        A[R, C + 1] = 0;
                        A[R + 1, C + 1] = 1;
                        step++;
                    }
                    break;
                case "Up":
                    if (A[R - 1, C] == 0 && A[R - 1, C + 1] == 0)
                    {
                        ((Button)sender).Top -= W;
                        A[R, C] = 0;
                        A[R - 1, C] = 1;
                        A[R, C + 1] = 0;
                        A[R - 1, C + 1] = 1;
                        step++;
                    }
                    break;
            }
            label2.Text = step.ToString(); //步数
        }
    }
}
