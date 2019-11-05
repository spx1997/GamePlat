﻿
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
    public class Boards
    {
        public int[,] board = new int[15, 15];
        private Graphics mg;
        private Stones stone;
        private PC pc = new PC(false);
        private bool flag = true;
        private bool first = false;
        private bool winflag = false;
        int score=0;

        public MyStack st = new MyStack();

        public Boards(Graphics g)
        {
            mg = g;
            stone = new Stones(mg);
            st.CreatStack();
        }


        public void Start(bool mflag)
        {
            ClearBoards();
            winflag = false;
            if (!mflag)
            {
                flag = true;
                PCPut();
            }
            else
            {
                flag = true;
            }
            DrawBoard();
        }

        public void ClearBoards()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    board[i, j] = -1;
                }
            }
        }

        public void DrawBoard()
        {
            Bitmap bt = new Bitmap(Image.FromFile("board.png"));
            //Assembly myAssembly = Assembly.GetExecutingAssembly();
            //Stream myStream = myAssembly.GetManifestResourceStream("FiveStone.board.png");
            //Bitmap bt = new Bitmap(myStream);
            //myStream.Close();
            mg.DrawImage(bt, 20, 20, bt.Width, bt.Height);

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (board[i, j] == 0)
                    {
                        stone.DrawStone(i, j, true);
                    }
                    if (board[i, j] == 1)
                    {
                        stone.DrawStone(i, j, false);
                    }
                }
            }
        }

        public void PutDown(int x, int y)
        {
            if (!winflag)
            {
                if (board[x, y] == -1)
                {
                    stone.DrawStone(x, y, flag);

                    if (flag)
                    {
                        board[x, y] = 0;
                    }
                    else
                    {
                        board[x, y] = 1;
                    }

                    st.Insert("X：" + x + " Y：" + y);

                    if (Rules.Winer(x, y, board) > 0)
                    {
                        switch (Rules.Winer(x, y, board))
                        {
                            case 1:
                                if (flag)
                                {
                                    first = !first;
                                    winflag = true;
                                    System.Windows.Forms.MessageBox.Show("黑子胜利");
                                    score++;

                                }
                                else
                                {
                                    first = !first;
                                    winflag = true;
                                    System.Windows.Forms.MessageBox.Show("白子胜利");
                                    score--;
                                }
                                break;
                            case 2:
                                first = !first;
                                winflag = true;
                                System.Windows.Forms.MessageBox.Show("平局");
                                break;
                        }
                    }

                    flag = !flag;
                }
            }
        }

        public void PersonPut(int x, int y)
        {
            if (x < 680 && y < 680)
            {
                int m = (int)(x / 42);
                int n = (int)(y / 42);
                if (m < 0)
                { m = 0; }
                if (n < 0)
                { n = 0; }
                if (m > 14)
                { m = 14; }
                if (n > 14)
                { n = 14; }
                if (!Rules.Exit(m, n, board))
                {
                    PutDown(m, n);
                    PCPut();
                }
            }
        }

        public void PCPut()
        {
            int m = 0, n = 0;
            int err = 0;
            do
            {
                pc.Down(board);
                m = pc.X;
                n = pc.Y;
                err++;
                if (err > 100)
                {
                    System.Windows.Forms.MessageBox.Show("发生了一些错误，棋局将重新开始");
                    Start(true);
                }
            }
            while (Rules.Exit(m, n, board));
            PutDown(m, n);
        }
    }
}
