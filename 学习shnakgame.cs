using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 学习shnakgame
{
    class SnakeGame 
    {
        
        static int width = 40;//宽
        static int height = 30;//高
        static int score = 0;//分数
        static List<(int x, int y)> Snake = new List<(int x, int y)>();//蛇
        static int DirX = 1 , DirY = 0;//蛇的移动方向
        static int foodX , foodY ;//食物坐标
        static bool GameOver = false;//游戏结束标志
        static Random random = new Random();//随机数生成器
        static int Speed = 150;//蛇的移动速度，单位毫秒
        static void Main() 
        {
            Console.CursorVisible = false;//隐藏光标
            Console.Title = "贪吃蛇游戏";//设置标题
            Console.SetWindowSize(width + 13, height + 1);//设置窗口大小
            Console.SetBufferSize(width + 13, height + 1);//设置缓冲区大小
            Console.Clear(); // 清除之前运行留下的旧边框、蛇和食物
            InitSnake();//初始化蛇
            DrawBorder();//绘制边框
            var timer = new Stopwatch();//创建计时器
            timer.Start();//启动计时器

            while (!GameOver)
            {
                HandleInput();
                if (timer.ElapsedMilliseconds >= Speed)//判断是否到达移动时间
                {
                    Update();//更新蛇的位置
                    timer.Restart();//重置计时器
                }

                Thread.Sleep(10);//降低CPU占用率
            }
        }
        static void Update()
        {
            int newX = Snake[0].x + DirX;
            int newY = Snake[0].y + DirY;
            if (newX <= 0 || newX >= width - 1 || newY <= 0 || newY >= height - 1)
            {
                GameOver = true;
                Console.SetCursorPosition(width / 2 - 5, height / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("游戏结束");
                return;
            }
            if (Snake.Exists(s => s.x == newX && s.y == newY))
            {
                GameOver = true;
                return;
            }
            Snake.Insert(0, (newX, newY));
            Setcell(newX, newY, 'O');
            if(newX == foodX && newY == foodY)
            {
                score += 10;
               Showscore();
               GenerateFood();
                if(Speed > 80)
                {
                    Speed -= 5;
                }
            }
            else
            {
                var tail = Snake[Snake.Count - 1];
                Setcell(tail.x, tail.y, ' ');
                Snake.RemoveAt(Snake.Count - 1);
            }
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
            Showscore();
        }
        static void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (DirY != 1) { DirX = 0; DirY = -1; }//防止蛇掉头
                        break;
                    case ConsoleKey.DownArrow:
                        if (DirY != -1) { DirX = 0; DirY = 1; }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (DirX != 1) { DirX = -1; DirY = 0; }
                        break;
                    case ConsoleKey.RightArrow:
                        if (DirX != -1) { DirX = 1; DirY = 0; }
                        break;
                }
            }
        }
        static void InitSnake()
        {
            Snake.Clear();
            int startX = width / 4; int startY = height / 4;
            //Console.ForegroundColor = ConsoleColor.Green;
            Snake.Add((startX, startY));
            Setcell(Snake[0].x, Snake[0].y, 'O');
            Snake.Add((startX - 1, startY));
            Setcell(Snake[1].x, Snake[1].y, 'O');
            Snake.Add((startX - 2, startY));
            Setcell(Snake[2].x, Snake[2].y, 'O');
            DirX = 1;
            DirY = 0;
            Speed = 150;
            score = 0;
            GenerateFood();
        }
        static void Setcell(int x, int y, char c)//设置单元格，简化代码
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
        static void GenerateFood()
        {
            do
            {
                foodX = random.Next(1,width - 1);
                foodY = random.Next(1,height - 1);
            }
            while (Snake.Exists(s => s.x == foodX && s.y == foodY));
            //Console.ForegroundColor = ConsoleColor.Red;
            Setcell(foodX, foodY, '*');
        }
        static void Showscore()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console .SetCursorPosition(width +3, 1);
            Console.Write("分数: {0}", score);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(width + 3, 2);
            Console.Write("长度: {0}", Snake.Count);

        }
    }
}
