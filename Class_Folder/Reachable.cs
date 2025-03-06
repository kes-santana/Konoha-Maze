namespace Konoha_Maze;
 public static class Reachable
        {
            public static void PositionValMax(int[,] board, int ValMax)
            {
                for (int i = 1; i < board.GetLength(0) - 1; i++)
                {
                    for (int j = 1; j < board.GetLength(1) - 1; j++)
                    {
                        board[i, j] = ValMax;
                    }
                }
            }
            public static bool ValidPosition(int totalrows, int totalcols, int row, int col)
            {
                // Es como un if, si secumple la condicion retorna true sino false
                return row >= 0 && row < totalrows && col >= 0 && col < totalcols;
            }
            public static bool ValidPositionForEffects(int totalrows, int totalcols, int row, int col)
            {
                // Es como un if, si secumple la condicion retorna true sino false
                return row > 0 && row < totalrows - 1 && col > 0 && col < totalcols - 1;
            }
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
       