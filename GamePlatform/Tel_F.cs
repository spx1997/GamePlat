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
    public partial class Tel_F : Form
    {
        public Tel_F()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(GamePlatform.register.connectionString);
            conn.Open();
            string Inquire = "select plat_owner,version,tell,company from Tab_plat where tell='18533570730'";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = Inquire;
            SqlDataReader reader = cmd.ExecuteReader();
            //reader.GetOrdinal("id")是得到ID所在列的index,  
            //reader.GetInt32(int n)这是将第n列的数据以Int32的格式返回  
            //reader.GetString(int n)这是将第n列的数据以string 格式返回  
            //cname = reader.GetString(reader.GetOrdinal("name"));
            while (reader.Read())
            {
                label_version.Text = reader.GetString(reader.GetOrdinal("version"));
                label_tell.Text = reader.GetString(reader.GetOrdinal("tell"));
                label_company.Text = reader.GetString(reader.GetOrdinal("company"));
                label_owner.Text = reader.GetString(reader.GetOrdinal("plat_owner"));
            }
            conn.Close();                       //关闭连接
            cmd = null;
            conn.Dispose();                     //释放对象

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
