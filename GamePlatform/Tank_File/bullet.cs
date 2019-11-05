using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Tank_File
{
    internal class bullet
    {
        private readonly bool type; //己方子弹true,敌方子弹false
        private int direct; //子弹行进方向
        private int height = 32;
        private int left;
        private int top; //子弹坐标（Top,Left)
        private int width = 32;

        public bullet(int type) // 子弹类构造函数
        {
            if (type == 6) //己方
                this.type = true;
            else
                this.type = false;
        }

        public int Top //Top属性
        {
            get { return top; }
            set { top = value; }
        }

        public int Left //Left属性
        {
            get { return left; }
            set { left = value; }
        }

        public int Direct //Direct属性(子弹行进方向）
        {
            get { return direct; }
            set { direct = value; }
        }

        public void move()
        {
            switch (Direct)
            {
                case 0:
                    Top--;
                    break;
                case 1:
                    Top++;
                    break;
                case 2:
                    Left--;
                    break;
                case 3:
                    Left++;
                    break;
            }
        }

        public void Draw(Graphics g)
        {
            Image bulletImage;
            if (type) //己方
                bulletImage = Image.FromFile("BMP/missile1.bmp");
            else
                bulletImage = Image.FromFile("BMP/missile2.bmp");
            //得到绘制这个子弹图形的在游戏面板中的矩形区域
            Rectangle destRect = new Rectangle(left * width, top * height, width, height);
            Rectangle srcRect = new Rectangle(0, 0, width, height);
            g.DrawImage(bulletImage, destRect, srcRect, GraphicsUnit.Pixel);
        }

        public bool hitE(int tanktype) //是否击中对方坦克
        {
            if (type == false) //敌方子弹
                if (tanktype >= 2 && tanktype <= 5)
                    //坦克的类型(2---5敌方，6己方）
                    return false;
                else
                    return true;
            if (type) //己方子弹
                if (tanktype == 6) //坦克的类型(2---5敌方，6己方）
                    return false;
                else
                    return true;
            return false;
        }
    }
}
