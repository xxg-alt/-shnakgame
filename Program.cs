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
        static List<(int x, int y)> snake = new List<(int x, int y)>() { (20, 20) };//蛇的初始位置)>
        static void Main() 
        {
            Console.CursorVisible = false;//隐藏光标
            Console.Title = "贪吃蛇游戏";//设置标题
            Console.SetWindowSize(width + 1, height + 1);//设置窗口大小
            Console.SetBufferSize(width + 1, height + 1);//设置缓冲区大小
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
        static void Setcell(int x, int y, char c)//设置单元格，简化代码
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
    }
}
