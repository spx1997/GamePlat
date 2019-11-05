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
    
    public partial class register : Form
    {
        //验证码字符
        public static string connectionString = "Data source=localhost;database=GamePlatData;integrated security=SSPI";
        public static string cname;

        string verifyCode = string.Empty;
        public register()
        {
            InitializeComponent();
            RefrashVerifyCodeSimple();

        }
        //刷新简单的验证码
        private void RefrashVerifyCodeSimple()
        {
            VerifyCodeImgSimple code = new VerifyCodeImgSimple();
            verifyCode = code.CreateVerifyCode(4);
            pictureBox1.Image = code.CreateImage(verifyCode, 35, "楷体", Color.Blue, Color.White);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            txtemail.Text = "";
            txtPwd.Text = "";
            txtemail.Focus();
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cName = txtname.Text.Trim();
            string cEmail = txtemail.Text.Trim();
            string cpas = txtPwd.Text.Trim();
            string csex = sextxt.Text.Trim();
            Random ran = new Random();
            int cpic = ran.Next(1, 4);
            int cgrade = 0;
            int money = 0;

            //连接数据库
            //Data Source=(local);Initial Catalog=news;User ID=sa;Password=123

            SqlConnection conn = new SqlConnection(connectionString);
            //SqlConnection conn = new SqlConnection("Data source=127.0.0.1;Initial Catalog=GamePlatData;User ID=sa;Password=4183059");
            conn.Open();
            //查询新注册的用户是否存在
            SqlCommand checkCmd = conn.CreateCommand();//创建SQL命令对象
            string s = "select email from tab_custom where email='" + cEmail +"'";
            checkCmd.CommandText = s;
            //实例化数据适配器
            SqlDataAdapter check = new SqlDataAdapter();
            check.SelectCommand = checkCmd;
            DataSet checkData = new DataSet();                 //实例化结果数据集
           // int n = check.Fill(checkData, "register");         //将结果放入数据适配器，返回元组个数
            int n = check.Fill(checkData);         //将结果放入数据适配器，返回元组个数
            if (txtname.Text == "" || txtemail.Text == "" || txtPwd.Text == "" || ensurePw.Text == ""
                            || txtValidCode.Text == "")
            {
                MessageBox.Show("请将信息填完整");
            }
            else
            {
                if (n != 0)
                {
                    MessageBox.Show("用户名存在！");
                    txtname.Text = ""; txtPwd.Text = "";
                    txtemail.Text = "";
                }
                else
                {
                    //确认密码
                    if (ensurePw.Text != txtPwd.Text)
                    {
                        MessageBox.Show("两次密码不一样！");
                        ensurePw.Text = "";
                    }
                    else
                    {
                        //验证码
                        if (verifyCode.ToUpper() != this.txtValidCode.Text.ToUpper())
                        {
                            MessageBox.Show("验证码输入有误！请重新输入");
                            this.txtValidCode.Text = "";
                            RefrashVerifyCodeSimple();
                        }
                        else
                        {
                            //插入数据SQL  逻辑
                            string s1 = "insert into tab_custom(name,sex,email,passwd,pic_num,grade,money) values ('" + txtname.Text + "','" + sextxt.Text + "','" + txtemail.Text + "','" + txtPwd.Text + "','" + cpic + "','" + cgrade + "','" + money + "')"; //编写SQL命令
                            SqlCommand mycom = new SqlCommand(s1, conn);          //初始化命令
                            mycom.ExecuteNonQuery();             //执行语句
                            conn.Close();                       //关闭连接
                            mycom = null;
                            conn.Dispose();                     //释放对象

                            MessageBox.Show("注册成功");
                            this.Close();
                            this.Close();
                        }

                    }
                }
            }
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefrashVerifyCodeSimple();
        }

    }
}
