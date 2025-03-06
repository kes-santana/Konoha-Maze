namespace Konoha_Maze;
public class Effect
{
    public static void EjecutarEfectoNaruto(Player jugadorActual, Player jugadorInactivo, int turno)
    {
        string sustitutionJutsu = " ha utilizado el jutsu de sustitucion para intercambiar su posicion con la de ";

        Console.SetCursorPosition(25, 2);
        Console.Write(jugadorActual.Name + sustitutionJutsu + jugadorInactivo.Name + ".");
        jugadorActual.ClearOldPos(jugadorActual.PositionPlayer.Item1, jugadorActual.PositionPlayer.Item2);
        jugadorInactivo.ClearOldPos(jugadorInactivo.PositionPlayer.Item1, jugadorInactivo.PositionPlayer.Item2);
        jugadorActual.positionsList.Clear();
        jugadorInactivo.positionsList.Clear();
        (int, int) newPositionPlayer1 = jugadorActual.PositionPlayer;
        (int, int) newPositionPlayer2 = jugadorInactivo.PositionPlayer;
        jugadorActual.PositionPlayer = newPositionPlayer2;
        jugadorInactivo.PositionPlayer = newPositionPlayer1;
        jugadorActual.PrintPosition();
        jugadorInactivo.PrintPosition();
        jugadorActual.positionsList.Add(jugadorActual.PositionPlayer);
        jugadorInactivo.positionsList.Add(newPositionPlayer1);
        jugadorActual.usedShakra -= jugadorActual.disminShakra;
        Thread.Sleep(2000);
    }
    /*  Efectos que se me han ocurrido:
      saltarse las paredes
      robo de shakra               
      caminar doble 
    */
    public static void EjecutarEfectoSakura(Player jugadorActual, Player jugadorInactivo, bool effectActive,ref bool kakashiEffect, int turno, ref int timer, ref bool sasukeEffect, ref bool sasukeEffectCopy)
    {
        string byakugou = "Sakura ha usado el Sello Yin: Liberar y junto ha él ha usado el byakugou.";
        Console.SetCursorPosition(25, 2);
        Console.Write(byakugou);
        var oldPosition = jugadorActual.PositionPlayer;
        effectActive = true;
        jugadorActual.PlayerOptions(Board.board2, Board.mask, Board.TrampBoard, jugadorActual, jugadorInactivo, effectActive,ref kakashiEffect, turno, ref timer, ref sasukeEffect, ref sasukeEffectCopy);
        jugadorActual.ClearOldPos(oldPosition.Item1, oldPosition.Item2);
        jugadorActual.PrintPosition();
        if (Board.mask[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] == true)
        {
            Board.mask[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] = false;
            Board.board2[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] = (int)Box.BoxType.Valid;
        }
        jugadorActual.usedShakra -= jugadorActual.disminShakra;
        effectActive = false;
        turno--;
        Thread.Sleep(2000);
    }
    public static void EjecutarEfectoSasuke(Player jugadorActual, ref int timer, ref bool sasukeEffect)
    {
        timer = 0;
        string shadowClon = " ha generado clones de sombra para evadir trampas.";
        Console.SetCursorPosition(25, 2);
        Console.Write(jugadorActual.Name + shadowClon);
        if (jugadorActual.Name == "Sasuke") sasukeEffect = true;
        jugadorActual.usedShakra -= jugadorActual.disminShakra;
        Thread.Sleep(1500);
    }
    public static void EjecutarEfectoKakashi(Player jugadorActual, Player jugadorInactivo, bool effectActive,ref bool kakashiEffect, int turno, ref int timer, ref bool sasukeEffect, ref bool sasukeEffectCopy)
    {
        // robo de efecto (copyNinja de Kakashi)
        string sharinganFirstEffect = $"Kakashi ha usado su sharingan para copiar el la habilidad de ";
        Console.SetCursorPosition(25, 2);
        Console.Write(sharinganFirstEffect + jugadorInactivo.Name);
        Thread.Sleep(1500);
        Console.SetCursorPosition(25, 2);
        Console.Write("                                                                                               ");

        if (jugadorInactivo.Name == "Naruto")
        {
            EjecutarEfectoNaruto(jugadorActual, jugadorInactivo, turno);
            // // no funciona como debe ser pero funciona
            // effectActive = true;
            // efectoRobado = jugadorInactivo.Name;
            // int shakraOriginal = jugadorInactivo.usedShakra;
            // Player jugadorExtra1 = jugadorActual;
            // Player jugadorExtra2 = jugadorInactivo;
            // jugadorActual = jugadorInactivo;
            // jugadorActual.Name = "Kakashi";
            // jugadorInactivo = jugadorExtra1;
            // jugadorInactivo.Name = "Naruto";
            // jugadorActual.usedShakra = jugadorActual.Shakra;
            // jugadorActual.PlayerOptions(Board.board2, Board.mask, Board.TrampBoard, jugadorActual, jugadorInactivo, effectActive, sasukeEffect, kakashiEffect, turno, timer, efectoRobado);
            // jugadorActual.Name = "Naruto";
            // jugadorInactivo.Name = "Kakashi";
            // jugadorActual = jugadorExtra1;
            // jugadorInactivo = jugadorExtra2;
            // efectoRobado = "";
            // effectActive = false;
            // jugadorActual.usedShakra -= jugadorActual.disminShakra;

        }
        if (jugadorInactivo.Name == "Sakura")
        {
            string maxStrength = "Kakashi ha concentrado su shakra en las manos para poder destruir obstaculos";
            Console.SetCursorPosition(25, 2);
            Console.Write(maxStrength);
            jugadorActual.Name = "Sakura";
            var oldPosition = jugadorActual.PositionPlayer;
            effectActive = true;
            jugadorActual.PlayerOptions(Board.board2, Board.mask, Board.TrampBoard, jugadorActual, jugadorInactivo, effectActive,ref kakashiEffect, turno, ref timer, ref sasukeEffect, ref sasukeEffectCopy);
            jugadorActual.ClearOldPos(oldPosition.Item1, oldPosition.Item2);
            jugadorActual.PrintPosition();
            if (Board.mask[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] == true)
            {
                Board.mask[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] = false;
                Board.board2[jugadorActual.PositionPlayer.Item2, jugadorActual.PositionPlayer.Item1] = (int)Box.BoxType.Valid;
            }
            jugadorActual.usedShakra -= jugadorActual.disminShakra;
            effectActive = false;
            turno--;
            jugadorActual.Name = "Kakashi";
            Thread.Sleep(2000);
        }
        if (jugadorInactivo.Name == "Sasuke")
        {
            kakashiEffect = true;
            sasukeEffectCopy = true;
            EjecutarEfectoSasuke(jugadorActual, ref timer, ref sasukeEffect);
        }
        if (jugadorInactivo.Name == "Hinata")
        {
            EjecutarEfectoHinata(jugadorActual);
        }
        if (jugadorInactivo.Name == "Ino")
        {
            EjecutarEfectoIno(jugadorActual, jugadorInactivo, effectActive, ref kakashiEffect, turno, ref timer, ref sasukeEffect, ref sasukeEffectCopy);
        }
        Thread.Sleep(1500);
    }
    public static void EjecutarEfectoHinata(Player jugadorActual)
    {
        Console.Clear();
        string byakugan = "Hinata ha usado su Byakugan para ver donde hay trampas";
        string byakuganCopy = "Kakashi ha usado su Sharingan para ver donde hay trampas";
        for (int i = 0; i < Board.board2.GetLength(0); i++)
        {
            for (int j = 0; j < Board.board2.GetLength(1); j++)
            {
                if (Board.TrampBoard[i, j] == (int)Tramp.TypeOfTramp.Neblina) Console.Write("n");
                else if (Board.TrampBoard[i, j] == (int)Tramp.TypeOfTramp.PergaminoTrampa) Console.Write("p");
                else if (Board.TrampBoard[i, j] == (int)Tramp.TypeOfTramp.TrampaTerrestre) Console.Write("t");
                else if (Board.mask[i, j] == true) { Console.Write("#"); }
                else if (Board.mask[i, j] == false && Board.TrampBoard[i, j] == 0 && Board.board2[i, j] != (int)Box.BoxType.Wood) { Console.Write(" "); }
                else if (Board.board2[i, j] == (int)Box.BoxType.Wood) { Console.Write("w"); }
            }
            Console.WriteLine();
        }
        Console.SetCursorPosition(25, 2);
        if (jugadorActual.Name == "Hinata")
            Console.Write(byakugan);
        if (jugadorActual.Name == "Kakashi")
            Console.Write(byakuganCopy);
        Thread.Sleep(2500);
        Console.Clear();
        for (int i = 0; i < Board.board2.GetLength(0); i++)
        {
            for (int j = 0; j < Board.board2.GetLength(1); j++)
            {
                if (Board.TrampBoard[i, j] == (int)Tramp.TypeOfTramp.Neblina) Console.Write(" ");
                else if (Board.TrampBoard[i, j] == (int)Tramp.TypeOfTramp.PergaminoTrampa) Console.Write(" ");
                else if (Board.TrampBoard[i, j] == (int)Tramp.TypeOfTramp.TrampaTerrestre) Console.Write(" ");
                else if (Board.mask[i, j] == true) { Console.Write("#"); }
                else if (Board.mask[i, j] == false && Board.TrampBoard[i, j] == 0 && Board.board2[i, j] != (int)Box.BoxType.Wood) { Console.Write(" "); }
                else if (Board.board2[i, j] == (int)Box.BoxType.Wood) { Console.Write("w"); }
            }
            Console.WriteLine();
        }
        jugadorActual.usedShakra -= jugadorActual.disminShakra;
    }
    // public void EjecutarEfectoShikamaru() { }
    // public void EjecutarEfectoGaara() { }
    // public void EjecutarEfectoTemari() { }
    public static void EjecutarEfectoIno(Player jugadorActual, Player jugadorInactivo, bool effectActive,ref bool kakashiEffect, int turno, ref int timer, ref bool sasukeEffect, ref bool sasukeEffectCopy)
    {
        string shintenshin = " ha usado el jutsu Cambio de Cuerpo y Mente para controlar a ";
        Console.SetCursorPosition(25, 2);
        Console.Write(jugadorActual.Name + shintenshin + jugadorInactivo.Name + ".");
        effectActive = true;
        Player jugadorInactivoCopy1 = jugadorInactivo;
        jugadorInactivo = jugadorActual;
        jugadorActual = jugadorInactivoCopy1;
        var oldPosition = jugadorActual.PositionPlayer;
        jugadorActual.PlayerOptions(Board.board2, Board.mask, Board.TrampBoard, jugadorActual, jugadorInactivo, effectActive, ref kakashiEffect, turno, ref timer, ref sasukeEffect, ref sasukeEffectCopy);
        jugadorActual.ClearOldPos(oldPosition.Item1, oldPosition.Item2);
        jugadorActual.PrintPosition();
        Player jugadorInactivoCopy2 = jugadorActual;
        jugadorActual = jugadorInactivo;
        jugadorInactivo = jugadorInactivoCopy2;
        effectActive = false;
        jugadorActual.usedShakra -= jugadorActual.disminShakra;
        Thread.Sleep(1500);
    }
    // public void EjecutarEfectoKiba() { }
    // public void EjecutarEfectoJiraja() { }
    // public void EjecutarEfectoMinato() { }
}
