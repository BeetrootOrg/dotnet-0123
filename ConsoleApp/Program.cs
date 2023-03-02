static void BubbleSort(int[] arr)
{
    int n = arr.Length;
    for(int i = 0;i<n-1;i++)
    {
        for(int j = 0; j<n-i-1;j++)
        {
            if(arr[j]>arr[j+1])
            {
                int curr = arr[j];
                arr[j] = arr[j + 1];
                arr[j+1] = curr;
            }
        }
    }
}

static void WriteLineArray(int[] arr)
{
    for (int i = 0;i>arr.Length;i++)
    {
        System.Console.WriteLine(arr[i]);
    }
}

int[] arr = {6,1,2,8,5};
WriteLineArray(arr);
BubbleSort(arr);
WriteLineArray(arr);