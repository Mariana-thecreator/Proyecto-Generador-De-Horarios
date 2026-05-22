using System;
using System.IO;

class Program
{
    // ==============================
    // VARIABLES GLOBALES
    // ==============================

    // Arreglo de cursos (nodos)
    static string[] cursos = new string[50];

    // Matriz de adyacencia (conflictos)
    static int[,] matriz = new int[50, 50];

    // Arreglo de colores (bloques horarios)
    static int[] colores = new int[50];

    // Cantidad actual de cursos
    static int cantidadCursos = 0;

    // ==============================
    // MAIN
    // ==============================

    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine(" SISTEMA DE HORARIOS ACADÉMICOS ");
            Console.WriteLine("====================================");

            Console.WriteLine("1. Cargar cursos desde archivo");
            Console.WriteLine("2. Agregar curso");
            Console.WriteLine("3. Eliminar curso");
            Console.WriteLine("4. Mostrar cursos");
            Console.WriteLine("5. Agregar conflicto");
            Console.WriteLine("6. Eliminar conflicto");
            Console.WriteLine("7. Mostrar matriz de adyacencia");
            Console.WriteLine("8. Generar horarios (Greedy)");
            Console.WriteLine("9. Validar horarios");
            Console.WriteLine("10. Mostrar matriz horaria");
            Console.WriteLine("11. Salir");

            Console.Write("\nSeleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:

                    Console.Write("\nIngrese el nombre del archivo: ");
                    string archivo = Console.ReadLine();

                    CargarArchivo(archivo);

                    break;

                case 2:

                    Console.Write("\nIngrese el nombre del curso: ");
                    string nombreCurso = Console.ReadLine();

                    AgregarCurso(nombreCurso);

                    break;

                case 3:

                    Console.Write("\nIngrese el curso a eliminar: ");
                    string cursoEliminar = Console.ReadLine();

                    EliminarCurso(cursoEliminar);

                    break;

                case 4:

                    MostrarCursos();

                    break;

                case 5:

                    Console.Write("\nIngrese el primer curso: ");
                    string curso1 = Console.ReadLine();

                    Console.Write("Ingrese el segundo curso: ");
                    string curso2 = Console.ReadLine();

                    AgregarConflicto(curso1, curso2);

                    break;

                case 6:

                    Console.Write("\nIngrese el primer curso: ");
                    string cursoA = Console.ReadLine();

                    Console.Write("Ingrese el segundo curso: ");
                    string cursoB = Console.ReadLine();

                    EliminarConflicto(cursoA, cursoB);

                    break;

                case 7:

                    MostrarMatriz();

                    break;

                case 8:

                    GenerarHorarios();

                    break;

                case 9:

                    ValidarHorarios();

                    break;

                case 10:

                    MostrarMatrizHoraria();

                    break;

                case 11:

                    Console.WriteLine("\nSaliendo del sistema...");

                    break;

                default:

                    Console.WriteLine("\nOpción inválida.");

                    break;
            }

        } while (opcion != 11);
    }

    // ==============================
    // BUSCAR CURSO
    // ==============================

    static int BuscarCurso(string nombre)
    {
        for (int i = 0; i < cantidadCursos; i++)
        {
            if (cursos[i] == nombre)
            {
                return i;
            }
        }

        return -1;
    }

    // ==============================
    // AGREGAR CURSO
    // ==============================

    static void AgregarCurso(string nombre)
    {
        if (BuscarCurso(nombre) != -1)
        {
            Console.WriteLine("\nEl curso ya existe.");
            return;
        }

        cursos[cantidadCursos] = nombre;

        colores[cantidadCursos] = -1;

        cantidadCursos++;

        Console.WriteLine("\nCurso agregado correctamente.");
    }

    // ==============================
    // ELIMINAR CURSO
    // ==============================

    static void EliminarCurso(string nombre)
    {
        int pos = BuscarCurso(nombre);

        if (pos == -1)
        {
            Console.WriteLine("\nEl curso no existe.");
            return;
        }

        // Mover cursos
        for (int i = pos; i < cantidadCursos - 1; i++)
        {
            cursos[i] = cursos[i + 1];
            colores[i] = colores[i + 1];
        }

        // Mover filas
        for (int i = pos; i < cantidadCursos - 1; i++)
        {
            for (int j = 0; j < cantidadCursos; j++)
            {
                matriz[i, j] = matriz[i + 1, j];
            }
        }

        // Mover columnas
        for (int j = pos; j < cantidadCursos - 1; j++)
        {
            for (int i = 0; i < cantidadCursos; i++)
            {
                matriz[i, j] = matriz[i, j + 1];
            }
        }

        cantidadCursos--;

        Console.WriteLine("\nCurso eliminado correctamente.");
    }

    // ==============================
    // MOSTRAR CURSOS
    // ==============================

    static void MostrarCursos()
    {
        if (cantidadCursos == 0)
        {
            Console.WriteLine("\nNo hay cursos registrados.");
            return;
        }

        Console.WriteLine("\n===== LISTA DE CURSOS =====");

        for (int i = 0; i < cantidadCursos; i++)
        {
            Console.WriteLine((i + 1) + ". " + cursos[i]);
        }
    }

    // ==============================
    // AGREGAR CONFLICTO
    // ==============================

    static void AgregarConflicto(string curso1, string curso2)
    {
        int i = BuscarCurso(curso1);
        int j = BuscarCurso(curso2);

        // Validar existencia
        if (i == -1 || j == -1)
        {
            Console.WriteLine("\nUno o ambos cursos no existen.");
            return;
        }

        // Validar mismo curso
        if (i == j)
        {
            Console.WriteLine("\nUn curso no puede tener conflicto consigo mismo.");
            return;
        }

        // Validar conflicto repetido
        if (matriz[i, j] == 1)
        {
            Console.WriteLine("\nEse conflicto ya existe.");
            return;
        }

        // Grafo NO dirigido
        matriz[i, j] = 1;
        matriz[j, i] = 1;

        Console.WriteLine("\nConflicto agregado correctamente.");
    }

    // ==============================
    // ELIMINAR CONFLICTO
    // ==============================

    static void EliminarConflicto(string curso1, string curso2)
    {
        int i = BuscarCurso(curso1);
        int j = BuscarCurso(curso2);

        if (i == -1 || j == -1)
        {
            Console.WriteLine("\nUno o ambos cursos no existen.");
            return;
        }

        if (matriz[i, j] == 0)
        {
            Console.WriteLine("\nEse conflicto no existe.");
            return;
        }

        matriz[i, j] = 0;
        matriz[j, i] = 0;

        Console.WriteLine("\nConflicto eliminado correctamente.");
    }

    // ==============================
    // MOSTRAR MATRIZ
    // ==============================

    static void MostrarMatriz()
    {
        if (cantidadCursos == 0)
        {
            Console.WriteLine("\nNo hay cursos registrados.");
            return;
        }

        Console.WriteLine("\n===== MATRIZ DE ADYACENCIA =====\n");

        Console.Write("".PadRight(15));

        // Encabezados
        for (int i = 0; i < cantidadCursos; i++)
        {
            Console.Write(cursos[i].PadRight(15));
        }

        Console.WriteLine();

        // Filas
        for (int i = 0; i < cantidadCursos; i++)
        {
            Console.Write(cursos[i].PadRight(15));

            for (int j = 0; j < cantidadCursos; j++)
            {
                Console.Write(matriz[i, j].ToString().PadRight(15));
            }

            Console.WriteLine();
        }
    }

    // ==============================
    // COLOREADO GREEDY
    // ==============================

    static void GenerarHorarios()
    {
        if (cantidadCursos == 0)
        {
            Console.WriteLine("\nNo hay cursos registrados.");
            return;
        }

        // Reiniciar colores
        for (int i = 0; i < cantidadCursos; i++)
        {
            colores[i] = -1;
        }

        // Primer nodo
        colores[0] = 0;

        // Colores disponibles
        bool[] disponible = new bool[50];

        // Recorrer nodos
        for (int i = 1; i < cantidadCursos; i++)
        {
            // Todos disponibles inicialmente
            for (int j = 0; j < 50; j++)
            {
                disponible[j] = true;
            }

            // Revisar vecinos
            for (int j = 0; j < cantidadCursos; j++)
            {
                if (matriz[i, j] == 1 && colores[j] != -1)
                {
                    disponible[colores[j]] = false;
                }
            }

            // Buscar primer color libre
            int color;

            for (color = 0; color < cantidadCursos; color++)
            {
                if (disponible[color])
                {
                    break;
                }
            }

            // Asignar color
            colores[i] = color;
        }

        Console.WriteLine("\nHorarios generados correctamente.");
    }

    // ==============================
    // VALIDAR HORARIOS
    // ==============================

    static void ValidarHorarios()
    {
        for (int i = 0; i < cantidadCursos; i++)
        {
            for (int j = 0; j < cantidadCursos; j++)
            {
                if (matriz[i, j] == 1 && colores[i] == colores[j])
                {
                    Console.WriteLine("\nConflicto encontrado entre:");

                    Console.WriteLine(cursos[i] + " y " + cursos[j]);

                    return;
                }
            }
        }

        Console.WriteLine("\nEl horario es válido y libre de conflictos.");
    }

    // ==============================
    // MOSTRAR MATRIZ HORARIA
    // ==============================

    static void MostrarMatrizHoraria()
    {
        if (cantidadCursos == 0)
        {
            Console.WriteLine("\nNo hay cursos registrados.");
            return;
        }

        string[] horarios =
        {
            "7:00 AM",
            "9:00 AM",
            "11:00 AM",
            "1:00 PM",
            "3:00 PM",
            "5:00 PM"
        };

        Console.WriteLine("\n===== MATRIZ HORARIA FINAL =====\n");

        Console.WriteLine("CURSO".PadRight(20) + "HORARIO");

        for (int i = 0; i < cantidadCursos; i++)
        {
            Console.WriteLine(
                cursos[i].PadRight(20)
                + horarios[colores[i]]
            );
        }
    }

    // ==============================
    // CARGAR ARCHIVO
    // ==============================

    static void CargarArchivo(string nombreArchivo)
    {
        if (!File.Exists(nombreArchivo))
        {
            Console.WriteLine("\nEl archivo no existe.");
            return;
        }

        string[] lineas = File.ReadAllLines(nombreArchivo);

        foreach (string linea in lineas)
        {
            string[] datos = linea.Split(',');

            if (datos.Length == 2)
            {
                string curso1 = datos[0].Trim();
                string curso2 = datos[1].Trim();

                // Agregar cursos si no existen
                if (BuscarCurso(curso1) == -1)
                {
                    AgregarCurso(curso1);
                }

                if (BuscarCurso(curso2) == -1)
                {
                    AgregarCurso(curso2);
                }

                // Agregar conflicto
                AgregarConflicto(curso1, curso2);
            }
        }

        Console.WriteLine("\nArchivo cargado correctamente.");
    }
}