using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Snake_file
{
    class Snake
    {
        ArrayList blockList;            //字段
        private int headNumber;         //蛇头序数或蛇长度
        private Point headPoint;        //蛇头位置（左上角坐标）
        private int direction = 1;      //0,1,2,3分别代表上、右、下、左
        public Snake()                 //构造函数
        {

        }
        public Snake(Point vertex, int count)                 //建立游戏开始的蛇
        {
            Block bb;
            Point p = new Point(vertex.X + 15, vertex.Y + 15);//定义起始位置
            blockList = new ArrayList(count);                   //初始数组长度为count
            for (int i = 0; i < count; i++)                    //通过循环填充blockList
            {
                p.X = p.X + 15;                                  //x坐标加
                bb = new Block();                               //实例化新块
                bb.Origin = p;                                  //块的位置赋值
                bb.Number = i + 1;                              //蛇中块序数从开始
                //如果是蛇头就把位置（顶点）赋给headPoint
                if (i == count - 1)
                {
                    headPoint = bb.Origin;                      //给蛇的头位置赋值
                    bb.Ishead = true;
                }
                blockList.Add(bb);                              //把块添加到blockList中
            }
            headNumber = count;                                 //给蛇头序数（蛇长度）赋值
        }


        public Point getHeadPoint                               //只读蛇头位置属性
        {
            get { return headPoint; }
        }
        public bool getHitSelf                                  //判断蛇是否碰到自身的只读属性
        {
            get
            {
                IEnumerator myEnumerator = blockList.GetEnumerator();//定义并实例化枚举接口
                try
                {
                    while (myEnumerator.MoveNext())               //通过循环遍历蛇的各块
                    {
                        Block b = (Block)myEnumerator.Current;      //读取当前块
                        //当前块不是蛇头且与蛇头位置相同
                        if (!b.Ishead && b.Origin.Equals(headPoint))//b.Number != headNumber
                        {
                            return true;                            //返回true
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                }
                return false;                                       //返回false
            }
        }
        public int Direction                                        //蛇的运行方向属性
        {
            get { return direction; }
            set { direction = value; }
        }

        public void TurnDirection(int pDirection)                   //蛇的转向方法，参数为蛇要改变方向
        {
            switch (direction)
            {
                case 0:                                             //原来向上
                    if (pDirection == 3)                             //如果改变方向为左
                        direction = 3;
                    else if (pDirection == 1)                       //如果改变方向为右
                        direction = 1;
                    break;
                case 1:
                    if (pDirection == 2)
                        direction = 2;
                    else if (pDirection == 0)
                        direction = 0;
                    break;
                case 2:
                    if (pDirection == 3)
                        direction = 3;
                    else if (pDirection == 1)
                        direction = 1;
                    break;
                case 3:
                    if (pDirection == 2)
                        direction = 2;
                    else if (pDirection == 0)
                        direction = 0;
                    break;
            }
        }

        public void Growth()                                        //蛇增长方法
        {
            Block b = (Block)blockList[blockList.Count - 1];
            int x = b.Origin.X;                         //读取当前块即蛇头的位置坐标
            int y = b.Origin.Y;
            b.Ishead = false;
            switch (direction)                           //根据当前运动方向设置新块坐标
            {
                case 0:                                 //向上y坐标减
                    y = y - 15;
                    break;
                case 1:
                    x = x + 15;
                    break;
                case 2:
                    y = y + 15;
                    break;
                case 3:
                    x = x - 15;
                    break;
            }
            Point headP = new Point(x, y);          //由坐标构造头位置点
            Block bb = new Block();                                 //定义并实例化新块
            bb.Origin = headP;                      //把点赋给新块的位置属性
            bb.Number = b.Number + 1;               //当前块的序数+1赋给新块的序数属性
            bb.Ishead = true;
            blockList.Add(bb);                      //把新块添加到blockList中
            headNumber++;                          //头块的序数（蛇的长度）增加
            headPoint = headP;                      //给头位置赋新值            
        }
        public void Go(Graphics g)                //蛇前行
        {
            Block b = new Block();                //定义并初始化新块b
            b = (Block)blockList[0];              //取出blockList的第一个元素(蛇尾快）给b
            b.UnDisplay(g);                       //消除b块显示
            blockList.RemoveAt(0);                //从blockList中移出第一块
            foreach (Block b1 in blockList)
            {
                b1.Number--;                      //当前块的序数属性值减1
            }
            headNumber--;
            Growth();
        }
        public void Display(Graphics g)            //显示蛇方法，参数为图形对象
        {
            foreach (Block b1 in blockList)
            {
                b1.Display(g);
            }
        }
        public void UnDisplay(Graphics g)          //消除蛇方法
        {
            foreach (Block b1 in blockList)
            {
                b1.UnDisplay(g);
            }
        }
        public void Reset(Point dian, int count)    //重新开始游戏
        {                                           //与构造函数相似
            Block bb;
            Point p = new Point(dian.X + 15, dian.Y + 15);
            blockList = new ArrayList(count);
            for (int i = 0; i < count; i++)
            {
                p.X = p.X + 15;
                bb = new Block();
                bb.Number = i + 1;
                bb.Origin = p;
                //如果是蛇头就把顶点赋给headPoint
                if (i == count - 1)
                {
                    headPoint = bb.Origin;
                    bb.Ishead = true;
                }
                blockList.Add(bb);
            }
            headNumber = count;
            direction = 1;            //向右方向
        }
    }
}
