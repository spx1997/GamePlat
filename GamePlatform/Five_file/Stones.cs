using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Five_file
{
    class Stones
    {
        private Graphics mg;
        private Bitmap bs;
        private Bitmap ws;

        public Stones(Graphics g)
        {
            //Assembly myAssembly = Assembly.GetExecutingAssembly();
            //string str = myAssembly.GetName().Name.ToString();
            //Stream bStream = myAssembly.GetManifestResourceStream(str + ".Resources" +  ".black.png");
            //Stream wStream = myAssembly.GetManifestResourceStream(str + ".Resources" +  ".white.png");
            //bs = new Bitmap(bStream);
            //ws = new Bitmap(wStream);

            //bStream.Close();
            //wStream.Close();
            Bitmap bbs = new Bitmap(Image.FromFile("black.png"));
            Bitmap bbw = new Bitmap(Image.FromFile("white.png"));
            bs = bbs;
            ws = bbw;
            mg = g;
        }

        public void DrawStone(int x, int y, bool flag)
        {
            if (flag)
            {
                mg.DrawImage(bs, x * 40 + 20, y * 40 + 23, bs.Width, bs.Height);
            }
            else
            {
                mg.DrawImage(ws, x * 40 + 20, y * 40 + 23, bs.Width, bs.Height);
            }
        }
    }
}
