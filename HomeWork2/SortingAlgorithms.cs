namespace HomeWork2
{
    public static class SortingAlgorithms
    {
        public static void BubbleSort(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length - 1; i++)
                //use (length - i - 1) for avoid compare the same element
                for (int j = 0; j < length - i - 1; j++)
                    //compare two adjacent elements and exchange them if they are in the wrong order.
                    if (array[j] > array[j + 1])
                        //exchange of two adjacent elements values 
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
        }

        public static void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length-1);
        }
        
        private static void MergeSort(int[] array, int leftBound, int rightBound)
        {
            if (leftBound < rightBound)
            {
                int middle = (leftBound + rightBound) / 2;

                //sort both parts
                MergeSort(array, leftBound, middle);
                MergeSort(array, middle + 1, rightBound);

                //merge both parts
                Merge(array, leftBound, middle, rightBound);
            }
        }
        
        private static void Merge(int[] array, int leftBound, int middle, int rightBound)
        {
            int lenghtOfLeftArray = middle - leftBound + 1;
            int lenghtOfRightArray = rightBound - middle;

            //create temporary array
            int[] leftArray = new int[lenghtOfLeftArray];
            int[] rightArray = new int[lenghtOfRightArray];

            // fill temporary leftArray[]
            for (int i = 0; i < lenghtOfLeftArray; ++i)
                leftArray[i] = array[leftBound + i];
            
            // fill temporary rightArray[]
            for (int i = 0; i < lenghtOfRightArray; ++i)
                rightArray[i] = array[middle + 1 + i];

            // union of temporary array to main array
            var leftIndex = 0;
            var rightIndex = 0;
            int movedIndex = leftBound;
            
            while (leftIndex < lenghtOfLeftArray && rightIndex < lenghtOfRightArray)
            {
                if (leftArray[leftIndex] <= rightArray[rightIndex])
                {
                    array[movedIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    array[movedIndex] = rightArray[rightIndex];
                    rightIndex++;
                }
                movedIndex++;
            }

            // copy remained leftArray[] items if they present
            while (leftIndex < lenghtOfLeftArray)
            {
                array[movedIndex] = leftArray[leftIndex];
                leftIndex++;
                movedIndex++;
            }

            // copy remained rightArray[] items if they present
            while (rightIndex < lenghtOfRightArray)
            {
                array[movedIndex] = rightArray[rightIndex];
                rightIndex++;
                movedIndex++;
            }
        }

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        
        private static void QuickSort(int[] array, int leftBound, int rightBound)
        {
            var leftIndex = leftBound;
            var rightIndex = rightBound;
            var movedIndex = array[leftBound];
            
            while (leftIndex <= rightIndex)
            {
                //increase left index while value less then moved index value 
                while (array[leftIndex] < movedIndex) leftIndex++;
        
                //decrease right index while value greater then moved index value 
                while (array[rightIndex] > movedIndex) rightIndex--;
                
                //swap, if they are in the wrong order.
                if (leftIndex <= rightIndex)
                {
                    (array[leftIndex], array[rightIndex]) = (array[rightIndex], array[leftIndex]);
                    leftIndex++;
                    rightIndex--;
                }
            }
    
            //recursively sort left and right part of array
            if (leftBound < rightIndex)
                QuickSort(array, leftBound, rightIndex);
            if (leftIndex < rightBound)
                QuickSort(array, leftIndex, rightBound);
        }
    }
}