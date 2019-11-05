using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Con_code
{
    class CustomInfo
    {
        string id;
        string cname;
        string sex;
        string email;
        string passwd;
        int pic_num;
        int grade;
        string pic;
        string rank;
        int money;
        public int Money
        {
            get { return money; }
            set { money = value; }
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Cname
        {
            get { return cname; }
            set { cname = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Passwd
        {
            get { return passwd; }
            set { passwd = value; }
        }
        public int Pic_num
        {
            get { return pic_num; }
            set { pic_num = value; }
        }
        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        public string Pic
        {
            get { return pic; }
            set { pic = value; }
        }
        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        //从数据库中得到用户的信息
        public void GetSqlData(string Sql_email)
        {
            SqlConnection conn = new SqlConnection(GamePlatform.register.connectionString);
            conn.Open();
            string Inquire = "select name,sex,email,passwd,pic_num,grade,money from tab_custom where email='" + Sql_email + "'";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = Inquire;
            SqlDataReader reader = cmd.ExecuteReader();
            //从reader中读取下一行数据,如果没有数据,reader.Read()返回flase  
            while (reader.Read())
            {
                //reader.GetOrdinal("id")是得到ID所在列的index,  
                //reader.GetInt32(int n)这是将第n列的数据以Int32的格式返回  
                //reader.GetString(int n)这是将第n列的数据以string 格式返回  
                cname= reader.GetString(reader.GetOrdinal("name"));
                sex = reader.GetString(reader.GetOrdinal("sex"));
                email = reader.GetString(reader.GetOrdinal("email"));
                passwd = reader.GetString(reader.GetOrdinal("passwd"));
                pic_num = reader.GetInt32(reader.GetOrdinal("pic_num"));
                pic = Convert.ToString(pic_num) + ".jpg";
                grade = reader.GetInt32(reader.GetOrdinal("grade"));
                if (grade < 10) rank = "江湖小虾";
                else if (grade < 30) rank = "江湖新秀";
                else if (grade < 70) rank = "江湖少侠";
                else if (grade < 120) rank = "江湖大侠";
                else if (grade < 200) rank = "一代宗师";
                else rank = "独孤求败";
                money= reader.GetInt32(reader.GetOrdinal("money"));
            }
        }
        //string categoryName = TextBox2.Text;
        //string categoryDescription = TextBox3.Text;
        //string MyConn = "server=127.0.0.1;uid=user;pwd=123456;database=Northwind;Trusted_Connection=no";
        //SqlConnection MyConnection = new SqlConnection(MyConn);//
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
        //更新用户的信息
        public void UpdateCus(string Sql_email)
        {
            //CustomInfo cus = new CustomInfo();

            SqlConnection conn = new SqlConnection(GamePlatform.register.connectionString);
            string myupdate = "update tab_custom set name='" + cname + "',sex='" + sex + "',email='" + email + "',passwd='" + passwd + "',grade='" + grade + "',money='" + money + "' where email='" + Sql_email + "'";
            SqlCommand cmd = new SqlCommand(myupdate, conn);
            //异常处理
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }
        //向数据库中写入数据
        public void InsertDate(string Sql_email)
        {
            //插入数据SQL  逻辑
            SqlConnection conn = new SqlConnection(GamePlatform.register.connectionString);
            string myinsert = "insert into tab_custom(name,sex,email,passwd,pic_num,grade,money) values ('" +cname  + "','" +sex + "','" +email  + "','" +passwd  + "','" +pic_num  + "','" + money + "')"; //编写SQL命令
            SqlCommand mycom = new SqlCommand(myinsert, conn);          //初始化命令
            mycom.ExecuteNonQuery();             //执行语句
            conn.Close();                       //关闭连接
            mycom = null;
            conn.Dispose();                     //释放对象
        }
    }
}
