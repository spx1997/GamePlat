using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlatform.Snake_file
{
    public partial class Snake_Help_F : Form
    {
        public Snake_Help_F()
        {
            InitializeComponent();
            label_help.Text = "F1开始/重新开始" +
                "\n\n" + "F2暂停/继续\n\n" + "上下右左键为控制蛇的方向键";
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
