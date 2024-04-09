//using system;
//using system.collections.generic;
//using system.componentmodel.dataannotations.schema;
//using system.linq;
//using system.text;
//using system.threading.tasks;

//namespace connect4
//{
//    public class ai
//    {
//        int x = 5, y = 0;

//        public void firstaiturn()
//        {
//            for (int i = 0; i < 7; i++)
//            {
//                if (board[5, i] == "x")
//                {
//                    if (i - 1 >= 0)
//                    {
//                        board[5, i - 1] = "o";
//                        y = i - 1;
//                        return;
//                    }
//                    else if (i + 1 < 7)
//                    {
//                        board[5, i + 1] = "o";
//                        y = i + 1;
//                        return;
//                    }
//                }
//            }
//        }

//        public void secondaiturn()
//        {
//            if (checkhorizontal(x, y) == 3 && checkvertical(x, y) == 3)
//            {
//                if (r.next(0, 2) == 0)
//                {
//                    if (y - 1 >= 0 && board[x, y - 1] != "x")
//                    {
//                        board[x, y - 1] = "o";
//                        y = y - 1;
//                    }
//                    else if (y + 1 < board.getlength(1) && board[x, y + 1] != "x")
//                    {
//                        board[x, y + 1] = "o";
//                        y = y + 1;
//                    }
//                }
//                else
//                {
//                    if (x + 1 < board.getlength(0) && board[x + 1, y] != "x")
//                    {
//                        board[x + 1, y] = "o";
//                        x = x + 1;
//                    }
//                }
//            }
//            else if (checkvertical(x, y) == 3)
//            {
//                if (x + 1 < board.getlength(0) && board[x + 1, y] != "x")
//                {
//                    board[x + 1, y] = "o";
//                    x = x + 1;
//                }
//            }
//            else if (checkhorizontal(x, y) == 3)
//            {
//                if (y - 1 >= 0 && board[x, y - 1] != "x")
//                {
//                    board[x, y - 1] = "o";
//                    y = y - 1;
//                }
//                else if (y + 1 < board.getlength(1) && board[x, y + 1] != "x")
//                {
//                    board[x, y + 1] = "o";
//                    y = y + 1;
//                }
//            }
//            else
//            {
//                for (int i = 0; i < 7; i++)
//                {
//                    if (board[5, i] == "x")
//                    {
//                        board[4, i] = "o";
//                        x = 4;
//                        y = i;
//                        break;
//                    }
//                }
//            }
//        }

//        public void checkaiturn()
//        {
//            random r = new random();
//            if (checkoponentvertical(oponentx, oponenty))
//            {
//                if (oponentx + 1 < board.getlength(0) && board[oponentx + 1, oponenty] == "*")
//                {
//                    board[oponentx + 1, oponenty] = "o";
//                    x = oponentx + 1;
//                    return;
//                }
//            }
//            if (checkoponenthorizontal(oponentx, oponenty))
//            {
//                for (int i = 0; i < 7; i++)
//                {
//                    if (board[oponentx, i] == "x" && i + 2 < board.getlength(1) && board[oponentx, i + 1] == "x" && board[oponentx, i + 2] == "x")
//                    {
//                        if ((i + 3 < board.getlength(1)) && (board[oponentx, i + 3] == "*" && (board[oponentx - 1, i + 3] == "o" || board[oponentx - 1, i + 3] == "x")))
//                        {
//                            board[oponentx, i + 3] = "o";
//                            y = i + 3;
//                            return;
//                        }
//                        else if ((i - 1 >= 0) && (board[oponentx, i - 1] == "*" && (board[oponentx - 1, i - 1] == "o" || board[oponentx - 1, i - 1] == "x")))
//                        {
//                            board[oponentx, i - 1] = "o";
//                            y = i - 1;
//                            return;
//                        }
//                    }
//                }
//            }
//            averageaiturn();
//        }

//        public void averageaiturn()
//        {

//        }

//        //public bool checkoponenthorizontaldouble(int x, int y)
//        //{
//        //    try
//        //    {
//        //        if (tabla[x, y - 2] == "*" && tabla[x, y + 2] == "*" && tabla[x, y + 1] == "x" || tabla[x, y - 1] == "x")
//        //            return true;
//        //        return false;
//        //    }
//        //    catch { return false; }
//        //}

//        public bool checkoponenthorizontal(int x, int y)
//        {
//            if (x - 1 >= 0 && x + 1 < board.getlength(0) && y >= 0 && y < board.getlength(1))
//            {
//                if ((board[x - 1, y] == "x" && board[x + 1, y] == "x") ||
//                    (x - 2 >= 0 && board[x - 2, y] == "x" && board[x - 1, y] == "x") ||
//                    (x + 2 < board.getlength(0) && board[x + 2, y] == "x" && board[x + 1, y] == "x"))
//                {
//                    return true;
//                }
//            }
//            return false;
//        }

//        public bool checkoponentvertical(int x, int y)
//        {
//            if (x >= 0 && x < board.getlength(0) && y - 2 >= 0 && y < board.getlength(1))
//            {
//                if (board[x, y - 1] == "x" && board[x, y - 2] == "x")
//                {
//                    return true;
//                }
//            }
//            return false;
//        }

//        public int checkvertical(int x, int y)
//        {
//            if (y + 3 < board.getlength(1))
//            {
//                if (board[x, y + 1] == "*" && board[x, y + 2] == "*" && board[x, y + 3] == "*")
//                {
//                    return 3;
//                }
//                else if (board[x, y + 1] == "*" && board[x, y + 2] == "*")
//                {
//                    return 2;
//                }
//                else if (board[x, y + 1] == "*")
//                {
//                    return 1;
//                }
//            }
//            return 0;
//        }

//        public int checkhorizontal(int x, int y)
//        {
//            // ellenőrizzük az indexek érvényességét
//            if (x - 3 >= 0 && x + 3 < board.getlength(0) && y >= 0 && y < board.getlength(1))
//            {
//                // ha az x-1 vagy x+1 indexek értéke "*" és az x-2 vagy x+2 indexek is "*" vagy az x-3 vagy x+3 indexek is "*"
//                if ((board[x - 1, y] == "*" && board[x - 2, y] == "*") ||
//                    (board[x + 1, y] == "*" && board[x + 2, y] == "*") ||
//                    (board[x - 1, y] == "*" && board[x - 2, y] == "*" && board[x - 3, y] == "*") ||
//                    (board[x + 1, y] == "*" && board[x + 2, y] == "*" && board[x + 3, y] == "*"))
//                {
//                    return 3;
//                }
//                // ha az x-1 vagy x+1 indexek értéke "*" és az x-2 vagy x+2 indexek közül valamelyik nem "*"
//                else if ((board[x - 1, y] == "*" && board[x - 2, y] != "*") ||
//                         (board[x + 1, y] == "*" && board[x + 2, y] != "*"))
//                {
//                    return 2;
//                }
//                // ha az x-1 vagy x+1 indexek értéke "*" és az x-2 vagy x+2 indexek közül egyik sem "*" vagy az x-3 vagy x+3 indexek értéke "*" és az x-1 vagy x+1 indexek közül valamelyik nem "*"
//                else if ((board[x - 1, y] == "*" && board[x - 2, y] != "*" && board[x + 1, y] != "*") ||
//                         (board[x + 1, y] == "*" && board[x + 2, y] != "*" && board[x - 1, y] != "*") ||
//                         (board[x - 1, y] != "*" && board[x + 1, y] == "*" && board[x + 2, y] != "*") ||
//                         (board[x + 1, y] != "*" && board[x - 1, y] == "*" && board[x - 2, y] != "*"))
//                {
//                    return 1;
//                }
//            }
//            return 0;
//        }
//    }
//}
