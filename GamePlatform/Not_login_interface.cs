using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlatform
{
    public partial class Not_login_interface : Form
    {
        DateTime dt = DateTime.Now;
        public static string  advertise = "制作者：石鹏翔\n\n学号：2153412\n\n版权所有，翻版必究";
        public static string getadvertise()
        {
            return advertise;
        }

        public Not_login_interface()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            btn_d_b.Click += button_Click;
            btn_d_dz.Click += button_Click;
            btn_d_e.Click += button_Click;
            btn_d_h.Click += button_Click;
            btn_d_l.Click += button_Click;
            btn_d_p.Click += button_Click;
            btn_d_q.Click += button_Click;
            btn_d_s.Click += button_Click;
            btn_d_t.Click += button_Click;
            btn_d_tcc.Click += button_Click;
            btn_d_tkdz.Click += button_Click;
            btn_d_txz.Click += button_Click;
            btn_d_ty.Click += button_Click;
            btn_d_w.Click += button_Click;
            btn_d_x.Click += button_Click;
            btn_d_xx.Click += button_Click;
           // pictureBox1.Click += button1_Click;
            pictureBox3.Click += button1_Click;
           // pictureBox4.Click += button1_Click;
            btn_w_cb.Click += button_Click;
            btn_w_cl.Click += button_Click;
            btn_w_s.Click += button_Click;
            btn_w_y.Click += button_Click;
            pictureBox2.Click += button1_Click;
            
        }

        private void 打开网页_Load(object sender, EventArgs e)
        {
           //StatusName.Text = "欢迎您：" + CName;
            label_Time.Text = "现在是：" + dt.Year + "年" + dt.Month + "月" + dt.Day + "日" + dt.Hour + "时" + dt.Minute + "分" + dt.Second + "秒";
            advertise_lab.Text = advertise;
        }

     

   
        //登录
        private void login_Click(object sender, EventArgs e)
        {
            Form loginfm = null;
            loginfm = new Login_inter();
            if (loginfm != null)
            {
                loginfm.Owner = this;
                loginfm.StartPosition = FormStartPosition.CenterParent;
                this.Hide();
                loginfm.ShowDialog(this);
            }
        }

        //internal static void hide()
        //{
            
        //    throw new NotImplementedException();
        //}

        private void button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请先登录，再开始游戏！","提示",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请先登录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://39.106.186.68/wp-blog");
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
