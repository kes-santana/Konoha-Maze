namespace Konoha_Maze;
public class Start_End
{
    public void StartGame()
    {
        // Buscarle nombre al juego.
        Console.WriteLine("\t* ¡Bienvenido a -nombre del juego-! *\n\n\tEn esta maravillosa aventura ayudarás a proteger la ilustre aldea de Konoha, hogar de extraordinarios \n\n\ty poderosos ninjas, quienes leales a su hogar lucharán y, de ser necesario, darán la vida \n\n\tcon el objetivo de traer paz y prosperidad a su aldea.");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\n\t* Sshhpuff ... !! *");
        Console.ReadKey();
        Console.WriteLine("\n\t- Orochimaru: Jajaja es hora de cumplir mi objetivo. Por fin invadiré Konoha.");
        Console.ReadKey();
        Console.WriteLine("\n\t- Tsunade: No creas que le harás daño a la aldea. No lo permitiré.");
        Console.ReadKey();
        Console.WriteLine("\n\t    ( ... )");
        Console.ReadKey();
        Console.WriteLine("\n\t* Tsunade y Orochimaru han luchado hasta quedar totalmente debilitados *");
        Console.ReadKey();
        Console.WriteLine("\n\t- Orochimaru: Has logrado debilitarme, pero no creas que mi plan ha terminado.");
        Console.ReadKey();
        Console.WriteLine("\n\t- Tsunade: No huyas!");
        Console.ReadKey();
        Console.WriteLine("\n\t- Tsunade:Aah!! Estoy muy debilitada como para perseguirlo.");
        Console.ReadKey();
        Console.WriteLine("\n\t* Tsunade se ha teletransportado a Konoha y ha convocado a una reunión ninja *");
        Console.ReadKey();
        Console.WriteLine("\n\t- Tsunade: Bien, ya todos deben a ver oído los rumores. Orochimaru a regresado con el objetivo\n\t de invadir la aldea. Nesecito voluntarios que vayan a enfrentarlo, el resto debe permanecer en la aldea\n\t para protegerla de cualquier otro peligro.");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\n\t * Tu misión será crear el equipo que busque a Orochimaru y evitar que lecause daño a la aldea *");
        Console.ReadKey();
        Console.Clear();
    }
    public void Menu()
    {
        Console.WriteLine("\t\t < MENU >");
        Console.WriteLine("\t* Play");
        Console.WriteLine("");
        Console.WriteLine("\t* Game Information");
        Console.WriteLine("");
        Console.WriteLine("\t* Exit");
        Console.WriteLine("");
        Console.WriteLine("\t   Elija una opcion.");
    }
    public void HowToPlay()
    {
        Console.Clear();
        Console.WriteLine("\t- El objetivo del juego es llegar a la salida del bosque denotada con una <B>.");
        Console.WriteLine("");
        Console.ReadKey();
        Console.WriteLine("\tComo jugar?");
        Console.WriteLine("");
        Console.ReadKey();
        Console.WriteLine("\t- Por partida debes escoger entre moverte o ejecutar la habilidad de tu personaje.");
        Console.WriteLine("\tPara moverte: \n\t * Hacia arriba presiona la tecla 'Flecha Arriba'. \n\t * Hacia abajo presiona la tecla 'Flecha Abajo'.");
        Console.WriteLine("\t * Hacia la izquierda presiona la tecla 'Flecha Izquierda'. \n\t * Hacia la dercha presiona la tecla 'Flecha Derecha'.");
        Console.WriteLine("");
        Console.ReadKey();
        Console.WriteLine("\tPara usar la habilidad de los personajes: Presiona la tecla 'A'. Debes tener");
        Console.ReadKey();
        Console.WriteLine("\ten cuenta que para usar la habilidad el shakra de tu personaje debe estar al maximo.");
        Console.WriteLine("\tA continuacion un ejemplo: \n\t   Shakra: 90/90  'disponible' \n\t   Shakra: 80/90  'reuniendo Shakra'");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\t- Existen tres tipos de trampas ocultas: \n\n\t* Neblina: imposibilita al jugador que cae en ella de moverse durante un turno");
        Console.WriteLine(" \t* Trampa Terrestre: si un jugador cae en ella no podra moverse en 5 turnos a menos que el otro jugador \n\tlo rescate (se posicione arriba, debajo o a un lado del jugador que esta en la trampa) ");
        Console.WriteLine(" \t* Pergamino Trampa: regresa al jugador a la posicion que tenia 5 turnos atras.");
        Console.WriteLine("");
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("\t- A continuacion se muestran los personajes disponibles:");

        Console.SetCursorPosition(5, 3);
        Console.Write("Naruto");
        Console.SetCursorPosition(5, 4);
        Console.Write("Initial: N");
        Console.SetCursorPosition(5, 5);
        Console.Write("Atk: Shadow Clon ... Rasengan");
        Console.SetCursorPosition(5, 6);
        Console.Write("Shakra: 95");
        Console.SetCursorPosition(5, 7);
        Console.Write("Effect: Sustitution Jutsu (intercambia su posicion");
        Console.SetCursorPosition(5, 8);
        Console.Write("        con la de su copmanero)");

        Console.SetCursorPosition(70, 3);
        Console.Write("Sakura");
        Console.SetCursorPosition(70, 4);
        Console.Write("Initial: S");
        Console.SetCursorPosition(70, 5);
        Console.Write("Atk: Byakugou");
        Console.SetCursorPosition(70, 6);
        Console.Write("Shakra: 80");
        Console.SetCursorPosition(70, 7);
        Console.Write("Effect: Byakugou (dota a Sakura de una gran fuerza");
        Console.SetCursorPosition(70, 8);
        Console.Write("        la cual utiliza para romper paredes y caminar doble)");

        Console.SetCursorPosition(5, 10);
        Console.Write("Sasuke");
        Console.SetCursorPosition(5, 11);
        Console.Write("Initial: E");
        Console.SetCursorPosition(5, 12);
        Console.Write("Atk: Chidori");
        Console.SetCursorPosition(5, 13);
        Console.Write("Shakra: 85");
        Console.SetCursorPosition(5, 14);
        Console.Write("Effect: Shadow Clon (usa en clon para evadir trampas");
        Console.SetCursorPosition(5, 15);
        Console.Write("        durante 4 turnos)");

        Console.SetCursorPosition(70, 10);
        Console.Write("Kakashi");
        Console.SetCursorPosition(70, 11);
        Console.Write("Initial: K");
        Console.SetCursorPosition(70, 12);
        Console.Write("Atk: Kamui");
        Console.SetCursorPosition(70, 13);
        Console.Write("Shakra: 90");
        Console.SetCursorPosition(70, 14);
        Console.Write("Effect: Sharingan Effect (usa su sharingan para");
        Console.SetCursorPosition(70, 15);
        Console.Write("        copiar la habilidad del otro jugador)");

        Console.SetCursorPosition(5, 17);
        Console.Write("Hinata");
        Console.SetCursorPosition(5, 18);
        Console.Write("Initial: H");
        Console.SetCursorPosition(5, 19);
        Console.Write("Atk: Juho Soshiken");
        Console.SetCursorPosition(5, 20);
        Console.Write("Shakra: 75");
        Console.SetCursorPosition(5, 21);
        Console.Write("Effect: Byakugan (usa su byakugan para ver ");
        Console.SetCursorPosition(5, 22);
        Console.Write("        donde hay trampas)");

        Console.SetCursorPosition(70, 17);
        Console.Write("Ino");
        Console.SetCursorPosition(70, 18);
        Console.Write("Initial: I");
        Console.SetCursorPosition(70, 19);
        Console.Write("Atk: Shintenshin");
        Console.SetCursorPosition(70, 20);
        Console.Write("Shakra: 70");
        Console.SetCursorPosition(70, 21);
        Console.Write("Effect: Shintenshin (usa el jutsu Cambio de Cuerpo y Mente");
        Console.SetCursorPosition(70, 22);
        Console.Write("        para mover a su companero)");

        Console.ReadKey();
        Console.Clear();
    }
    public void PrintBoard()
    {
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
    }
    public void EndGame(Player player1, Player player2)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        int[,] finalBoard = new int[Program.Rows, Program.Cols];
        for (int i = 0; i < finalBoard.GetLength(0); i++)
        {
            for (int j = 0; j < finalBoard.GetLength(1); j++)
            {
                if (i == 0 || i == finalBoard.GetLength(0) - 1 || j == 0 || j == finalBoard.GetLength(1) - 1)
                {
                    finalBoard[i, j] = (int)Box.BoxType.Invalid;
                }
                else if (i == ((Program.Rows - 2) / 2) + 1 && j == ((Program.Cols - 2) / 4) + 1) { finalBoard[i, j] = (int)Box.BoxType.Valid1; }
                else if (i == ((Program.Rows - 2) / 4) + 1 && j == ((Program.Cols - 2) / 2) + 1) { finalBoard[i, j] = (int)Box.BoxType.Valid2; }
                else if (i == ((Program.Rows - 2) / 2) + 1 && j == ((Program.Cols - 2) / 2) + 1) { finalBoard[i, j] = (int)Box.BoxType.Valid3; }
                else { finalBoard[i, j] = (int)Box.BoxType.Valid; }
            }
        }
        for (int i = 0; i < finalBoard.GetLength(0); i++)
        {
            for (int j = 0; j < finalBoard.GetLength(1); j++)
            {
                if (finalBoard[i, j] == (int)Box.BoxType.Invalid) { Console.Write("#"); }
                else if (finalBoard[i, j] == (int)Box.BoxType.Valid) { Console.Write(" "); }
                if (finalBoard[i, j] == (int)Box.BoxType.Valid1) { Console.Write(player1.Initial); }
                if (finalBoard[i, j] == (int)Box.BoxType.Valid2) { Console.Write(player2.Initial); }
                if (finalBoard[i, j] == (int)Box.BoxType.Valid3) { Console.Write("O"); }
            }
            Console.WriteLine();
        }

        Console.SetCursorPosition(25, 0);
        Console.Write($"- {player1.Name}: Orochimaru!!");
        Console.ReadKey();
        Console.SetCursorPosition(25, 1);
        Console.Write("- Orochimaru:Veo que me han encontrado, jajaja ya es demasiado tarde para que puedan detenerme.");
        Console.ReadKey();
        Console.SetCursorPosition(25, 2);
        Console.Write($"- {player2.Name}: No creas que te saldrás con la tuya. Konoha saldrá ilesa de tus amenazas.");
        Console.ReadKey();
        Console.SetCursorPosition(25, 3);
        Console.Write("- Orochimaru: Veamos si son tan fuertes como dicen ser.");
        Console.ReadKey();
        Console.SetCursorPosition(25, 4);
        Console.Write($"- {player1.Name}: {player1.atkName}.");
        Console.ReadKey();
        Console.SetCursorPosition(25, 5);
        Console.Write("- Orochimaru:  Sen'eijashu (Manos de Serpientes Ocultas en las Sombras.)");
        Console.ReadKey();
        Console.SetCursorPosition(25, 6);
        Console.Write($"- {player2.Name} : {player2.atkName}.");
        Console.ReadKey();
        Console.SetCursorPosition(25, 8);
        Console.Write("  ( ... ) ");
        Console.ReadKey();
        Console.SetCursorPosition(25, 10);
        Console.Write($"* Orochimaru se ha debilitado y ha huido *");
        Console.ReadKey();
        Console.SetCursorPosition(25, 12);
        Console.Write($"* {player1.Name} y {player2.Name} han logrado salvar a Konoha *");
        Console.ReadKey();
        Console.Clear();
    }
    public static void ClearComentarys()
    {
        Thread.Sleep(600);
        Console.SetCursorPosition(25, 0);
        Console.Write("                                                                                               ");
        Console.SetCursorPosition(25, 1);
        Console.Write("                                                                                               ");
        Console.SetCursorPosition(25, 2);
        Console.Write("                                                                                               ");
        Console.SetCursorPosition(25, 3);
        Console.Write("                                                                                               ");
        Console.SetCursorPosition(25, 4);
        Console.Write("                                                                                               ");
        Console.SetCursorPosition(25, 5);
        Console.Write("                                                                                               ");
        Console.SetCursorPosition(25, 6);
        Console.Write("                                                                                               ");
        Console.SetCursorPosition(25, 7);
        Console.Write("                                                                                               ");
        Console.SetCursorPosition(25, 8);
        Console.Write("                                                                                               ");
        Console.SetCursorPosition(25, 9);
        Console.Write("                                                                                               ");
    }
    public static void PrintBoard2(int[,] board)
    {
        // Este metodo solo es para hacer verificaciones
        for (int i = 0; i < Program.Rows; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("\n");
            }

            for (int j = 0; j < Program.Cols; j++)
            {
                if (j == 0)
                {
                    Console.Write("");
                    if (board[i, j] < 0) { Console.Write($"  {board[i, j]} "); }
                    else if (board[i, j] < 10) { Console.Write($"  {board[i, j]} "); }
                    else if (board[i, j] < 100) { Console.Write($" {board[i, j]} "); }
                    else { Console.Write($"{board[i, j]} "); }
                }
                else
                {
                    if (board[i, j] < 0) { Console.Write($" {board[i, j]} "); }
                    else if (board[i, j] < 10) { Console.Write($"  {board[i, j]} "); }
                    else if (board[i, j] < 100) { Console.Write($" {board[i, j]} "); }
                    else { Console.Write($"{board[i, j]} "); }
                }

            }
            // Salto de linea al final de cada fila
            Console.WriteLine();
        }
        // Agregar un salto de linea al final del tablero
        Console.WriteLine("\n");
    }
}
