using System;
using System.Collections.Generic;
namespace TrabajoIntegrador
{
    internal class OldProgram
    {
        //Mediante un menu, se debe poder instanciar diferentes jugadores conforme se vayan agregando
        //Ya tener instanciados algunos pre-hechos nos serviría
        //Los jugadores poseen estos atributos private string nombre, nacionalidad, posición,fechaNacimiento,goles,
        //asistencias, pasesTotales, faltasRecibidas, lesionesSufridas y valorMercado.
        //Mediante los getter podemos obtener los atributos de cada Jugador ya instanciado (ya definí la clase de antemano 😎)
        //Vamos a utilizar una estructura ==> lista, matriz o vector (tenemos que hablarlo con el profe, seguramente le pregunte a Gauthier)
        //En caso de que nos obliguen a usar vectores, hay que aprenderse el método de ordenamiento por burbujeo
        // Fecha de Entrega y presentación: En las clase del '15-10' al '22-10' como fecha límite para la entrega del proyecto y la exposición en clase.

        private static void AddPlayer(List<Jugador> players)
        {
            Console.Write("Ingrese el nombre: ");
            string nombre = StringInput();
            Console.Write("Ingrese la nacionalidad: ");
            string nacionalidad = StringInput();
            Console.Write("Ingrese la posición: ");
            string position = StringInput();
            Console.Write("Ingrese el equipo: ");
            string equipo = StringInput();
            Console.Write("Ingrese la fecha de nacimiento: ");
            DateTime? fechaNacimiento = DateInput();
            Console.Write("Ingrese la cantidad de goles: ");
            int goles = IntInput();
            Console.Write("Ingrese la cantidad de asistencias: ");
            int asistencias = IntInput();
            Console.Write("Ingrese la cantidad de pases: ");
            int pases = IntInput();
            Console.Write("Ingrese la cantidad de faltas recibidas: ");
            int faltas = IntInput();
            Console.Write("Ingrese la cantidad de lesiones sufridas: ");
            int lesiones = IntInput();
            Console.Write("Ingrese el valor en el mercado: ");
            double valorMercado = DoubleInput();
            if (
                nombre != null && nacionalidad != null && position != null &&
                fechaNacimiento != null && goles != -1 && asistencias != -1 &&
                pases != -1 && faltas != -1 && lesiones != -1 && valorMercado != -1
                )
            {
                players.Add(new Jugador(nombre, nacionalidad, position, equipo, (DateTime)fechaNacimiento, goles, asistencias, pases, faltas, lesiones, valorMercado));
            }
            else
            {
                Console.WriteLine("No se ha añadido el jugador, faltan datos.");
            }
        }

        private static void ChangeColor(ConsoleColor cc) => Console.ForegroundColor = cc;

        private static DateTime? DateInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dt))
            {
                Console.ResetColor();
                return dt;
            }
            Console.ResetColor();
            return null;
        }

        private static double DoubleInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (double.TryParse(Console.ReadLine(), out double n))
            {
                Console.ResetColor();
                return n;
            }
            Console.ResetColor();
            return -1;
        }

        private static void DrawBorder()
        {
            ChangeColor(ConsoleColor.Blue);
            Console.Write("╠");
            for (int i = 0; i < 38; i++)
            {
                Console.Write("─");
            }
            Console.Write("╣\n");
        }

        private static void Informe(List<Jugador> players)
        {
            //Promedio de goles por jugadores
            double PromedioGoles()
            {
                int cantGoles = 0;
                foreach (Jugador j in players)
                {
                    cantGoles += j.Goles;
                }
                return cantGoles / players.Count;
            }
            Console.WriteLine($"PROMEDIO DE GOLES POR JUGADOR = {PromedioGoles():n2}");
            //Promedio de asistencias por jugadores
            double PromedioAsistencias()
            {
                int cantAsists = 0;
                foreach (Jugador j in players)
                {
                    cantAsists += j.Asistencias;
                }
                return cantAsists / players.Count;
            }
            Console.WriteLine($"PROMEDIO DE ASISTENCIAS POR JUGADOR = {PromedioAsistencias():n2}");
            //Promedio de goles por equipos
            void GolesPorEquipo()
            {
                Dictionary<String, int> GpE = new Dictionary<string, int>();
                int cantGoles = 0;
                foreach (Jugador j in players)
                {
                    if (GpE.ContainsKey(j.Equipo))
                    {
                        GpE[j.Equipo] += j.Goles;
                    }
                    else
                    {
                        GpE.Add(j.Equipo, j.Goles);
                    }
                    cantGoles += j.Goles;

                }
                if (GpE.Count > 0 && cantGoles > 0)
                {
                    foreach (KeyValuePair<String, int> equipo in GpE)
                    {
                        Console.WriteLine($"Porcentaje de goles del equipo '{equipo.Key}' sobre el total = {(double)(equipo.Value*100/cantGoles):n2}% con {equipo.Value} goles.");
                    }
                }
            }
            GolesPorEquipo();
            //Jugador con más pases
            void JugadorMasPases()
            {
                Jugador j = new Jugador(0);
                foreach (Jugador p in players)
                {
                    if (p.PasesTotales >= j.PasesTotales)
                        j = p;

                }
                Console.WriteLine($"El Jugador con más pases es {j.Nombre} del equipo {j.Equipo} con {j.PasesTotales} pases totales.");
            }
            JugadorMasPases();
            //Jugador con más faltas recibidas
            void JugadorMasFaltas()
            {
                Jugador j = new Jugador();
                j.FaltasRecibidas = 0;
                foreach (Jugador p in players)
                {
                    if (p.FaltasRecibidas >= j.FaltasRecibidas)
                        j = p;
                }
                Console.WriteLine($"El Jugador con más faltas es {j.Nombre} del equipo {j.Equipo} con {j.FaltasRecibidas} faltas recibidas.");
            }
            JugadorMasFaltas();
            //Jugador con mas lesiones
            void JugadorMasLesiones()
            {
                Jugador j = new Jugador();
                j.LesionesSufridas = 0;
                foreach (Jugador p in players)
                {
                    if (p.LesionesSufridas >= j.LesionesSufridas)
                        j = p;
                }
                Console.WriteLine($"El Jugador con más lesiones es {j.Nombre} del equipo {j.Equipo} con {j.LesionesSufridas} lesiones sufridas.");
            }
            JugadorMasLesiones();
            //Jugador mas caro y mas barato
            void JugadorMasCaroYMasBarato()
            {
                Jugador caro = new Jugador(0.0);
                Jugador barato = new Jugador(99999999.0);
                foreach (Jugador j in players)
                {
                    if (j.ValorMercado >= caro.ValorMercado)
                    {
                        caro = j;
                    }
                    if (j.ValorMercado <= barato.ValorMercado)
                    {
                        barato = j;
                    }
                }
                Console.WriteLine($"Jugador más caro = {caro.Nombre} del equipo {caro.Equipo} ==> ${caro.ValorMercado:n2}");
                if (!(barato.Nombre == "" || string.IsNullOrEmpty(barato.Nombre)))
                    Console.WriteLine($"Jugador más barato = {barato.Nombre} del equipo {barato.Equipo} ==> ${barato.ValorMercado:n2}");
                else
                {
                    Console.WriteLine("No existe un jugador más barato.");
                }
            }
            JugadorMasCaroYMasBarato();
        }

        private static int IntInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Console.ResetColor();
                return n;
            }
            Console.ResetColor();
            return -1;
        }

        private static void ListOption(int n, string desc)
        {
            ChangeColor(ConsoleColor.Blue);
            Console.Write('║');
            ChangeColor(ConsoleColor.Cyan);
            Console.Write($" {n} ");
            Console.ResetColor();
            Console.Write("-> ");
            ChangeColor(ConsoleColor.Green);
            Console.Write($"{desc}. ");
            ChangeColor(ConsoleColor.Blue);
            int totalLength = 39;
            int currentLength = 9 + desc.Length;
            int spaces = totalLength - currentLength;
            Console.Write(new string(' ', spaces));
            ChangeColor(ConsoleColor.Blue);
            Console.WriteLine('║');
            Console.ResetColor();
        }
        private static int Menu()
        {
            char supIzq = '╔', supDer = '╗', infIzq = '╚', infDer = '╝',
                borHorizon = '═';
            ConsoleColor borderColor = ConsoleColor.Blue;
            ChangeColor(borderColor);
            Console.Write(supIzq);
            for (int i = 0; i < 38; i++)
            {
                Console.Write(borHorizon);
            }
            Console.WriteLine(supDer);
            Console.WriteLine("║              BIENVENIDO!             ║");
            Console.Write("╠");
            for (int i = 0; i < 38; i++)
            {
                Console.Write(borHorizon);
            }
            Console.Write("╣\n");
            ListOption(1, "Añadir Jugador");
            DrawBorder();
            ListOption(2, "Listar Jugadores");
            DrawBorder();
            ListOption(3, "Buscar Jugador por nombre");
            DrawBorder();
            ListOption(4, "Generar Informe");
            DrawBorder();
            ListOption(5, "Salir");
            ChangeColor(borderColor);
            Console.Write(infIzq);
            for (int i = 0; i < 38; i++)
            {
                Console.Write(borHorizon);
            }
            Console.WriteLine(infDer);
            Console.ResetColor();
            Console.Write("Ingrese una opción: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (int.TryParse(Console.ReadLine(), out int selection))
            {
                Console.ResetColor();
                return selection;
            }
            Console.ResetColor();
            return -1;
        }
        private static void Search(List<Jugador> players, string nombre)
        {
            bool found = false;
            foreach (Jugador j in players)
            {
                if (j.Nombre.Equals(nombre))
                {
                    found = true;
                    Console.WriteLine("Encontrado!");
                    Console.WriteLine(j);
                }
            }
            if (!found)
            {
                Console.WriteLine($"No se ha encontrado un jugador llamado: {nombre}");
            }
        }
        private static void Sort(List<Jugador> players, int mode)
        {
            if (mode == 1)
            {
                players.Sort((p1, p2) => p1.Equipo.CompareTo(p2.Equipo));
            }
            else
            {
                players.Sort((p1, p2) => p1.Nombre.CompareTo(p2.Nombre));
            }
            foreach (Jugador j in players)
            {
                Console.WriteLine(j);
            }
        }
        private static string StringInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string s = Console.ReadLine();
            Console.ResetColor();
            return s;
        }
        private static void Main2(string[] args)
        {
            List<Jugador> players = new List<Jugador>();
            int option = -1;
            do
            {
                option = Menu();
                switch (option)
                {
                    case 1:
                        AddPlayer(players);
                        break;

                    case 2:
                        if (players.Count > 0)
                        {
                            ListOption(1, "Por equipo");
                            ListOption(2, "Alfabéticamente");
                            if (int.TryParse(Console.ReadLine(), out int sortOption) && sortOption == 1 || sortOption == 2)
                            {
                                Sort(players, sortOption);
                            }
                            else
                            {
                                Console.WriteLine("Ingrese un valor válido!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No existen jugadores!");
                        }

                        break;

                    case 3:
                        if (players.Count > 0)
                        {
                            Console.Write("Ingrese el nombre: ");
                            string searchNombre = StringInput();
                            if (searchNombre != null)
                            {
                                Search(players, searchNombre);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No existen jugadores!");
                        }
                        break;

                    case 4:
                        if (players.Count > 0)
                        {
                            Informe(players);
                        }
                        else
                        {
                            Console.WriteLine("No existen jugadores!");
                        }
                        break;

                    case 5:
                        //SALIR
                        break;

                    default:
                        Console.WriteLine("Ingrese una opción válida!");
                        break;
                }
                Console.ReadKey(true);
                Console.Clear();
            } while (option != 5);
            Console.ResetColor();
        }
    }
}