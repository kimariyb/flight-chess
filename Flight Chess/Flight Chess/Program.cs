using System;

namespace Flight_Chess
{
    internal class Program
    {
        static int[] Maps = new int[100];

        public static void Main(string[] args)
        {
            GameShow();
            InitailMap();
            Console.ReadKey();
        }


        /// <summary>
        /// 画游戏头
        /// </summary>
        static void GameShow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("========= Welcome to play ==========");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("====================================");
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
                Maps[luckyTurn[i]] = 1;
            }
            // 地雷
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
            for (int i = 0; i < landMine.Length; i++)
            {
                // 将 Maps 中符合 landMine 赋值为 2
                Maps[landMine[i]] = 2;
            }
            // 暂停
            int[] pause = { 9, 27, 60, 93 };
            for (int i = 0; i < pause.Length; i++)
            {
                // 将 Maps 中符合 pause 赋值为 3
                Maps[pause[i]] = 3;
            }
            // 时空隧道
            int[] timeTurn = { 20, 25, 45, 63, 72, 88, 90 };
            for (int i = 0; i < timeTurn.Length; i++)
            {
                // 将 Maps 中符合 timeTurn 赋值为 4
                Maps[timeTurn[i]] = 4;
            }
        }
    }
}