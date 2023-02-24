int[] unsorted = new int[] { 5, 1, 4, 2, 8 };

int[] BubbleSort(int[] array)
{
    if (array == null)
    {
        throw new ArgumentNullException();
    }
    if (array.Length == 0 || array.Length == 1)
    {
        return array;
    }

    int[] result = new int[array.Length];
    Array.Copy(array, result, result.Length);

    bool isSorted = false;
    while (!isSorted)
    {
        isSorted = true;
        for (int i = 0; i < result.Length - 1; i++)
        {
            if (result[i] > result[i + 1])
            {
                int temp = result[i];
                result[i] = result[i + 1];
                result[i + 1] = temp;
                isSorted = false;
            }
        }
    }
    return result;
}

var sorted = BubbleSort(unsorted);
Console.WriteLine();

