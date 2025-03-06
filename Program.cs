
namespace Konoha_Maze
{
    // Que me expliquen esto
    public static class Program
    {
        static void Main(string[] args)
        {
            Start_End Visual = new Start_End();
            Play playGame= new Play();
            // Visual.StartGame();
            while (true)
            {
                Visual.Menu();
                int errorCount = 0;
                string? doingSomething = Console.ReadLine()?.ToUpper().Trim();
                while (true)
                {
                    if (doingSomething != "GAME INFORMATION" && doingSomething != "PLAY" && doingSomething != "EXIT")
                    {
                        if (errorCount == 3)
                        {
                            errorCount = 0;
                            Console.Clear();
                            Console.WriteLine("\t\t < MENU >");
                            Console.WriteLine("\t* Play");
                            Console.WriteLine("");
                            Console.WriteLine("\t* Game Information");
                            Console.WriteLine("");
                            Console.WriteLine("\t* Exit");
                            Console.WriteLine("");
                            Console.WriteLine("\t   Elija una opcion.");
                            doingSomething = Console.ReadLine()?.ToUpper().Trim();

                        }
                        else
                        {
                            Console.WriteLine("\t   Opcion no valida. Escoja una opcion de la lista.");
                            doingSomething = Console.ReadLine()?.ToUpper().Trim();
                            errorCount++;
                        }
                    }
                    else { break; }
                }
                switch (doingSomething)
                {
                    case "PLAY":
                        Console.Clear();
                        Dictionary<int, string> ListaDePersonajes = new Dictionary<int, string>
                        {
                          { 1, "NARUTO"},
                          { 2, "SAKURA"},
                          { 3, "SASUKE"},
                          { 4, "KAKASHI"},
                          { 5, "HINATA"},
                          { 6, "INO"}
                        };

                        Console.WriteLine("\n\tPlayer 1 por favor escoja un personaje de la lista escribiendo el nombre.\n");
                        foreach (KeyValuePair<int, string> Persons in ListaDePersonajes)
                        {
                            Console.WriteLine($"\t{Persons.Key} -  {Persons.Value}");
                        }
                        Console.WriteLine();
                        string? jugador1 = Console.ReadLine()?.ToUpper().Trim();
                        while (true)
                        {
                            if (jugador1 != "NARUTO" && jugador1 != "SAKURA" && jugador1 != "SASUKE" && jugador1 != "KAKASHI" && jugador1 != "HINATA" && jugador1 != "INO")
                            {
                                Console.WriteLine();
                                Console.WriteLine("\tPersonaje no valido. Por favor escoja un personaje de la lista.");
                                jugador1 = Console.ReadLine()?.ToUpper().Trim();
                            }
                            else { break; }
                        }

                        for (int i = 1; i <= ListaDePersonajes.Count; i++)
                        {
                            if (ListaDePersonajes[i] == jugador1)
                            {
                                ListaDePersonajes[i] += "      Player 1";
                            }
                        }
                        Player.Personajes x;
                        switch (jugador1)
                        {
                            case "NARUTO":
                                x = Player.Personajes.Naruto;
                                break;
                            case "SAKURA":
                                x = Player.Personajes.Sakura;
                                break;
                            case "SASUKE":
                                x = Player.Personajes.Sasuke;
                                break;
                            case "KAKASHI":
                                x = Player.Personajes.Kakashi;
                                break;
                            case "HINATA":
                                x = Player.Personajes.Hinata;
                                break;
                            case "INO":
                                x = Player.Personajes.Ino;
                                break;
                            default:
                                throw new NotImplementedException();
                        }

                        Console.WriteLine("\n\tPlayer 2 por favor escoja un personaje de la lista escribiendo el nombre.\n");
                        foreach (KeyValuePair<int, string> Persons in ListaDePersonajes)
                        {
                            Console.WriteLine($"\t{Persons.Key} -  {Persons.Value}");
                        }
                        Console.WriteLine();
                        string? jugador2 = Console.ReadLine()?.ToUpper().Trim();
                        while (true)
                        {
                            if (jugador1 == jugador2 || (jugador2 != "NARUTO" && jugador2 != "SAKURA" && jugador2 != "SASUKE" && jugador2 != "KAKASHI" && jugador2 != "HINATA" && jugador2 != "INO"))
                            {
                                Console.WriteLine();
                                Console.WriteLine("\tPersonaje no valido. Por favor escoja un personaje de la lista.");
                                jugador2 = Console.ReadLine()?.ToUpper().Trim();
                            }
                            else break;
                        }

                        Player.Personajes y;
                        switch (jugador2)
                        {
                            case "NARUTO":
                                y = Player.Personajes.Naruto;
                                break;
                            case "SAKURA":
                                y = Player.Personajes.Sakura;
                                break;
                            case "SASUKE":
                                y = Player.Personajes.Sasuke;
                                break;
                            case "KAKASHI":
                                y = Player.Personajes.Kakashi;
                                break;
                            case "HINATA":
                                y = Player.Personajes.Hinata;
                                break;
                            case "INO":
                                y = Player.Personajes.Ino;
                                break;
                            default:
                                throw new NotImplementedException();
                        }

                        Player p1 = new Player(x);
                        Player p2 = new Player(y);

                        // System.Console.WriteLine(a.Name);
                        // System.Console.WriteLine((int)x);

                        // ConsoleKeyInfo key = System.Console.ReadKey();

                        // Console.WriteLine(key.KeyChar);

                        // if (key.KeyChar == 'r')
                        //     System.Console.WriteLine("yey");

                        // Llamar al metodo TypeOfBox para generar el board2
                        Board.TypeOfBox();
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Visual.PrintBoard();
                        // Llamar al metodo LeeAlgorithm para calcular las distancias minimas
                        // int[,] distances = Lee.LeeAlgorithm(Board.mask, 1, 1);
                        string winPlayer = playGame.Jugar(p1, p2);
                        Visual.EndGame(p1, p2);
                        Console.WriteLine("\tLa partida la ha ganado " + winPlayer + ".");
                        Console.ReadKey(false);
                        Console.Clear();
                        break;
                    case "GAME INFORMATION":
                        Visual.HowToPlay();
                        break;
                    case "EXIT":
                        return;
                        // default:
                        //     throw new NotImplementedException();
                }
            }

        }
        public const int Rows = 13;
        public const int Cols = 21;

    }
}
