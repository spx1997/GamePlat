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

namespace GamePlatform.Puzzle_file
{
    public partial class Puzzle_F : Form
    {
        string cemail;
        string game_name;

        public PictureBox[] PicBlock;
        int GameSize;                 //布局大小 
        int MAP_WIDTH = 300;          //图片宽度
        int FirstBlock, SecondBlock;
        bool flag;                    //是否交换   
        int[] Position;              //存放图片序号的数组
        Bitmap Source;                //原图像300*300
        string filename;              //所选择的文件名

        public Puzzle_F(string cemail,string game_name)
        {
            InitializeComponent();
            this.cemail = cemail;
            this.game_name = game_name;
        }
        
        private void Puzz_F_Load(object sender, System.EventArgs e)
        {
            CustomInfo cus = new CustomInfo();
            cus.GetSqlData(cemail);
            label_name.Text = cus.Cname;
            filename = Application.StartupPath + "\\puzzle_pic.jpg";
            pictureBox1.Image = Image.FromFile(filename);
            flag = false;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("9");
            comboBox1.Items.Add("16");
            comboBox1.Items.Add("25");
            comboBox1.Text = "9";
            MAP_WIDTH = 300;
            Source = new Bitmap(MAP_WIDTH, MAP_WIDTH);//原图像
            SaveBmp();
        }
        private void SaveBmp() //按MAP_WIDTH*MAP_WIDTH大小保存所选图片到Source位图
        {
            Graphics g;
            g = Graphics.FromImage(Source);     //生成Graphics对象 
            g.DrawImage(Image.FromFile(filename), 0, 0, MAP_WIDTH, MAP_WIDTH);
            //pictureBox1.Image
        }
        private void init(int n)
        {
            Random rdm;
            ArrayList al = new ArrayList();
            int t = 0;
            rdm = new Random();
            t = 0;
            while (al.Count < n * n)
            {
                t = rdm.Next(0, n * n);
                if ((!al.Contains(t)))
                {
                    al.Add(t);
                }
            }
            //清除已有图片框控件数组中的控件
            if (PicBlock != null)
            {
                for (int i = 0; i < PicBlock.Length; i++)
                    if (PicBlock[i] != null) PicBlock[i].Dispose();
            }
            PicBlock = new PictureBox[n * n];
            Position = new int[n * n];
            for (t = 0; t <= al.Count - 1; t++)
            {
                Position[t] = Convert.ToInt16(al[t]);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            GameSize = (int)Math.Sqrt(Convert.ToInt16(comboBox1.Text));
            init(GameSize);
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                filename = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(filename);
                SaveBmp();
            }
        }
        private void button2_Click(object sender, System.EventArgs e) //开始按钮
        {

            init(GameSize);       //卸载上次的图片块
                                  //重新加载图片块 
            int i = 0;
            int BWidth = 0; BWidth = MAP_WIDTH / GameSize;
            for (i = 0; i <= GameSize * GameSize - 1; i++)
            {
                PicBlock[i] = new PictureBox();
                this.Controls.Add(PicBlock[i]);
                PicBlock[i].Left = 250 + BWidth * (i % GameSize);
                PicBlock[i].Top = BWidth * (int)(i / GameSize) + 70;
                PicBlock[i].Width = BWidth;
                PicBlock[i].Height = BWidth;
                PicBlock[i].Name = "PicBlock" + i.ToString();
                PicBlock[i].Tag = i;
                PicBlock[i].Image = create_image(Position[i]);
                PicBlock[i].BorderStyle = BorderStyle.Fixed3D;
                //PicBlock[i].BringToFront() 
                ((PictureBox)PicBlock[i]).Click += swap;
            }
        }
        private void swap(object sender, System.EventArgs e)
        {
            //这里处理公共事件,根据单击交换数组元素； 
            PictureBox bClick = (PictureBox)sender;
            int i = 0;
            Image temp;
            //将被点击的控件赋给bClick变量 
            if (flag == false)
            {
                flag = true;
                FirstBlock = Convert.ToInt16(bClick.Tag);
            }
            else  //交换
            {
                this.Text = "";
                SecondBlock = Convert.ToInt16(bClick.Tag);
                temp = PicBlock[SecondBlock].Image;
                PicBlock[SecondBlock].Image = PicBlock[FirstBlock].Image;
                PicBlock[FirstBlock].Image = temp;
                flag = false;
                i = Position[SecondBlock];
                Position[SecondBlock] = Position[FirstBlock];
                Position[FirstBlock] = i;
                foreach (int s in Position)
                {
                    this.Text = this.Text + Position[s].ToString();
                }
                if (CheckWin() == true) //过关
                {
                    MessageBox.Show("成功了", "提示");
                }
            }
        }

        private bool CheckWin() //判断是否成功 
        {
            int t = 0;
            for (t = 0; t <= Position.Length - 1; t++)
            {
                if (Position[t] != t)
                {
                    return false;
                }
            }
            return true;
        }

        private Bitmap create_image(int n)  //按标号n截图 
        {
            int W = 0;
            W = MAP_WIDTH / GameSize;
            Bitmap bit = new Bitmap(W, W);
            Graphics g = Graphics.FromImage(bit);   //生成Graphics对象 
            Rectangle a = new Rectangle(0, 0, W, W);
            Rectangle b = new Rectangle((n % GameSize) * W, n / GameSize * W, W, W);
            g.DrawImage(Source, a, b, GraphicsUnit.Pixel);
            //截图  Copy W*W part from source image Image.FromFile("temp.bmp")
            return bit;
        }
    }
}
