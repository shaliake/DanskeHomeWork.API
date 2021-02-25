using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Linq;
using DanskeHomeWork.Services;
using System.IO;

namespace DanskeHomeWork.Tests
{
    [TestClass]
    public class SortingServiceTests : TestBase
    {
        internal SortingService sortingService = new SortingService();
        [TestMethod]
        public void BubbleSortTest()
        {
            int elementsToSort = Randomizer.Next(20, 50);
            int[] arrayToSort = new int[elementsToSort];
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                arrayToSort[i] = Randomizer.Next(10000);
            }
            int[] sortedArrayByLanguageLib = (int[])arrayToSort.Clone();
            int[] sortedArray = sortingService.BubbleSort(arrayToSort);

            Array.Sort(sortedArrayByLanguageLib);

            Assert.IsTrue(Enumerable.SequenceEqual(sortedArray, sortedArrayByLanguageLib));
        }
        [TestMethod]
        public void SelectionSortTest()
        {
            int elementsToSort = Randomizer.Next(20, 50);
            int[] arrayToSort = new int[elementsToSort];
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                arrayToSort[i] = Randomizer.Next(10000);
            }
            int[] sortedArrayByLanguageLib = (int[])arrayToSort.Clone();
            int[] sortedArray = sortingService.SelectionSort(arrayToSort);

            Array.Sort(sortedArrayByLanguageLib);

            Assert.IsTrue(Enumerable.SequenceEqual(sortedArray, sortedArrayByLanguageLib));
        }
    }
}
