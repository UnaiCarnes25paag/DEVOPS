using System;
using FileSorter.Core;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Ordenador de archivo de texto ===");
        Console.Write("Ingrese la ruta del archivo: ");
        string rutaArchivo = Console.ReadLine();

        if (!System.IO.File.Exists(rutaArchivo))
        {
            Console.WriteLine("El archivo no existe. Verifique la ruta.");
            return;
        }

        try
        {
            var sorted = FileSorterService.SortFileLines(rutaArchivo);  // 👈 ahora sí
            Console.WriteLine("\n--- Archivo ordenado alfabéticamente ---");
            foreach (var line in sorted) Console.WriteLine(line);

            Console.Write("\n¿Desea guardar el resultado en un nuevo archivo? (s/n): ");
            string respuesta = Console.ReadLine();

            if (respuesta?.ToLower() == "s")
            {
                var nuevaRuta = FileSorterService.SaveSorted(rutaArchivo);
                Console.WriteLine($"Archivo ordenado guardado en: {nuevaRuta}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error: " + ex.Message);
        }
    }
}
