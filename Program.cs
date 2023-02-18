//bubble sort

int[] a = new int[6] {8, 5, 3, 1, 0, -1};

int[] BubbleSort(int[] arr)
{
    int[] sorted = new int[arr.Length];
    Array.Copy(arr, sorted, arr.Length);
    int temp = 0;

    for (int i = 0; i < arr.Length - 1; i++)
    {
        for (int j = 0; j < arr.Length - 1; j++)
        {
            if (arr[j] >= arr[j+1])
            {
                temp = arr[j];
                arr[j] = arr[j+1];
                arr[j+1] = temp;
            }
        }
    }
    return arr;
}

static void WriteLineArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine(arr[i]);
    }
}

WriteLineArray(BubbleSort(a));
