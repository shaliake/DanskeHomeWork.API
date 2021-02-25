using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DanskeHomeWork.Contracts
{
    public interface ISortingService
    {
        public int[] BubbleSort(int[] arrayToSort);
        public int[] SelectionSort(int[] arrayToSort);
    }
}
