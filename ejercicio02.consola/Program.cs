using ConsoleTables;
using ejercicio02.entidades;

namespace ejercicio02.consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? opcionSeleccionada;
            Velocidad[] velocidades = new Velocidad[5];
            do
            {
                Console.Clear();
                Console.WriteLine("0 - salir");
                Console.WriteLine("1 - ingresar velocidades");
                Console.WriteLine("2 - mostrar velocidades");
                Console.WriteLine("3 - datos estadisticos");
                Console.WriteLine("4 - marcar superiores al promedio");
                Console.WriteLine("5 - ordenar vector");
                Console.Write("ingrese seleccion: ");
                opcionSeleccionada = Console.ReadLine();
                switch (opcionSeleccionada)
                {
                    case "0":
                        Console.WriteLine("fin de la operacion");
                        return;
                    case "1":
                        ingresarDatos(velocidades);
                        break;
                    case "2":
                        mostrarVelocidades(velocidades);
                        break;
                    case "3":
                        datosEstadisticos(velocidades);
                        break;
                    case "4":
                        marcarSuperioresPromedio(velocidades);
                        break;
                    case "5":
                        ordenarVector(velocidades);
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (true);
        }
        private static void ordenarVector(Velocidad[] velocidades)
        {
            Array.Sort(velocidades, (v1, v2) => v1.KmH.CompareTo(v2.KmH));
            mostrarVelocidades(velocidades);
        }

        private static void marcarSuperioresPromedio(Velocidad[] velocidades)
        {
            var promedio = velocidades.Average(v => v.KmH);
            Console.Clear();
            Console.WriteLine("listado de velocidades con superiores al promedio");
            Console.WriteLine($"velocidad promedio: {promedio:N2}");

            var tabla = new ConsoleTable("pos", "km", "millas", "sup. promedio");
            for (int i = 0; i < velocidades.Length; i++)
            {
                var millas = velocidades[i].MillasH;
                if (velocidades[i].KmH > promedio)
                {
                    tabla.AddRow(i, velocidades[i].KmH, millas, "*");
                }
                else
                {
                    tabla.AddRow(i, velocidades[i].KmH, millas, string.Empty);
                }
            }
            Console.WriteLine(tabla.ToString());
            esperarTecla("listado finalizado... tecla para continuar");
        }

        private static void datosEstadisticos(Velocidad[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("datos estadisticos del vector");
            var maxVelocidad = velocidades.Max(v => v.KmH);
            var minVelocidad = velocidades.Min(v => v.KmH);
            var promVelocidad = velocidades.Average(v => v.KmH);
            var cantidadInferiorPromedio = velocidades.Count(v => v.KmH < promVelocidad);
            Console.WriteLine($"mayor velocidad...: {maxVelocidad}");
            Console.WriteLine($"menor velocidad...: {minVelocidad}");
            Console.WriteLine($"velocidad promedio: {promVelocidad}");
            Console.WriteLine($"inferiores al prom: {cantidadInferiorPromedio}");
            esperarTecla("proceso finalizado... presione tecla para continuar");
        }

        private static void mostrarVelocidades(Velocidad[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("listado de velocidades");
            var tabla = new ConsoleTable("pos", "km", "millas");
            for (int i = 0; i < velocidades.Length; i++)
            {
                var millas = velocidades[i].MillasH;
                tabla.AddRow(i, velocidades[i].KmH, millas);
            }
            Console.WriteLine(tabla.ToString());
            esperarTecla("listado finalizado... tecla para continuar");
        }

        private static void ingresarDatos(Velocidad[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("ingreso de velocidades al vector ");
            for (int i = 0; i < velocidades.Length; i++)
            {
                int velocidad;
                do
                {
                    Console.Write($"ingrese la {i + 1} velocidad: ");
                    if (!int.TryParse(Console.ReadLine(), out velocidad) || velocidad < 100 || velocidad > 300)
                    {
                        Console.WriteLine("velocidad mal ingresada o fuera de rango [100 - 300] ");
                    }
                    else
                    {
                        velocidades[i] = new Velocidad(velocidad);
                        break;
                    }
                } while (true);
            }
            esperarTecla("ingreso finalizado... presione tecla para continuar");
        }

        private static void esperarTecla(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.ReadLine();
        }
    }
}
