using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB.Interfaces
{
    public interface ICounter
    {
        public int Count(string text, string delimiter = " ");

        public Task<int> CountAsync(string text, string delimiter = " ");
    }
}
