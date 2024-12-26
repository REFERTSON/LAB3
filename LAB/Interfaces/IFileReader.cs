using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB.Interfaces
{
    public interface IFileReader
    {
        public string ReadFile(string filePath);

        public Task<string> ReadFileAsync(string filePath);

        public Task<IEnumerable<string>> ReadFileByLinesAsync(string filePath);
    }
}
