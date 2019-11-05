using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Con_code
{
    class Data_Game_R
    {
        string email;       //用户账号
        int score;          //得分
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public void GetSqlData(string tab_name,string Sql_email)
        {
            SqlConnection conn = new SqlConnection(GamePlatform.register.connectionString);//新建数据库连接
            conn.Open();//打开连接
            string Inquire = "select email,score from "+tab_name+" where email='" + Sql_email + "'";//查询语句
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = Inquire;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())//获取查询结果
            {
                email = reader.GetString(reader.GetOrdinal("email"));
                score = reader.GetInt32(reader.GetOrdinal("score"));
            }
        }
    }
}
