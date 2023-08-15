using System;

namespace Flight_Chess
{
    internal class Program
    {
        // 声明静态字段来模拟全局变量
        static int[] _map = new int[100];

        // 声明一个静态数组存储玩家 A 和玩家 B 的坐标
        static int[] _playerPos = new int[2];

        public static void Main(string[] args)
        {
            GameShow();
            InitailMap();
            DrawMap();
            Console.ReadKey();
        }


        /// <summary>
        /// 画游戏头
        /// </summary>
        static void GameShow()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t============================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t============================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t============================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t============= Welcome to play ==============");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t============================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t============================================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t============================================");
        }

        /// <summary>
        /// 初始化地图
        /// </summary>
        static void InitailMap()
        {
            // 幸运轮盘
            int[] luckyTurn = { 6, 23, 40, 55, 69, 83 };
            for (int i = 0; i < luckyTurn.Length; i++)
            {
                // 将 Maps 中符合 LuckyTurn 赋值为 1
                _map[luckyTurn[i]] = 1;
            }

            // 地雷
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
            for (int i = 0; i < landMine.Length; i++)
            {
                // 将 Maps 中符合 landMine 赋值为 2
                _map[landMine[i]] = 2;
            }

            // 暂停
            int[] pause = { 9, 27, 60, 93 };
            for (int i = 0; i < pause.Length; i++)
            {
                // 将 Maps 中符合 pause 赋值为 3
                _map[pause[i]] = 3;
            }

            // 时空隧道
            int[] timeTurn = { 20, 25, 45, 63, 72, 88, 90 };
            for (int i = 0; i < timeTurn.Length; i++)
            {
                // 将 Maps 中符合 timeTurn 赋值为 4
                _map[timeTurn[i]] = 4;
            }
        }

        /// <summary>
        /// 画地图
        /// </summary>
        static void DrawMap()
        {
            // 第一行
            for (int i = 0; i < 30; i++)
            {
                // 如果玩家 A 和玩家 B 的坐标相同，画一个符号 <>
                if (_playerPos[0] == _playerPos[1] && _playerPos[1] == i)
                {
                    Console.Write("<>");
                }
                else if (_playerPos[0] == i)
                {
                    // 全角　Ａ　Ｂ
                    Console.Write("Ａ");
                }
                else if (_playerPos[1] == i)
                {
                    // 全角　Ａ　Ｂ
                    Console.Write("Ｂ");
                }
                else
                {
                    switch (_map[i])
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("□");
                            break;
                        case 1: 
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("◎");
                            break;
                        case 2: 
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("☆");
                            break;
                        case 3: 
                            Console.ForegroundColor = ConsoleColor.Blue;

                            Console.Write("▲");
                            break;
                        case 4: 
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("※");
                            break;
                    }
                }

            }
        }
    }
}