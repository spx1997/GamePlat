using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Tank_File
{
    internal class Tank
    {
        private readonly int height; //坦克的高度
        private readonly int width; //坦克的宽度
        public ArrayList bList = new ArrayList(); //子弹序列
        private int direct; //0--上,1--下,2--左,3--右
        private int left; //坦克位置的横坐标
        private int top; //坦克位置的纵坐标
        private int type; //坦克的类型(2---5敌方，6己方）

        public Tank(int tank_type) //构造函数
        {
            Random r = new Random();
            direct = r.Next(0, 4); //产生0—3的数 
            width = 32;
            height = 32;
            left = r.Next(0, 10); //产生0—9的数
            top = r.Next(0, 10); //产生0—9的数
            type = tank_type;
        }

        public int Top //Top属性
        {
            get { return top; }
            set
            {
                if (top >= 0 && top <= 9)
                {
                    top = value;
                    //if (top == 0 || top == 9) newDirect();
                }
            }
        }

        public int Type //坦克的类型属性
        {
            get { return type; }
            set
            {
                if (top >= 1 && top <= 5)
                {
                    type = value;
                }
            }
        }

        public int Left //Left属性
        {
            get { return left; }
            set
            {
                if (left >= 0 && left <= 9)
                {
                    left = value;
                    //if (left == 0 || left == 9) newDirect();
                }
            }
        }

        public int Direct //Direct属性(坦克方向）
        {
            get { return direct; }
            set { direct = value; }
        }

        public void newDirect() //改变方向
        {
            Random r = new Random();
            int new_Direct = r.Next(0, 4); //产生0—3的数
            while (direct == new_Direct)
                new_Direct = r.Next(0, 4); //产生0—3的数
            direct = new_Direct;
        }

        public void Draw(Graphics g, int type) //根据坦克类型选择不同图片
        {
            Image tankImage = Image.FromFile("BMP/ETANK1.BMP");
            if (type == 2) tankImage = Image.FromFile("BMP/ETANK2.BMP");
            if (type == 3) tankImage = Image.FromFile("BMP/ETANK3.BMP");
            if (type == 4) tankImage = Image.FromFile("BMP/ETANK4.BMP");
            if (type == 5) tankImage = Image.FromFile("BMP/ETANK1.BMP");
            if (type == 6) tankImage = Image.FromFile("BMP/MYTANK.BMP");
            //得到绘制这个坦克图形的在游戏面板中的矩形区域
            Rectangle destRect = new Rectangle(left * width, top * height, width, height);
            Rectangle srcRect = new Rectangle(direct * width, 0, width, height);
            g.DrawImage(tankImage, destRect, srcRect, GraphicsUnit.Pixel);
        }

        public void Explore(Graphics g) //坦克爆炸动画
        {
            //得到绘制这个坦克图形的在游戏面板中的矩形区域
            Rectangle destRect = new Rectangle(left * width, top * height, width, height);
            Rectangle srcRect = new Rectangle(0, 0, width, height);
            Image tankImage = Image.FromFile("BMP/explode1.bmp");
            g.DrawImage(tankImage, destRect, srcRect, GraphicsUnit.Pixel);
            tankImage = Image.FromFile("BMP/explode1.bmp");
            g.DrawImage(tankImage, destRect, srcRect, GraphicsUnit.Pixel);
            tankImage = Image.FromFile("BMP/explode2.bmp");
            g.DrawImage(tankImage, destRect, srcRect, GraphicsUnit.Pixel);
            PlaySound.Play("Sound/Explode.wav");
        }

        public void fire()
        {
            bullet b = new bullet(type); //根据坦克产生不同子弹
            b.Direct = Direct; //坦克的朝向
            b.Top = Top;
            b.Left = Left;
            //b.move();
            bList.Add(b);
            if (type == 6) PlaySound.Play("Sound/Shoot.wav"); //己方发射出声
        }

        public void MoveBullet(ref int[,] Map)
        {
            for (int i = bList.Count - 1; i >= 0; i--) //遍历子弹序列
                                                       //for (int i = 0; i < bList.Count;i++ )
            {
                bullet t = ((bullet)bList[i]);
                //移动以前
                if (t.Left < 0 || t.Left > 9 || t.Top < 0 || t.Top > 9)
                //超出边界
                {
                    bList.RemoveAt(i);
                    continue; //删除此颗子弹
                }
                if (Map[t.Left, t.Top] != 0 && Map[t.Left, t.Top] != type)
                //已遇到坦克和墙等障碍物
                {
                    bList.RemoveAt(i); //删除此颗子弹
                    if (t.hitE(Map[t.Left, t.Top])) //击中对方坦克
                        Map[t.Left, t.Top] = -1; //此处坦克被打中
                    continue;
                }
                t.move(); //移动以后
                if (t.Left < 0 || t.Left > 9 || t.Top < 0 || t.Top > 9)
                //超出边界
                {
                    bList.RemoveAt(i);
                    continue; //删除此颗子弹
                }
                if (Map[t.Left, t.Top] != 0) //已遇到物体
                {
                    bList.RemoveAt(i); //删除此颗子弹
                    if (t.hitE(Map[t.Left, t.Top])) //击中对方坦克
                        Map[t.Left, t.Top] = -1; //此处坦克被打中
                    continue;
                }
            }
        }

        public void DrawBullet(Graphics g, int[,] Map) //画子弹
        {
            MoveBullet(ref Map);
            foreach (bullet t in bList) //遍历子弹序列
                t.Draw(g);
        }

        //public void NewPosition()//产生新坐标
        //{
        //    Random r = new Random();
        //    this.left = r.Next(0, 10);//产生0—9的数
        //    this.top = r.Next(0, 10);//产生0—9的数
        //}
        //public bool ComparePosition(Tank s)//比较坦克位置
        //{
        //    if (this.left == s.left && this.top == s.top)
        //        return true;
        //    else
        //        return false;
        //}     
    }
}
