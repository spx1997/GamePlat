using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlatform.Sokoban_file
{
    public partial class Sokoban_FrmConfig_F : Form
    {
        
        private readonly Map_State[,] myArray = new Map_State[7, 7];
        private int BlockSize = 50;
        private Map_State m_now_Select; //当前选中的图标工具

        public Sokoban_FrmConfig_F()
        {
            InitializeComponent();
            
        }
        private void Sokoban_FrmConfig_F_Load(object sender, EventArgs e)
        {
            ClearMap();
        }

        private void toolStripBtn_Wall_Click(object sender, EventArgs e)
        {
            //选中墙
            m_now_Select = Map_State.Wall;
        }

        private void toolStripBtn_Box_Click(object sender, EventArgs e)
        {
            //选中箱子
            m_now_Select = Map_State.Box;
        }

        private void toolStripBtn_Destination_Click(object sender, EventArgs e)
        {
            //选中目的地
            m_now_Select = Map_State.Destination;
        }

        private void toolStripBtn_Passageway_Click(object sender, EventArgs e)
        {
            //选中通道
            m_now_Select = Map_State.Passageway;
        }

        private void toolStripBtn_Worker_Click(object sender, EventArgs e)
        {
            //选中人
            m_now_Select = Map_State.Worker;
        }

        private void toolStripBtn_New_Click(object sender, EventArgs e)
        {
            ClearMap();
        }

        private void toolStripBtn_Save_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void ClearMap()
        {
            m_now_Select = Map_State.None; //当前未选中图标工具
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    myArray[i, j] = Map_State.None;
            pictureBox1.Width = 7 * BlockSize + 2;
            pictureBox1.Height = 7 * BlockSize + 2;
            drawimage();
        }

        private void SaveMap()
        {
            if (!Directory.Exists("map")) //map文件夹是否存在
                Directory.CreateDirectory("map");
            string[] files = Directory.GetFiles("map");
            int n = files.Length + 1;
            string filename = "map\\map_" + n.ToString() + ".info";
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            BinaryWriter w = new BinaryWriter(fs);
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    w.Write((byte)myArray[i, j]);
            w.Close();
            fs.Close();
            MessageBox.Show("你设计的是" + n.ToString() + "关");
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int x, y;
            x = e.X / 50;
            y = e.Y / 50;
            myArray[x, y] = m_now_Select; //修改地图
            drawimage();
        }

        //绘制整个游戏区域图形
        private void drawimage()
        {
            Bitmap bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bit);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Image image;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (myArray[i, j] == Map_State.Wall)
                    {
                        image = new Bitmap("wall.gif");
                        g.DrawImage(image, i * 50, j * 50, 50, 50);
                    }
                    if (myArray[i, j] == Map_State.Worker)
                    {
                        image = new Bitmap("worker.gif");
                        g.DrawImage(image, i * 50, j * 50, 50, 50);
                    }
                    if (myArray[i, j] == Map_State.Box)
                    {
                        image = new Bitmap("box.gif");
                        g.DrawImage(image, i * 50, j * 50, 50, 50);
                    }
                    if (myArray[i, j] == Map_State.Passageway)
                    {
                        image = new Bitmap("passageway.gif");
                        g.DrawImage(image, i * 50, j * 50, 50, 50);
                    }
                    if (myArray[i, j] == Map_State.Destination)
                    {
                        image = new Bitmap("destination.gif");
                        g.DrawImage(image, i * 50, j * 50, 50, 50);
                    }
                }
            }
            pictureBox1.Image = bit;
        }

        #region Nested type: Map_State

        private enum Map_State
        {
            None = -1,
            Wall = 0,
            Worker,
            Box,
            Passageway,
            Destination,
            WorkerInDest,
            RedBox
        };

        #endregion

    }
}
