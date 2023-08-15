using System;

namespace Flight_Chess
{
    internal class Program
    {
        // 声明静态字段来模拟全局变量
        static int[] _map = new int[100];

        // 声明一个静态数组存储玩家 A 和玩家 B 的坐标
        static int[] _playerPos = new int[2];

        // 声明一个静态数组，存储两个玩家的姓名
        static string[] _playerNames = new string[2];
        
        // 声明一个静态数组，存储两个玩家的标记，默认为 Flase
        static bool[] _flags = new bool[2];

        public static void Main(string[] args)
        {
            // 显示游戏头
            GameShow();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            // 输入第一个玩家的姓名
            Console.WriteLine("请输入玩家 A 的姓名：");
            _playerNames[0] = Console.ReadLine();
            // 判断不能为空
            while (_playerNames[0] == "")
            {
                Console.WriteLine("玩家 A 的姓名不能为空，请重新输入！");
                _playerNames[0] = Console.ReadLine();
            }

            // 输入第二个玩家的姓名
            Console.WriteLine("请输入玩家 B 的姓名：");
            _playerNames[1] = Console.ReadLine();
            // 判断不能为空和不能和玩家 A 重复
            while (_playerNames[1] == "" || _playerNames[1] == _playerNames[0])
            {
                if (_playerNames[1] == "")
                {
                    Console.WriteLine("玩家 B 的姓名不能为空，请重新输入！");
                    _playerNames[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家 B 的姓名不能和玩家 A 的姓名一致，请重新输入！");
                    _playerNames[1] = Console.ReadLine();
                }
            }

            // 输入姓名之后，清屏
            Console.Clear();
            // 重新调用游戏头
            GameShow();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("初始化地图成功！");
            Console.WriteLine("提示: 玩家 {0} 的士兵用 A 表示", _playerNames[0]);
            Console.WriteLine("提示: 玩家 {0} 的士兵用 B 表示", _playerNames[1]);

            // 初始化地图
            InitailMap();
            // 绘制地图
            Console.WriteLine("");
            DrawMap();
            Console.WriteLine("");

            // 玩家 A 和玩家 B 没有一个人在终点，可以一直玩
            while (_playerPos[0] < 99 || _playerPos[1] < 99)
            {
                if (_flags[0] == false)
                {
                    PlayGame(0);
                }
                else
                {
                    _flags[0] = false;
                }

                if (_playerPos[0] >= 99)
                {
                    Console.WriteLine("玩家 {0} 无耻的胜利了！", _playerNames[0]);
                    break;
                }

                if (_flags[1] == false)
                {
                    PlayGame(1);
                }
                else
                {
                    _flags[1] = false;
                }
                
                if (_playerPos[1] >= 99)
                {
                    Console.WriteLine("玩家 {0} 无耻的胜利了！", _playerNames[1]);
                    break;
                }
            }
            
            // 胜利标志
            Console.Clear();
            Win();
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
            // 图例
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("图例：幸运轮盘 ◎, 地雷 ☆, 暂停 ▲, 时空隧道 ※");
            // 第一行
            for (int i = 0; i < 30; i++)
            {
                Console.Write(DrawStringMap(i));
            }

            // 空行
            Console.WriteLine();
            // 第一列
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j <= 28; j++)
                {
                    Console.Write("  ");
                }

                Console.Write(DrawStringMap(i));

                // 换行
                Console.WriteLine();
            }

            // 第二行
            for (int i = 64; i >= 35; i--)
            {
                Console.Write(DrawStringMap(i));
            }

            // 空行
            Console.WriteLine();
            // 第二列
            for (int i = 65; i <= 69; i++)
            {
                Console.WriteLine(DrawStringMap(i));
            }

            // 第三行
            for (int i = 70; i <= 99; i++)
            {
                Console.Write(DrawStringMap(i));
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 封装一个方法用来输出字符
        /// </summary>
        static string DrawStringMap(int i)
        {
            string str = "";
            // 如果玩家 A 和玩家 B 的坐标相同，画一个符号 <>
            if (_playerPos[0] == _playerPos[1] && _playerPos[1] == i)
            {
                str = "<>";
            }
            else if (_playerPos[0] == i)
            {
                // 全角　Ａ　Ｂ
                str = "Ａ";
            }
            else if (_playerPos[1] == i)
            {
                // 全角　Ａ　Ｂ
                str = "Ｂ";
            }
            else
            {
                switch (_map[i])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        str = "□";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = "◎";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        str = "☆";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        str = "▲";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        str = "※";
                        break;
                }
            }

            return str;
        }

        /// <summary>
        /// 玩游戏
        /// </summary>
        static void PlayGame(int playerNumber)
        {
            // 生成 1~6 随机数
            Random r = new Random();
            int rNumber = r.Next(1, 7);
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("玩家 {0} 按任意键开始掷骰子", _playerNames[playerNumber]);
            Console.ReadKey(true);
            Console.WriteLine("玩家 {0} 掷骰子掷出了 {1}", _playerNames[playerNumber], rNumber);
            _playerPos[playerNumber] += rNumber;
            ChangePos();
            Console.ReadKey(true);
            Console.WriteLine("玩家 {0} 行动完毕", _playerNames[playerNumber]);
            Console.ReadKey(true);
            // 玩家有可能踩到了玩家 B、方块、幸运轮盘 。。。
            if (_playerPos[playerNumber] == _playerPos[1 - playerNumber])
            {
                Console.WriteLine("玩家 {0} 踩到了玩家 {1}，玩家 {2} 后退 6 格",
                    _playerNames[playerNumber], _playerNames[1 - playerNumber], _playerNames[1 - playerNumber]);
                _playerPos[1 - playerNumber] -= 6;
                ChangePos();
                Console.ReadKey(true);
            }
            else // 踩到了关卡
            {
                switch (_map[_playerPos[playerNumber]])
                {
                    case 0:
                        Console.WriteLine("玩家 {0} 踩到了方块，安全", _playerNames[playerNumber]);
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("玩家 {0} 踩到了幸运轮盘，请选择 1. 交换位置 2. 轰炸对方退后 6 格", _playerNames[playerNumber]);
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input == "1")
                            {
                                Console.WriteLine("玩家 {0} 选择和玩家 {1} 交换位置", _playerNames[playerNumber],
                                    _playerNames[1 - playerNumber]);
                                Console.ReadKey(true);
                                // 通过元组交换
                                (_playerPos[playerNumber], _playerPos[1 - playerNumber]) = (
                                    _playerPos[1 - playerNumber], _playerPos[playerNumber]);
                                ChangePos();
                                Console.WriteLine("交换完成！按任意键继续游戏！");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("玩家 {0} 选择轰炸玩家 {1}，玩家 {2} 退后 6 格", _playerNames[playerNumber],
                                    _playerNames[1 - playerNumber], _playerNames[1 - playerNumber]);
                                Console.ReadKey(true);
                                _playerPos[1 - playerNumber] -= 6;
                                ChangePos();
                                Console.WriteLine("玩家 {0} 后退 6 格", _playerNames[1 - playerNumber]);
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("重新输入，仅能输入 1. 交换位置 2. 轰炸对方退后 6 格");
                                input = Console.ReadLine();
                            }
                        }

                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.WriteLine("玩家 {0} 踩到了地雷，退后 6 格", _playerNames[playerNumber]);
                        _playerPos[playerNumber] -= 6;
                        ChangePos();
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Console.WriteLine("玩家 {0} 踩到了暂停，暂停一回合", _playerNames[playerNumber]);
                        _flags[playerNumber] = true;
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.WriteLine("玩家 {0} 踩到了时空隧道，前进 10 格", _playerNames[playerNumber]);
                        _playerPos[playerNumber] += 10;
                        ChangePos();
                        Console.ReadKey(true);
                        break;
                }
            }

            // 当位置改变之后，清屏
            ChangePos();
            Console.Clear();
            // 重新绘图
            DrawMap();
        }
        
        /// <summary>
        /// 当坐标发生改变时，限制坐标
        /// </summary>
        static void ChangePos()
        {
            if (_playerPos[0] < 0)
            {
                _playerPos[0] = 0;
            }
            if (_playerPos[0] >= 99)
            {
                _playerPos[0] = 99;
            }
            if (_playerPos[1] < 0)
            {
                _playerPos[1] = 0;
            }
            if (_playerPos[1] >= 99)
            {
                _playerPos[1] = 99;
            }
        }

        /// <summary>
        /// 胜利
        /// </summary>
        static void Win()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  V       V  III  CCCCC  TTTTT  OOO   RRRRR   Y     Y");
            Console.WriteLine("   V     V    I  C         T   O   O  R    R   Y   Y ");
            Console.WriteLine("    V   V     I  C         T   O   O  RRRRR     Y Y  ");
            Console.WriteLine("     V V      I  C         T   O   O  R   R      Y   ");
            Console.WriteLine("      V     III  CCCCC     T    OOO   R    R     Y   ");
        }
    }
}