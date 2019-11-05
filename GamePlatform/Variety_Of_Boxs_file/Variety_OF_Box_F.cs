using GamePlatform.Con_code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlatform.Variety_Of_Boxs_file
{
    public partial class Variety_OF_Box_F : Form
    {
        //在类class Form1中声明私有的数据成员变量
        private const int CHIP_COUNT = 8;
        private const int MAX_POINTS = 8;
        private const int CHIP_WIDTH = 40;
        private readonly int[,] OrgMap = new int[6, 6]; //初始化目标地图OrgMap
        private readonly CChip[] m_chipList = new CChip[CHIP_COUNT];
        private bool Drag_PictBox;
        private int[,] Map = new int[6, 6];
        private int m_nCurrIndex; //用户选中的拼块 
        private int max = 10; //图案的数量
        private int n = 1; //图案序号
        private int oldx, oldy; //记录鼠标原位置
        

        string cemail;
        string game_name;
        int score=0;

        private void btn_save_Click(object sender,EventArgs e)
        {
            Data_Game_R Inser_data = new Data_Game_R();
            Inser_data.Email = cemail;
            Inser_data.Score = score;
            Data_Game_W Inser_data_m = new Data_Game_W();
            Inser_data_m.Insert_Data(game_name, Inser_data);
            MessageBox.Show("游戏分数保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_help_Click(object sender,EventArgs e)
        {
            Variety_Help_F variety_help_f = new Variety_Of_Boxs_file.Variety_Help_F();
            variety_help_f.Show();
        }
        private void btn_rank_Click(object sender, EventArgs e)
        {
            Variety_Rank_F variety_rank_f = new Variety_Of_Boxs_file.Variety_Rank_F(game_name);
            variety_rank_f.Show();
        }
        public Variety_OF_Box_F(string cemail,string game_name)
        {
            InitializeComponent();
            this.cemail = cemail;
            this.game_name = game_name;
            label_score.Text = score.ToString();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            SolidBrush myBrush = new SolidBrush(Color.Green);
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                {
                    if (OrgMap[i, j] == 0)
                        gp.FillRectangle(myBrush, i * CHIP_WIDTH, j * CHIP_WIDTH, CHIP_WIDTH, CHIP_WIDTH);
                }
            Pen p = new Pen(Color.Brown, 1);
            for (int i = 1; i < 7; i++)
                for (int j = 1; j < 7; j++)
                {
                    gp.DrawLine(p, 1, j * CHIP_WIDTH, CHIP_WIDTH * 6, j * CHIP_WIDTH);
                    gp.DrawLine(p, i * CHIP_WIDTH, 1, i * CHIP_WIDTH, CHIP_WIDTH * 6);
                }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            label1.Text = p.ToString();
            if (Drag_PictBox)
            {
                Cursor.Current = Cursors.Hand;
                m_chipList[m_nCurrIndex].Move2(e.X - oldx, e.Y - oldy); //移动
                Draw_AllChip(); //画出所有拼块
                //Thread.Sleep(10);            //线程sleep0.01秒，明显减少屏幕闪烁            
            }
            oldx = e.X;
            oldy = e.Y;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            for (int i = 0; i < CHIP_COUNT; i++)
                if (m_chipList[i].PtInChip(p))
                {
                    m_nCurrIndex = i; //记录用户选中的拼块
                    Drag_PictBox = true; //??? 
                    oldx = e.X;
                    oldy = e.Y;
                    break;
                }
            if (e.Button == MouseButtons.Right) //右键旋转
            {
                m_chipList[m_nCurrIndex].Rotation2(); //旋转顺时针45度
                m_chipList[m_nCurrIndex].Rotation2(); //旋转顺时针45度
                Draw_AllChip(); //画出所有拼块
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Drag_PictBox = false;
            //对用户选中的m_nCurrIndex拼块坐标进行修正，放置到正确位置
            m_chipList[m_nCurrIndex].Verity(CHIP_WIDTH);
            Draw_AllChip(); //画出所有拼块
            if (Win())
            {
                MessageBox.Show("成功完成此关"); //判断是否成功    
                score++;
                label_score.Text = score.ToString();
            }
                   
        }

        private bool Win() //判断是否成功
        {
            for (int i = 1; i < 7; i++)
                for (int j = 1; j < 7; j++)
                {
                    Point pt = new Point(i * CHIP_WIDTH - 20, j * CHIP_WIDTH - 20);
                    //如果此方块在拼快中
                    bool flag = false;
                    for (int k = 0; k < CHIP_COUNT; k++)
                        if (m_chipList[k].PtInChip(pt))
                        {
                            Map[i - 1, j - 1] = 1;
                            flag = true;
                        }
                    if (flag == false) Map[i - 1, j - 1] = 0;

                    //仅仅判断m_nCurrIndex有问题
                    //if (m_chipList[m_nCurrIndex].PtInChip(pt) == true)
                    //    Map[i - 1, j - 1] = 1;
                }
            for (int i = 1; i < 7; i++)
                for (int j = 1; j < 7; j++)
                {
                    if (Map[i - 1, j - 1] != OrgMap[i - 1, j - 1])
                        return false;
                    //不是窗体背景色c
                    //Color c2 = tmr_Tick(pt);//GetPixelColor(pt);
                    //if ( c2.Name != c.Name )
                    //    Map[i-1, j-1] = 1;
                    //if (Map[i-1, j-1] != OrgMap[i-1, j-1])
                    //    return false; 
                }
            return true;
        }

        // 初始化拼图块 
        private void Reset()
        {
            for (int i = 0; i < CHIP_COUNT; i++)
                m_chipList[i] = new CChip();
            Point[] pointList = new Point[MAX_POINTS];
            int sx = 250, sy = 0;
            pointList[0] = new Point(sx, sy);
            pointList[1] = new Point(sx + 2 * CHIP_WIDTH, sy);
            pointList[2] = new Point(sx + 2 * CHIP_WIDTH, sy + 2 * CHIP_WIDTH);
            pointList[3] = new Point(sx, sy + 2 * CHIP_WIDTH);
            //m_chipList[0]为一个2W*2W的正方形
            m_chipList[0].SetChip(1, pointList, 4);
            sx = 170;
            sy = 90;
            pointList[0] = new Point(sx + CHIP_WIDTH * 2, sy);
            pointList[1] = new Point(sx + CHIP_WIDTH * 6, sy);
            pointList[2] = new Point(sx + CHIP_WIDTH * 6, sy + CHIP_WIDTH);
            pointList[3] = new Point(sx + CHIP_WIDTH * 2, sy + CHIP_WIDTH);
            //m_chipList[1]为一个4W*1W的长方形
            m_chipList[1].SetChip(2, pointList, 4);
            sx = 250;
            sy = 70;
            pointList[0] = new Point(sx, sy + CHIP_WIDTH * 2);
            pointList[1] = new Point(sx + CHIP_WIDTH, sy + CHIP_WIDTH * 2);
            pointList[2] = new Point(sx + CHIP_WIDTH, sy + 3 * CHIP_WIDTH);
            pointList[3] = new Point(sx + 2 * CHIP_WIDTH, sy + 3 * CHIP_WIDTH);
            pointList[4] = new Point(sx + 2 * CHIP_WIDTH, sy + 4 * CHIP_WIDTH);
            pointList[5] = new Point(sx + CHIP_WIDTH, sy + 4 * CHIP_WIDTH);
            pointList[6] = new Point(sx + CHIP_WIDTH, sy + 5 * CHIP_WIDTH);
            pointList[7] = new Point(sx, sy + 5 * CHIP_WIDTH);

            //m_chipList[2]为一个头朝右的┣形
            m_chipList[2].SetChip(3, pointList, 8);

            sx = 0;
            sy = 90;
            pointList[0].X = sx + CHIP_WIDTH;
            pointList[0].Y = sy + CHIP_WIDTH * 4;
            pointList[1].X = sx + CHIP_WIDTH * 2;
            pointList[1].Y = sy + CHIP_WIDTH * 4;
            pointList[2].X = sx + CHIP_WIDTH * 2;
            pointList[2].Y = sy + CHIP_WIDTH * 6;
            pointList[3].X = sx;
            pointList[3].Y = sy + CHIP_WIDTH * 6;
            pointList[4].X = sx;
            pointList[4].Y = sy + CHIP_WIDTH * 5;
            pointList[5].X = sx + CHIP_WIDTH;
            pointList[5].Y = sy + CHIP_WIDTH * 5;
            //m_chipList[3]为一个┛的折形
            m_chipList[3].SetChip(4, pointList, 6);

            sx = 20;
            sy = 170;
            pointList[0] = new Point(sx + 2 * CHIP_WIDTH, sy + 2 * CHIP_WIDTH);
            pointList[1] = new Point(sx + 3 * CHIP_WIDTH, sy + 2 * CHIP_WIDTH);
            pointList[2] = new Point(sx + 3 * CHIP_WIDTH, sy + 5 * CHIP_WIDTH);
            pointList[3] = new Point(sx + 2 * CHIP_WIDTH, sy + 5 * CHIP_WIDTH);
            m_chipList[4].SetChip(5, pointList, 4); //m_chipList[4]为一个1W*3W的长方形

            sx = 70;
            sy = 70;
            pointList[0] = new Point(sx + 2 * CHIP_WIDTH, sy + 5 * CHIP_WIDTH);
            pointList[1] = new Point(sx + 4 * CHIP_WIDTH, sy + 5 * CHIP_WIDTH);
            pointList[2] = new Point(sx + 4 * CHIP_WIDTH, sy + 6 * CHIP_WIDTH);
            pointList[3] = new Point(sx + 2 * CHIP_WIDTH, sy + 6 * CHIP_WIDTH);
            m_chipList[5].SetChip(6, pointList, 4); //m_chipList[5]为一个1W*2W的长方形

            sx = 100;
            sy = 200;
            pointList[0] = new Point(sx + 5 * CHIP_WIDTH, sy + CHIP_WIDTH);
            pointList[1] = new Point(sx + 6 * CHIP_WIDTH, sy + CHIP_WIDTH);
            pointList[2] = new Point(sx + 6 * CHIP_WIDTH, sy + 3 * CHIP_WIDTH);
            pointList[3] = new Point(sx + 5 * CHIP_WIDTH, sy + 3 * CHIP_WIDTH);
            pointList[4] = new Point(sx + 5 * CHIP_WIDTH, sy + 4 * CHIP_WIDTH);
            pointList[5] = new Point(sx + 4 * CHIP_WIDTH, sy + 4 * CHIP_WIDTH);
            pointList[6] = new Point(sx + 4 * CHIP_WIDTH, sy + 2 * CHIP_WIDTH);
            pointList[7] = new Point(sx + 5 * CHIP_WIDTH, sy + 2 * CHIP_WIDTH);
            m_chipList[6].SetChip(7, pointList, 8); //m_chipList[6]为一个Z形

            sx = 0;
            sy = 200;
            pointList[0] = new Point(sx + 5 * CHIP_WIDTH, sy + 3 * CHIP_WIDTH);
            pointList[1] = new Point(sx + 6 * CHIP_WIDTH, sy + 3 * CHIP_WIDTH);
            pointList[2] = new Point(sx + 6 * CHIP_WIDTH, sy + 6 * CHIP_WIDTH);
            pointList[3] = new Point(sx + 4 * CHIP_WIDTH, sy + 6 * CHIP_WIDTH);
            pointList[4] = new Point(sx + 4 * CHIP_WIDTH, sy + 5 * CHIP_WIDTH);
            pointList[5] = new Point(sx + 5 * CHIP_WIDTH, sy + 5 * CHIP_WIDTH);
            m_chipList[7].SetChip(8, pointList, 6); //m_chipList[7]为一个L形
        }

        private void button1_Click(object sender, EventArgs e) //“新图案”按钮
        {
            n++;
            if (n > max)
            {
                MessageBox.Show("没有新图案了");
                n--;
                return;
            }
            ReadOrgMap(n); //读目标地图OrgMap文件
            Map = new int[6, 6];
            Reset(); // 初始化拼图块
            Draw_AllChip(); //画出所有拼块        
        }

        //画出所有拼块及目标图案
        private void Draw_AllChip()
        {
            Bitmap bmp = new Bitmap(Width, Height);
            BackgroundImage = bmp;
            //Graphics g = this.CreateGraphics();
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(BackColor);
            string r = n.ToString() + ".jpg";
            Bitmap s = (Bitmap)Image.FromFile(r);
            //在(450,10)处显示320*240图案
            g.DrawImage(s, new Rectangle(450, 10, 320, 240),
                        new Rectangle(0, 0, 640, 480), GraphicsUnit.Pixel);
            for (int i = 0; i < CHIP_COUNT; i++)
                m_chipList[i].DrawChip(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset(); // 初始化拼图块
            //以下两句是为了设置控件样式为双缓冲，这可以有效减少图片闪烁的问题，
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint
                     | ControlStyles.UserPaint, true);
            UpdateStyles();
            Top = 0;
            Left = 0;
            ReadOrgMap(1); // 读出第一关目标图案的地图信息到OrgMap二维数组中         
            Draw_AllChip(); //画出所有拼块
        }

        //保存方块图案
        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("map.txt", true, Encoding.Default);
            string t = null;
            for (int i = 1; i < 7; i++)
                for (int j = 1; j < 7; j++)
                    t += Map[i - 1, j - 1] + ",";
            sw.WriteLine(t);
            sw.Close();
        }

        private void ReadOrgMap(int n)
        {
            string filename = "map.txt";
            FileStream fs = File.OpenRead(filename);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            string t = null;
            while (n > 0)
            {
                t = sr.ReadLine();
                n--;
            }
            sr.Close();
            fs.Close();
            string[] a = new string[36 + 1];
            a = t.Split(',');
            for (int i = 1; i < 7; i++)
                for (int j = 1; j < 7; j++)
                    OrgMap[i - 1, j - 1] = Convert.ToInt16(a[(i - 1) * 6 + j - 1]);
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            string r = n.ToString() + "A.jpg";
            Bitmap s = (Bitmap)Image.FromFile(r);
            //在(450,280)显示参考拼图方案
            g.DrawImage(s, new Rectangle(450, 280, 320, 240),
                        new Rectangle(0, 0, 640, 480), GraphicsUnit.Pixel);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            for (int i = 0; i < CHIP_COUNT; i++)
                if (m_chipList[i].PtInChip(p))
                {
                    m_nCurrIndex = i; //记录用户选中的拼块
                    Drag_PictBox = true; //??? 
                    oldx = e.X;
                    oldy = e.Y;
                    break;
                }
            m_chipList[m_nCurrIndex].ReverseTurn(); //// 水平反转
            Draw_AllChip(); //画出所有拼块
        }
    }


    internal class CChip
    {
        private int m_nPointCount; //顶点个数
        private int m_nType; //类型代号
        private Point[] m_pointList; //顶点坐标
        private GraphicsPath myPath;
        // 设置拼图块参数
        public void SetChip(int type, Point[] ppointlist, int count)
        {
            m_nType = type;
            m_nPointCount = count;
            m_pointList = new Point[m_nPointCount];
            for (int i = 0; i < count; i++)
                m_pointList[i] = ppointlist[i];
            myPath = new GraphicsPath();
            myPath.AddLines(m_pointList);
            myPath.CloseFigure(); //CloseFigure方法闭合当前图形并开始新的图形。
        }

        // 检测一点是否在拼图块中
        public bool PtInChip(Point p)
        {
            return (myPath.IsVisible(p));
        }

        public void Verity(int CHIP_WIDTH)
        {
            myPath.Reset(); //清空路径
            int x_offset = 0, y_offset = 0;
            int d;
            d = m_pointList[0].X % CHIP_WIDTH;
            if (d != 0)
                x_offset -= (d < CHIP_WIDTH / 2 ? d : d - CHIP_WIDTH);
            d = m_pointList[0].Y % CHIP_WIDTH;
            if (d != 0)
                y_offset -= (d < CHIP_WIDTH / 2 ? d : d - CHIP_WIDTH);
            for (int i = 0; i < m_nPointCount; i++) // 平移各点
            {
                m_pointList[i].X += x_offset;
                m_pointList[i].Y += y_offset;
            }
            myPath.AddLines(m_pointList);
            myPath.CloseFigure();
        }

        public void Move(int x_offset, int y_offset)
        {
            Matrix matrix = new Matrix();
            matrix.Translate(x_offset, y_offset); //追加平移
            myPath.Transform(matrix); //应用变形
        }

        public void Rotation()
        {
            Matrix matrix = new Matrix();
            RectangleF rect = new RectangleF();
            rect = myPath.GetBounds();
            // 计算旋转中心坐标(x,y)
            double x = rect.Left + rect.Width / 2;
            double y = rect.Top + rect.Height / 2;
            //matrix.Rotate(45.0f); //旋转顺时针45度
            matrix.RotateAt(45.0f, new Point((int)x, (int)y)); //旋转顺时针45度
            myPath.Transform(matrix); //应用变形
        }

        public void Move2(int x_offset, int y_offset)
        {
            myPath.Reset(); //清空路径
            for (int i = 0; i < m_nPointCount; i++) // 平移各点
            {
                m_pointList[i].X += x_offset;
                m_pointList[i].Y += y_offset;
            }
            myPath.AddLines(m_pointList);
            myPath.CloseFigure();
        }

        public void Rotation2() //45度旋转
        {
            RectangleF rect = new RectangleF();
            rect = myPath.GetBounds();
            myPath.Reset();
            double x = rect.Left + rect.Width / 2; // 计算旋转中心
            double y = rect.Top + rect.Height / 2;
            double dx, dy;
            for (int i = 0; i < m_nPointCount; i++) // 旋转各点
            {
                dx = m_pointList[i].X - x;
                dy = m_pointList[i].Y - y;
                m_pointList[i].X = (int)(x + dx * 0.7071 - dy * 0.7071);
                m_pointList[i].Y = (int)(y + dx * 0.7071 + dy * 0.7071);
                //m_pointList[i].X = (int)(x - dy );
                //m_pointList[i].Y = (int)(y + dx );
            }
            myPath.AddLines(m_pointList);
            myPath.CloseFigure();
        }

        public void ReverseTurn() // 水平反转
        {
            RectangleF rect = new RectangleF();
            rect = myPath.GetBounds();
            myPath.Reset();
            double x = rect.Left + rect.Width / 2; // 计算旋转中心
            double y = rect.Top + rect.Height / 2;
            for (int i = 0; i < m_nPointCount; i++) // 水平反转各点
            {
                m_pointList[i].X = (int)(2 * x - m_pointList[i].X);
                m_pointList[i].Y = m_pointList[i].Y;
            }
            myPath.AddLines(m_pointList);
            myPath.CloseFigure();
        }

        public void DrawChip(Graphics g) //画拼块
        {
            Pen myPen = new Pen(Color.Black, 1);
            g.DrawPath(myPen, myPath);
            int alpha = 140; //透明度
            Color c = Color.FromArgb(alpha, 255, 255, 255);
            switch (m_nType)
            {
                case 1:
                    c = Color.FromArgb(alpha, 127, 127, 127);
                    break;
                case 2:
                    c = Color.FromArgb(alpha, 255, 0, 0);
                    break;
                case 3:
                    c = Color.FromArgb(alpha, 200, 255, 0);
                    break;
                case 4:
                    c = Color.FromArgb(alpha, 200, 0, 255);
                    break;
                case 5:
                    c = Color.FromArgb(alpha, 127, 127, 0);
                    break;
                case 6:
                    c = Color.FromArgb(alpha, 127, 0, 127);
                    break;
                case 7:
                    c = Color.FromArgb(alpha, 0, 127, 127);
                    break;
                case 8:
                    c = Color.FromArgb(alpha, 228, 128, 128);
                    break;
            }

            SolidBrush brushNew = new SolidBrush(c);
            g.FillPath(brushNew, myPath);
        }

        //public void DrawChip2(Graphics g)//画同色拼块
        //{
        //    Pen myPen = new Pen(Color.Black, 1);
        //    g.DrawPath(myPen, myPath);
        //    int alpha = 140;   //透明度
        //    Color c = Color.FromArgb(alpha, 228, 128, 128);
        //    if (m_nType <= 8)
        //        c = Color.FromArgb(alpha, 0, 0, 255);
        //    else
        //        c = Color.FromArgb(alpha, 0, 255, 0);

        //    SolidBrush brushNew = new SolidBrush(c);
        //    g.FillPath(brushNew, myPath);
        //}
    }
}
