using LAB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB
{
    public class Counter : ICounter
    {
        public int Count(string text, string delimiter = " ")
        {
            return text.Count(c => c == ' ');
        }

        public async Task<int> CountAsync(string text, string delimiter = " ")
        {
            return await Task.Run(() => text.Count(c => c == ' '));
        }
    }
}
