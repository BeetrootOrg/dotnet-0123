int[] nums1 ={1, 2, 3, 4};
int[] nums2 = new[] {1,2,3,4};
int[] nums3 = new int[]{1, 2, 3};
int[] nums4 = new int[3]{1,2,3};
int[] nums5 = new int[5];

void WriteLineArray (int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        System.Console.WriteLine(arr[i]);
    }
}

WriteLineArray(nums1);

void UpdateElementAt (int[] arr, int index, int newValue)
{
    arr[index] = newValue;
} 

static void UpdateArray (int[] arr)
{
    arr = new[] {5, 6, 7, 8};
}

UpdateElementAt (nums1, 1, 0);
WriteLineArray(nums1);

UpdateArray(nums1);
WriteLineArray(nums1);

static void UpdateArrayRef (ref int[] arr)
{
    arr = new[] {5, 6, 7, 8};
}

UpdateArrayRef(ref nums1);
WriteLineArray(nums1);

// static void WriteLineForeach (int[] arr)
// {
//     foreach
// }
