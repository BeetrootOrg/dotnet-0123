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

int Partition(int[] arr, int low, int high)
{
   int[] copy = CreateArrayCopy(arr, out int length);

   int pivot = copy[high];
   int i = low - 1;

   for (int j = low; j < high; j++)
   {
        if (copy[j] <= pivot)
        {
            i++;
            SwapVar(ref copy[i], ref copy[j]);
        }
   }

   SwapVar(ref copy[i+1], ref copy[high]);
   return (i + 1);
}

void Sorting(int[] arr, int low, int high)
{
    if (low < high)
    {
        int pi = Partition(arr, low, high);
        Sorting(arr, low, pi - 1);
        Sorting(arr, pi + 1, high);
    }
}

int[] QuickSort(int[] arr)
{
    int[] copy = CreateArrayCopy(arr, out int length);
    int low = 0;
    int high = length - 1;

    Sorting(copy, low, high);
    return copy;
}




int[] random = new int[] { 6, 3, 2, 4, 1 };
int[] sorted = new int[] { -7, 0, 5, 7 };
int[] backsorted = new int[] { 7, 5, 0, -7 };

System.Console.WriteLine("Random Array - QuickSort");
WriteLineArray(QuickSort(random));

System.Console.WriteLine("Sorted Array - QuickSort");
WriteLineArray(QuickSort(sorted));

System.Console.WriteLine("BackSorted Array - QuickSort");
WriteLineArray(QuickSort(backsorted));





