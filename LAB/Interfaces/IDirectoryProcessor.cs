using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB.Interfaces
{
    public interface IDirectoryProcessor
    {
        public IEnumerable<string> GetFilesPathFromDirectory(string directoryPath);
    }
}
