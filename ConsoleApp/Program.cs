int[] nums1 = { 1, 2, 3 };
int[] nums2 = new[] { 1, 2, 3 };
int[] nums3 = new int[] { 1, 2, 3 };
int[] nums4 = new int[3] { 1, 2, 3 };
int[] nums5 = new int[3];

Console.WriteLine(nums1);
Console.WriteLine(nums2);
Console.WriteLine(nums3);
Console.WriteLine(nums4);
Console.WriteLine(nums5);

static void WriteLineArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine(arr[i]);
    }
}

WriteLineArray(nums1);