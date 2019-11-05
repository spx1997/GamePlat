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

namespace GamePlatform.Variety_Of_Boxs_file
{
    public partial class Variety_Rank_F : Form
    {
        string game_name;
        string inquiry = "";
        public Variety_Rank_F(string game_name)
        {
            InitializeComponent();

            this.game_name = game_name;
            SqlConnection conn = new SqlConnection(GamePlatform.register.connectionString);
            conn.Open();
            inquiry = "select top 8 email as 用户,score as 得分 from " + game_name + " order by score desc";
            Console.WriteLine(inquiry);
            SqlDataAdapter adp1 = new SqlDataAdapter(inquiry, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
