using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Tetris_file
{
   public class Block
    {
        private short width;
        private short height;
        private short top;
        private short left;
        private int ID;    　　　//方块部件的ID
        public int[,] shape;　　//存储方块部件的形状，０为空白，１为有砖块
        public Block()//构造函数
        {
            Random randomGenerator = new Random();
            int randomBlock = randomGenerator.Next(1, 5);//产生1—4的数
            this.ID = randomBlock;
            switch (this.ID)
            {
                case 1:   //横条形
                    this.Width = 4;
                    this.Height = 1;
                    this.Top = 0;
                    this.Left = 3;
                    shape = new int[this.Width, this.Height];
                    shape[0, 0] = 1; shape[1, 0] = 1;
                    shape[2, 0] = 1; shape[3, 0] = 1;
                    break;
                case 2:　	//正方形
                    this.Width = 2;
                    this.Height = 2;
                    this.Top = 0;
                    this.Left = 4;
                    // Creates the new shape for this block.
                    shape = new int[this.Width, this.Height];
                    shape[0, 0] = 1; shape[0, 1] = 1;
                    shape[1, 0] = 1; shape[1, 1] = 1;
                    break;
                case 3:　	//Ｔ形
                    this.Width = 3;
                    this.Height = 3;
                    this.Top = 0;
                    this.Left = 4;
                    // Creates the new shape for this block.
                    shape = new int[this.Width, this.Height];
                    shape[0, 0] = 1; shape[1, 0] = 1;
                    shape[2, 0] = 1; shape[1, 1] = 1;
                    shape[1, 2] = 1;
                    break;
                case 4:　	//L形
                    this.Width = 2;
                    this.Height = 3;
                    this.Top = 0;
                    this.Left = 4;
                    // Creates the new shape for this block.
                    shape = new int[this.Width, this.Height];
                    shape[0, 0] = 1; shape[0, 1] = 1;
                    shape[0, 2] = 1; shape[1, 2] = 1;
                    break;
            }
        }
        public short Width//Width属性
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public short Height//Height属性
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public short Top//Top属性
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }
        public short Left//Left属性
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }
        public void Draw(Graphics g)
        {
            Image brickImage = Image.FromFile("image/block0.gif");
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    if (this.shape[i, j] == 1)//黑色格子
                    {
                        //得到绘制这个格子的在游戏面板中的矩形区域
                        Rectangle rect = new Rectangle((this.Left + i) * Game.BlockImageWidth, (this.Top + j) * Game.BlockImageHeight, Game.BlockImageWidth, Game.BlockImageHeight);
                        g.DrawImage(brickImage, rect);
                    }
                }
            }
        }
    }
}
