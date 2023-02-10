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

static void WriteLineArrayForeach(int[] arr)
{
    foreach (int item in arr)
    {
        Console.WriteLine(item);
    }
}

WriteLineArray(nums1);

int[] nullArr = null;
if (nullArr != null)
{
    Console.WriteLine(nullArr.Length);
}

static void UpdateElementAt(int[] arr, int index, int newValue)
{
    arr[index] = newValue;
}

#pragma warning disable IDE0059
static void UpdateArray(int[] arr)
{
    arr = new[] { 4, 5, 6, 7 };
}
#pragma warning restore

static void UpdateArrayRef(ref int[] arr)
{
    arr = new[] { 4, 5, 6, 7 };
}

Console.WriteLine("UPDATE ARRAY ELEMENT");
UpdateElementAt(nums1, 1, 42);
WriteLineArray(nums1);

Console.WriteLine("UPDATE ARRAY");
UpdateArray(nums1);
WriteLineArray(nums1);

Console.WriteLine("UPDATE ARRAY REF");
UpdateArrayRef(ref nullArr);
WriteLineArrayForeach(nullArr);

Console.WriteLine("RANGE OPERATOR 1..3");
WriteLineArray(nullArr[1..3]); // [1][2]

Console.WriteLine("RANGE OPERATOR ..3");
WriteLineArray(nullArr[..3]); // [0][1][2]

Console.WriteLine("RANGE OPERATOR ..3");
WriteLineArray(nullArr[1..]); // [1][2][3]

Console.WriteLine("COPY ARRAY");
int[] subarray = nullArr[1..];
subarray[0] = 42;
WriteLineArray(nullArr);

Console.WriteLine("RANGE OPERATOR ^3..^1");
WriteLineArray(nullArr[^3..^1]); // [1][2]

Console.WriteLine("RANGE OPERATOR ..^1");
WriteLineArray(nullArr[..^1]); // [0][1][2]

Console.WriteLine("RANGE OPERATOR ^3..");
WriteLineArray(nullArr[..^1]); // [1][2][3]

Console.WriteLine("SUM");
static int Sum(int[] arr)
{
    int sum = 0;
    foreach (int item in arr)
    {
        sum += item;
    }

    return sum;
}

static int SumParams(params int[] arr)
{
    int sum = 0;
    foreach (int item in arr)
    {
        sum += item;
    }

    return sum;
}

Console.WriteLine(Sum(nums2));
// COMPILATION ERRORS BELOW:
// Console.WriteLine(Sum(1, 2, 3));
// Console.WriteLine(Sum());

Console.WriteLine(SumParams(nums2));
Console.WriteLine(SumParams(1, 2, 3));
Console.WriteLine(SumParams());

static void ResizeArray(ref int[] arr, int size)
{
    if (arr.Length == size)
    {
        return;
    }

    int[] newArr = new int[size];
    int minLength = arr.Length < size ? arr.Length : size;
    for (int i = 0; i < minLength; i++)
    {
        newArr[i] = arr[i];
    }

    arr = newArr;
}

Console.WriteLine("RESIZE");
ResizeArray(ref nums3, 4);
WriteLineArray(nums3);

ResizeArray(ref nums3, 2);
WriteLineArray(nums3);

// BEST OPTION
Array.Resize(ref nums3, 4);
WriteLineArray(nums3);

static int[] MulBy2(int[] arr)
{
    int[] copy = new int[arr.Length];
    Array.Copy(arr, copy, arr.Length);

    for (int i = 0; i < copy.Length; i++)
    {
        copy[i] *= 2;
    }

    return copy;
}

Console.WriteLine("MUL BY 2");
WriteLineArray(MulBy2(nums4));

Console.WriteLine("ORIGINAL nums4");
WriteLineArray(nums4);

int[,] matrix = new int[2, 4] { { 0, 1, 2, 3 }, { 4, 5, 6, 7 } };
foreach (int item in matrix)
{
    Console.WriteLine(item);
}

Console.WriteLine($"LENGTH = {matrix.Length}");
Console.WriteLine($"GetLength(0) = {matrix.GetLength(0)}");
Console.WriteLine($"GetLength(1) = {matrix.GetLength(1)}");

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.WriteLine(matrix[i, j]);
    }
}