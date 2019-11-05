using GamePlatform.Con_code;
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
    public partial class Sokoban_F : Form
    {
        string game_name;
        string cemail;

        private int Order = 1; //游戏关的序号
        private Map_State[,] myArray;
        private int x; //工人当前位置(x,y)
        private int y;
        //private bool flag = true;
        //0代表墙，1代表人，2代表箱子，3代表路，4代表目的地
        //5代表人在目的地，6代表放到目的地的箱子

        public Sokoban_F(string game_name, string cemail)
        {
            InitializeComponent();
            this.game_name = game_name;
            this.cemail = cemail;
        }

        private void ReadMap(int n)
        {
            string filename = "map\\map_" + n.ToString() + ".info";
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            //读取数据
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    myArray[i, j] = (Map_State)r.ReadByte();
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    if (myArray[i, j] == Map_State.Worker)
                    {
                        x = i;
                        y = j;
                    }
            r.Close();
            fs.Close();
        }

        public void initdata()
        {
            myArray = new Map_State[7, 7];
            ReadMap(Order);
        }

        private void Sokoban_F_Load(object sender, EventArgs e)
        {
            initdata();
            drawimage();
        }
        private void btn_save_Click(object sender,EventArgs e)
        {
            Data_Game_R Inser_data = new Data_Game_R();
            Inser_data.Email = cemail;
            Inser_data.Score = Order;
            Data_Game_W Inser_data_m = new Data_Game_W();
            Inser_data_m.Insert_Data(game_name, Inser_data);
            MessageBox.Show("游戏分数保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            Sokoban_Help_F sokoban_help_f = new Sokoban_file.Sokoban_Help_F();
            sokoban_help_f.Show();
        }

        private void btn_rank_Click(object sender, EventArgs e)
        {
            Sokoban_Rank_F sokoban_rank_f = new Sokoban_Rank_F(game_name);
            sokoban_rank_f.Show();
        }
        //绘制整个游戏区域图形
        private void drawimage()
        {
            Bitmap bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bit);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Image image = new Bitmap("worker.gif");
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
                    if (myArray[i, j] == Map_State.WorkerInDest)
                    {
                        image = new Bitmap("worker.gif");
                        g.DrawImage(image, i * 50, j * 50, 50, 50);
                    }
                    if (myArray[i, j] == Map_State.RedBox)
                    {
                        image = new Bitmap("redbox.gif");
                        g.DrawImage(image, i * 50, j * 50, 50, 50);
                    }
                }
            }
            pictureBox1.Image = bit;
        }

        private void Sokoban_F_KeyDown(object sender, KeyEventArgs e)
        {
            int x1, y1, x2, y2;
            //工人当前位置(x,y)	        
            switch (e.KeyCode) //分析按键消息
            {
                //向上
                case Keys.Up:
                    x1 = x;
                    y1 = y - 1;
                    x2 = x;
                    y2 = y - 2;
                    //将所有位置输入以判断并作地图更新
                    MoveTo(x1, y1, x2, y2);
                    break;
                //向下
                case Keys.Down:
                    x1 = x;
                    y1 = y + 1;
                    x2 = x;
                    y2 = y + 2;
                    MoveTo(x1, y1, x2, y2);
                    break;
                //向左
                case Keys.Left:
                    x1 = x - 1;
                    y1 = y;
                    x2 = x - 2;
                    y2 = y;
                    MoveTo(x1, y1, x2, y2);
                    break;
                //向右
                case Keys.Right:
                    x1 = x + 1;
                    y1 = y;
                    x2 = x + 2;
                    y2 = y;
                    MoveTo(x1, y1, x2, y2);
                    break;
                case Keys.Space: //空格键
                    重玩ToolStripMenuItem_Click(null, null);
                    break;
            }
        }

        private void MoveMan(int x, int y)
        {
            if (myArray[x, y] == Map_State.Worker)
                myArray[x, y] = Map_State.Passageway;
            else if (myArray[x, y] == Map_State.WorkerInDest)
                myArray[x, y] = Map_State.Destination;
        }

        private void MoveTo(int x1, int y1, int x2, int y2)
        {
            Map_State P1, P2;
            P1 = P2 = Map_State.None;
            if (IsInGameArea(x1, y1)) //判断是否在游戏区域
                P1 = myArray[x1, y1];
            if (IsInGameArea(x2, y2))
                P2 = myArray[x2, y2];
            if (P1 == Map_State.Passageway) //P1处为通道
            {
                MoveMan(x, y);
                x = x1;
                y = y1;
                myArray[x1, y1] = Map_State.Worker;
            }
            if (P1 == Map_State.Destination) //P1处为目的地
            {
                MoveMan(x, y);
                x = x1;
                y = y1;
                myArray[x1, y1] = Map_State.WorkerInDest;
            }
            if (P1 == Map_State.Wall || !IsInGameArea(x1, y1))
            //P1处为墙或出界
            {
                return;
            }
            if (P1 == Map_State.Box) //P1处为箱子
                if (P2 == Map_State.Wall || !IsInGameArea(x1, y1)
                    || P2 == Map_State.Box) ////P2处为墙或出界

                {
                    return;
                }
            //以下P1处为箱子

            //P1处为箱子,P2处为通道
            if (P1 == Map_State.Box && P2 == Map_State.Passageway)
            {
                MoveMan(x, y);
                x = x1;
                y = y1;
                myArray[x2, y2] = Map_State.Box;
                myArray[x1, y1] = Map_State.Worker;
            }
            if (P1 == Map_State.Box && P2 == Map_State.Destination)
            {
                MoveMan(x, y);
                x = x1;
                y = y1;
                myArray[x2, y2] = Map_State.RedBox;
                myArray[x1, y1] = Map_State.Worker;
            }

            //P1处为放到目的地的箱子,P2处为通道
            if (P1 == Map_State.RedBox && P2 == Map_State.Passageway)
            {
                MoveMan(x, y);
                x = x1;
                y = y1;
                myArray[x2, y2] = Map_State.Box;
                myArray[x1, y1] = Map_State.WorkerInDest;
            }
            //P1处为放到目的地的箱子,P2处为目的地
            if (P1 == Map_State.RedBox && P2 == Map_State.Destination)
            {
                MoveMan(x, y);
                x = x1;
                y = y1;
                myArray[x2, y2] = Map_State.RedBox;
                myArray[x1, y1] = Map_State.WorkerInDest;
            }
            drawimage();
            //这里要验证是否过关
            if (IsFinish())
            {
                MessageBox.Show("恭喜你顺利过关", "提示");
                下一关ToolStripMenuItem_Click(null, null);
                return;
            }
        }

        //判断是否在游戏区域
        private bool IsInGameArea(int row, int col)
        {
            return (row >= 0 && row < 7 && col >= 0 && col < 7);
        }

        public bool IsFinish() //验证是否过关
        {
            bool bFinish = true;
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    if (myArray[i, j] == Map_State.Destination
                        || myArray[i, j] == Map_State.WorkerInDest)
                        bFinish = false;
            return bFinish;
        }

        private void 编辑地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sokoban_FrmConfig_F f2 = new Sokoban_FrmConfig_F();
            f2.ShowDialog();
        }

        private void 重玩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "第" + Order.ToString() + "关";
            initdata();
            drawimage();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            this.Close();
        }

        private void 下一关ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order++;
            string filename = "map\\map_" + Order.ToString() + ".info";
            if (!File.Exists(filename))
            {
                MessageBox.Show("没有下一关了", "提醒");
                Order--;
                return;
            }
            Text = "第" + Order.ToString() + "关";
            initdata();
            drawimage();
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
