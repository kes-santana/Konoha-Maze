namespace Konoha_Maze;
public static class Lee
{
    public static bool ValidPosition(int totalrows, int totalcols, int row, int col)
    {
        // Es como un if, si secumple la condicion retorna true sino false
        return row >= 0 && row < totalrows && col >= 0 && col < totalcols;

    }
    public static int[,] LlenarDistances(int[,] distances, bool[,] mask)
    {

        for (int i = 0; i < distances.GetLength(0); i++)
        {
            for (int j = 0; j < distances.GetLength(1); j++)
            {
                if (mask[i, j] == true) { distances[i, j] = -2; }

                else { distances[i, j] = -1; }
            }
        }
        return distances;
    }
    public static int[,] LeeAlgorithm(bool[,] board, int initial_row, int initial_col)
    {
        // Array de distancias
        int[,] distances = new int[Program.Rows, Program.Cols];
        LlenarDistances(distances, Board.mask);
        // Crear una array mascara que contenga los cambios ------- Ojo ver en que uso esto 
        bool[,] mask = new bool[Program.Rows, Program.Cols];

        // Marcar la celda inicial
        distances[initial_row, initial_col] = 0;

        //                 N  S  E  W
        int[] deltaRow = [-1, 1, 0, 0];
        int[] deltaCol = [0, 0, 1, -1];

        bool change;
        int Contador = 0;
        do
        {
            Contador++;
            change = false;
            // Para cada posible casilla del tablero
            for (int i = 0; i < Program.Rows; i++)
            {
                for (int j = 0; j < Program.Cols; j++)
                {
                    // Saltarse las casillas no marcadas 
                    // Este if funciona como un if normal 
                    if (distances[i, j] != Contador - 1) continue;

                    // Saltarse casillas invalidas
                    // Este if funciona como si fuera un if else  
                    // Ojo en el libro esta como if (!board[i,j]) continue, porque en el libro las casillas false son las no validas
                    if (board[i, j]) continue;

                    // Inspeccionar casillas vecinas a la casilla [i,j]
                    // Este seria como el else
                    for (int k = 0; k < deltaRow.Length; k++)
                    {
                        int nr = i + deltaRow[k];
                        int nc = j + deltaCol[k];

                        // Determinar si la casilla vecina es valida y no ha sido cambiada
                        if (ValidPosition(Program.Rows, Program.Cols, nr, nc) && distances[nr, nc] == -1 && !board[nr, nc])
                        {
                            // actualizar esta celda
                            distances[nr, nc] = Contador;
                            change = true;
                        }
                    }
                }
            }
        } while (change);
        return distances;
    }
    public static void WalkableBoard(bool[,] mask, int[,] board2)
    {
        int[,] newBoard2 = Lee.LeeAlgorithm(mask, 1, 1);
        for (int m1 = 0; m1 < Program.Rows; m1++)
        {
            for (int n1 = 0; n1 < Program.Cols; n1++)
            {
                if (newBoard2[m1, n1] == -1)
                {
                    ReachableWay(board2, newBoard2, m1, n1);
                    newBoard2 = Lee.LeeAlgorithm(mask, 1, 1);
                }
            }
        }
    }
    public static void ReachableWay(int[,] board2, int[,] yo, int i, int j)
    {
        int[] dx = [-1, 1, 0, 0];
        int[] dy = [0, 0, -1, 1];
        Queue<(int, int)> camino = new Queue<(int, int)>();
        camino.Enqueue((i, j));
        while (camino.Count > 0)
        {
            var (x, y) = camino.Dequeue();
            for (int k = 0; k < dx.Length; k++)
            {
                int nx = x + dx[k];
                int ny = y + dy[k];
                if (nx == 0 || nx == Program.Rows - 1 || ny == 0 || ny == Program.Cols - 1) { continue; }
                if (ValidPosition(Program.Rows, Program.Cols, nx, ny) && yo[nx, ny] == -2)
                {
                    board2[nx, ny] = 3;
                    camino.Enqueue((nx, ny));
                    Board.IsValid(nx, ny);
                }
                else if (ValidPosition(Program.Rows, Program.Cols, nx, ny) && yo[nx, ny] == -1)
                {
                    camino.Enqueue((nx, ny));
                    continue;
                }
                else if (ValidPosition(Program.Rows, Program.Cols, nx, ny) && yo[nx, ny] != -1 && yo[nx, ny] != -2)
                {
                    for (int ii = 0; ii < Program.Rows; ii++)
                    {
                        for (int jj = 0; jj < Program.Cols; jj++)
                        {
                            // ver si el yoo lo puedo sacar del doble for
                            int[,] yoo = Lee.LeeAlgorithm(Board.mask, 1, 1);
                            if (yoo[ii, jj] == -1)
                            {
                                ReachableWay(board2, yoo, ii, jj);
                            }
                        }
                    }
                    return;
                }
            }
        }
    }
    public static bool ValidPositionForEffects(int totalrows, int totalcols, int row, int col)
    {
        // Es como un if, si secumple la condicion retorna true sino false
        return row > 0 && row < totalrows - 1 && col > 0 && col < totalcols - 1;
    }

    //     public static void PositionValMax(int[,] board, int ValMax)
    //     {
    //         for (int i = 1; i < board.GetLength(0) - 1; i++)
    //         {
    //             for (int j = 1; j < board.GetLength(1) - 1; j++)
    //             {
    //                 board[i, j] = ValMax;
    //             }
    //         }
    //     }

    // public static bool ValidPosition(int totalrows, int totalcols, int row, int col)
    // {
    //     // Es como un if, si secumple la condicion retorna true sino false
    //     return row >= 0 && row < totalrows && col >= 0 && col < totalcols;
    // }

    // public static bool VerConect(bool[,] mask, int inicioX, int inicioY)
    // {
    //     int filas = mask.GetLength(0);
    //     int cols = mask.GetLength(1);
    //     bool[,] visitado = new bool[filas, cols];
    //     bool esOno = false;
    //     // int totalDeCelsInalcanzables = 0;
    //     Explorar(mask, visitado, inicioX, inicioY);
    //     for (int i = 1; i < filas - 1; i++)
    //     {
    //         for (int j = 1; j < cols - 1; j++)
    //         {

    //             if (!mask[i, j] && !visitado[i, j])
    //             {
    //                 // para ver casillas inalcazables
    //                 esOno = true;
    //             }
    //         }
    //     }
    //     return esOno;
    // }
    // static void Explorar(bool[,] mask, bool[,] visitado, int x, int y)
    // {
    //     int rows = Board.board2.GetLength(0);
    //     int cols = Board.board2.GetLength(1);
    //     int[] deltaRow = [-1, 1, 0, 0];
    //     int[] deltaCol = [0, 0, 1, -1];

    //     for (int i = 0; i < 4; i++)
    //     {
    //         if (!ValidPosition(rows, cols, x, y) || mask[x, y] || visitado[x, y])
    //         {
    //             continue;
    //         }
    //         visitado[x, y] = true;
    //         int nuevoX = x + deltaRow[i];
    //         int nuevoY = y + deltaCol[i];
    //         Explorar(mask, visitado, nuevoX, nuevoY);
    //     }
    // }

}
