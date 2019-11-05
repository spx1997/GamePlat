using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Snake_file
{
    class Bean
    {
        int foodtype;//食物类型1.表示苹果，其他的表示梨子
        public int Foodtype
        {
            get { return foodtype; }
            set { foodtype = value; }
        }
        public Bean()//构造函数
        {
            
        }
        private Point origin;                           //定义位置字段
        public Point Origin                             //定义位置属性
        {
            get { return origin; }
            set { origin = value; }
        }
        public void Display(Graphics g)                 //显示豆方法
        {
            //SolidBrush b = new SolidBrush(Color.Red);     //定义红色画刷
            //g.FillRectangle(b, origin.X, origin.Y, 15, 15);   //画实心矩形
           
            if (foodtype == 1)
            {
                Bitmap b = new Bitmap(Image.FromFile("apple.png"));
                g.DrawImage(b, origin.X, origin.Y, 15, 15);
            }
            else
            {
                Bitmap b = new Bitmap(Image.FromFile("pear.png"));
                g.DrawImage(b, origin.X, origin.Y, 15, 15);
            }
            
        }
        public void UnDisplay(Graphics g)               //消除豆方法
        {
            SolidBrush b = new SolidBrush(Color.Silver);  //定义背景色画刷
            //用背景色重画原来矩形即消除原矩形
            g.FillRectangle(b, origin.X, origin.Y, 15, 15);
        }
    }
}
