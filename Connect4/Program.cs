namespace Connect4
{
    public struct playerInfo
    {
        public String playerName;
        public char playerID;
    };
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ██████╗ ██████╗ ███╗   ██╗███╗   ██╗███████╗ ██████╗████████╗    ███████╗ ██████╗ ██╗   ██╗██████╗ ");
            Console.WriteLine("██╔════╝██╔═══██╗████╗  ██║████╗  ██║██╔════╝██╔════╝╚══██╔══╝    ██╔════╝██╔═══██╗██║   ██║██╔══██╗");
            Console.WriteLine("██║     ██║   ██║██╔██╗ ██║██╔██╗ ██║█████╗  ██║        ██║       █████╗  ██║   ██║██║   ██║██████╔╝");
            Console.WriteLine("██║     ██║   ██║██║╚██╗██║██║╚██╗██║██╔══╝  ██║        ██║       ██╔══╝  ██║   ██║██║   ██║██╔══██╗");
            Console.WriteLine("╚██████╗╚██████╔╝██║ ╚████║██║ ╚████║███████╗╚██████╗   ██║       ██║     ╚██████╔╝╚██████╔╝██║  ██║");
            Console.WriteLine(" ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═══╝╚══════╝ ╚═════╝   ╚═╝       ╚═╝      ╚═════╝  ╚═════╝ ╚═╝  ╚═╝");
            Console.WriteLine("Nyomj ENTER-t a továbblépéshez");
            Console.ReadLine();

            playerInfo playerOne = new playerInfo();
            playerInfo playerTwo = new playerInfo();
            char[,] board = new char[9, 10];
            int dropChoice, aiDropChoice, win, full, again;

            Console.WriteLine("Add meg a neved: ");
            playerOne.playerName = Console.ReadLine();
            playerOne.playerID = 'X';
            playerTwo.playerName = "Robot";
            playerTwo.playerID = 'O';
            Console.WriteLine("Válassz nehézségi szintet: \tKönnyű(1)\tKözepes(2)\tNehéz(3)");
            int nLevel = int.Parse(Console.ReadLine());

            full = 0;
            win = 0;
            again = 0;
            int index = 0;
            int x = 6, y = 0;

            Console.Clear();
            DisplayBoard(board);
            do
            {
                if (index == 0)
                {
                    dropChoice = PlayerDrop(board, playerOne);
                    CheckAlso(board, playerOne, dropChoice);
                    DisplayBoard(board);
                    win = CheckForWin(board, playerOne);
                    if (win == 1)
                    {
                        PlayerWin(playerOne);
                        again = restart(board);
                        if (again == 2)
                        {
                            break;
                        }
                    }

                    y = aiDropChoice = firstAiTurn(board);
                    CheckAlso(board, playerTwo, aiDropChoice);
                    DisplayBoard(board);
                    win = CheckForWin(board, playerTwo);
                    if (win == 1)
                    {
                        PlayerWin(playerTwo);
                        again = restart(board);
                        if (again == 2)
                        {
                            break;
                        }
                    }

                    index++;
                }
                else if (index == 1)
                {
                    dropChoice = PlayerDrop(board, playerOne);
                    CheckAlso(board, playerOne, dropChoice);
                    DisplayBoard(board);
                    win = CheckForWin(board, playerOne);
                    if (win == 1)
                    {
                        PlayerWin(playerOne);
                        again = restart(board);
                        if (again == 2)
                        {
                            break;
                        }
                    }

                    aiDropChoice = secondAiTurn(board, x, y);
                    CheckAlso(board, playerTwo, aiDropChoice);
                    DisplayBoard(board);
                    win = CheckForWin(board, playerTwo);
                    if (win == 1)
                    {
                        PlayerWin(playerTwo);
                        again = restart(board);
                        if (again == 2)
                        {
                            break;
                        }
                    }

                    index++;
                }

                full = FullBoard(board);
                if (full == 7)
                {
                    Console.WriteLine("A tábla tele van, döntetlen!");
                    again = restart(board);
                }

            } while (again != 2);
        }

        static void DisplayBoard(char[,] board)
        {
            Console.WriteLine(" ██████╗ ██████╗ ███╗   ██╗███╗   ██╗███████╗ ██████╗████████╗    ███████╗ ██████╗ ██╗   ██╗██████╗ ");
            Console.WriteLine("██╔════╝██╔═══██╗████╗  ██║████╗  ██║██╔════╝██╔════╝╚══██╔══╝    ██╔════╝██╔═══██╗██║   ██║██╔══██╗");
            Console.WriteLine("██║     ██║   ██║██╔██╗ ██║██╔██╗ ██║█████╗  ██║        ██║       █████╗  ██║   ██║██║   ██║██████╔╝");
            Console.WriteLine("██║     ██║   ██║██║╚██╗██║██║╚██╗██║██╔══╝  ██║        ██║       ██╔══╝  ██║   ██║██║   ██║██╔══██╗");
            Console.WriteLine("╚██████╗╚██████╔╝██║ ╚████║██║ ╚████║███████╗╚██████╗   ██║       ██║     ╚██████╔╝╚██████╔╝██║  ██║");
            Console.WriteLine(" ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═══╝╚══════╝ ╚═════╝   ╚═╝       ╚═╝      ╚═════╝  ╚═════╝ ╚═╝  ╚═╝\n");

            int rows = 6, columns = 7;

            for (int i = 1; i <= rows; i++)
            {
                for (int ix = 1; ix <= columns; ix++)
                {
                    if (board[i, ix] != 'X' && board[i, ix] != 'O')
                        board[i, ix] = '*';

                    Console.Write(board[i, ix]);
                }
                Console.Write('\n');
            }
        }

        static int PlayerDrop(char[,] board, playerInfo activePlayer)
        {
            int dropChoice;

            Console.WriteLine("\n Te jössz! \n");
            do
            {
                Console.WriteLine("Adj meg egy számot 1 és 7 között: \n");
                dropChoice = Convert.ToInt32(Console.ReadLine());
            } while (dropChoice < 1 || dropChoice > 7);

            while (board[1, dropChoice] == 'X' || board[1, dropChoice] == 'O')
            {
                Console.WriteLine("Az a sor már tele van, adj meg egy másikat: ");
                dropChoice = Convert.ToInt32(Console.ReadLine());
            }

            return dropChoice;
        }

        static void CheckAlso(char[,] board, playerInfo activePlayer, int dropChoice)
        {
            int length, kor;
            length = 6;
            kor = 0;

            do
            {
                if (board[length, dropChoice] != 'X' && board[length, dropChoice] != 'O')
                {
                    board[length, dropChoice] = activePlayer.playerID;
                    kor = 1;
                }
                else
                    --length;
            } while (kor != 1);

            Console.Clear();

        }

        static int CheckForWin(char[,] board, playerInfo activePlayer)
        {
            char XO;
            int win;

            XO = activePlayer.playerID;
            win = 0;

            for (int i = 8; i >= 1; --i)
            {

                for (int ix = 9; ix >= 1; --ix)
                {

                    if (board[i, ix] == XO &&
                        board[i - 1, ix - 1] == XO &&
                        board[i - 2, ix - 2] == XO &&
                        board[i - 3, ix - 3] == XO)
                    {
                        win = 1;
                    }


                    if (board[i, ix] == XO &&
                        board[i, ix - 1] == XO &&
                        board[i, ix - 2] == XO &&
                        board[i, ix - 3] == XO)
                    {
                        win = 1;
                    }

                    if (board[i, ix] == XO &&
                        board[i - 1, ix] == XO &&
                        board[i - 2, ix] == XO &&
                        board[i - 3, ix] == XO)
                    {
                        win = 1;
                    }

                    if (board[i, ix] == XO &&
                        board[i - 1, ix + 1] == XO &&
                        board[i - 2, ix + 2] == XO &&
                        board[i - 3, ix + 3] == XO)
                    {
                        win = 1;
                    }

                    if (board[i, ix] == XO &&
                         board[i, ix + 1] == XO &&
                         board[i, ix + 2] == XO &&
                         board[i, ix + 3] == XO)
                    {
                        win = 1;
                    }
                }

            }

            return win;
        }

        static int FullBoard(char[,] board)
        {
            int full;
            full = 0;
            for (int i = 1; i <= 7; ++i)
            {
                if (board[1, i] != '*')
                    ++full;
            }

            return full;
        }

        static void PlayerWin(playerInfo activePlayer)
        {
            if (activePlayer.playerID == 'X')
                Console.WriteLine("\n" + activePlayer.playerName + ", te győztél! Gratulálok! :D");
            else
            {
                Console.WriteLine("\nSajnálom, vesztettél. :(");
            }
        }

        static int restart(char[,] board)
        {
            int restart;

            Console.WriteLine("\nSzeretnéd újrakezdeni? Igen(1) Nem(2)");
            restart = Convert.ToInt32(Console.ReadLine());
            if (restart == 1)
            {
                Console.Clear();
                for (int i = 1; i <= 6; i++)
                {
                    for (int ix = 1; ix <= 7; ix++)
                    {
                        board[i, ix] = '*';
                    }
                }
                DisplayBoard(board);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(" ██████╗ ██████╗ ███╗   ██╗███╗   ██╗███████╗ ██████╗████████╗    ███████╗ ██████╗ ██╗   ██╗██████╗ ");
                Console.WriteLine("██╔════╝██╔═══██╗████╗  ██║████╗  ██║██╔════╝██╔════╝╚══██╔══╝    ██╔════╝██╔═══██╗██║   ██║██╔══██╗");
                Console.WriteLine("██║     ██║   ██║██╔██╗ ██║██╔██╗ ██║█████╗  ██║        ██║       █████╗  ██║   ██║██║   ██║██████╔╝");
                Console.WriteLine("██║     ██║   ██║██║╚██╗██║██║╚██╗██║██╔══╝  ██║        ██║       ██╔══╝  ██║   ██║██║   ██║██╔══██╗");
                Console.WriteLine("╚██████╗╚██████╔╝██║ ╚████║██║ ╚████║███████╗╚██████╗   ██║       ██║     ╚██████╔╝╚██████╔╝██║  ██║");
                Console.WriteLine(" ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═══╝╚══════╝ ╚═════╝   ╚═╝       ╚═╝      ╚═════╝  ╚═════╝ ╚═╝  ╚═╝\n");
                Console.WriteLine("Viszlát!");
            }

            return restart;
        }

        //int x = 5, y = 0;

        static int firstAiTurn(char[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                if (board[6, i] == 'X')
                {
                    if (i < 4)
                    {
                        return i + 1;
                    }
                    else
                    {
                        return i - 1;
                    }
                }
            }
            return 0;
        }

        static int secondAiTurn(char[,] board, int x, int y)
        {
            Random r = new Random();
            if (checkVertical(x, y, board))
            {
                return y;
            }
            else
            {
                return checkHorizontal(x, y, board);
            }
        }

        //public void CheckAiTurn(char[,] board)
        //{
        //    Random r = new Random();
        //    if (checkOponentVertical(oponentX, oponentY, board))
        //    {
        //        if (oponentX + 1 < board.GetLength(0) && board[oponentX + 1, oponentY] == '*')
        //        {
        //            board[oponentX + 1, oponentY] = 'O';
        //            x = oponentX + 1;
        //            return;
        //        }
        //    }
        //    if (checkOponentHorizontal(oponentX, oponentY, board))
        //    {
        //        for (int i = 0; i < 7; i++)
        //        {
        //            if (board[oponentX, i] == 'X' && i + 2 < board.GetLength(1) && board[oponentX, i + 1] == 'X' && board[oponentX, i + 2] == 'X')
        //            {
        //                if ((i + 3 < board.GetLength(1)) && (board[oponentX, i + 3] == '*' && (board[oponentX - 1, i + 3] == 'O' || board[oponentX - 1, i + 3] == 'X')))
        //                {
        //                    board[oponentX, i + 3] = 'O';
        //                    y = i + 3;
        //                    return;
        //                }
        //                else if ((i - 1 >= 0) && (board[oponentX, i - 1] == '*' && (board[oponentX - 1, i - 1] == 'O' || board[oponentX - 1, i - 1] == 'X')))
        //                {
        //                    board[oponentX, i - 1] = 'O';
        //                    y = i - 1;
        //                    return;
        //                }
        //            }
        //        }
        //    }
        //    averageAiTurn(board);
        //}

        //public void averageAiTurn(char[,] board)
        //{

        //}

        //public bool checkOponentHorizontalDouble(int x, int y)
        //{
        //    try
        //    {
        //        if (tabla[x, y - 2] == "*" && tabla[x, y + 2] == "*" && tabla[x, y + 1] == "X" || tabla[x, y - 1] == "X")
        //            return true;
        //        return false;
        //    }
        //    catch { return false; }
        //}

        //public bool checkOponentHorizontal(int x, int y, char[,] board)
        //{
        //    if (x - 1 >= 0 && x + 1 < board.GetLength(0) && y >= 0 && y < board.GetLength(1))
        //    {
        //        if ((board[x - 1, y] == 'X' && board[x + 1, y] == 'X') ||
        //            (x - 2 >= 0 && board[x - 2, y] == 'X' && board[x - 1, y] == 'X') ||
        //            (x + 2 < board.GetLength(0) && board[x + 2, y] == 'X' && board[x + 1, y] == 'X'))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public bool checkOponentVertical(int x, int y, char[,] board)
        //{
        //    if (x >= 0 && x < board.GetLength(0) && y - 2 >= 0 && y < board.GetLength(1))
        //    {
        //        if (board[x, y - 1] == 'X' && board[x, y - 2] == 'X')
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        static bool checkVertical(int x, int y, char[,] board)
        {
            if (board[x - 1, y] == '*')
            {
                return true;
            }
            return false;
        }

        static int checkHorizontal(int x, int y, char[,] board)
        {
            if (y == 4 && board[x, y - 1] == 'X')
            {
                return 5;
            }
            else if (y - 3 > 0)
            {
                return y - 1;
            }
            else
            {
                return y + 1;
            }
        }
    }
}
