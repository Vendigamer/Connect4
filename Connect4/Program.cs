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
                    //Console.WriteLine(board[6, 4]);
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

                    y = aiDropChoice;
                    index++;
                }
                else
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

                    aiDropChoice = CheckAiTurn(board, dropChoice, nLevel, y);
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

                    y = aiDropChoice;
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
                Console.WriteLine("\n" + activePlayer.playerName + "Te győztél! Gratulálok! :D");
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
        //AI
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
            if (checkVertical(x, y, board))
            {
                return y;
            }
            else
            {
                return checkHorizontal(x, y, board);
            }
        }

        static int CheckAiTurn(char[,] board, int oponentY, int choice, int aiY)
        {
            int oponentX = checkX(oponentY, board);
            Random r = new Random();
            int chance = r.Next(1, 11);
            if (choice == 1)
            {
                if ((checkOponentHorizontal(oponentX, oponentY, board) || checkOponentVertical(oponentX, oponentY, board) || checkOponentHorizontalDouble(oponentX, oponentY, board)) && chance <= 3)
                {
                    if (checkOponentHorizontal(oponentX, oponentY, board))
                    {
                        if (oponentY - 1 >= 0 && board[oponentX, oponentY - 1] == '*')
                        {
                            return oponentY - 1;
                        }
                        else if (oponentY + 1 <= 7 && board[oponentX, oponentY + 1] == '*')
                        {
                            return oponentY + 1;
                        }
                        else
                        {
                            return averageAiTurn(board, aiY);
                        }
                    }
                    else if (checkOponentVertical(oponentX, oponentY, board))
                    {
                        if (oponentX - 1 >= 0 && board[oponentX - 1, oponentY] == '*')
                        {
                            return oponentY;
                        }
                        else
                        {
                            return averageAiTurn(board, aiY);
                        }
                    }
                    else
                    {
                        if (oponentY - 2 >= 0 && board[oponentX, oponentY - 2] == '*')
                        {
                            return oponentY - 2;
                        }
                        else if (oponentY + 2 <= 7 && board[oponentX, oponentY + 2] == '*')
                        {
                            return oponentY + 2;
                        }
                        else
                        {
                            return averageAiTurn(board, aiY);
                        }
                    }
                }
                else
                {
                    return averageAiTurn(board, aiY);
                }
            }
            else if (choice == 2)
            {
                if ((checkOponentHorizontal(oponentX, oponentY, board) || checkOponentVertical(oponentX, oponentY, board) || checkOponentHorizontalDouble(oponentX, oponentY, board)) && chance <= 6)
                {
                    if (checkOponentHorizontal(oponentX, oponentY, board))
                    {
                        if (oponentY - 3 >= 0 && board[oponentX, oponentY - 3] == '*')
                        {
                            return oponentY - 3;
                        }
                        else if (oponentY + 3 <= 7 && board[oponentX, oponentY + 3] == '*')
                        {
                            return oponentY + 3;
                        }
                        else
                        {
                            return averageAiTurn(board, aiY);
                        }
                    }
                    else if (checkOponentVertical(oponentX, oponentY, board))
                    {
                        if (oponentX - 1 >= 0 && board[oponentX - 1, oponentY] == '*')
                        {
                            return oponentY;
                        }
                        else
                        {
                            return averageAiTurn(board, aiY);
                        }
                    }
                    else
                    {
                        if (oponentY - 2 >= 0 && board[oponentX, oponentY - 2] == '*')
                        {
                            return oponentY - 2;
                        }
                        else if (oponentY + 2 <= 7 && board[oponentX, oponentY + 2] == '*')
                        {
                            return oponentY + 2;
                        }
                        else
                        {
                            return averageAiTurn(board, aiY);
                        }
                    }
                }
                else
                {
                    return averageAiTurn(board, aiY);
                }
            }
            else
            {
                if ((checkOponentHorizontal(oponentX, oponentY, board) || checkOponentVertical(oponentX, oponentY, board) || checkOponentHorizontalDouble(oponentX, oponentY, board)) && chance <= 9)
                {
                    if (checkOponentHorizontal(oponentX, oponentY, board))
                    {
                        if (oponentY - 3 >= 0 && board[oponentX, oponentY - 3] == '*')
                        {
                            return oponentY - 3;
                        }
                        else if (oponentY + 3 <= 7 && board[oponentX, oponentY + 3] == '*')
                        {
                            return oponentY + 3;
                        }
                        else
                        {
                            return averageAiTurn(board, aiY);
                        }
                    }
                    else if (checkOponentVertical(oponentX, oponentY, board))
                    {
                        if (oponentX - 1 >= 0 && board[oponentX - 1, oponentY] == '*')
                        {
                            return oponentY;
                        }
                        else
                        {
                            return averageAiTurn(board, aiY);
                        }
                    }
                    else
                    {
                        if (oponentY - 2 >= 0 && board[oponentX, oponentY - 2] == '*')
                        {
                            return oponentY - 2;
                        }
                        else if (oponentY + 2 <= 7 && board[oponentX, oponentY + 2] == '*')
                        {
                            return oponentY + 2;
                        }
                        else
                        {
                            return averageAiTurn(board, aiY);
                        }
                    }
                }
                else
                {
                    return averageAiTurn(board, aiY);
                }
            }
        }

        static int averageAiTurn(char[,] board, int y)
        {
            Random r = new Random();
            int x = checkAiX(y, board);
            if (x + 1 <= 6 && board[x + 1, y] == 'O' && board[x - 1, y] == '*')
            {
                return y;
            }
            else if (y - 1 >= 0 && y + 1 <= 7 && board[x, y - 1] == 'O' && board[x, y + 1] == '*')
            {
                return y + 1;

            }
            else if (y - 1 >= 0 && y + 1 <= 7 && board[x, y + 1] == 'O' && board[x, y - 1] == '*')
            {
                return y - 1;
            }
            else if (y - 2 >= 0 && board[x, y - 1] == 'O' && board[x, y - 2] == '*')
            {
                return y - 2;
            }
            else if (y + 2 <= 7 && board[x, y + 1] == 'O' && board[x, y + 2] == '*')
            {
                return y + 2;
            }
            else if (y - 1 >= 0 && board[x, y - 1] == '*')
            {
                return y - 1;
            }
            else if (y + 1 <= 7 && board[x, y + 1] == '*')
            {
                return y + 1;
            }
            else if (x - 1 >= 0 && board[x - 1, y] == '*')
            {
                return y;
            }
            else
            {
                int rand = r.Next(1, 8);
                while (board[0, rand] != '*')
                {
                    rand = r.Next(1, 8);
                }
                return rand;
            }
        }

        static bool checkOponentHorizontal(int x, int y, char[,] board)
        {
            if (y - 2 >= 0 && y + 2 <= 7)
            {
                if ((board[x, y - 2] == 'X' && board[x, y - 1] == 'X') || (board[x, y + 2] == 'X' && board[x, y + 1] == 'X'))
                {
                    return true;
                }
                return false;
            }
            else if (y - 2 >= 0)
            {
                if (board[x, y - 2] == 'X' && board[x, y - 1] == 'X')
                {
                    return true;
                }
                return false;
            }
            else if (y + 2 <= 7)
            {
                if (board[x, y + 2] == 'X' && board[x, y + 1] == 'X')
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        static bool checkOponentHorizontalDouble(int x, int y, char[,] board)
        {
            if (y - 2 >= 0 || y + 2 <= 7)
            {
                if (board[x, y - 1] == 'X' && board[x, y + 1] == 'X')
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        static bool checkOponentVertical(int x, int y, char[,] board)
        {
            if (x + 2 <= 6)
            {
                if (board[x + 1, y] == 'X' && board[x + 2, y] == 'X')
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        static int checkAiX(int y, char[,] board)
        {
            for (int x = 0; x <= 6; x++)
            {
                if (board[x, y] == '*' && (board[x + 1, y] == 'X' || board[x + 1, y] == 'O'))
                {
                    if (board[x + 1, y] == 'O')
                    {
                        return x + 1;
                    }
                    else
                    {
                        return x + 2;
                    }
                }
            }
            return 0;
        }

        static int checkX(int y, char[,] board)
        {
            for (int x = 0; x <= 6; x++)
            {
                if (board[x, y] == '*' && board[x + 1, y] == 'X')
                {
                    return x + 1;
                }
            }
            return 0;
        }

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
