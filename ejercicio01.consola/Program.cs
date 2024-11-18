using ConsoleTables;
using ejercicio01.entidades;
using System.Text;

namespace ejercicio01.consola
{
    internal class Program
    {
        private static readonly Random random = new Random();
        private static VectorDatos vectorDatos;
        static void Main(string[] args)
        {
            vectorDatos = new VectorDatos(10);
            int opcionSeleccionada;

            do
            {
                MostrarMenu();
                opcionSeleccionada = ObtenerOpcionSeleccionada();

                switch (opcionSeleccionada)
                {
                    case 0:
                        Console.WriteLine("Fin de la aplicación");
                        break;
                    case 1:
                        GenerarElementos();
                        break;
                    case 2:
                        MostrarVector();
                        break;
                    case 3:
                        Estadisticas();
                        break;
                    case 4:
                        OrdenarVector();
                        break;
                    case 5:
                        MostrarPares();
                        break;
                    case 6:
                        MostrarPrimos();
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Pausar();
                        break;
                }
            } while (opcionSeleccionada != 0);
        }
        private static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("0 - salir");
            Console.WriteLine("1 - generar vector");
            Console.WriteLine("2 - mostrar vector");
            Console.WriteLine("3 - estadisticas");
            Console.WriteLine("4 - ordenar vector");
            Console.WriteLine("5 - mostrar numeros pares");
            Console.WriteLine("6 - mostrar numeros primos");
        }

        private static int ObtenerOpcionSeleccionada()
        {
            int opcionSeleccionada;
            do
            {
                Console.Write("Ingrese selección: ");
                if (int.TryParse(Console.ReadLine(), out opcionSeleccionada))
                {
                    break;
                }
                Console.WriteLine("¡¡¡Opción mal ingresada!!! Reintentar");
            } while (true);

            return opcionSeleccionada;
        }

        private static void Pausar()
        {
            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
        }

        private static void GenerarElementos()
        {
            vectorDatos.GenerarElementos(random);
            Console.WriteLine("Números generados...");
            Pausar();
        }

        private static void MostrarVector()
        {
            if (vectorDatos.EstaVacio())
            {
                Console.WriteLine("¡¡¡Vector vacío!!!");
                Pausar();
                return;
            }

            var elementos = vectorDatos.ObtenerElementos();
            for (int i = 0; i < elementos.Length; i++)
            {
                Console.WriteLine($"Posición: {i}, Valor: {elementos[i]}");
            }
            Pausar();
        }

        private static void Estadisticas()
        {
            if (vectorDatos.EstaVacio())
            {
                Console.WriteLine("¡¡¡Vector vacío!!!");
                Pausar();
                return;
            }

            Console.WriteLine($"Menor elemento: {vectorDatos.MenorElemento()}");
            Console.WriteLine($"Mayor elemento: {vectorDatos.MayorElemento()}");
            Console.WriteLine($"Media de elementos: {vectorDatos.MediaElementos()}");
            Pausar();
        }

        private static void OrdenarVector()
        {
            vectorDatos.OrdenarVector();
            Console.WriteLine("Vector ordenado.");
            MostrarVector();
        }

        private static void MostrarPares()
        {
            if (vectorDatos.EstaVacio())
            {
                Console.WriteLine("¡¡¡Vector vacío!!!");
                Pausar();
                return;
            }

            var elementos = vectorDatos.ObtenerElementos();
            for (int i = 0; i < elementos.Length; i++)
            {
                if (vectorDatos.EsPar(elementos[i]))
                {
                    Console.WriteLine($"Posición: {i}, Valor: {elementos[i]} - Par");
                }
            }
            Pausar();
        }

        private static void MostrarPrimos()
        {
            if (vectorDatos.EstaVacio())
            {
                Console.WriteLine("¡¡¡Vector vacío!!!");
                Pausar();
                return;
            }

            var elementos = vectorDatos.ObtenerElementos();
            for (int i = 0; i < elementos.Length; i++)
            {
                if (vectorDatos.EsPrimo(elementos[i]))
                {
                    Console.WriteLine($"Posición: {i}, Valor: {elementos[i]} - Primo");
                }
            }
            Pausar();
        }
    }
}
