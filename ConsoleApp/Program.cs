int [] nums1 = { 1, 2, 3};
int [] nums2 = new[] { 1, 2, 3};
int [] nums3 = new int[] { 1, 2, 3};
int [] nums4 = new int[3] { 1, 2, 3};
int [] nums5 = new int [5];

System.Console.WriteLine(nums1);
System.Console.WriteLine(nums2);
System.Console.WriteLine(nums3);
System.Console.WriteLine(nums4);
System.Console.WriteLine(nums5);

 static void WriteLineArray(int[] arr)
{
    for (int i =0; i < arr.Length; i++)
    {
        System.Console.WriteLine(arr[i]);
    }
}
WriteLineArray(nums1);

static void WriteLineArrayForeach(int[] arr)
{
    foreach(int item in arr)
    {
        System.Console.WriteLine(item);
    }
}

UpdateElementAt(nums1, 1, 42);
WriteLineArrayForeach(nums1);

void UpdateElementAt(int[] arr, int index, int newValue)
{
    arr[index] = newValue;
}
UpdateElementAt(nums1, 1, 42);
WriteLineArray(nums1);

static void UpateArrayRef( ref int[] arr)
{
    arr = new[] { 5, 6, 7, 8};
}
UpateArrayRef(ref nums1);
WriteLineArray(nums1);

int[] nullArr = null;
if (nullArr != null)
{
    System.Console.WriteLine(nullArr.Length);
}
UpateArrayRef(ref nullArr);
WriteLineArrayForeach(nullArr);

System.Console.WriteLine("Range operator 1..3");
WriteLineArray(nullArr[1..3]); // [1] [2]

System.Console.WriteLine("Range operator ..3");
WriteLineArray(nullArr[..3]); // [0] [1] [2]

System.Console.WriteLine("Range operator 1..");
WriteLineArray(nullArr[1..]); // [1] [2] [3]

int[] subarray = nullArr[1..];
subarray[0] = 42;
WriteLineArray(nullArr);

System.Console.WriteLine("Range operator ^3..^1");
WriteLineArray(nullArr[^3..^1]); // [1] [2]

System.Console.WriteLine("Sum");
int Sum (int[] arr)
{
    int sum = 0;
    foreach(var item in arr)
    {
        sum += item;
    }

    return sum;
}

int SumParams (params int[] arr)
{
    int sum = 0;
    foreach(var item in arr)
    {
        sum += item;
    }

    return sum;
}
System.Console.WriteLine(Sum(nums2));

System.Console.WriteLine(SumParams(nums2));
System.Console.WriteLine(SumParams(1, 2, 3));
System.Console.WriteLine(SumParams());

void ResizeArray( ref int[] arr, int size)
{
    if (arr.Length == size)
    {
        return;
    }

    int [] newArr = new int[size];
    int minLenght = arr.Length < size ? arr.Length : size;
    for (int i = 0; i < minLenght; i++)
    {
            newArr[i] = arr[i];
    }
    arr = newArr; 
}

System.Console.WriteLine("Resize");
ResizeArray(ref nums3, 4);
WriteLineArray(nums3);

ResizeArray(ref nums3, 2);
WriteLineArray(nums3);

Array.Resize(ref nums3, 4);
WriteLineArray(nums3);

 static int[] MulBy2(int[] arr)
{
    int[] copy = new int [arr.Length];
    Array.Copy(arr, copy, arr.Length);

    for (int i = 0; i < copy.Length; i++)
    {
        copy[i] *= 2;
    }
    return copy;
}

System.Console.WriteLine("Mul By 2");
WriteLineArray(MulBy2(nums4));

int[,] matrix = new int[2, 4] {{0, 1, 2, 3}, {4, 5, 6, 7}};
foreach(var item in matrix)
{
    System.Console.WriteLine(item);
}
System.Console.WriteLine($"Length = {matrix.Length}");
System.Console.WriteLine($"GetLength(0) = {matrix.GetLength(0)}");
System.Console.WriteLine($"GetLength(1) = {matrix.GetLength(1)}");
for ( int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        System.Console.WriteLine(matrix[i, j]);
    }
}

int[] [] jagged = new int[2] []
{
    new[] {1, 2, 3},
    new [] {1, 2}, 
};

foreach (int[] item in jagged)
{
    System.Console.WriteLine("Jagged Array");
    WriteLineArray(item);
}

System.Console.WriteLine($"Length = {jagged.Length}");

for (int i = 0; i < jagged.Length; i++)
{
    int[] inner = jagged[i];
    for (int j = 0; j < inner.Length; j++)
    {
        System.Console.WriteLine(inner[j]);
    }
}

int[] toSort = new [] {-5, 10, 0, 15, -20, 100, 0};

int[] Sort(int[] arr)
{
    int[] sorted = new int[arr.Length];
    Array.Copy(arr, sorted, arr.Length);
    
    for (int i = 1; i < arr.Length; i++)
    {
        var item = arr[i];
        var index = i;
        for (int j = i - 1; j >= 0; j--)
        {
            var current = arr[j];
            if (current > item)
            {
                arr[j + 1] = arr[j];
                index = j;
            }
            else 
            {
                break;
            }
        }
        arr[index] = item;
    }
    return arr;
}

int [] sorted = new [] { -1, 0, 1, 3};
int [] random = new [] { -5, 10, 0, 15, -20, 100, 0};
int [] backsorted = new [] { 3, 1, 0, -1 };
int [] empty = new int [0];

System.Console.WriteLine("Sort array");
WriteLineArray(Sort(sorted));

System.Console.WriteLine("Random array");
WriteLineArray(Sort(random));

System.Console.WriteLine("Backsorted array");
WriteLineArray(Sort(backsorted));

System.Console.WriteLine("Empty array");
WriteLineArray(Sort(empty));

int[] Reverse(int[] arr)
{
    int[] reversed = new int[arr.Length];
    Array.Copy(arr, reversed, arr.Length);

    int halfSize = reversed.Length / 2;
    for (int i = 0; i < halfSize; i++)
    {
        int temp = reversed[i];
        reversed[i] = reversed[^(i + 1)];
        reversed[^(i + 1)] = temp;
    }
    return reversed;
}
System.Console.WriteLine("Reverse");
WriteLineArray(Reverse(new[] {1, 2, 3}));
System.Console.WriteLine("Reverse");
WriteLineArray(Reverse(new[] {1, 2, 3, 4}));