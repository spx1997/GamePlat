using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Con_code
{
    class Data_Game_W
    {
        SqlConnection conn = new SqlConnection(GamePlatform.register.connectionString);
        public void Insert_Data(string tab_name,Data_Game_R Insert_data)
        {
            //查询是否存在数据
            //若不存在，则加进去，
            //若存在，比较大小，
                 //若现在的数据大于数据库中的数据，则插入数据库
                 //否则，不进行修改

            conn.Open();
            SqlCommand checkCmd = conn.CreateCommand();
            string s = "select email from " + tab_name + " where email='" + Insert_data.Email + "'";
            checkCmd.CommandText = s;
            //实例化数据适配器
            SqlDataAdapter check = new SqlDataAdapter();
            check.SelectCommand = checkCmd;
            DataSet checkData = new DataSet();
            int n = check.Fill(checkData);
            if (n != 0)
            {
                Data_Game_R old_data = new Data_Game_R();
                old_data.GetSqlData(tab_name, Insert_data.Email);
                if (old_data.Score < Insert_data.Score)
                {
                    //更新
                    SqlConnection MyConnection = new SqlConnection(GamePlatform.register.connectionString);
                    string update = "Update "+ tab_name + " set score='" + Insert_data.Score + "' where email='"+ Insert_data.Email+"'";//+"(email,score) values('" + Insert_data.Email 
                    SqlCommand mycom = new SqlCommand(update , MyConnection);
                    try
                    {
                        MyConnection.Open();
                        mycom.ExecuteNonQuery();
                        MyConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0} Exception caught.", ex);
                    }
                    //mycom.ExecuteNonQuery();
                    conn.Close();

                    mycom = null;
                    conn.Dispose();
                }
            }
            else
            {
                //插入
                string insert = "Insert into " + tab_name + "(email,score) values('" + Insert_data.Email + "','" + Insert_data.Score + "')";
                SqlCommand mycom = new SqlCommand(insert, conn);
                mycom.ExecuteNonQuery();
                conn.Close();

                mycom = null;
                conn.Dispose();
            }

        }
        
    }
}
