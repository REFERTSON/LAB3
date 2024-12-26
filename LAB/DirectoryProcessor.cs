using LAB.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB
{
    public class DirectoryProcessor : IDirectoryProcessor
    {
        public IEnumerable<string> GetFilesPathFromDirectory(string directoryPath)
        {
            return Directory.GetFiles(directoryPath, "*.txt");
        }

        public bool CheckFileExists(string filePath) 
        { 
            return File.Exists(filePath); 
        }
    }
}
