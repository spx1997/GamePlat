using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlatform.Five_file
{
    public partial class Five_F : Form
    {
        string cemail;
        string game_name;
      //  int score;
        public Five_F(string cemail,string game_name)
        {
            InitializeComponent();
            this.cemail=cemail;
            this.game_name=game_name;
        }
        public Boards bd;

        private void Form1_Load(object sender, EventArgs e)
        {
            bd = new Boards(this.CreateGraphics());
            bd.ClearBoards();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            bd.DrawBoard();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 680 && e.Y < 680)
            {
                int m = (int)(e.X / 42);
                int n = (int)(e.Y / 42);
                if (m < 0)
                { m = 0; }
                if (n < 0)
                { n = 0; }
                if (m > 14)
                { m = 14; }
                if (n > 14)
                { n = 14; }
                label1.Text = "X：" + m.ToString() + "  Y：" + n.ToString();
                toolStripStatusLabel1.Text = "落子点：X " + m.ToString() + " Y " + n.ToString() + "";
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bd.PersonPut(e.X, e.Y);

            if (historylist.Items.Count == 0)
            {
                historylist.Items.Add(bd.st.GetPerson());
                historylist.Items.Add(bd.st.GetPC());
            }
            else
            {
                if (historylist.Items[historylist.Items.Count - 1].ToString() != bd.st.GetPC() && historylist.Items[historylist.Items.Count - 2].ToString() != bd.st.GetPerson())
                {
                    historylist.Items.Add(bd.st.GetPerson());
                    historylist.Items.Add(bd.st.GetPC());
                }
            }
        }

        private void 新游戏ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void 玩家先ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 电脑先ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 排行榜RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Five_Rank_F five_rank_f = new Five_file.Five_Rank_F(game_name);
            five_rank_f.Show();
        }

        private void 帮助HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Five_Help_F five_help_f = new Five_Help_F();
            five_help_f.Show();
        }

        private void 保存得分ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存分数成功");
        }
    }
}
