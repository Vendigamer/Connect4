using System.Xml.Linq;

int TERMX = Console.WindowWidth;
int TERMY = Console.WindowHeight;

Console.WriteLine(" ██████╗ ██████╗ ███╗   ██╗███╗   ██╗███████╗ ██████╗████████╗    ███████╗ ██████╗ ██╗   ██╗██████╗ ");
Console.WriteLine("██╔════╝██╔═══██╗████╗  ██║████╗  ██║██╔════╝██╔════╝╚══██╔══╝    ██╔════╝██╔═══██╗██║   ██║██╔══██╗");
Console.WriteLine("██║     ██║   ██║██╔██╗ ██║██╔██╗ ██║█████╗  ██║        ██║       █████╗  ██║   ██║██║   ██║██████╔╝");
Console.WriteLine("██║     ██║   ██║██║╚██╗██║██║╚██╗██║██╔══╝  ██║        ██║       ██╔══╝  ██║   ██║██║   ██║██╔══██╗");
Console.WriteLine("╚██████╗╚██████╔╝██║ ╚████║██║ ╚████║███████╗╚██████╗   ██║       ██║     ╚██████╔╝╚██████╔╝██║  ██║");
Console.WriteLine(" ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═══╝╚══════╝ ╚═════╝   ╚═╝       ╚═╝      ╚═════╝  ╚═════╝ ╚═╝  ╚═╝");
Console.WriteLine("Nyomj ENTER-t a továbblépéshez");
Console.ReadLine();



static void show(int[,] board)
{
    Console.Clear();
    string[] cells = { " ", "●", "○" };

    Console.WriteLine("\n\n");
    Console.WriteLine("  1   2   3   4   5   6   7 ");
    for (int row = 5; row >= 0; row--)
    {
        Console.Write("+---+---+---+---+---+---+---+\n|");
        for (int col = 0; col < 7; col++)
        {
            Console.Write(" " + cells[board[row, col]] + " |");
        }
        Console.WriteLine();
    }
    Console.WriteLine("+---+---+---+---+---+---+---+\n\n\n");
}

static int[,] create_board()
{
    return new int[6, 7];
}