using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Linq;
using DanskeHomeWork.Services;
using System.IO;

namespace DanskeHomeWork.Tests
{
    [TestClass]
    public class IOServiceTests : TestBase
    {
        internal IOService ioService = new IOService();
        [TestMethod]
        public async Task WriteToFileTest()
        {
            string fileName = $"testWriter{Randomizer.Next(int.MaxValue)}.txt";
            int numbersOfDataPoints = 10;
            int[] numbers = new int[numbersOfDataPoints];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Randomizer.Next(0, 10);
            }

            await ioService.WriteToFile(fileName, numbers);

            Assert.IsNotNull(File.Exists(fileName));
        }
        [TestMethod]
        public async Task ReadFromFile()
        {
            string fileName = $"testReader{Randomizer.Next(int.MaxValue)}.txt";
            using StreamWriter streamWriter = new StreamWriter(fileName);
            int[] testNumberArray = {Randomizer.Next(10), Randomizer.Next(10), Randomizer.Next(10),
                Randomizer.Next(10), Randomizer.Next(10)};
            await streamWriter.WriteLineAsync(string.Join(' ', testNumberArray));
            await streamWriter.DisposeAsync();

            int[] arrayFromFile = await ioService.ReadFromFile(fileName);

            Assert.IsTrue(File.Exists(fileName));
            Assert.AreEqual(testNumberArray.Length, arrayFromFile.Length);
        }
        [TestCleanup]
        public void CleanUp()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            foreach (var item in files)
            {
                File.Delete(item);
            }
        }
    }
}
