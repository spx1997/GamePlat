using GamePlatform.Con_code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlatform.Mine_weeper_file
{
    public partial class Mine_Weeper_F : Form
    {
        string game_name;
        string cemail;
        private int CostTime;     //所用时间
        private int MineNum = 10; //雷的总数
        private int MineWidth = 30; //雷方块的大小(宽度为30像素)
        private Button[,] Mines;
        private int RestMine = 10; //剩余的雷数
        private int[,] Turn; //==-1 表示这个位置已经翻开；
        private int XNum = 12; //一行方块的数目
        private int YNum = 9; //一列方块的数目
        private int score = 0;
        public Mine_Weeper_F(string cemail,string game_name)
        {
            InitializeComponent();
            this.cemail = cemail;
            this.game_name = game_name;
        }
        //设置雷的雷数
        private void difficult_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Tsmi = sender as ToolStripMenuItem;
            switch (Tsmi.Text)
            {
                case "低级（L）":
                    MineNum = 10;
                    break;
                case "中级（H）":
                    MineNum = 20;
                    break;
                case "高级（M）":
                    MineNum = 30;
                    break;
            }
            lblMine.Text = Convert.ToString(MineNum);
            RestMine = MineNum;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Turn = new int[XNum, YNum];
            Mines = new Button[XNum, YNum];
            for (int x = 0; x < XNum; x += 1)
                for (int y = 0; y < YNum; y += 1)
                {
                    Mines[x, y] = new Button();
                    Controls.Add(Mines[x, y]);
                    Mines[x, y].Left = 10 + MineWidth * x;
                    Mines[x, y].Top = 70 + MineWidth * y;
                    Mines[x, y].Width = MineWidth;
                    Mines[x, y].Height = MineWidth;
                    Mines[x, y].Font = new Font("宋体", 10.5F, FontStyle.Bold, GraphicsUnit.Point, ((134)));
                    Mines[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    Mines[x, y].Name = "Mines" + (x + y * XNum).ToString();
                    Mines[x, y].MouseUp += bt_MouseUp;
                    Mines[x, y].Visible = false;
                }
        }

        private void GameInit() //游戏初始化
        {
            for (int x = 0; x < XNum; x += 1)
                for (int y = 0; y < YNum; y += 1)
                {
                    Mines[x, y].Text = "";
                    Mines[x, y].Visible = true;
                    Mines[x, y].Enabled = true;
                    Mines[x, y].Tag = null;
                    Mines[x, y].BackgroundImage = null;
                    Turn[x, y] = 0;
                }
            LayMines();
        }

        ///布雷
        private void LayMines()
        {
            int x, y;
            Random s = new Random();
            //取随机数
            for (int i = 0; i < MineNum;)
            {
                //取随机数
                x = s.Next(XNum);
                y = s.Next(YNum);
                if (Convert.ToInt16(Mines[x, y].Tag) != 1)
                {
                    //==1时，代表这个位置是地雷
                    Mines[x, y].Tag = 1; //修改属性为雷
                    //Mines[x, y].Text = "u";
                    i++;
                }
            }
        }

        ///获取某个小方块区域相邻8个区域的雷个数
        private int GetAroundNum(int row, int col)
        {
            int i, j;
            int around = 0;
            int minRow = (row == 0) ? 0 : row - 1;
            int maxRow = row + 2;
            int minCol = (col == 0) ? 0 : col - 1;
            int maxCol = col + 2;
            for (i = minRow; i < maxRow; i++)
            {
                for (j = minCol; j < maxCol; j++)
                {
                    if (!IsInMineArea(i, j)) //判断是否在扫雷区域
                        continue;
                    if (Convert.ToInt16(Mines[i, j].Tag) == 1) around++;
                }
            }
            return around;
        }

        ///判断是否在扫雷区域
        private bool IsInMineArea(int row, int col)
        {
            return (row >= 0 && row < XNum && col >= 0 && col < YNum);
        }

        ///雷方块拓展(对于周围无雷的空白区域)
        private void ExpandMines(int row, int col)
        {
            int i, j;
            int minRow = (row == 0) ? 0 : row - 1;
            int maxRow = row + 2;
            int minCol = (col == 0) ? 0 : col - 1;
            int maxCol = col + 2;
            int around = GetAroundNum(row, col);
            //对周围一个雷都没有的空白区域拓展
            if (around == 0)
            {
                Mines[row, col].Enabled = false;
                for (i = minRow; i < maxRow; i++)
                {
                    for (j = minCol; j < maxCol; j++)
                    {
                        //对于周围可以拓展的区域进行的规拓展			
                        if (!IsInMineArea(i, j)) continue;
                        if (!(i == row && j == col) && Mines[i, j].Enabled)
                        //&& Convert.ToInt16(Mines[i,j].Tag)!= 1
                        {
                            ExpandMines(i, j);
                        }
                        Mines[i, j].Enabled = false; //周围无雷的区域按钮无效
                        if (GetAroundNum(i, j) != 0) //周围无雷**********6--28
                            Mines[i, j].Text = GetAroundNum(i, j).ToString();
                    }
                }
            }
        }

        ///胜利判断并处理
        private bool Victory() // 检测是否胜利
        {
            for (int i = 0; i < XNum; i++)
                for (int j = 0; j < YNum; j++)
                {
                    //没翻开且未标示,则未成功
                    if (Mines[i, j].Enabled && Turn[i, j] != 1) return false;
                    //不是雷却误标示为雷,则也未成功
                    if (Convert.ToInt16(Mines[i, j].Tag) != 1 && Turn[i, j] == 1) return false;
                }
            return true;
        }

       
        //添加按钮控件Click事件与处理方法bt_Click：
        private void bt_MouseUp(object sender, MouseEventArgs e) //这里处理事件方法
        {
            String btName;
            Button bClick = (Button)sender; //将被击的按钮赋给定义的bClick变量
            btName = bClick.Name; //获取按钮的Name
            int n = Convert.ToInt16(btName.Substring(5));
            int x = n % XNum;
            int y = n / XNum;
            //通过按钮Name属性来判断是哪个Button被点击，并执行相应的操作
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (Convert.ToInt16(Mines[x, y].Tag) != 1) //不是雷
                    {
                        Mines[x, y].BackgroundImage = null;
                        Mines[x, y].Text = GetAroundNum(x, y).ToString();
                        Mines[x, y].Enabled = false;
                        ExpandMines(x, y); //完成无雷拓展
                        if (Victory())
                        {
                            // 判断是否胜利，是则将地图中所有雷标识出来
                            show();
                            MessageBox.Show("胜利!!!", "结束");
                            score = Convert.ToInt16(10000 / CostTime); 
                            timer1.Enabled = false; //停止计时
                        }
                    }
                    else //触雷
                    {
                        Mines[x, y].BackgroundImage = Image.FromFile("mine1.bmp");
                        MessageBox.Show("失败!!!", "结束");
                        timer1.Enabled = false; //停止计时
                        show(); //将地图中所有雷标识出来
                    }
                    break;
                case MouseButtons.Right:
                    Mines[x, y].BackgroundImage = Image.FromFile("flag.bmp");
                    if (Turn[x, y] == 1) //表示这个位置插上红旗
                    {
                        Turn[x, y] = 0; //取消红旗,表示这个位置没有翻开
                        RestMine++;
                        Mines[x, y].BackgroundImage = null;
                    }
                    else
                    {
                        Turn[x, y] = 1; //表示这个位置插上红旗
                        RestMine--;
                    }
                    lblMine.Text = RestMine.ToString();
                    if (Victory())
                    {
                        MessageBox.Show("胜利!!!", "结束");
                        timer1.Enabled = false; //停止计时
                    }
                    break;
            }
        }

        //将地图中所有雷标识出来
        private void show() 
        {
            for (int i = 0; i < XNum; i++)
                for (int j = 0; j < YNum; j++)
                    if (Convert.ToInt16(Mines[i, j].Tag) == 1)
                    {
                        //==1时，代表这个位置是地雷
                        Mines[i, j].BackgroundImage = Image.FromFile("mine.bmp");
                    }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            RestMine = MineNum;
            GameInit(); //游戏初始化
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CostTime++;
            lblTime.Text = CostTime.ToString(); // "用时：" + CostTime.ToString() + "秒"; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            show(); //将地图中所有雷标识出来
        }

        private void save_Click(object sender,EventArgs e)
        {
            if (Victory())
            {
                Data_Game_R Inser_data = new Data_Game_R();
                Inser_data.Email = cemail;
                Inser_data.Score = score;
                Data_Game_W Inser_data_m = new Data_Game_W();
                Inser_data_m.Insert_Data(game_name, Inser_data);
                MessageBox.Show("游戏分数保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("游戏还未结束，保存分数失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Close();
        }
        private void exit_Click(object sender, EventArgs e)
        {
            if (Victory())
            {
                Data_Game_R Inser_data = new Data_Game_R();
                Inser_data.Email = cemail;
                Inser_data.Score = score;
                Data_Game_W Inser_data_m = new Data_Game_W();
                Inser_data_m.Insert_Data(game_name, Inser_data);
                MessageBox.Show("游戏即将退出，正在保存数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("游戏还未结束，退出不能保存数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Close();
        }
        private void help_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Mine_Help_F mine_help_f = new Mine_Help_F();
            mine_help_f.Show();
            timer1.Enabled = true;
        }
        private void rank_Click(object sender, EventArgs e)
        {
            Mine_Rank_F mink_rank_f = new Mine_Rank_F(game_name);
            mink_rank_f.Show();
        }
        private void lblMine_Click(object sender, EventArgs e)
        {

        }
    }
}
