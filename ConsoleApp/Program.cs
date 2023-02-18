int[] CreateArrayCopy(int[] arr, out int length)
{
    length = arr.Length;
    int[] copy = new int[length];
    Array.Copy(arr, copy, length);

    return copy;
}

void SwapVar(ref int a, ref int b)
{
    int current = a;
    a = b;
    b = current;
}

void SwapArray(int[] arr, int i, int j)
{
    int temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}

void WriteLineArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        System.Console.WriteLine(arr[i]);
    }
}

int MinOfArray(int[] arr, out int index)
{
    int minOfArray = arr[0];
    index = 0;
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] < minOfArray)
        {
            minOfArray = arr[i];
            index = i;
        }
    }

    return minOfArray;
}

int[] BubbleSort(int[] arr)
{
    int[] copy = CreateArrayCopy(arr, out int length);

    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length - i - 1; j++)
        {
            if (copy[j] > copy[j + 1])
            {
                var current = copy[j];
                copy[j] = copy[j + 1];
                copy[j + 1] = current;
            }
        }
    }

    return copy;
}


int[] SelectionSort(int[] arr)
{
    int[] copy = CreateArrayCopy(arr, out int length);

    for (int i = 0; i < length; i++)
    {
        int minMember = MinOfArray(copy[i..], out int indexMin);
        SwapVar(ref copy[i], ref copy[indexMin + i]);
    }

    return copy;
}

int[] QuickSort(int[] arr)
{
   int[] copy = CreateArrayCopy(arr, out int length);
   int low = 0;
   int high = length - 1;

   int pivot = copy[high];
   int i = low - 1;

   for (int j = low; j < high; j++)
   {
        if (copy[j] <= pivot)
        {
            i++;
            SwapVar(ref copy[i], ref copy[j];)
        };
   };

   SwapVar(ref copy[i+1], ref copy[high]);
   return copy;
}

int[] random = new int[] { 6, 3, 2, 4, 1 };
int[] sorted = new int[] { -7, 0, 5, 7 };
int[] backsorted = new int[] { 7, 5, 0, -7 };

System.Console.WriteLine("Random Array - BubbleSort");
WriteLineArray(BubbleSort(random));

System.Console.WriteLine("Sorted Array - BubbleSort");
WriteLineArray(BubbleSort(sorted));

System.Console.WriteLine("BackSorted Array - BubbleSort");
WriteLineArray(BubbleSort(backsorted));

System.Console.WriteLine("Random Array - SelectionSort");
WriteLineArray(SelectionSort(random));

System.Console.WriteLine("Sorted Array - SelectionSort");
WriteLineArray(SelectionSort(sorted));

System.Console.WriteLine("BackSorted Array - SelectionSort");
WriteLineArray(SelectionSort(backsorted));





