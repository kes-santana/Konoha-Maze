namespace Konoha_Maze;
public static class Board
{
    public static bool[,] mask = new bool[Program.Rows, Program.Cols];
    public static int[,] board2 = new int[Program.Rows, Program.Cols];
    public static int[,] TrampBoard = new int[Program.Rows, Program.Cols];
    public static bool[,]IsValid(int i, int j)
    {
        if (board2[i, j] == (int)Box.BoxType.Invalid || board2[i, j] == (int)Box.BoxType.Obstacle || board2[i, j] == (int)Box.BoxType.Obstacle1 || board2[i, j] == (int)Box.BoxType.Obstacle2)
        {
            mask[i, j] = true;
        }
        else { mask[i, j] = false; }
        return mask;
    }
    public static void TypeOfBox()
    {
        // int ValMax = Program.Rows * Program.Cols;
        // Lee.PositionValMax(board2, ValMax);
        Random box = new Random();
        Random TrampBox = new Random();

        for (int i = 0; i < Program.Rows; i++)
        {
            for (int j = 0; j < Program.Cols; j++)
            {
                // Hacer los extremos del laberinto 
                if (i == 0 || i == Program.Rows - 1 || j == 0 || j == Program.Cols - 1)
                {
                    board2[i, j] = (int)Box.BoxType.Invalid;
                IsValid(i, j);
                }
                // Generar un numero aleatorio entre 1 y 4
                else
                {
                    if (i == 1 && j == 1) board2[i, j] = (int)Box.BoxType.Valid;
                    else
                    {
                        int cell = box.Next((int)Box.BoxType.Valid + 1);
                        board2[i, j] = cell;
                    IsValid(i, j);
                    }
                }
                if (i == Program.Rows - 2 && j == Program.Cols - 2) { board2[i, j] = (int)Box.BoxType.Wood;IsValid(i, j); }
                if (i == Program.Rows - 2 && j == Program.Cols - 3 || i == Program.Rows - 3 && j == Program.Cols - 2) { board2[i, j] = (int)Box.BoxType.Valid;IsValid(i, j); }
            }
        }
        Lee.WalkableBoard(mask, board2);
        for (int tramp_i = 0; tramp_i < Program.Rows; tramp_i++)
        {
            for (int tramp_j = 0; tramp_j < Program.Cols; tramp_j++)
            {
                if (board2[tramp_i, tramp_j] == 0)
                {
                    int TrampCell = TrampBox.Next((int)Tramp.TypeOfTramp.Neblina, (int)Tramp.TypeOfTramp.PergaminoTrampa + 1);
                    TrampBoard[tramp_i, tramp_j] = TrampCell;
                }
            }
        }
    }
}
