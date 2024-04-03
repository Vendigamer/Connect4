using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class AI
    {
        int x = 5, y = 0;

        public void firstAiTurn()
        {
            for (int i = 0; i < 7; i++)
            {
                if (board[5, i] == "X")
                {
                    if (i - 1 >= 0)
                    {
                        board[5, i - 1] = "O";
                        y = i - 1;
                        return;
                    }
                    else if (i + 1 < 7)
                    {
                        board[5, i + 1] = "O";
                        y = i + 1;
                        return;
                    }
                }
            }
        }

        public void secondAiTurn()
        {
            if (checkHorizontal(x, y) == 3 && checkVertical(x, y) == 3)
            {
                if (r.Next(0, 2) == 0)
                {
                    if (y - 1 >= 0 && board[x, y - 1] != "X")
                    {
                        board[x, y - 1] = "O";
                        y = y - 1;
                    }
                    else if (y + 1 < board.GetLength(1) && board[x, y + 1] != "X")
                    {
                        board[x, y + 1] = "O";
                        y = y + 1;
                    }
                }
                else
                {
                    if (x + 1 < board.GetLength(0) && board[x + 1, y] != "X")
                    {
                        board[x + 1, y] = "O";
                        x = x + 1;
                    }
                }
            }
            else if (checkVertical(x, y) == 3)
            {
                if (x + 1 < board.GetLength(0) && board[x + 1, y] != "X")
                {
                    board[x + 1, y] = "O";
                    x = x + 1;
                }
            }
            else if (checkHorizontal(x, y) == 3)
            {
                if (y - 1 >= 0 && board[x, y - 1] != "X")
                {
                    board[x, y - 1] = "O";
                    y = y - 1;
                }
                else if (y + 1 < board.GetLength(1) && board[x, y + 1] != "X")
                {
                    board[x, y + 1] = "O";
                    y = y + 1;
                }
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    if (board[5, i] == "X")
                    {
                        board[4, i] = "O";
                        x = 4;
                        y = i;
                        break;
                    }
                }
            }
        }

        public void CheckAiTurn()
        {
            Random r = new Random();
            if (checkOponentVertical(oponentX, oponentY))
            {
                if (oponentX + 1 < board.GetLength(0) && board[oponentX + 1, oponentY] == "*")
                {
                    board[oponentX + 1, oponentY] = "O";
                    x = oponentX + 1;
                    return;
                }
            }
            if (checkOponentHorizontal(oponentX, oponentY))
            {
                for (int i = 0; i < 7; i++)
                {
                    if (board[oponentX, i] == "X" && i + 2 < board.GetLength(1) && board[oponentX, i + 1] == "X" && board[oponentX, i + 2] == "X")
                    {
                        if ((i + 3 < board.GetLength(1)) && (board[oponentX, i + 3] == "*" && (board[oponentX - 1, i + 3] == "O" || board[oponentX - 1, i + 3] == "X")))
                        {
                            board[oponentX, i + 3] = "O";
                            y = i + 3;
                            return;
                        }
                        else if ((i - 1 >= 0) && (board[oponentX, i - 1] == "*" && (board[oponentX - 1, i - 1] == "O" || board[oponentX - 1, i - 1] == "X")))
                        {
                            board[oponentX, i - 1] = "O";
                            y = i - 1;
                            return;
                        }
                    }
                }
            }
            averageAiTurn();
        }

        public void averageAiTurn()
        {

        }

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

        public bool checkOponentHorizontal(int x, int y)
        {
            if (x - 1 >= 0 && x + 1 < board.GetLength(0) && y >= 0 && y < board.GetLength(1))
            {
                if ((board[x - 1, y] == "X" && board[x + 1, y] == "X") ||
                    (x - 2 >= 0 && board[x - 2, y] == "X" && board[x - 1, y] == "X") ||
                    (x + 2 < board.GetLength(0) && board[x + 2, y] == "X" && board[x + 1, y] == "X"))
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkOponentVertical(int x, int y)
        {
            if (x >= 0 && x < board.GetLength(0) && y - 2 >= 0 && y < board.GetLength(1))
            {
                if (board[x, y - 1] == "X" && board[x, y - 2] == "X")
                {
                    return true;
                }
            }
            return false;
        }

        public int checkVertical(int x, int y)
        {
            if (y + 3 < board.GetLength(1))
            {
                if (board[x, y + 1] == "*" && board[x, y + 2] == "*" && board[x, y + 3] == "*")
                {
                    return 3;
                }
                else if (board[x, y + 1] == "*" && board[x, y + 2] == "*")
                {
                    return 2;
                }
                else if (board[x, y + 1] == "*")
                {
                    return 1;
                }
            }
            return 0;
        }

        public int checkHorizontal(int x, int y)
        {
            // Ellenőrizzük az indexek érvényességét
            if (x - 3 >= 0 && x + 3 < board.GetLength(0) && y >= 0 && y < board.GetLength(1))
            {
                // Ha az x-1 vagy x+1 indexek értéke "*" és az x-2 vagy x+2 indexek is "*" vagy az x-3 vagy x+3 indexek is "*"
                if ((board[x - 1, y] == "*" && board[x - 2, y] == "*") ||
                    (board[x + 1, y] == "*" && board[x + 2, y] == "*") ||
                    (board[x - 1, y] == "*" && board[x - 2, y] == "*" && board[x - 3, y] == "*") ||
                    (board[x + 1, y] == "*" && board[x + 2, y] == "*" && board[x + 3, y] == "*"))
                {
                    return 3;
                }
                // Ha az x-1 vagy x+1 indexek értéke "*" és az x-2 vagy x+2 indexek közül valamelyik nem "*"
                else if ((board[x - 1, y] == "*" && board[x - 2, y] != "*") ||
                         (board[x + 1, y] == "*" && board[x + 2, y] != "*"))
                {
                    return 2;
                }
                // Ha az x-1 vagy x+1 indexek értéke "*" és az x-2 vagy x+2 indexek közül egyik sem "*" vagy az x-3 vagy x+3 indexek értéke "*" és az x-1 vagy x+1 indexek közül valamelyik nem "*"
                else if ((board[x - 1, y] == "*" && board[x - 2, y] != "*" && board[x + 1, y] != "*") ||
                         (board[x + 1, y] == "*" && board[x + 2, y] != "*" && board[x - 1, y] != "*") ||
                         (board[x - 1, y] != "*" && board[x + 1, y] == "*" && board[x + 2, y] != "*") ||
                         (board[x + 1, y] != "*" && board[x - 1, y] == "*" && board[x - 2, y] != "*"))
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
