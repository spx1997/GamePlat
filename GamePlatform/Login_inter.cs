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

namespace GamePlatform
{
    public partial class Login_inter : Form
    {
        private int errorTime = 3;
        //验证码字符

        string verifyCode = string.Empty;
        //刷新简单的验证码
        private void RefrashVerifyCodeSimple()
        {
            VerifyCodeImgSimple code = new VerifyCodeImgSimple();
            verifyCode = code.CreateVerifyCode(4);
            pictureBox1.Image = code.CreateImage(verifyCode, 35, "楷体", Color.Blue, Color.White);

        }
        public Login_inter()
        {
            InitializeComponent();
            RefrashVerifyCodeSimple();
        }

        private void register_Click(object sender, EventArgs e)
        {
            Form fm = null;
            fm = new register();
            if (fm != null)
            {
                fm.Owner = this;
                fm.StartPosition = FormStartPosition.CenterParent;
                fm.ShowDialog(this);
            }
        }

        private void login_Click(object sender, EventArgs e)
        {
            string cemail = txtemail.Text.ToString();
            string cpasw = txtpsw.Text.ToString();
            errorTime = errorTime - 1;

            SqlConnection conn = new SqlConnection(GamePlatform.register.connectionString);
            conn.Open();

            //创建SQL命令执行对象
            SqlCommand mycom = conn.CreateCommand();

            //编写SQL命令
            string s1 = "select email,passwd from tab_custom where email='" + cemail + "'and passwd='" + cpasw + "'";
            
            //执行Sql命令
            mycom.CommandText = s1;
            
            //实例化数据适配器
            SqlDataAdapter myDA = new SqlDataAdapter();
            
            //让适配器执行select命令
            myDA.SelectCommand = mycom;
            
            //实例化结果集
            DataSet myDS = new DataSet();
            //将结果放入数据适配器，放回元组个数
            int n = myDA.Fill(myDS, "tab_custom");
            if (n != 0)
            {
                if(checktxt.Text.ToUpper()== verifyCode.ToUpper())
                {
                    CustomInfo cus = new CustomInfo();
                    cus.GetSqlData(cemail);
                    cus.Grade = cus.Grade + 1;
                    //string categoryName = TextBox2.Text;
                    //string categoryDescription = TextBox3.Text;
                    //string MyConn = "server=127.0.0.1;uid=user;pwd=123456;database=Northwind;Trusted_Connection=no";
                    //SqlConnection MyConnection = new SqlConnection(MyConn);
                    //string MyUpdate = "Update Categories set CategoryName='" + categoryName + "',Description='" + categoryDescription + "' where CategoryID=" + TextBox1.Text;
                    //SqlCommand MyCommand = new SqlCommand(MyUpdate, MyConnection);
                    //try
                    //{
                    //    MyConnection.Open();
                    //    MyCommand.ExecuteNonQuery();
                    //    MyConnection.Close();
                    //    TextBox1.Text = "";
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine("{0} Exception caught.", ex);
                    //}

                    //string MyUpdate="Update Categories set CategoryName='"+categoryName+"',Description='"+categoryDescription+"' where CategoryID="+TextBox1.Text;  
                    string MyConn = GamePlatform.register.connectionString;
                    SqlConnection MyConnection = new SqlConnection(MyConn);
                    string myupdate = "Update tab_custom set grade='" + cus.Grade + "' where email='" + cus.Email+"'";
                    SqlCommand MyCommand = new SqlCommand(myupdate, MyConnection);
                    try//异常处理  
                    {
                        MyConnection.Open();
                        MyCommand.ExecuteNonQuery();
                        MyConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0} Exception caught.", ex);
                    }

                    //MessageBox.Show("欢迎进入游戏！");
                    // Not_login_interface.hide();
                    Main main = new Main(cemail);
                    main.Show();
                    this.Close();
                }else
                {
                    MessageBox.Show("验证码填写有错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checktxt.Text = "";
                }
            }else
            {
                MessageBox.Show("邮箱，或者账号错误","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefrashVerifyCodeSimple();
        }
    }
}
