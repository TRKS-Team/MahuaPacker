using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahuaPacker
{
    class Program
    {
        static void Main(string[] args)
        {
            var platformNames = new[] { "CleverQQ", "MPQ", "CQP", "QQLight" };
            foreach (var platformName in platformNames)
            {
                var results = Directory.GetDirectories(".", platformName, SearchOption.AllDirectories)
                    .Where(dir => dir.ToLower().Contains("bin")).ToArray();
                if (results.Length == 0) continue;
                if (results.Length > 1) throw new DirectoryNotFoundException(
                    $"Found multiple folder that meets the requirement: {string.Join(", ", results)}.");

                Console.WriteLine($"Compressing: {platformName}");
                ZipFile.CreateFromDirectory(results.First(), $"{platformName}.zip");
            }
        }
    }
}
