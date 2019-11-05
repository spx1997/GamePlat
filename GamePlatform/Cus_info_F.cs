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

namespace GamePlatform
{
    public partial class Cus_info_F : Form
    {
        string cemail;
        public Cus_info_F(string cemail)
        {
            InitializeComponent();
            this.cemail = cemail;

            CustomInfo cus = new CustomInfo();
            cus.GetSqlData(cemail);
            label_money.Text =Convert.ToString(cus.Money) ;
            label_name.Text = cus.Cname;
            label_rank.Text = cus.Rank;
            label_sex.Text = cus.Sex;
            label_passwd.Text = cus.Passwd;
            label_email.Text = cus.Email;
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            CustomInfo cus = new CustomInfo();
            cus.GetSqlData(label_email.Text);
            cus.Sex = label_sex.Text;
            cus.Cname = label_name.Text;
            cus.Email = label_email.Text;
            //cus.Rank = label_rank.Text;
            cus.Passwd = label_passwd.Text;
            cus.Money =Convert.ToInt16(label_money.Text);
            cus.UpdateCus(label_email.Text);
            MessageBox.Show("修改成功！");
        }

    }
}
