using ConsoleTables;
using ejercicio03.entidades;

namespace ejercicio03.consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? opcionSeleccionada;
            Persona[] personas = new Persona[8];
            do
            {
                Console.Clear();
                Console.WriteLine("0 - salir");
                Console.WriteLine("1 - ingresar personas");
                Console.WriteLine("2 - mostrar personas");
                Console.WriteLine("3 - mostrar nombres por letra");
                Console.WriteLine("4 - estadisticas");
                Console.WriteLine("5 - ordenar vector");
                Console.WriteLine("6 - listado de nombres con datos");
                Console.Write("ingrese seleccion: ");
                opcionSeleccionada = Console.ReadLine();
                switch (opcionSeleccionada)
                {
                    case "0":
                        Console.WriteLine("fin de la aplicacion");
                        return;
                    case "1":
                        ingresarPersonas(personas);
                        break;
                    case "2":
                        listadoDePersonas(personas);
                        break;
                    case "3":
                        listadoPorLetraInicial(personas);
                        break;
                    case "4":
                        estadisticaPorLetra(personas);
                        break;
                    case "5":
                        ordenarVector(personas);
                        break;
                    case "6":
                        mostrarMasDatos(personas);
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (true);
        }
        private static void mostrarMasDatos(Persona[] personas)
        {
            Console.Clear();
            Console.WriteLine("listado de nombres con datos adicionales");
            var tabla = new ConsoleTable("nombre", "cant. letras", "cant. vocales");
            foreach (var persona in personas.Where(p => !string.IsNullOrEmpty(p.Nombre)))
            {
                tabla.AddRow(persona.Nombre, persona.CantidadLetras, persona.CantidadVocales);
            }
            Console.WriteLine(tabla.ToString());
            esperaTecla("¡¡¡listado de nombres terminado!!!");
        }

        private static void ordenarVector(Persona[] personas)
        {
            var personasOrdenadas = personas
                .Where(p => !string.IsNullOrEmpty(p.Nombre))
                .OrderBy(p => p.Nombre)
                .ToArray();

            Console.Clear();
            Console.WriteLine("listado ordenado de nombres");
            imprimirListado(personasOrdenadas);
            esperaTecla("listado ordenado finalizado");
        }

        private static void estadisticaPorLetra(Persona[] personas)
        {
            Console.Clear();
            Console.WriteLine("nombres por letra inicial");
            var tabla = new ConsoleTable("letra", "cantidad");
            for (int i = 65; i <= 90; i++)
            {
                char letra = (char)i;
                int cantidad = personas
                    .Where(p => !string.IsNullOrEmpty(p.Nombre) && p.Nombre.ToUpper().StartsWith(letra.ToString()))
                    .Count();

                tabla.AddRow(letra, cantidad);
            }
            Console.WriteLine(tabla.ToString());
            esperaTecla("listado por letra finalizado");
        }

        private static void listadoPorLetraInicial(Persona[] personas)
        {
            Console.Clear();
            Console.WriteLine("listado de nombres por letra inicial");
            Console.Write("ingrese letra: ");
            string letra = Console.ReadLine().ToUpper();
            var tabla = new ConsoleTable("nombre");
            foreach (var persona in personas.Where(p => !string.IsNullOrEmpty(p.Nombre) && p.Nombre.ToUpper().StartsWith(letra)))
            {
                tabla.AddRow(persona.Nombre);
            }
            Console.WriteLine(tabla.ToString());
            esperaTecla("¡¡¡listado de nombres por letra terminado!!!");
        }

        private static void listadoDePersonas(Persona[] personas)
        {
            Console.Clear();
            Console.WriteLine("listado de personas");
            imprimirListado(personas);
            esperaTecla("¡¡¡listado de nombres terminado!!!");
        }

        private static void imprimirListado(Persona[] personas)
        {
            var tabla = new ConsoleTable("nombre");
            foreach (var persona in personas.Where(p => !string.IsNullOrEmpty(p.Nombre)))
            {
                tabla.AddRow(persona.Nombre);
            }
            Console.WriteLine(tabla.ToString());
        }

        private static void ingresarPersonas(Persona[] personas)
        {
            for (int i = 0; i < personas.Length; i++)
            {
                Console.Write($"ingrese el {i + 1}° nombre: ");
                string nombre = Console.ReadLine();
                personas[i] = new Persona(nombre);
            }
            esperaTecla("¡¡¡ingreso de nombres terminado!!!");
        }

        private static void esperaTecla(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.ReadLine();
        }
    }
}
