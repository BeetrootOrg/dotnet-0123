void WriteArray(int[] array)
{
    foreach (var item in array)
    {
        Console.Write($"{item} ");
    }
    Console.Write("\n");
}

int[] CopyArray(int[] originArray)
{
    int[] copyArray = new int[originArray.Length];
    Array.Copy(originArray, copyArray, originArray.Length);
    return copyArray;
}

void SwapElementsInArray(int[] array, int firstIndex, int secondIndex)
{
    int temp = array[firstIndex];
    array[firstIndex] = array[secondIndex];
    array[secondIndex] = temp;
}

int[] QuickSort(int[] array, int lowestIndex, int highestIndex)
{
    int[] copy = CopyArray(array);
    if (lowestIndex < highestIndex)
    {
        int pivotIndex = highestIndex;
        int smallestElementIndex = lowestIndex - 1;
        for (int i = lowestIndex; i < highestIndex; i++)
        {
            if (array[i] < array[pivotIndex])
            {
                smallestElementIndex++;
                SwapElementsInArray(copy, smallestElementIndex, i);
            }
        }
        smallestElementIndex++;
        SwapElementsInArray(copy, smallestElementIndex, pivotIndex);
        copy = QuickSort(copy, lowestIndex, smallestElementIndex - 1);
        copy = QuickSort(copy, smallestElementIndex + 1, highestIndex);
    }
    return copy;
}


Console.WriteLine("Random");
int[] testArray = { 6, 8, 4, 7, 3, 0, 0 };
WriteArray(testArray);
WriteArray(QuickSort(testArray, 0, testArray.Length - 1));
Console.WriteLine("Sorted");
testArray = new int[] { 1, 2, 3, 4, 5, 6, 7 };
WriteArray(testArray);
WriteArray(QuickSort(testArray, 0, testArray.Length - 1));
Console.WriteLine("Backsorted");
testArray = new int[] { 7, 6, 5, 4, 3, 2, 1 };
WriteArray(testArray);
WriteArray(QuickSort(testArray, 0, testArray.Length - 1));
Console.WriteLine("Empty");
testArray = new int[] { };
WriteArray(testArray);
WriteArray(QuickSort(testArray, 0, testArray.Length - 1));