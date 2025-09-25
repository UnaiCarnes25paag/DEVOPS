using System.IO;
using Xunit;
using FileSorter.Core;

namespace FileSorter.Tests
{
    public class FileSorterTests
    {
        [Fact]
        public void SortFileLines_SortsAlphabetically()
        {
            var tmp = Path.GetTempFileName();
            File.WriteAllLines(tmp, new[] { "b", "A", "c" });

            var result = FileSorterService.SortFileLines(tmp);

            Assert.Equal(new[] { "A", "b", "c" }, result);

            File.Delete(tmp);
        }

        [Fact]
        public void SaveSorted_CreatesSortedFile()
        {
            var tmp = Path.GetTempFileName();
            File.WriteAllLines(tmp, new[] { "z", "y", "x" });

            var dest = Path.Combine(Path.GetDirectoryName(tmp), "salida_ordenado.txt");
            var returned = FileSorterService.SaveSorted(tmp, dest);

            Assert.True(File.Exists(returned));
            Assert.Equal(new[] { "x", "y", "z" }, File.ReadAllLines(returned));

            File.Delete(tmp);
            File.Delete(returned);
        }
    }
}
