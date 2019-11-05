using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Tetris_file
{
    class Game
    {
        public const int BlockImageWidth = 21;//方砖中每个小方格的大小
        public const int BlockImageHeight = 21;
        public const int PlayingFieldWidth = 10;//游戏面板大小
        public const int PlayingFieldHeight = 20;
        private int[,] pile; //存储在游戏面板中的所有方砖;
        private Block currentBlock;//当前的俄罗斯方块
        private Block nextBlock;//下一个的俄罗斯方块
        public int score = 0, lines = 0;
        public bool over = false;//游戏是否结束
        public Game()//Game类构造函数
        {
            pile = new int[PlayingFieldWidth, PlayingFieldHeight];
            ClearPile();
            CreateNewBlock();//产生新的俄罗斯方块
        }
        private void ClearPile()//清空游戏面板中的所有方砖
        {
            for (int i = 0; i < PlayingFieldWidth; i++)
            {
                for (int j = 0; j < PlayingFieldHeight; j++)
                {
                    pile[i, j] = 0;
                }
            }
        }
        private void CreateNewBlock()//产生新的俄罗斯方块
        {
            if (this.nextBlock != null)
            {
                currentBlock = nextBlock;
            }
            else
            {
                currentBlock = new Block();
            }
            nextBlock = new Block();
        }
        public void DrawPile(Graphics g)
        {
            Image brickImage = Image.FromFile("image/block1.gif");//方砖的图形
            for (int i = 0; i < PlayingFieldWidth; i++)
            {
                for (int j = 0; j < PlayingFieldHeight; j++)
                {
                    if (pile[i, j] == 1)
                    {
                        Rectangle rect = new Rectangle(i * BlockImageWidth, j * BlockImageHeight, BlockImageWidth, BlockImageHeight);//(j - 1)
                        g.DrawImage(brickImage, rect);
                    }
                }
            }
        }
        public void DrawCurrentBlock(Graphics g)
        {
            if (currentBlock != null)//检查当前块是否为空
            {
                currentBlock.Draw(g);
            }
        }
        public void DrawNextBlock(Graphics drawingSurface)
        {
            if (nextBlock != null)
            {
                short currentLeft = nextBlock.Left;
                short currentTop = nextBlock.Top;
                nextBlock.Left = (short)((6 - nextBlock.Width) / 2);
                nextBlock.Top = (short)((6 - nextBlock.Height) / 2);
                nextBlock.Draw(drawingSurface);
                nextBlock.Left = currentLeft;
                nextBlock.Top = currentTop;
            }
        }
        private void MoveBlockToPile()//固定到游戏面板上
        {
            for (int i = 0; i < currentBlock.Width; i++)
            {
                for (int j = 0; j < currentBlock.Height; j++)
                {
                    int fx, fy;
                    fx = currentBlock.Left + i;
                    fy = currentBlock.Top + j;
                    if (currentBlock.shape[i, j] == 1)
                    {
                        pile[fx, fy] = 1;
                    }
                }
            }
            CheckForLines();
            if (CheckForGameOver())//检查游戏是否结束
                over = true;
        }
        public bool DownCurrentBlock()
        {
            bool hit = false;
            currentBlock.Top++;
            if ((currentBlock.Top + currentBlock.Height) > PlayingFieldHeight)
            {
                hit = true;//当前块触游戏面板底
            }
            else//检查是否接触到下一行其他已落方块
            {
                for (int i = 0; i < currentBlock.Width; i++)
                {
                    for (int j = 0; j < currentBlock.Height; j++)
                    {
                        int fx, fy;
                        fx = currentBlock.Left + i;
                        fy = currentBlock.Top + j;
                        if ((currentBlock.shape[i, j] == 1) && (pile[fx, fy] == 1))//(fy + 1)
                        {
                            hit = true;
                        }
                    }
                }
            }
            if (hit)//触到其他已落方块或游戏面板底
            {
                currentBlock.Top--;
                MoveBlockToPile();//固定到游戏面板上            　　
                CreateNewBlock(); //产生新的俄罗斯方块
            }
            return hit;
        }
        public void RotateCurrentBlock()//旋转方块
        {
            bool canRotate = true;
            short newWidth = 0;
            short newHeight = 0;
            int[,] newShape;
            newWidth = currentBlock.Height;
            newHeight = currentBlock.Width;
            newShape = new int[newWidth, newHeight];
            int x, y;
            if (((currentBlock.Left + newWidth) <= Game.PlayingFieldWidth)
                && ((currentBlock.Top + newHeight) < Game.PlayingFieldHeight))
            {
                for (int i = 0; i < currentBlock.Width; i++)
                {
                    for (int j = 0; j < currentBlock.Height; j++)
                    {
                        x = ((currentBlock.Height - 1) - j);
                        y = i;
                        newShape[x, y] = currentBlock.shape[i, j];
                        if (newShape[x, y] == 1 && pile[x + currentBlock.Left, y + currentBlock.Top] == 1)
                        {
                            canRotate = false; return;//不能旋转 }
                        }
                    }
                }
                if (canRotate)
                {
                    currentBlock.Width = newWidth;
                    currentBlock.Height = newHeight;
                    currentBlock.shape = newShape;
                }
            }
        }
        public void MoveCurrentBlockSide(bool left)//左右移动
        {
            bool canMove = true;
            if (left)//左移动
            {
                if (currentBlock.Left > 0)
                {
                    for (int i = 0; i < currentBlock.Width; i++)
                    {
                        for (int j = 0; j < currentBlock.Height; j++)
                        {
                            int fx, fy;
                            fx = currentBlock.Left + i;
                            fy = (currentBlock.Top + 1) + j;
                            if ((currentBlock.shape[i, j] == 1) && (pile[(fx - 1), fy] == 1))
                            {
                                canMove = false;
                            }
                        }
                    }
                    if (canMove)
                    {
                        currentBlock.Left--;
                    }
                }
            }
            else//右移动
            {
                if ((currentBlock.Left + currentBlock.Width) < PlayingFieldWidth)
                {
                    for (int i = 0; i < currentBlock.Width; i++)
                    {
                        for (int j = 0; j < currentBlock.Height; j++)
                        {
                            int fx, fy;
                            fx = currentBlock.Left + i;
                            fy = (currentBlock.Top + 1) + j;
                            if ((currentBlock.shape[i, j] == 1) && (pile[(fx + 1), fy] == 1))
                            {
                                canMove = false;
                            }
                        }
                    }
                    if (canMove)
                    {
                        currentBlock.Left++;
                    }
                }
            }
        }
        private int CheckForLines()//检查是否满行并消去
        {
            int numLines = 0;
            int[] completeLines = new int[PlayingFieldHeight];
            for (int j = PlayingFieldHeight - 1; j > 0; j--)//j = PlayingFieldHeight
            {
                bool fullLine = true;
                for (int i = 0; i < PlayingFieldWidth; i++)
                {
                    if (pile[i, j] == 0)
                    {
                        fullLine = false;
                        break;
                    }
                }
                if (fullLine)
                {
                    numLines++;
                    completeLines[numLines] = j;
                }
            }

            if (numLines > 0)
            {
                for (int i = 1; i <= numLines; i++)
                {
                    ClearLine((completeLines[i] + (i - 1)));
                }
                score += 5 * (numLines * (numLines + 1));
                lines += numLines;
            }
            return numLines;
        }
        private void ClearLine(int lineNumber)
        {
            for (int j = lineNumber; j > 0; j--)
            {
                for (int i = 0; i < PlayingFieldWidth; i++)
                {
                    pile[i, j] = pile[i, (j - 1)];
                }
            }
            for (int i = 0; i < PlayingFieldWidth; i++)
            {
                pile[i, 0] = 0;
            }
        }
        public bool CheckForGameOver()//检查游戏是否结束
        {
            if (currentBlock.Top == 0)
                return true;
            else
                return false;
        }
    }
}
