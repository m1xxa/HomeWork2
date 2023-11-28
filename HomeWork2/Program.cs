using System;
using System.Diagnostics;

namespace HomeWork2
{
    abstract class Program
    {
        private static int LengthOfFirstArray => 5000;
        private static int LengthOfSecondArray => 25000;
        private static int LengthOfThirdArray => 50000;

        static void Main()
        {
            int[] arrayOf5000Elements = new int[LengthOfFirstArray];
            int[] arrayOf25000Elements = new int[LengthOfSecondArray];
            int[] arrayOf50000Elements = new int[LengthOfThirdArray];

            FillArrayByRandomValues(arrayOf5000Elements);
            FillArrayByRandomValues(arrayOf25000Elements);
            FillArrayByRandomValues(arrayOf50000Elements);
            
            PrintExecutionSpeed(arrayOf5000Elements);
            PrintExecutionSpeed(arrayOf25000Elements);
            PrintExecutionSpeed(arrayOf50000Elements);
        }

        private static void PrintElapsedTime(String textBefore, String textAfter = null)
        {
            if(!String.IsNullOrEmpty(textBefore)) Console.Write(textBefore + ". ");
            if(!String.IsNullOrEmpty(textAfter)) Console.Write(textAfter + ".");
            Console.WriteLine();
        }

        private static int[] GetNewCopyOfIntArray(int[] array)
        {
            int[] copiedArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                copiedArray[i] = array[i];
            return copiedArray;
        }

        private static void PrintExecutionSpeed(int[] array)
        {
            var stopWatch = new Stopwatch(); 
            
            var arrayCopy1 = GetNewCopyOfIntArray(array);
            var arrayCopy2 = GetNewCopyOfIntArray(array);
            var arrayCopy3 = GetNewCopyOfIntArray(array);
            
            stopWatch.Start();
            SortingAlgorithms.BubbleSort(arrayCopy1);
            stopWatch.Stop();
            PrintElapsedTime($"BubbleSort of {arrayCopy1.Length} elements", "Elapsed: " + stopWatch.ElapsedMilliseconds);
            stopWatch.Reset();
            
            stopWatch.Start();
            SortingAlgorithms.MergeSort(arrayCopy2);
            stopWatch.Stop();
            PrintElapsedTime($"MergeSort of {arrayCopy2.Length} elements", "Elapsed: " + stopWatch.ElapsedMilliseconds);
            stopWatch.Reset();
            
            stopWatch.Start();
            SortingAlgorithms.QuickSort(arrayCopy3);
            stopWatch.Stop();
            PrintElapsedTime($"QuickSort of {arrayCopy3.Length} elements", "Elapsed: " + stopWatch.ElapsedMilliseconds);
            stopWatch.Reset();
        }

        private static void FillArrayByRandomValues(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next();
        }
    }
}