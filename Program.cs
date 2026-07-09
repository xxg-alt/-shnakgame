using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 学习shnakgame
{
    class SnakeGame 
    { 
        static int width = 40;//宽
        static int height = 40;//高
        static List<(int x, int y)> Snake = new List<(int x, int y)>();//蛇
        static void Main() 
        {
            Console.CursorVisible = false;//隐藏光标
            Console.Title = "贪吃蛇游戏";//设置标题
            Console.SetWindowSize(width + 1, height + 1);//设置窗口大小
            Console.SetBufferSize(width + 1, height + 1);//设置缓冲区大小
            InitSnake();//初始化蛇
            DrawBorder();//绘制边框
        }
        static void DrawBorder()
        {
            for (int x = 0; x < width; x++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Setcell(x, 0, '#');
                Setcell(x, height - 1, '#');
            }
            for (int y = 0; y < height; y++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Setcell(0, y, '#');
                Setcell(width - 1, y, '#');
            }
        }
        static void InitSnake()
        {
            Snake.Clear();
            int startX = width / 4; int startY = height / 4;
            Snake.Add((startX, startY));
            Setcell(Snake[0].x, Snake[0].y, 'O');
            Snake.Add((startX - 1, startY));
            Setcell(Snake[1].x, Snake[1].y, '0');
        }
        static void Setcell(int x, int y, char c)//设置单元格，简化代码
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
    }
}
