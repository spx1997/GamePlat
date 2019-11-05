using GamePlatform.Con_code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlatform.Tank_File
{
    public partial class Tank_F : Form
    {
        //private Tank []eTanks=new Tank[11];
        private readonly int[,] Map = new int[10, 10]; //砖块地图
        private readonly Tank MyTank = new Tank(6);
        private readonly ArrayList eTanks = new ArrayList();
        private int Score; //计分
        public int[,] TMap = new int[10, 10]; //含坦克，砖的地图
        private int eCount; //敌方坦克数量
        private int eMaxCount = 10; //eMaxCount敌方坦克最大量
        private Tank eTank;
        private string path; //应用程序路径
        private int width = 32;
        string cemail;
        string game_name;
        public Tank_F(string cemail,string game_name)
        {
            InitializeComponent();
            this.cemail = cemail;
            this.game_name = game_name;
        }
        private void Tank_F_Load(object sender, EventArgs e)
        {
            CustomInfo cus = new CustomInfo();
            cus.GetSqlData(cemail);
            label1.Text = "玩家姓名："+cus.Cname;
            pictureBox1.Width = 10 * width;
            pictureBox1.Height = 10 * width;
            path = Application.StartupPath;
            Random r = new Random();
            for (int x = 0; x < 10; x += 2)
                for (int y = 0; y < 10; y += 2)
                {
                    //产生0,1数其中０代表空地,1代表墙砖  
                    Map[x, y] = r.Next(0, 2);
                }
            Map[4, 9] = 0;
            MyTank.Top = 9;
            MyTank.Left = 4;
            MyTank.Direct = 0;
            lblX.Text = "X坐标：" + MyTank.Left + "  Y坐标：" + MyTank.Top;
        }
  
        private void save_Click(object sender, EventArgs e)
        {
            Data_Game_R Inser_data = new Data_Game_R();
            Inser_data.Email = cemail;
            Inser_data.Score = Score;
            Data_Game_W Inser_data_m = new Data_Game_W();
            Inser_data_m.Insert_Data(game_name, Inser_data);
            MessageBox.Show("游戏分数保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void rank_Click(object sender, EventArgs e)
        {
            Tank_Rank_F tank_rank_f = new Tank_Rank_F(game_name);
            tank_rank_f.Show();
        }
        private void help_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            Tank_Help_F tank_help_f = new Tank_Help_F();
            tank_help_f.Show();
            timer1.Enabled = true;
            timer2.Enabled = true;
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DragWall(Graphics g) //画游戏地图
        {
            Image WallImage = Image.FromFile("BMP/TQ.BMP");
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                {
                    if (Map[x, y] == 1)
                    {
                        //得到绘制这个墙砖块的在游戏面板中的矩形区域
                        Rectangle Rect = new Rectangle(x * width, y * width, width, width);
                        g.DrawImage(WallImage, Rect);
                    }
                }
        }

        private void Tank_F_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: //上 
                    if (MyTank.Top == 0 || Map[MyTank.Left, MyTank.Top - 1] == 1
                        || Meet_Tank(MyTank.Left, MyTank.Top - 1)) //遇到墙砖或坦克
                        ; //不动
                    else if (MyTank.Direct == 0) MyTank.Top--;
                    MyTank.Direct = 0;
                    break;
                case Keys.Down: //下 
                    if (MyTank.Top == 9 || Map[MyTank.Left, MyTank.Top + 1] == 1
                        || Meet_Tank(MyTank.Left, MyTank.Top + 1)) //遇到墙砖或坦克
                        ; //不动
                    else if (MyTank.Direct == 1) MyTank.Top++;
                    MyTank.Direct = 1;
                    break;

                case Keys.Left: //左 
                    if (MyTank.Left == 0 || Map[MyTank.Left - 1, MyTank.Top] == 1
                        || Meet_Tank(MyTank.Left - 1, MyTank.Top)) //遇到墙砖或坦克
                        ; //不动
                    else if (MyTank.Direct == 2) MyTank.Left--;
                    MyTank.Direct = 2;
                    break;
                case Keys.Right: //右 
                    if (MyTank.Left == 9 || Map[MyTank.Left + 1, MyTank.Top] == 1
                        || Meet_Tank(MyTank.Left + 1, MyTank.Top)) //遇到墙砖或坦克
                        ; //不动
                    else if (MyTank.Direct == 3) MyTank.Left++;
                    MyTank.Direct = 3;
                    break;
                case Keys.Space: //空格发射子弹
                    MyTank.fire();
                    break;
            }
            pictureBox1.Invalidate(); //重画游戏面板区域
            lblX.Text = "X坐标：" + MyTank.Left + "  Y坐标：" + MyTank.Top;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Tank t in eTanks)
            {
                switch (t.Direct) //0--上,1--下,2--左,3--右
                {
                    case 0: //向上
                        if (t.Top == 0 || Map[t.Left, t.Top - 1] == 1
                            || Meet_Tank(t.Left, t.Top - 1)) //遇到墙砖或坦克
                            t.newDirect(); //坦克转向
                        else
                            t.Top--;
                        break;
                    case 1: //向下
                        if (t.Top == 9 || Map[t.Left, t.Top + 1] == 1
                            || Meet_Tank(t.Left, t.Top + 1)) //遇到墙砖或坦克
                            t.newDirect(); //坦克转向
                        else
                            t.Top++;
                        break;
                    case 2: //向左
                        if (t.Left == 0 || Map[t.Left - 1, t.Top] == 1
                            || Meet_Tank(t.Left - 1, t.Top)) //遇到墙砖或坦克
                            t.newDirect(); //坦克转向
                        else
                            t.Left--;
                        break;
                    case 3: //向右
                        if (t.Left == 9 || Map[t.Left + 1, t.Top] == 1
                            || Meet_Tank(t.Left + 1, t.Top)) //遇到墙砖或坦克
                            t.newDirect(); //坦克转向
                        else
                            t.Left++;
                        break;
                }
                Random r = new Random();
                int fire_bool = r.Next(0, 8); //产生0—7的数
                if (fire_bool == t.Direct) t.fire();
            }
            pictureBox1.Invalidate(); //重画游戏面板区域            
        }

        private bool Meet_Tank(int left, int top) //比较坦克位置
        {
            foreach (Tank t in eTanks) //遍历地方
            {
                if (left == t.Left && top == t.Top) //遇到坦克
                    return true;
            }
            if (left == MyTank.Left && top == MyTank.Top) //遇到游戏方坦克
                return true;
            return false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //修改含坦克信息的地图
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                {
                    if (Map[x, y] == 1) TMap[x, y] = 1; //砖块
                    else TMap[x, y] = 0; //０空地
                }
            for (int i = 0; i < eTanks.Count; i++)
                if (eTanks[i] != null)
                {
                    int x = ((Tank)eTanks[i]).Left;
                    int y = ((Tank)eTanks[i]).Top;
                    TMap[x, y] = ((Tank)eTanks[i]).Type; //此处为敌方坦克
                }
            TMap[MyTank.Left, MyTank.Top] = MyTank.Type; //此处为己方坦克(6)

            //*******************重画游戏界面
            DragWall(e.Graphics); //画墙砖
            for (int i = 0; i < eTanks.Count; i++) //画敌方坦克及子弹
                if (eTanks[i] != null)
                {
                    Tank t = (Tank)eTanks[i];
                    t.Draw(e.Graphics, t.Type);
                    t.DrawBullet(e.Graphics, TMap);
                }
            MyTank.Draw(e.Graphics, MyTank.Type); //画己方坦克Type=6
            MyTank.DrawBullet(e.Graphics, TMap); //画己方子弹
            //处理爆破
            for (int i = 0; i < eTanks.Count; i++) //画敌方坦克爆破
                if (eTanks[i] != null)
                {
                    Tank t = (Tank)eTanks[i];
                    if (TMap[t.Left, t.Top] == -1)
                    {
                        t.Explore(e.Graphics);
                        eTanks.RemoveAt(i);
                        i--; //注意此处                        
                        TMap[t.Left, t.Top] = 0;
                        lblX.Text = "(" + t.Left + "," + t.Top + ")坦克被击中";
                        Score += 100;
                        //PlaySound.Play("Sound/Score.WAV"); 
                        lblScore.Text ="分数："+ Score.ToString();
                    }
                }
            if (TMap[MyTank.Left, MyTank.Top] == -1) //画己方坦克爆破
            {
                MyTank.Explore(e.Graphics);
                TMap[MyTank.Left, MyTank.Top] = 0;
                lblX.Text = "游戏者你被击中,游戏结束";
                timer1.Enabled = false; //游戏结束
            }
            CheckWin(); //检查是否胜利
        }

        private void CheckWin() //检查是否胜利
        {
            if (eTanks.Count == 0 && eCount == eMaxCount) //胜利
            {
                lblX.Text = " 过关！ , 恭喜";
                PlaySound.Play("Sound/WIN.WAV"); //过关后播放相应音乐
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e) //定时产生新敌方坦克
        {
            if (eCount < eMaxCount) //eMaxCount敌方坦克最大量
            {
                //敌方坦克类型为3,改变此数可以产生不同图案的地方坦克
                eTank = new Tank(3);
                eTanks.Add(eTank); // eTanks[eCount] = eTank;
                eCount++;
            }
            else
                timer2.Enabled = false; //不再产生新的敌方坦克
        }
    }
}
