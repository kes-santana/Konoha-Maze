namespace Konoha_Maze;
class Play
{
    public string Jugar(Player player1, Player player2)
    {
        // Console.Clear();
        // Player jugador1 = player1;
        // Player jugador2 = player2;

        // ConsoleKeyInfo key = Console.ReadKey();
        // Console.WriteLine(key.KeyChar);

        Player jugadorActual;
        Player jugadorInactivo;
        int turno = 1;
        int CatchPlayerTimes = 0;
        bool Ganar = false;
        string? Ganador = "";

        // effect se usa en convinacion con effectInfo se usa para saber si el efecto esta disponible o no
        string effectInfo = "";
        bool effect = false;

        bool effectActive = false;
        bool sasukeEffect = false;
        bool sasukeEffectCopy = false;
        int kakashiTimer = 0;
        bool kakashiEffect = false;
        int timer = 0;

        while (!Ganar)
        {
            // El ordemn de jugadores esta asi "jugador2 : jugador1" ya que el primer turno es impar y el player 
            jugadorActual = turno % 2 == 0 ? player2 : player1;
            jugadorInactivo = turno % 2 == 1 ? player2 : player1;
            if (jugadorActual.usedShakra == jugadorActual.Shakra) { effect = true; }
            if (jugadorActual.usedShakra < jugadorActual.Shakra) { effect = false; }
            effectInfo = "";
            effectInfo += effect ? "Habilidad: disponible" : "Habilidad: reuniendo shakra";
            Console.SetCursorPosition(25, 0);
            Console.Write($"Turno numero: {turno} \t Jugador: {jugadorActual.Name} \t Shakra: {jugadorActual.usedShakra}/{jugadorActual.Shakra} \t {effectInfo}");
            if (Board.TrampBoard[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] == (int)Tramp.TypeOfTramp.TrampaTerrestre
            && Board.TrampBoard[jugadorInactivo.PositionPlayer.Item2, jugadorInactivo.PositionPlayer.Item1] == (int)Tramp.TypeOfTramp.TrampaTerrestre)
            {
                string? rescuedPlayerName;
                Random rescate = new Random();
                int playerRescatado = rescate.Next(2);
                if (playerRescatado == 0)
                {
                    Board.TrampBoard[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] = 0;
                    rescuedPlayerName = jugadorActual.Name;
                }
                else
                {
                    Board.TrampBoard[jugadorInactivo.PositionPlayer.Item2, jugadorInactivo.PositionPlayer.Item1] = 0;
                    rescuedPlayerName = jugadorInactivo.Name;
                }
                Console.SetCursorPosition(25, 4);
                Console.WriteLine($"Shhh-plaff ... Alguien misterioso ha ayudado a salir a {rescuedPlayerName} de la trampa terrestre.");
            }
            if (Board.TrampBoard[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] != 0)
            {
                // Terminar
                if ((sasukeEffect && jugadorActual.Name != "Sasuke") || (!sasukeEffect && jugadorActual.Name == "Sasuke") || (!sasukeEffect && jugadorActual.Name != "Sasuke"))
                {
                    if (!kakashiEffect && !sasukeEffectCopy && jugadorActual.Name == "Kakashi" || !kakashiEffect && !sasukeEffectCopy && jugadorActual.Name != "Kakashi" || kakashiEffect && !sasukeEffectCopy && jugadorActual.Name != "Kakashi")
                    {
                        if (Board.TrampBoard[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] == (int)Tramp.TypeOfTramp.Neblina)
                        {
                            Console.SetCursorPosition(25, 3);
                            Console.Write($"{jugadorActual.Name} está rodeado/a de niebla y no puede ver el camino. Será necesario");
                            Console.SetCursorPosition(25, 4);
                            Console.Write("que espere un turno para que esta se despeje un poco.");
                            Board.TrampBoard[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] = 0;
                            turno++;
                            continue;
                        }
                        if (Board.TrampBoard[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] == (int)Tramp.TypeOfTramp.TrampaTerrestre)
                        {                                                                                                                   
                            Console.SetCursorPosition(25, 3);
                            Console.Write($"{jugadorActual.Name} cayó en una trampa terrestre y no puede salir. Será necesario");
                            Console.SetCursorPosition(25, 4);
                            Console.Write("que espere a que lo/a rescaten o que intente escapar por sí solo/a.");
                            Tramp.TrampEfect((int)Tramp.TypeOfTramp.TrampaTerrestre, jugadorActual, jugadorInactivo, turno, Board.TrampBoard, CatchPlayerTimes);
                            CatchPlayerTimes++;
                            if (Board.TrampBoard[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] == 0) CatchPlayerTimes = 0;
                            Console.SetCursorPosition(25, 0);
                            Console.Write("                                                                                               ");
                            turno++;
                            continue;
                        }
                    }
                }
            }
            var currentPos = jugadorActual.PositionPlayer;
            jugadorActual.PlayerOptions(Board.board2, Board.mask, Board.TrampBoard, jugadorActual, jugadorInactivo, effectActive, ref kakashiEffect, turno, ref timer, ref sasukeEffect, ref sasukeEffectCopy);
            jugadorActual.ClearOldPos(currentPos.Item1, currentPos.Item2);
            jugadorActual.PrintPosition();

            if (jugadorActual.positionsList.Count == 5 && jugadorActual.positionsList[0] != jugadorActual.PositionPlayer)
            {
                jugadorActual.positionsList[4] = jugadorActual.positionsList[3];
                jugadorActual.positionsList[3] = jugadorActual.positionsList[2];
                jugadorActual.positionsList[2] = jugadorActual.positionsList[1];
                jugadorActual.positionsList[1] = jugadorActual.positionsList[0];
                jugadorActual.positionsList[0] = (jugadorActual.PositionPlayer.Item1, jugadorActual.PositionPlayer.Item2);
            }
            else if (jugadorActual.positionsList.Count < 5 && jugadorActual.positionsList[jugadorActual.positionsList.Count - 1] != jugadorActual.PositionPlayer)
            {
                jugadorActual.positionsList.Add((jugadorActual.PositionPlayer.Item1, jugadorActual.PositionPlayer.Item2));
                if (jugadorActual.positionsList.Count == 5)
                {
                    jugadorActual.positionsList.Reverse();
                }
            }

            if (Board.TrampBoard[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] != 0)
            {
                if (sasukeEffect && jugadorActual.Name == "Sasuke") { turno++; continue; }
                if (kakashiEffect && sasukeEffectCopy && jugadorActual.Name == "Kakashi") { turno++; continue; }
                // esto es para que se ejecute la trampa "pergamino trampa"
                int NumberOfTramp = Board.TrampBoard[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1];
                Tramp.TrampEfect(NumberOfTramp, jugadorActual, jugadorInactivo, turno, Board.TrampBoard, CatchPlayerTimes);
            }

            jugadorActual.usedShakra += jugadorActual.aumentShakra;
            if (jugadorActual.usedShakra > jugadorActual.Shakra) { jugadorActual.usedShakra = jugadorActual.Shakra; }
            if (sasukeEffect && jugadorActual.Name == "Sasuke")
            {
                timer++;
                if (timer == 4)
                {
                    sasukeEffect = false;
                    timer = 0;
                }
            }
            if (sasukeEffectCopy && jugadorActual.Name == "Kakashi")
            {
                kakashiTimer++;
                if (kakashiTimer == 4)
                {
                    kakashiEffect = false;
                    sasukeEffectCopy = false;
                    kakashiTimer = 0;
                }
            }
            Console.SetCursorPosition(25, 0);
            Console.Write("                                                                                               ");
            Console.SetCursorPosition(25, 0);
            Console.Write($"Turno numero: {turno} \t Jugador: {jugadorActual.Name} \t Shakra: {jugadorActual.usedShakra}/{jugadorActual.Shakra}");
            if (jugadorActual.PositionPlayer == (Board.board2.GetLength(1) - 2, Board.board2.GetLength(0) - 2))
            {
                (int, int) endPosJugadorInactivo = jugadorInactivo.PositionPlayer;
                jugadorInactivo.PositionPlayer = (Board.board2.GetLength(1) - 2, Board.board2.GetLength(0) - 3);
                jugadorInactivo.ClearOldPos(endPosJugadorInactivo.Item1, endPosJugadorInactivo.Item2);
                jugadorInactivo.PrintPosition();
                Ganador = jugadorActual.Name;
                Ganar = true;
            }
            turno++;
            Start_End.ClearComentarys();
        }
        Thread.Sleep(1500);
        // Console.Clear();
        // Console.SetCursorPosition(0, 0);
        // Console.WriteLine($"{Ganador} ha ganado");
        // Thread.Sleep(2000);
        return Ganador!;
    }
}