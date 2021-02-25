using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DanskeHomeWork.Contracts;

namespace DanskeHomeWork.Services
{
    public class IOService : IIOService
    {
        public async Task<int[]> ReadFromFile(string fileName)
        {
            using StreamReader streamReader = new StreamReader(fileName);
            string lineOfNumbers = await streamReader.ReadLineAsync();
            return lineOfNumbers.Split(' ').Select(numberAsString => int.Parse(numberAsString)).ToArray();
        }
        public async Task WriteToFile(string fileName, int[] arrayToWrite)
        {
            using StreamWriter streamWriter = new StreamWriter(fileName);
            await streamWriter.WriteLineAsync(string.Join(' ', arrayToWrite));
        }
    }
}
