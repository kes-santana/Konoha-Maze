namespace Konoha_Maze;
 public class Tramp
        {
            public enum TypeOfTramp
            {
                Neblina = 1,
                TrampaTerrestre,
                PergaminoTrampa,

            }
            public static void TrampEfect(int NumberOfTramp, Player jugadorActual, Player jugadorInactivo, int turno, int[,] TrampBoard, int CatchPlayerTimes)
            {
                switch (NumberOfTramp)
                {
                    case (int)TypeOfTramp.Neblina:
                        // Board.TrampBoard[player.PositionPlayer.Item2, player.PositionPlayer.Item1] = 0;
                        // turno++;
                        // return true;
                        break;
                    case (int)TypeOfTramp.TrampaTerrestre:
                        int posX = jugadorActual.PositionPlayer.Item1;
                        int posY = jugadorActual.PositionPlayer.Item2;

                        if (jugadorInactivo.PositionPlayer == (posX + 1, posY) ||
                            jugadorInactivo.PositionPlayer == (posX - 1, posY) ||
                            jugadorInactivo.PositionPlayer == (posX, posY + 1) ||
                            jugadorInactivo.PositionPlayer == (posX, posY - 1))
                        {
                            Console.SetCursorPosition(25, 3);
                            Console.Write("                                                                                               ");
                            Console.SetCursorPosition(25, 4);
                            Console.Write("                                                                                               ");
                            Console.SetCursorPosition(25, 3);
                            Console.Write($"{jugadorInactivo.Name} rescató a {jugadorActual.Name} de la trampa");
                            Board.TrampBoard[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] = 0;
                            break;
                        }
                        else if (CatchPlayerTimes == 4)
                        {
                            Console.SetCursorPosition(25, 3);
                            Console.Write("                                                                                               ");
                            Console.SetCursorPosition(25, 4);
                            Console.Write("                                                                                               ");
                            Console.SetCursorPosition(25, 3);
                            Console.Write($"{jugadorActual.Name} logró escapar de la trampa");
                            Board.TrampBoard[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] = 0;
                            break;
                        }
                        break;
                    case (int)TypeOfTramp.PergaminoTrampa:
                        Console.SetCursorPosition(25, 3);
                        Console.Write($"{jugadorActual.Name} un sujeto estraño te ha entregado un pergamino un poco raro.");
                        Console.SetCursorPosition(25, 4);
                        Console.Write($"- {jugadorActual.Name}: El pergamino dice que nuestro oponente está cerca de aquí.");
                        Console.SetCursorPosition(25, 5);
                        Console.Write(" Usaré un jutsu de rayo para llegar más rápido.");
                        Console.SetCursorPosition(25, 6);
                        Console.Write("Un momento después ...");
                        Thread.Sleep(4500);
                        (int, int) currentPos = jugadorActual.PositionPlayer;
                        TrampBoard[currentPos.Item2, currentPos.Item1] = 0;
                        jugadorActual.ClearOldPos(currentPos.Item1, currentPos.Item2);
                        if (jugadorActual.positionsList.Count == 5)
                        {
                            jugadorActual.PositionPlayer = jugadorActual.positionsList[4];
                        }
                        else jugadorActual.PositionPlayer = jugadorActual.positionsList.First();
                        jugadorActual.PrintPosition();
                        jugadorActual.positionsList.Clear();
                        jugadorActual.positionsList.Add(jugadorActual.PositionPlayer);
                        Console.SetCursorPosition(25, 7);
                        Console.Write($"- {jugadorActual.Name}: Queee!! ... En la letra chiquita dice: Jaja caíste en un jutsu ilusorio");
                        Console.SetCursorPosition(25, 8);
                        Console.Write(" ahora podré llegar antes a la aldea para destruirla!");
                        Console.SetCursorPosition(25, 9);
                        Console.Write($"- {jugadorActual.Name}: Aah! ... me las pagará.");
                        Thread.Sleep(4500);
                        break;
                }
            }
        }
