using GamePlatform.Con_code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GamePlatform;
using GamePlatform.Snake_file;
using GamePlatform.Mine_weeper_file;
using GamePlatform.Tank_File;
using GamePlatform.Tetris_file;
using GamePlatform.HuaRong_file;
using GamePlatform.Sokoban_file;
using GamePlatform.Park_file;
using GamePlatform.Puzzle_file;
using GamePlatform.Type_file;
using GamePlatform.Variety_Of_Boxs_file;
using GamePlatform.Lian_Look_file;
using GamePlatform.Five_file;

namespace GamePlatform
{
    public partial class Main : Form
    {
        CustomInfo cus = new CustomInfo();
        string cemail;
        DateTime dt = DateTime.Now;
        public Main(string cemail)
        {
            InitializeComponent();
            this.cemail = cemail;
        }

        private void main_load(object sender, EventArgs e)
        {
            cus.GetSqlData(cemail);
            string str_adv = Not_login_interface.getadvertise();
            string startupPath = Application.StartupPath;                           //值是：C:\App\project\gar\bin\Debug
            startupPath = startupPath.Substring(0, startupPath.LastIndexOf("\\"));  //这里把\\Debug移除了，//值是：C:\App\project\gar\bin
            startupPath = startupPath.Substring(0, startupPath.LastIndexOf("\\"));  //这里把\\bin移除了,//值是：C:\App\project\gar

            label_adv.Text = str_adv;

            label_status.Text = "现在是：" + dt.Year + "年" + dt.Month + "月" + dt.Day + "日" + dt.Hour + "时" + dt.Minute + "分" + dt.Second + "秒";
            //SqlConnection conn = new SqlConnection(GamePlatform.register.connectionString);
            //conn.Open();
            label_name.Text = cus.Cname;
            label_statuename.Text = cus.Cname+",您好！";
            if (cus.Sex == "男")
            {
                Bitmap b_pic = new Bitmap(startupPath + @"\Resources\character\pic_head1\man\" + cus.Pic);
                this.pic_head.BackgroundImage = b_pic;
                //this.pic_head.BackgroundImageLayout = "stretch";

            }
            else
            {
                Bitmap b_pic = new Bitmap(startupPath + @"\Resources\character\pic_head1\woman\" + cus.Pic);
                this.pic_head.BackgroundImage = b_pic;
            }
            //if (cus.Grade <= 20)
            //{
            //    Bitmap b_pic = new Bitmap(startupPath + @"\Resources\picture_grade\1.png");
            //    this.pic_grade.BackgroundImage = b_pic;
            //}
            //else if (cus.Grade <= 50)
            //{
            //    Bitmap b_pic = new Bitmap(startupPath + @"\Resources\picture_grade\2.png");
            //    this.pic_grade.BackgroundImage = b_pic;
            //}
            //else if (cus.Grade <= 90)
            //{
            //    Bitmap b_pic = new Bitmap(startupPath + @"\Resources\picture_grade\3.png");
            //    this.pic_grade.BackgroundImage = b_pic;
            //}
            //else if (cus.Grade <= 140)
            //{
            //    Bitmap b_pic = new Bitmap(startupPath + @"\Resources\picture_grade\4.png");
            //    this.pic_grade.BackgroundImage = b_pic;
            //}
            //else
            //{
            //    Bitmap b_pic = new Bitmap(startupPath + @"\Resources\picture_grade\5.png");
            //    this.pic_grade.BackgroundImage = b_pic;
            //}
            label_rank.Text = cus.Rank;
            
        }

        private void btn_d_t_Click(object sender, EventArgs e)
        {
            Snake_F snake_f = new Snake_F(cemail, "Snake");
            snake_f.Show();
        }

        private void btn_d_s_Click(object sender, EventArgs e)
        {
            Mine_Weeper_F mine_weeper_f = new Mine_Weeper_F(cemail, "Minesweeper");
            mine_weeper_f.Show();
        }

        private void btn_d_tkdz_Click(object sender, EventArgs e)
        {
            Tank_F tank_f= new Tank_F(cemail, "Tank_battle");
            tank_f.Show();
        }

        private void btn_d_e_Click(object sender, EventArgs e)
        {
            Teris_F teris_f = new Teris_F(cemail, "Tetris");
            teris_f.Show();
        }

        private void btn_d_h_Click(object sender, EventArgs e)
        {
            HuaRong_F huarong_f = new HuaRong_F(cemail, "Huarong_Road");
            huarong_f.Show();
        }

        private void btn_d_txz_Click(object sender, EventArgs e)
        {
            Sokoban_F sokoban_f = new Sokoban_F(cemail, "Sokoban");
            sokoban_f.Show();
        }

        private void btn_d_tcc_Click(object sender, EventArgs e)
        {
            Park_F park_f = new Park_F(cemail, "Parking");
            park_f.Show();
        }

        private void btn_d_p_Click(object sender, EventArgs e)
        {
            Puzzle_F puzzle_f = new Puzzle_F(cemail, "Puzzle");
            puzzle_f.Show();
        }

        private void btn_w_s_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://seer.61.com/");

        }

        private void btn_w_cb_Click(object sender, EventArgs e)
        {
            //http://news.4399.com/csbh/
            System.Diagnostics.Process.Start("http://news.4399.com/csbh/");
        }

        private void btn_w_cl_Click(object sender, EventArgs e)
        {
            //http://news.4399.com/cslm/
            System.Diagnostics.Process.Start("http://news.4399.com/cslm/");
        }

        private void btn_w_y_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4399.com/flash/64131.htm");
        }

        private void btn_d_dz_Click(object sender, EventArgs e)
        {
            Type_F type_f = new Type_F(cemail, "Typing_game");
            type_f.Show();
        }

       

        private void btn_d_b_Click(object sender, EventArgs e)
        {
            Variety_OF_Box_F variet_of_box_f = new Variety_OF_Box_F(cemail, "Variety_of_boxes");
            variet_of_box_f.Show();
        }

        private void btn_d_l_Click(object sender, EventArgs e)
        {
            Lian_F lian_f=new Lian_F (cemail , "Lianlianlook") ;
            lian_f.Show();
        }

        private void btn_d_w_Click(object sender, EventArgs e)
        {
            Five_F five_f = new Five_F(cemail, "Gobang");
            five_f.Show();
        }

        private void btn_zh_Click(object sender, EventArgs e)
        {
            Recharge_F recharge_f = new Recharge_F();
            recharge_f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Mine_Weeper_F mine_weeper_f = new Mine_Weeper_F(cemail, "Minesweeper");
            mine_weeper_f.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://39.106.186.68/wp-blog");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Cus_info_F cus_info_f = new GamePlatform.Cus_info_F(cemail);
            if (cus_info_f != null)
            {
                cus_info_f.Owner = this;
                cus_info_f.StartPosition = FormStartPosition.CenterParent;
                //this.Hide();
                cus_info_f.ShowDialog(this);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form tel_f = null;
            tel_f = new Tel_F();
            if (tel_f != null)
            {
                tel_f.Owner = this;
                tel_f.StartPosition = FormStartPosition.CenterParent;
                //this.Hide();
                tel_f.ShowDialog(this);
            }
        }
    }
}
