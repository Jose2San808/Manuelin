using System;
using System.Collections.Generic;

namespace Manuelin
{
    class Program
    {
        static int TamañoTablaHash = 0;
        static List<string>[] TablaHashDivision;
        static List<string>[] TablaHashMultiplicacion;
        static List<string>[] TablaHashSuma;

        static void Main(string[] args)
        {
            Console.Write("Ingrese el tamaño de la tabla hash: ");
            TamañoTablaHash = int.Parse(Console.ReadLine());

            TablaHashDivision = new List<string>[TamañoTablaHash];
            TablaHashMultiplicacion = new List<string>[TamañoTablaHash];
            TablaHashSuma = new List<string>[TamañoTablaHash];

            for (int i = 0; i < TamañoTablaHash; i++)
            {
                TablaHashDivision[i] = new List<string>();
                TablaHashMultiplicacion[i] = new List<string>();
                TablaHashSuma[i] = new List<string>();
            }

            while (true)
            {
                Console.WriteLine("\nMENÚ:");
                Console.WriteLine("1. Elegir método de hash");
                Console.WriteLine("2. Mostrar tablas hash (solo claves)");
                Console.WriteLine("3. Mostrar tablas completas (claves y contenido)");
                Console.WriteLine("4. Salir");
                Console.Write("Ingrese su opción: ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ElegirMetodoHash();
                        break;
                    case 2:
                        MostrarTablasSoloClaves();
                        break;
                    case 3:
                        MostrarTablasContenidoCompleto();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        static int FuncionHashDivision(int clave)
        {
            return clave % TamañoTablaHash;
        }

        static int FuncionHashMultiplicacion(int clave)
        {
            double A = (Math.Sqrt(5) - 1) / 2;
            return (int)Math.Truncate(TamañoTablaHash * ((clave * A) % 1));
        }

        static int FuncionHashSuma(int clave)
        {
            int suma = 0;
            while (clave > 0)
            {
                suma += clave % 10;
                clave /= 10;
            }
            return suma % TamañoTablaHash;
        }

        static void ElegirMetodoHash()
        {
            Console.WriteLine($"MÉTODOS DE HASH DISPONIBLES:");
            Console.WriteLine("1. Método de división");
            Console.WriteLine("2. Método de multiplicación");
            Console.WriteLine("3. Método de suma");
            Console.Write("Ingrese el número del método de hash que desea utilizar: ");
            int metodo = int.Parse(Console.ReadLine());

            if (metodo < 1 || metodo > 3)
            {
                Console.WriteLine("Opción no válida. Seleccionando método de división por defecto.");
                metodo = 1;
            }

            Console.Write("Ingrese la clave: ");
            int clave = int.Parse(Console.ReadLine());

            int indice;
            switch (metodo)
            {
                case 1:
                    indice = FuncionHashDivision(clave);
                    TablaHashDivision[indice].Add(clave.ToString());
                    Console.WriteLine("Clave agregada a la tabla hash usando el método de división.");
                    break;
                case 2:
                    indice = FuncionHashMultiplicacion(clave);
                    TablaHashMultiplicacion[indice].Add(clave.ToString());
                    Console.WriteLine("Clave agregada a la tabla hash usando el método de multiplicación.");
                    break;
                case 3:
                    indice = FuncionHashSuma(clave);
                    TablaHashSuma[indice].Add(clave.ToString());
                    Console.WriteLine("Clave agregada a la tabla hash usando el método de suma.");
                    break;
                default:
                    break;
            }
        }

        static void MostrarTablasSoloClaves()
        {
            Console.WriteLine("\nTABLAS HASH (SOLO CLAVES):");
            Console.WriteLine("Método de división:");
            for (int i = 0; i < TamañoTablaHash; i++)
            {
                if (TablaHashDivision[i].Count == 0)
                {
                    Console.WriteLine($"Índice {i}: *******");
                }
                else
                {
                    Console.WriteLine($"Índice {i}: {string.Join(", ", TablaHashDivision[i])}");
                }
            }

            Console.WriteLine("\nMétodo de multiplicación:");
            for (int i = 0; i < TamañoTablaHash; i++)
            {
                if (TablaHashMultiplicacion[i].Count == 0)
                {
                    Console.WriteLine($"Índice {i}: *******");
                }
                else
                {
                    Console.WriteLine($"Índice {i}: {string.Join(", ", TablaHashMultiplicacion[i])}");
                }
            }

            Console.WriteLine($"Método de suma:");
            for (int i = 0; i < TamañoTablaHash; i++)
            {
                if (TablaHashSuma[i].Count == 0)
                {
                    Console.WriteLine($"Índice {i}: *******");
                }
                else
                {
                    Console.WriteLine($"Índice {i}: {string.Join(", ", TablaHashSuma[i])}");
                }
            }
        }

        static void MostrarTablasContenidoCompleto()
        {
            Console.WriteLine($"TABLAS HASH (CLAVES Y CONTENIDO):");
            Console.WriteLine("Método de división:");
            for (int i = 0; i < TamañoTablaHash; i++)
            {
                if (TablaHashDivision[i].Count == 0)
                {
                    Console.WriteLine($"Índice {i}: *******");
                }
                else
                {
                    Console.WriteLine($"Índice {i}: {string.Join(", ", TablaHashDivision[i])}");
                }
            }

            Console.WriteLine($"Método de multiplicación:");
            for (int i = 0; i < TamañoTablaHash; i++)
            {
                if (TablaHashMultiplicacion[i].Count == 0)
                {
                    Console.WriteLine($"Índice {i}: *******");
                }
                else
                {
                    Console.WriteLine($"Índice {i}: {string.Join(", ", TablaHashMultiplicacion[i])}");
                }
            }

            Console.WriteLine($"Método de suma:");
            for (int i = 0; i < TamañoTablaHash; i++)
            {
                if (TablaHashSuma[i].Count == 0)
                {
                    Console.WriteLine($"Índice {i}: *******");
                }
                else
                {
                    Console.WriteLine($"Índice {i}: {string.Join(", ", TablaHashSuma[i])}");
                }
            }
        }
    }
}