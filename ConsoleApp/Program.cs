static int[] CopyArray(int[] arr)
{
    int[] copy = new int[arr.Length];
    Array.Copy(arr, copy, arr.Length);
    return copy;
}

static int[] SelectionSort(int[] arr)
{
    int[] arrCopy = CopyArray(arr);
    
    for (int i = arrCopy.Length - 1; i >= 0; i--)
    {
        int indexOfMaxValue = i;
        
        for (int j = 0; j <= i; j++ )
        {
            if (arrCopy[j] > arrCopy[indexOfMaxValue])
            {
                indexOfMaxValue = j;
            }
        }
        
        if (indexOfMaxValue != i)
        {
            int value = arrCopy[i];
            arrCopy[i] = arrCopy[indexOfMaxValue];
            arrCopy[indexOfMaxValue] = value;
        }
    }
    
    return arrCopy;
}

static int[] BubbleSort(int[] arr)
{
    int[] arrCopy = CopyArray(arr);
    
    for (int i = 1; i < arrCopy.Length; i++)
    {
        for (int j = 1; j < arrCopy.Length; j++)
        {
            if (arrCopy[j - 1] > arrCopy[j])
            {
                int value = arrCopy[j];
                arrCopy[j] = arrCopy[j - 1];
                arrCopy[j - 1] = value;
            }
        }
    }

    return arrCopy;
}
