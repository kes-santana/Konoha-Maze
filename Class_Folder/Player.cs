namespace Konoha_Maze;
public class Player
{
    public string? Name;
    public char Initial;
    public string? atkName;
    public int Shakra;
    public int usedShakra;
    public int disminShakra;
    public int aumentShakra;
    public List<(int, int)> positionsList = new List<(int, int)>();
    public (int, int) PositionPlayer;
    Personajes player;

    // estas propiedades de los personajes estan en proceso de confexion y de busqueda de uso
    /* cuando esten listas hay que ponerlas despues de la propiedad Initial y los espacios que hay es que en ese espacio
    va la cantidad de propiedades que siguen despues de las que estan comentadas (tantas propiedades como lineas en blanco 
    en el comentario siguiente)*/
    //public int Hp;

    // public int Atk;            
    // public int Def;

    // ----------------------------------------------------- lo de abajo de esto es otra cosa
    //int personaje => (int)p;
    //public string Name => p.ToString();
    public Player(Personajes personaje)
    {
        PositionPlayer = (1, 1);
        player = personaje;

        switch (personaje)
        {
            case Personajes.Naruto:
                Name = "Naruto";
                Initial = 'N';
                atkName = "Shadow Clon ... Rasengan";
                // Hp = 100;                        
                Shakra = 95;
                usedShakra = 95;
                // Atk = 25;
                // Def = 20;
                //Effect = EjecutarEfectoNaruto;
                positionsList?.Add((1, 1));
                disminShakra = Shakra * 25 / 100;
                aumentShakra = 5;
                // cooltime 4
                break;

            case Personajes.Sakura:
                Name = "Sakura";
                Initial = 'S';
                atkName = "Byakugou";
                // Hp = 100;                        
                Shakra = 80;
                usedShakra = 80;
                // Atk = 15;
                // Def = 10;
                //  Effect = EjecutarEfectoSakura;
                positionsList?.Add((1, 1));
                disminShakra = Shakra * 25 / 100;
                aumentShakra = 5;
                // cooltime 6
                break;

            case Personajes.Sasuke:
                Name = "Sasuke";
                Initial = 'E';
                atkName = "Chidori";
                // Hp = 100;                        
                Shakra = 85;
                usedShakra = 85;
                // Atk = 20;
                // Def = 10;
                // Effect = EjecutarEfectoSasuke;
                positionsList?.Add((1, 1));
                disminShakra = Shakra * 60 / 100;
                aumentShakra = 7;
                // cooltime 8                   
                break;

            case Personajes.Kakashi:
                Name = "Kakashi";
                Initial = 'K';
                atkName = "Kamui";
                // Hp = 100;                        
                Shakra = 90;
                usedShakra = 90;
                // Atk = 20;
                // Def = 10;
                // Effect = EjecutarEfectoKakashi;
                positionsList?.Add((1, 1));
                disminShakra = Shakra - Shakra * 30 / 100;
                aumentShakra = 6;
                // cooltime 5
                break;

            case Personajes.Hinata:
                Name = "Hinata";
                Initial = 'H';
                atkName = "Juho Soshiken";
                // Juho Soshiken --- Paso suave puños de león
                // Hp = 100;                        
                Shakra = 75;
                usedShakra = 75;
                // Atk = 20;
                // Def = 10;
                // Effect = EjecutarEfectoHinata;
                positionsList?.Add((1, 1));
                disminShakra = Shakra - Shakra * 28 / 100;
                aumentShakra = 6;
                // cooltime 4
                break;

            case Personajes.Ino:
                Name = "Ino";
                Initial = 'I';
                atkName = "Shintenshin";
                // Hp = 100;                        
                Shakra = 70;
                usedShakra = 70;
                // Atk = 20;
                // Def = 10;
                // Effect = EjecutarEfectoIno;
                positionsList?.Add((1, 1));
                disminShakra = Shakra - Shakra * 20 / 100;
                aumentShakra = 3;
                // cooltime 5
                break;
        }
    }
    public enum Personajes
    {
        Naruto = 1,
        Sakura = 2,
        Sasuke = 3,
        Kakashi = 4,
        Hinata = 5,
        Shikamaru = 6,
        Gaara = 7,
        Temari = 8,
        Ino = 9,
        Kiba = 10,
        Jiraya = 11,
        Minato = 12,

    }
    public void PlayerOptions(int[,] board2, bool[,] mask, int[,] TrampBoard, Player jugadorActual, Player jugadorInactivo, bool effectActive,ref bool kakashiEffect, int turno, ref int timer, ref bool sasukeEffect,ref bool sasukeEffectCopy)
    {
        var key = Console.ReadKey(false).Key;
        while (true)
        {
            if (key != ConsoleKey.UpArrow && key != ConsoleKey.DownArrow && key != ConsoleKey.LeftArrow && key != ConsoleKey.RightArrow && key != ConsoleKey.A && key != ConsoleKey.Enter)
            { key = Console.ReadKey(false).Key; }
            else { break; }
        }
        if (effectActive && (jugadorActual.Name == "Sakura" || jugadorActual.Name == "Ino"))
        {
            while (true)
            {
                if (key != ConsoleKey.UpArrow && key != ConsoleKey.DownArrow && key != ConsoleKey.LeftArrow && key != ConsoleKey.RightArrow)
                {
                    key = Console.ReadKey(false).Key;
                }
                else { break; }
            }
        }        
        // if (kakashiEffect )
        // {
        //     while (true)
        //     {
        //         if (key != ConsoleKey.A)
        //         {
        //             key = Console.ReadKey(false).Key;
                   
        //         }
        //         else { break; }
        //     }
        // }
        switch (key)
        {
            case ConsoleKey.UpArrow or ConsoleKey.DownArrow or ConsoleKey.LeftArrow or ConsoleKey.RightArrow:
                MovePlayer(board2, mask, key, effectActive, jugadorActual);
                break;

            case ConsoleKey.A:
                if (jugadorActual.usedShakra == jugadorActual.Shakra)
                {
                    EjecutarEfecto(jugadorActual, jugadorInactivo, effectActive,ref kakashiEffect, turno, ref timer, ref sasukeEffect,ref  sasukeEffectCopy);
                }
                break;
        }

    }
    private void MovePlayer(int[,] board, bool[,] mask, ConsoleKey key, bool effectActive, Player jugadorActual)
    {
        var exit = false;
        while (!exit)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (!Lee.ValidPosition(board.GetLength(0), board.GetLength(1), PositionPlayer.Item2 - 1, PositionPlayer.Item1)) break;
                    if (!Lee.ValidPositionForEffects(board.GetLength(0), board.GetLength(1), PositionPlayer.Item2 - 1, PositionPlayer.Item1)) break;
                    if (!effectActive || effectActive && jugadorActual.Name != "Sakura")
                    {
                        if (CanMove(mask, PositionPlayer.Item1, PositionPlayer.Item2 - 1)) break;
                    }
                    PositionPlayer.Item2 -= 1;
                    exit = true;
                    break;
                case ConsoleKey.DownArrow:
                    if (!Lee.ValidPosition(board.GetLength(0), board.GetLength(1), PositionPlayer.Item2 + 1, PositionPlayer.Item1)) break;
                    if (!Lee.ValidPositionForEffects(board.GetLength(0), board.GetLength(1), PositionPlayer.Item2 + 1, PositionPlayer.Item1)) break;
                    if (!effectActive || effectActive && jugadorActual.Name != "Sakura")
                    {
                        if (CanMove(mask, PositionPlayer.Item1, PositionPlayer.Item2 + 1)) break;
                    }
                    PositionPlayer.Item2 += 1;
                    exit = true;
                    break;
                case ConsoleKey.LeftArrow:
                    if (!Lee.ValidPosition(board.GetLength(0), board.GetLength(1), PositionPlayer.Item2, PositionPlayer.Item1 - 1)) break;
                    if (!Lee.ValidPositionForEffects(board.GetLength(0), board.GetLength(1), PositionPlayer.Item2, PositionPlayer.Item1 - 1)) break;
                    if (!effectActive || effectActive && jugadorActual.Name != "Sakura")
                    {
                        if (CanMove(mask, PositionPlayer.Item1 - 1, PositionPlayer.Item2)) break;
                    }
                    PositionPlayer.Item1 -= 1;
                    exit = true;
                    break;
                case ConsoleKey.RightArrow:
                    if (!Lee.ValidPosition(board.GetLength(0), board.GetLength(1), PositionPlayer.Item2, PositionPlayer.Item1 + 1)) break;
                    if (!Lee.ValidPositionForEffects(board.GetLength(0), board.GetLength(1), PositionPlayer.Item2, PositionPlayer.Item1 + 1)) break;
                    if (!effectActive || effectActive && jugadorActual.Name != "Sakura")
                    {
                        if (CanMove(mask, PositionPlayer.Item1 + 1, PositionPlayer.Item2)) break;
                    }
                    PositionPlayer.Item1 += 1;
                    exit = true;
                    break;
            }
            if (!exit)
                key = Console.ReadKey(false).Key;
            if (key == ConsoleKey.Enter) continue;
        }
    }
    private bool CanMove(bool[,] mask, int x, int y)
    {
        return mask[y, x];
    }
    public void ClearOldPos(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(" ");
    }
    public void PrintPosition()
    {
        Console.SetCursorPosition(PositionPlayer.Item1, PositionPlayer.Item2);
        Console.Write(Initial);
    }
    public void EjecutarEfecto(Player jugadorActual, Player jugadorInactivo, bool effectActive,ref bool kakashiEffect, int turno, ref int timer, ref bool sasukeEffect,ref bool sasukeEffectCopy)
    {
        switch (player)
        {
            // Hecho
            case Personajes.Naruto:
                Effect.EjecutarEfectoNaruto(jugadorActual, jugadorInactivo, turno);
                break;
            // Hecho 
            case Personajes.Sakura:
                Effect.EjecutarEfectoSakura(jugadorActual, jugadorInactivo, effectActive,ref kakashiEffect, turno, ref timer, ref sasukeEffect,ref  sasukeEffectCopy);
                break;
            // Hecho defectar
            case Personajes.Sasuke:
                Effect.EjecutarEfectoSasuke(jugadorActual, ref timer, ref sasukeEffect);
                break;
            //Revisar
            case Personajes.Kakashi:
                Effect.EjecutarEfectoKakashi(jugadorActual, jugadorInactivo, effectActive,ref kakashiEffect, turno, ref timer, ref sasukeEffect,ref sasukeEffectCopy);
                break;
            // defectar
            case Personajes.Hinata:
                Effect.EjecutarEfectoHinata(jugadorActual);
                break;
            // hecho
            case Personajes.Ino:
                Effect.EjecutarEfectoIno(jugadorActual, jugadorInactivo, effectActive,ref kakashiEffect, turno, ref timer, ref sasukeEffect,ref sasukeEffectCopy);
                break;
        }
    }

    //         case Personajes.Shikamaru:
    //             EjecutarEfectoShikamaru();
    //             break;
    //         case Personajes.Gaara:
    //             EjecutarEfectoGaara();
    //             break;
    //         case Personajes.Temari:
    //             EjecutarEfectoTemari();
    //             break;
    //         case Personajes.Kiba:
    //             EjecutarEfectoKiba();
    //             break;
    //         case Personajes.Jiraya:
    //             EjecutarEfectoJiraja();
    //             break;
    //         case Personajes.Minato:
    //             EjecutarEfectoMinato();
    //             break;
}
