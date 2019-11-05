using GamePlatform.Con_code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePlatform.Lian_Look_file
{
    public partial class Lian_F : Form
    {
        #region LinkType enum

        public enum LinkType
        {
            LineType,
            OneCornerType,
            TwoCornerType
        };

        #endregion

        private readonly int[] m_map = new int[10 * 10];
        private int BLANK_STATE = -1;

        private int GameSize = 10; //布局大小即行列数
        private LinkType LType; //连通方式
        private bool Select_first; //是否已经选中第一块
        private Bitmap Source; //所有动物图案的图片
        private int W = 50; //动物方块图案的宽度
        private int m_nCol = 10;
        private int m_nRow = 10;
        private int x1; //被选中第一块的地图坐标
        private int x2; //被选中第二块的地图坐标
        private int y1; //被选中第一块的地图坐标
        private int y2; //被选中第二块的地图坐标
        private Point z1, z2; //折点棋盘坐标

        string cemail;
        string game_name;
        int Score=1;
        public Lian_F(string cemail,string game_name)
        {

            InitializeComponent();
            this.cemail = cemail;
            this.game_name = game_name;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Source = (Bitmap)Image.FromFile("..\\..\\res\\animal.bmp");
            pictureBox1.Height = W * (m_nRow + 2);
            pictureBox1.Width = W * (m_nCol + 2);
            pictureBox1.Top = 0;
            pictureBox1.Left = 0;
            //当前窗体标题栏高度
            int d = (Height - ClientRectangle.Height);
            Height = pictureBox1.Height + pictureBox1.Top + d;
            Width = pictureBox1.Width + pictureBox1.Left;
            //for (int i = 0; i < 10 * 10; i++)
            //{
            //    m_map[i] = i % 6;
            //} 
            label_score.Text = Score.ToString();
            //StartNewGame();
            //Init_Graphic();
        }

        private void StartNewGame()
        {
            //初始化地图,将地图中所有方块区域位置置为空方块状态
            for (int iNum = 0; iNum < (m_nCol * m_nRow); iNum++)
            {
                m_map[iNum] = BLANK_STATE;
            }
            Random r = new Random();
            //生成随机地图
            //将所有的动物物种放进一个临时的地图tmpMap中
            ArrayList tmpMap = new ArrayList();
            for (int i = 0; i < (m_nCol * m_nRow) / 4; i++)
                for (int j = 0; j < 4; j++)
                    tmpMap.Add(i);

            //每次从上面的临时地图tmpMap中取走(获取后并在临时地图删除)
            //一个动物放到地图的空方块上
            for (int i = 0; i < m_nRow * m_nCol; i++)
            {
                //随机挑选一个位置
                int nIndex = r.Next() % tmpMap.Count;
                //获取该选定物件放到地图的空方块
                m_map[i] = (int)tmpMap[nIndex];

                //在临时地图tmpMap除去该动物
                tmpMap.RemoveAt(nIndex);
            }
        }

        private void Init_Graphic()
        {
            Graphics g = get_Graphic(); //生成Graphics对象

            for (int i = 0; i < 10 * 10; i++)
            {
                g.DrawImage(create_image(m_map[i]), W * (i % GameSize) + W,
                            W * (i / GameSize) + W, W, W);
            }
        }

        private Graphics get_Graphic()
        {
            if (pictureBox1.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
            }
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            return g;
        }

        public Graphics GetGraphicsObject(ref PictureBox pic)
        {
            Graphics g;
            Bitmap bmp = new Bitmap(pic.Width, pic.Height);
            pic.Image = bmp;
            g = Graphics.FromImage(bmp);
            return g;
        }

        //create_image（）方法实现按标号n从所有动物图案的图片中截图。
        private Bitmap create_image(int n) //按标号n截图 
        {
            Bitmap bit = new Bitmap(W, W);
            Graphics g = Graphics.FromImage(bit); //生成Graphics对象 
            Rectangle a = new Rectangle(0, 0, W, W);
            Rectangle b = new Rectangle(0, n * 39, 39, 39);
            //截取原图中b矩形区域的图形
            g.DrawImage(Source, a, b, GraphicsUnit.Pixel);
            return bit;
        }

        ///检测是否已经赢得了游戏
        private bool IsWin()
        {
            //检测所有是否尚有非未被消除的方块
            // (非BLANK_STATE状态)
            for (int i = 0; i < m_nRow * m_nCol; i++)
            {
                if (m_map[i] != BLANK_STATE)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsSame(int x1, int y1, int x2, int y2)
        {
            if (m_map[y1 * m_nCol + x1] == m_map[y2 * m_nCol + x2])
                return true;
            else
                return false;
        }

        //
        //X直接连通即垂直方向连通
        //
        private bool X_Link(int x, int y1, int y2)
        {
            //保证y1的值小于y2
            if (y1 > y2)
            {
                //数据交换
                int n = y1;
                y1 = y2;
                y2 = n;
            }

            //直通 	
            for (int i = y1 + 1; i <= y2; i++)
            {
                if (i == y2)
                    return true;
                if (m_map[i * m_nCol + x] != BLANK_STATE)
                    break;
            }
            return false;
        }

        //
        //Y直接连通即水平方向连通
        //
        private bool Y_Link(int x1, int x2, int y)
        {
            if (x1 > x2)
            {
                int x = x1;
                x1 = x2;
                x2 = x;
            }
            //直通
            for (int i = x1 + 1; i <= x2; i++)
            {
                if (i == x2)
                    return true;
                if (m_map[y * m_nCol + i] != BLANK_STATE)
                    break;
            }
            return false;
        }

        //
        //  1直角接口连通
        //
        private bool OneCornerLink(int x1, int y1, int x2, int y2)
        {
            if (x1 > x2) //目标点（x1,y1）,（x2,y2）两点交换
            {
                int n = x1;
                x1 = x2;
                x2 = n;
                n = y1;
                y1 = y2;
                y2 = n;
            }
            if (y2 < y1) //（x1,y1）为矩形左下顶点，（x2,y2）点为矩形右上顶点
            {
                //判断矩形右下角折点（x2,y1）是否空
                if (m_map[y1 * m_nCol + x2] == BLANK_STATE)
                {
                    if (Y_Link(x1, x2, y1) && X_Link(x2, y1, y2))
                    //判断折点（x2,y1）与两个目标点是否直通
                    {
                        z1.X = x2;
                        z1.Y = y1; //保存折点坐标到z1
                        return true;
                    }
                }
                //判断矩形左上角折点（x1,y2）是否空
                if (m_map[y2 * m_nCol + x1] == BLANK_STATE)
                {
                    if (Y_Link(x2, x1, y2) && X_Link(x1, y2, y1))
                    //判断折点 （x1,y2）与两个目标点是否直通
                    {
                        z1.X = x1;
                        z1.Y = y2; //保存折点坐标到z1
                        return true;
                    }
                }
                return false;
            }
            else //（x1,y1）为矩形左上顶点，（x2,y2）点为矩形右下顶点
            {
                //判断矩形左下角折点（x1,y2）是否空
                if (m_map[y2 * m_nCol + x1] == BLANK_STATE)
                {
                    if (Y_Link(x1, x2, y2) && X_Link(x1, y1, y2))
                    //判断折点 （x1,y2）与两个目标点是否直通
                    {
                        z1.X = x1;
                        z1.Y = y2; //保存折点坐标到z1
                        return true;
                    }
                }
                //判断矩形右上角折点（x2,y1）是否空
                if (m_map[y1 * m_nCol + x2] == BLANK_STATE)
                {
                    if (Y_Link(x1, x2, y1) && X_Link(x2, y1, y2))
                    //判断折点（x2,y1）与两个目标点是否直通  
                    {
                        z1.X = x2;
                        z1.Y = y1; //保存折点坐标到z1
                        return true;
                    }
                }
                return false;
            }
        }

        ///2折点连通
        private bool TwoCornerLink(int x1, int y1, int x2, int y2)
        {
            if (x1 > x2)
            {
                int n = x1;
                x1 = x2;
                x2 = n;
                n = y1;
                y1 = y2;
                y2 = n;
            }
            //右
            int x, y;
            for (x = x1 + 1; x <= m_nCol; x++)
            {
                if (x == m_nCol)
                    //两个折点在选中方块的右侧，且两个折点在图案区域之外
                    if (XThrough(x2 + 1, y2, true))
                    //Y_Link(x2 + 1, m_nCol-1, y2)&&m_map[y1 * (m_nCol-1) + x]== BLANK_STATE
                    {
                        z2.X = m_nCol;
                        z2.Y = y1;
                        z1.X = m_nCol;
                        z1.Y = y2;
                        return true;
                    }
                    else
                        break;
                if (m_map[y1 * m_nCol + x] != BLANK_STATE)
                    break;
                if (OneCornerLink(x, y1, x2, y2))
                {
                    z2.X = x;
                    z2.Y = y1;
                    return true;
                }
            }
            //左
            for (x = x1 - 1; x >= -1; x--)
            {
                if (x == -1)
                    //两个折点在选中方块的左侧，且两个折点在图案区域之外
                    if (XThrough(x2 - 1, y2, false))
                    {
                        z2.X = -1;
                        z2.Y = y1;
                        z1.X = -1;
                        z1.Y = y2;
                        return true;
                    }
                    else
                        break;

                if (m_map[y1 * m_nCol + x] != BLANK_STATE)
                    break;
                if (OneCornerLink(x, y1, x2, y2))
                {
                    z2.X = x;
                    z2.Y = y1;
                    return true;
                }
            }
            //上
            for (y = y1 - 1; y >= -1; y--)
            {
                if (y == -1)
                    //两个折点在选中方块的上侧，且两个折点在图案区域之外
                    if (YThrough(x2, y2 - 1, false))
                    {
                        z2.X = x1;
                        z2.Y = -1;
                        z1.X = x2;
                        z1.Y = -1;

                        return true;
                    }
                    else
                        break;
                if (m_map[y * m_nCol + x1] != BLANK_STATE)
                    break;
                if (OneCornerLink(x1, y, x2, y2))
                {
                    z2.X = x1;
                    z2.Y = y;
                    return true;
                }
            }
            //下
            for (y = y1 + 1; y <= m_nRow; y++)
            {
                if (y == m_nRow)
                    //两个折点在选中方块的下侧，且两个折点在图案区域之外
                    if (YThrough(x2, y2 + 1, true))
                    {
                        z2.X = x1;
                        z2.Y = m_nRow;
                        z1.X = x2;
                        z1.Y = m_nRow;
                        return true;
                    }
                    else
                        break;
                if (m_map[y * m_nCol + x1] != BLANK_STATE)
                    break;
                if (OneCornerLink(x1, y, x2, y2))
                {
                    z2.X = x1;
                    z2.Y = y;
                    return true;
                }
            }
            return false;
        }

        private bool XThrough(int x, int y, bool bAdd) //水平方向判断到边界的连通性  
        {
            if (bAdd) //True,水平向右判断是否连通（是否为空）
            {
                for (int i = x; i < m_nCol; i++)
                    if (m_map[y * m_nCol + i] != BLANK_STATE)
                        return false;
            }
            else //false, 水平向左判断是否连通（是否为空）
            {
                for (int i = 0; i <= x; i++)
                    if (m_map[y * m_nCol + i] != BLANK_STATE)
                        return false;
            }
            return true;
        }

        private bool YThrough(int x, int y, bool bAdd) //垂直方向判断到边界的连通性）
        {
            if (bAdd) //True, 垂直方向向下判断是否连通（是否为空）
            {
                for (int i = y; i < m_nRow; i++)
                    if (m_map[i * m_nCol + x] != BLANK_STATE)
                        return false;
            }
            else //false, 垂直方向向上判断是否连通（是否为空）
            {
                for (int i = 0; i <= y; i++)
                    if (m_map[i * m_nCol + x] != BLANK_STATE)
                        return false;
            }
            return true;
        }

        //
        //  判断选中的两个方块是否可以消除
        //
        private bool IsLink(int x1, int y1, int x2, int y2)
        {
            //X直连方式即垂直方向连通
            if (x1 == x2)
            {
                if (X_Link(x1, y1, y2))
                {
                    LType = LinkType.LineType;
                    return true;
                }
            }
            //Y直连方式即水平方向连通
            else if (y1 == y2)
            {
                if (Y_Link(x1, x2, y1))
                {
                    LType = LinkType.LineType;
                    return true;
                }
            }
            //一个转弯（折点）的联通方式
            if (OneCornerLink(x1, y1, x2, y2))
            {
                LType = LinkType.OneCornerType;
                return true;
            }
            //两个转弯（折点）的联通方式
            else if (TwoCornerLink(x1, y1, x2, y2))
            {
                LType = LinkType.TwoCornerType;
                return true;
            }
            return false;
        }

        private bool Find2Block()
        {
            bool bFound = false;
            //第一个方块从地图的0位置开始
            for (int i = 0; i < m_nRow * m_nCol; i++)
            {
                //找到则跳出循环
                if (bFound)
                    break;
                //无动物的空格跳过
                if (m_map[i] == BLANK_STATE)
                    continue;
                //第二个方块从前一个方块的后面开始
                for (int j = i + 1; j < m_nRow * m_nCol; j++)
                {
                    //第二个方块不为空 且与第一个方块的动物相同
                    if (m_map[j] != BLANK_STATE && m_map[i] == m_map[j])
                    {
                        //算出对应的虚拟行列位置
                        x1 = i % m_nCol;
                        y1 = i / m_nCol;
                        x2 = j % m_nCol;
                        y2 = j / m_nCol;

                        //判断是否可以连通
                        if (IsLink(x1, y1, x2, y2))
                        {
                            bFound = true;
                            break;
                        }
                    }
                }
            }
            if (bFound)
            {
                //（x1,y1）与（x2,y2）连通
                Graphics g = pictureBox1.CreateGraphics(); //生成Graphics对象
                //**********************************
                //Graphics g = get_Graphic();              //生成Graphics对象
                //************************************
                Pen myPen = new Pen(Color.Blue, 3);
                Rectangle b1 = new Rectangle(x1 * W + 1 + W, y1 * W + 1 + W, W - 3, W - 3);
                g.DrawRectangle(myPen, b1);
                Rectangle b2 = new Rectangle(x2 * W + 1 + W, y2 * W + 1 + W, W - 3, W - 3);
                g.DrawRectangle(myPen, b2);
            }
            return bFound;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Init_Graphic();
        }

        private void Delay(int second) //让程序延时数秒
        {
            DateTime now = DateTime.Now;
            while (now.AddSeconds(second) > DateTime.Now)
            {
            }
        }

        /// <summary>
        ///   画选中方块之间连接线
        /// </summary>
        private void DrawLinkLine(int x1, int y1, int x2, int y2, LinkType LType)
        {
            Graphics g = pictureBox1.CreateGraphics(); //生成Graphics对象
            Pen p = new Pen(Color.Red, 3);
            Point p1 = new Point(x1 * W + W / 2 + W, y1 * W + W / 2 + W);
            Point p2 = new Point(x2 * W + W / 2 + W, y2 * W + W / 2 + W);
            if (LType == LinkType.LineType)
                g.DrawLine(p, p1, p2);
            if (LType == LinkType.OneCornerType)
            {
                Point pixel_z1 = new Point(z1.X * W + W / 2 + W, z1.Y * W + W / 2 + W);
                g.DrawLine(p, p1, pixel_z1);
                g.DrawLine(p, pixel_z1, p2);
            }
            if (LType == LinkType.TwoCornerType)
            {
                Point pixel_z1 = new Point(z1.X * W + W / 2 + W, z1.Y * W + W / 2 + W);
                Point pixel_z2 = new Point(z2.X * W + W / 2 + W, z2.Y * W + W / 2 + W);
                if (!(p1.X == pixel_z2.X || p1.Y == pixel_z2.Y))
                {
                    //p1与pixel_z2不在一直线上，则pixel_z1，pixel_z2交换
                    Point c;
                    c = pixel_z1;
                    pixel_z1 = pixel_z2;
                    pixel_z2 = c;
                }
                g.DrawLine(p, p1, pixel_z2);
                g.DrawLine(p, pixel_z2, pixel_z1);
                g.DrawLine(p, pixel_z1, p2);
            }
        }

        /// <summary>
        ///   清除选中方块之间连接线
        /// </summary>
        private void UnDrawLinkLine(int x1, int y1, int x2, int y2, LinkType LType)
        {
            Graphics g = pictureBox1.CreateGraphics(); //生成Graphics对象
            Pen p = new Pen(BackColor, 3);
            Point p1 = new Point(x1 * W + W / 2 + W, y1 * W + W / 2 + W);
            Point p2 = new Point(x2 * W + W / 2 + W, y2 * W + W / 2 + W);
            if (LType == LinkType.LineType)
                g.DrawLine(p, p1, p2);
            if (LType == LinkType.OneCornerType)
            {
                Point pixel_z1 = new Point(z1.X * W + W / 2 + W, z1.Y * W + W / 2 + W);
                g.DrawLine(p, p1, pixel_z1);
                g.DrawLine(p, pixel_z1, p2);
            }
            if (LType == LinkType.TwoCornerType)
            {
                Point pixel_z1 = new Point(z1.X * W + W / 2 + W, z1.Y * W + W / 2 + W);
                Point pixel_z2 = new Point(z2.X * W + W / 2 + W, z2.Y * W + W / 2 + W);
                if (!(p1.X == pixel_z2.X || p1.Y == pixel_z2.Y))
                {
                    //p1与pixel_z2不在一直线上，则pixel_z1，pixel_z2交换
                    Point c;
                    c = pixel_z1;
                    pixel_z1 = pixel_z2;
                    pixel_z2 = c;
                }
                g.DrawLine(p, p1, pixel_z2);
                g.DrawLine(p, pixel_z2, pixel_z1);
                g.DrawLine(p, pixel_z1, p2);
            }
        }

        private void DrawSelectedBlock(int x, int y, Pen myPen, Graphics g)
        {
            //画选中方块的示意边框线
            Rectangle b1 = new Rectangle(x * W + 1 + W, y * W + 1 + W, W - 3, W - 3);
            g.DrawRectangle(myPen, b1);
        }

        private void ClearSelectedBlock(int x, int y, Graphics g)
        {
            Score++;
            label_score.Text = Score.ToString();
            //清除选中方块
            SolidBrush myBrush = new SolidBrush(BackColor); //定义背景色画刷
            Rectangle b1 = new Rectangle(x * W + W, y * W + W, W, W);
            g.FillRectangle(myBrush, b1);
        }

     
        private void 保存得分ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_Game_R Inser_data = new Data_Game_R();
            Inser_data.Email = cemail;
            Inser_data.Score = Score;
            Data_Game_W Inser_data_m = new Data_Game_W();
            Inser_data_m.Insert_Data(game_name, Inser_data);
            MessageBox.Show("游戏分数保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 排行榜RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lian_Rank_F lian_rank_f = new Lian_Rank_F(game_name);
            lian_rank_f.Show();
        }

        private void 帮助HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lian_Help_F lian_help_f = new Lian_Help_F();
            lian_help_f.Show();
        }

        private void 开始游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame();
            Init_Graphic();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
            Graphics g = pictureBox1.CreateGraphics(); //生成Graphics对象
            //**********************************
            //Graphics g = get_Graphic();              //生成Graphics对象
            //************************************
            Pen myPen = new Pen(Color.Red, 3);
            int x, y;
            if (e.Button == MouseButtons.Left)
            {
                //计算点击的方块的位置坐标
                x = (e.X - W) / W;
                y = (e.Y - W) / W;
                if (x >= GameSize || y >= GameSize) return;
                //如果该区域无方块
                if (m_map[y * m_nCol + x] == BLANK_STATE) return;
                if (Select_first == false)
                {
                    x1 = x;
                    y1 = y;
                    //画选定（x1,y1)处的框线
                    DrawSelectedBlock(x1, y1, myPen, g);
                    Select_first = true;
                }
                else
                {
                    x2 = x;
                    y2 = y;
                    //判断第二次点击的方块是否已被第一次点击选取，如果是则返回。
                    if ((x1 == x2) && (y1 == y2)) return;
                    //画选定（x2,y2)处的框线
                    //myPen = new Pen(Color.Red, 3);
                    //Rectangle b = new Rectangle(x2 * W + 1, y2 * W + 1, W - 3, W - 3);
                    //g.DrawRectangle(myPen, b);
                    DrawSelectedBlock(x2, y2, myPen, g);
                    //判断是否连通
                    if (IsSame(x1, y1, x2, y2) && IsLink(x1, y1, x2, y2))
                    {
                        DrawLinkLine(x1, y1, x2, y2, LType); //画选中方块之间连接线
                        Thread.Sleep(500); //延时0.5秒
                        ClearSelectedBlock(x1, y1, g); //清除第一个选定方块
                        ClearSelectedBlock(x2, y2, g); //清除第一个选定方块
                        //清空记录方块的值
                        m_map[y1 * m_nCol + x1] = BLANK_STATE;
                        m_map[y2 * m_nCol + x2] = BLANK_STATE;
                        Select_first = false;
                        UnDrawLinkLine(x1, y1, x2, y2, LType); //清除选中方块之间连接线
                    }
                    else //重新选定第一个方块
                    {
                        //重画（x1,y1)处动物图案来达到取消原选定（x1,y1)处的框线
                        int i = y1 * m_nCol + x1;
                        g.DrawImage(create_image(m_map[i]), W * (i % GameSize) + W,
                                    W * (i / GameSize) + W, W, W);
                        //设置重新选定第一个方块的坐标
                        x1 = x;
                        y1 = y;
                        //画新选定（x1,y1)处的框线
                        //myPen = new Pen(Color.Red, 3);
                        //Rectangle b2 = new Rectangle(x1 * W + 1, y1 * W + 1, W - 3, W - 3);
                        //g.DrawRectangle(myPen, b2);
                        Select_first = true;
                    }
                }
            }
            if (e.Button == MouseButtons.Right) //智能查找功能
            {
                if (!Find2Block()) MessageBox.Show("没有连通的方块了！！");
            }
            //察看是否已经胜利
            if (IsWin())
            {
                MessageBox.Show("恭喜您胜利闯关,即将开始新局");
                //StartNewGame();
            }
        }
    }
}
