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

        public int firstAiTurn()
        {
            for (int i = 0; i < 7; i++)
            {
                if (tabla[5, i] == "X")
                {
                    try
                    {
                        tabla[5, i - 1] = "O";
                        y = i - 1;
                    }
                    catch
                    {
                        tabla[5, i + 1] = "O";
                        y = i + 1;
                    }
                }
            }
        }

        public void secondAiTurn()
        {
            if (checkHorizontal(x, y) == 3 && checkVertical(x, y) == 3)
            {
                if (r.Next(0, 1) == 0)
                {
                    if (tabla[x, y - 1] != "X")
                    {
                        tabla[x, y - 1] == "O";
                        y = y - 1;
                    }
                    else
                    {
                        tabla[x, y + 1] == "O";
                        y = y + 1;
                    }
                }
                else
                {
                    tabla[x + 1, y] == "O";
                    x = x + 1;
                }
            }
            else if (checkVertical(x, y) == 3)
            {
                tabla[x + 1, y] == "O";
                x = x + 1;
            }
            else if (checkHorizontal(x, y) == 3)
            {
                if (tabla[x, y - 1] != "X")
                {
                    tabla[x, y - 1] == "O";
                    y = y - 1;
                }
                else
                {
                    tabla[x, y + 1] == "O";
                    y = y + 1;
                }
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    if (tabla[5, i] == "X")
                    {
                        tabla[4, i] == "O";
                        y = i;
                        x = 4;
                    }
                }
            }
        }

        public void checkAiTurn()
        {
            Random r = new Random();
            if (checkOponentVertical(oponentX, oponentY) == true)
            {
                if (table[oponentX + 1, oponentY] == "*" && oponentX + 1 < table.GetLength(0))
                {
                    table[oponentX + 1, oponentY] = "O";
                    x = oponentX + 1;
                }
                else
                    avargeAiTurn();
            }
            else if (checkOponentHorizontal(oponentX, oponentY) == true)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (table[oponentX, i] == "X" && table[oponentX, i + 1] == "X" && table[oponentX, i + 2] == "X" && table[oponentX, i + 3] == "*" || table[oponentX, i - 1] == "*")
                    {
                        if (table[oponentX, i + 3] == "*" && i + 3 < table.GetLength(1))
                        {
                            table[oponentX, i + 3] = "O";
                            y = i + 3;
                        }
                        else if (table[oponentX, i - 1] == "*" && i - 1 < table.GetLength(1))
                        {
                            table[oponentX, i - 1] = "O";
                            y = i - 1;
                        }
                        else
                            avargeAiTurn();
                        break;
                    }
                }
            }
            else
                avargeAiTurn();
        }

        public void avargeAiTurn()
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
            try
            {
                if (tabla[x - 1, y] == "X" && tabla[x + 1, y] == "X" || tabla[x - 2, y] == "X" && tabla[x - 1, y] == "X" || tabla[x + 2, y] == "X" && tabla[x + 1, y] == "X")
                    return true;
                return false;
            }
            catch { return false; }
        }

        public bool checkOponentVertical(int x, int y)
        {
            try
            {
                if (tabla[x, y - 1] == "X" && tabla[x, y - 2] == "X")
                    return true;
                return false;
            }
            catch { return false; }
        }

        public int checkVertical(int x, int y)
        {
            try
            {
                if (tabla[x, y + 1] == "*")
                {
                    if (tabla[x, y + 2] == "*")
                    {
                        if (tabla[x, y + 3] == "*")
                        {
                            return 3;
                        }
                        return 2;
                    }
                    return 1;
                }
                return 0;
            }
            catch { return 0; }
        }

        public int checkHorizontal(int x, int y)
        {
            try
            {
                if (tabla[x - 1, y] == "*" || tabla[x + 1, y] == "*")
                {
                    if (tabla[x - 1, y] == "*" && tabla[x - 2, y] == "*" || tabla[x + 1, y] == "*" && tabla[x + 2, y] == "*")
                    {
                        if (tabla[x - 1, y] == "*" && tabla[x - 2, y] == "*" && tabla[x - 3, y] == "*" || tabla[x + 1, y] == "*" && tabla[x + 2, y] == "*" && tabla[x + 3, y] == "*")
                        {
                            return 3;
                        }
                        return 2;
                    }
                    return 1;
                }
                return 0;
            }
            catch { return 0; }
        }
    }
}
