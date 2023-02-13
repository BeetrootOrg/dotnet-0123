int [] nums1 = { 1, 2, 3};

//System.Console.WriteLine(nums1);

 static void WriteLineArray(int[] arr)
{
    for (int i =0; i < arr.Length; i++)
    {
        System.Console.WriteLine(arr[i]);
    }
}

 int[] toBubble = new [] {0, 2, 4, 6, -8, -10};

 int[] Bubble (int[] arr)
{
    int [] bubbled = new int [arr.Length];
    Array.Copy(arr, bubbled, arr.Length);

     for(int i = 0; i < arr.Length -1; i++)
    {
        for (int j = 0; j < arr.Length -1; j++)
        {
            if (bubbled[j] > bubbled[j + 1])
            {
                int temp = bubbled[j];
                bubbled[j] = bubbled[j + 1];
                bubbled[j + 1] = temp;
            }
        }
    }
    return bubbled;
}
Console.WriteLine("The sorted array of numbers: ");
WriteLineArray(Bubble(toBubble));
