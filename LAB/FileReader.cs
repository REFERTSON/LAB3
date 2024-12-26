using LAB.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB
{
    public class FileReader : IFileReader
    {
        public string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public async Task<string> ReadFileAsync(string filePath)
        {
            return await File.ReadAllTextAsync(filePath);
        }

        public async Task<IEnumerable<string>> ReadFileByLinesAsync(string filePath)
        {
            return await File.ReadAllLinesAsync(filePath);
        }
    }
}
