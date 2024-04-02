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
            int dropChoice, win, full, again;

            Console.WriteLine("Add meg a neved: ");
            playerOne.playerName = Console.ReadLine();
            playerOne.playerID = 'X';
            playerTwo.playerName = "Robot";
            playerTwo.playerID = 'O';

            full = 0;
            win = 0;
            again = 0;

            Console.Clear();
            DisplayBoard(board);
            do
            {
                dropChoice = PlayerDrop(board, playerOne);
                CheckAlso(board, playerOne, dropChoice);
                DisplayBoard(board);
                win = CheckForWin(board, playerOne);
                if (win == 1)
                {
                    break;
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

            int rows = 6, columns = 7, i, ix;

            for (i = 1; i <= rows; i++)
            {
                Console.Write("|");
                for (ix = 1; ix <= columns; ix++)
                {
                    if (board[i, ix] != 'X' && board[i, ix] != 'O')
                        board[i, ix] = '*';

                    Console.Write(board[i, ix]);

                }

                Console.Write("| \n");
            }

        }

        static int PlayerDrop(char[,] board, playerInfo activePlayer)
        {
            int dropChoice;

            Console.WriteLine(activePlayer.playerName + " köre");
            do
            {
                Console.WriteLine("Adj meg egy számot 1 és 7 között: ");
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
    }
}
