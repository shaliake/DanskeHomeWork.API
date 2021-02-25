using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanskeHomeWork.Contracts
{
    public interface IIOService
    {
        public Task WriteToFile(string fileName, int[] arrayToWrite);
        public Task<int[]> ReadFromFile(string fileName);
    }
}
