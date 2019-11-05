using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace GamePlatform.Con_code
{
    class Database
    {
        SqlConnection conn = new SqlConnection("Data source=localhost;database=GamePlatData;integrated security=SSPI");
        SqlCommand cmd;
        SqlDataReader dr;
        //连接数据库
        public SqlConnection GetConn()
        {
            conn.Open();
            return conn;
        }
        //查询
        public int GetSelectCount(string table ,string sqlWhere)
        {
            conn.Open();
            cmd = new SqlCommand("select count(*)from" + table + "where 1=1" + sqlWhere, conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return count;
        }
        //修改
        public int GetCount(string sql)
        {
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }
    }
}
