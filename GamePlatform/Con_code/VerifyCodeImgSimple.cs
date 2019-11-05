using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Con_code
{
    class VerifyCodeImgSimple
    {
        //生成随机字符串
        public string CreateVerifyCode(int length)
        {
            string code = "";
            string baseChar = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rnd = new Random();
            for (int i = 1; i <= length; i++)
            {
                code += baseChar[rnd.Next(baseChar.Length)].ToString();

            }
            return code;
        }
        //生成校验图片
        public Bitmap CreateImage(string code,int fontSize,string font,Color foreColor,Color bgColor)
        {
            //图像的宽度和高度
            int imageWidth=(code.Length*fontSize)+40;
            int imageHeight = fontSize * 2 + 10;
            //生成图像框
            Bitmap image = new Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(image);
            g.Clear(bgColor);
            Font fnt = new Font(font, fontSize, FontStyle.Bold);
            g.DrawString(code, fnt, new SolidBrush(foreColor), 1, 1);//设置验证码
            
            Random rnd = new Random();
            //給背景添加随机生成的噪点
            for (int i=1; i <= 100; i++)
            {
                int x = rnd.Next(imageWidth);
                int y = rnd.Next(imageHeight);
                g.FillRectangle(new SolidBrush(Color.FromArgb(rnd.Next())), x, y, 2, 2);
            }
            //给背景添加随机生成的干扰线
            for (int i = 1; i <= 50; i++)
            {
                int x1 = rnd.Next(imageWidth);
                int y1 = rnd.Next(imageHeight);
                int x2 = rnd.Next(imageWidth);
                int y2 = rnd.Next(imageHeight);
                g.DrawLine(new Pen(Color.FromArgb(rnd.Next()), 2), x1, y1, x2, y2);
                
            }
            return image;
        }
    }
}
