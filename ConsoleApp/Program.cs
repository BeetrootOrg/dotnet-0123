int[] nums1 = {1,2,3};
int[] nums2 = new[] {1,2,3};
int[] nums3 = new int[] {1,2,3};
int[] nums4 = new int[3] {1,2,3};

System.Console.WriteLine(nums1);
System.Console.WriteLine(nums2);
System.Console.WriteLine(nums3);
System.Console.WriteLine(nums4);

void WriteLineArray(int[] array)
{
    foreach (var item in array)
    {
        System.Console.WriteLine(item);
    }
}
WriteLineArray(nums1);

void ResizeArray(ref int[] arr, int size)
{
    if (arr.Length==size)
    {
        return;
    }
    int[] newArr = new int[size];
    int minLength = size<arr.Length?arr.Length:size;
    for (int i = 0; i < minLength; i++)
    {
        newArr[i]= arr[i];
    }
    arr = newArr;
}

WriteLineArray(nums3);
Array.Resize(ref nums3,4);
WriteLineArray(nums3);

int[] MulBy2(int[] arr)
{
    int[] copy = new int[arr.Length];
    Array.Copy(arr,copy, arr.Length);
    for (int i = 0; i < copy.Length; i++)
    {
        copy[i]*=2;
    }
    return copy;
}
System.Console.WriteLine("Mul by 2");
WriteLineArray(MulBy2(nums3));
