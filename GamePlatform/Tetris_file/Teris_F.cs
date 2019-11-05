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

namespace GamePlatform.Tetris_file
{
    public partial class Teris_F : Form
    {
        string game_name;
        string cemail;
        bool startflag = false;
        public Teris_F(string cemail,string game_name)
        {
            InitializeComponent();
            this.game_name = game_name;
            this.cemail = cemail;
        }
        Game game = null;
        private void button1_Click(object sender, EventArgs e)
        {
            startflag = true;
            game = new Game();
            pictureBox1.Height = Game.BlockImageHeight * Game.PlayingFieldHeight + 3;
            pictureBox1.Width = Game.BlockImageWidth * Game.PlayingFieldWidth + 3;
            pictureBox1.Invalidate();//重画游戏面板区域
            timer1.Enabled = true;
            button1.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "暂停游戏")
            {
                timer1.Enabled = false; button2.Text = "继续游戏";
            }
            else
            {
                timer1.Enabled = true; button2.Text = "暂停游戏";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //重画游戏面板
            if (game != null)
            {
                game.DrawPile(e.Graphics);
                game.DrawCurrentBlock(e.Graphics);
            }
        }
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            ////重画下一个方块
            if (game != null) game.DrawNextBlock(e.Graphics);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!game.DownCurrentBlock())
            {
                pictureBox1.Invalidate();//重画游戏面板区域
                pictureBox2.Invalidate();//重画下一个方块
            }
            lblScore.Text = game.score.ToString();
            if (game.over == true)
            {
                timer1.Enabled = false;
                MessageBox.Show("游戏结束,", "提示");
                button1.Enabled = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys e)
        //重写ProcessCmdKey方法
        {
            if (button2.Text == "继续游戏") return true;//暂停时不响应键盘
            if (e == Keys.Up || e == Keys.Down || e == Keys.Space ||
                     e == Keys.Left || e == Keys.Right)
            {
                MyKeyPress(this, new KeyPressEventArgs((char)e));
            }
            return true;
        }
        //然后在MyKeyPress方法中处理   
        private void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            if (startflag)
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Up:
                        game.RotateCurrentBlock();
                        break;
                    case (char)Keys.Down:
                        if (!game.DownCurrentBlock())
                            pictureBox1.Invalidate();//重画游戏面板区域
                        break;
                    case (char)Keys.Right:
                        game.MoveCurrentBlockSide(false);
                        break;
                    case (char)Keys.Left:
                        game.MoveCurrentBlockSide(true);
                        break;
                    case (char)Keys.Space:
                        button2.PerformClick();
                        break;
                }
                pictureBox1.Invalidate();
                pictureBox2.Invalidate();
            }
          
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Interval = 550 - Convert.ToInt16(comboBox1.Text) * 50;
        }
        private void save_Click(object sender,EventArgs e)
        {
            if (!startflag) MessageBox.Show("游戏还未开始！");
            else
            {
                Data_Game_R Inser_data = new Data_Game_R();
                Inser_data.Email = cemail;
                Inser_data.Score = game.score;
                Data_Game_W Inser_data_m = new Data_Game_W();
                Inser_data_m.Insert_Data(game_name, Inser_data);
                MessageBox.Show("游戏分数保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void help_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Teris_Help_F teris_help_f = new Teris_Help_F();
            teris_help_f.Show();
            timer1.Enabled = true;
        }
        private void rank_Click(object sender, EventArgs e)
        {

            Teris_Rank_F teris_rank_f = new Teris_Rank_F(game_name);
            teris_rank_f.Show(); 
        }
    }
}
