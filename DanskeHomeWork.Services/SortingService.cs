using DanskeHomeWork.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanskeHomeWork.Services
{
    public class SortingService : ISortingService
    {
        public int[] BubbleSort(int[] arrayToSort)
        {
            int[] internalArray = (int[])arrayToSort.Clone();
            for (int i = 0; i < internalArray.Length; i++)
            {
                bool isNotInOrder = false;
                for (int j = 0; j < internalArray.Length - i - 1; j++)
                {
                    if (internalArray[j] > internalArray[j + 1])
                    {
                        isNotInOrder = true;
                        int swapValue = internalArray[j];
                        internalArray[j] = internalArray[j + 1];
                        internalArray[j + 1] = swapValue;
                    }
                }
                if (!isNotInOrder) break;
            }
            return internalArray;
        }
        public int[] SelectionSort(int[] arrayToSort)
        {
            int[] internalArray = (int[])arrayToSort.Clone();
            for (int i = 0; i < internalArray.Length - 1; i++)
            {
                int indexOfMinimum = i;
                for (int j = i + 1; j < internalArray.Length; j++)
                {
                    if (internalArray[j] < internalArray[indexOfMinimum])
                        indexOfMinimum = j;
                }
                int swapValue = internalArray[indexOfMinimum];
                internalArray[indexOfMinimum] = internalArray[i];
                internalArray[i] = swapValue;
            }
            return internalArray;
        }
    }
}