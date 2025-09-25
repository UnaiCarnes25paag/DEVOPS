using System;
using System.IO;
using System.Linq;

namespace FileSorter.Core
{
    public static class FileSorterService
    {
        public static string[] SortFileLines(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"El archivo no existe: {path}");

            var lines = File.ReadAllLines(path);
            return lines.OrderBy(l => l, StringComparer.OrdinalIgnoreCase).ToArray();
        }

        public static string SaveSorted(string path, string destination = null)
        {
            var sorted = SortFileLines(path);

            var dest = destination ?? Path.Combine(
                Path.GetDirectoryName(path),
                Path.GetFileNameWithoutExtension(path) + "_ordenado.txt"
            );

            File.WriteAllLines(dest, sorted);
            return dest;
        }
    }
}
