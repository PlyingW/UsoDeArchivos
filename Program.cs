using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Editor de archivos de texto");
        Console.WriteLine("--------------------------");

        while (true)
        {
            Console.WriteLine("1. Ingresar o editar contenido del archivo");
            Console.WriteLine("2. Mostrar contenido del archivo");
            Console.WriteLine("3. Ver todos los archivos existentes");
            Console.WriteLine("4. Finalizar");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    IngresarOEditarContenido();
                    break;
                case "2":
                    MostrarContenido();
                    break;
                case "3":
                    VerArchivosExistentes();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void IngresarOEditarContenido()
    {
        Console.Write("Ingrese el nombre del archivo: ");
        string nombreArchivo = Console.ReadLine();

        Console.Write("Ingrese o edite el contenido del archivo: ");
        string contenido = Console.ReadLine();

        try
        {
            if (File.Exists(nombreArchivo))
            {
                string contenidoExistente = File.ReadAllText(nombreArchivo);

                contenidoExistente += contenido;

                File.WriteAllText(nombreArchivo, contenidoExistente);
                Console.WriteLine("Contenido actualizado exitosamente.");
            }
            else
            {
                File.WriteAllText(nombreArchivo, contenido);
                Console.WriteLine("Archivo creado y contenido guardado exitosamente.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al ingresar o editar el contenido: {ex.Message}");
        }
    }

    static void MostrarContenido()
    {
        Console.Write("Ingrese el nombre del archivo que desea mostrar: ");
        string nombreArchivo = Console.ReadLine();

        try
        {
            if (File.Exists(nombreArchivo))
            {
                string contenido = File.ReadAllText(nombreArchivo);
                Console.WriteLine("Contenido del archivo:");
                Console.WriteLine(contenido);
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al mostrar el archivo: {ex.Message}");
        }
    }

    static void VerArchivosExistentes()
    {
        string directorioActual = Directory.GetCurrentDirectory();
        string[] archivos = Directory.GetFiles(directorioActual);

        Console.WriteLine("Archivos existentes en el directorio actual:");
        foreach (string archivo in archivos)
        {
            Console.WriteLine(Path.GetFileName(archivo));
        }
    }
}
