// int[] nums1 ={1, 2, 3, 4};
// int[] nums2 = new[] {1,2,3,4};
// int[] nums3 = new int[]{1, 2, 3};
// int[] nums4 = new int[3]{1,2,3};
// int[] nums5 = new int[5];

// void WriteLineArray (int[] arr)
// {
//     for (int i = 0; i < arr.Length; i++)
//     {
//         System.Console.WriteLine(arr[i]);
//     }
// }

// WriteLineArray(nums1);

// void UpdateElementAt (int[] arr, int index, int newValue)
// {
//     arr[index] = newValue;
// } 

// static void UpdateArray (int[] arr)
// {
//     arr = new[] {5, 6, 7, 8};
// }

// UpdateElementAt (nums1, 1, 0);
// WriteLineArray(nums1);

// UpdateArray(nums1);
// WriteLineArray(nums1);

// static void UpdateArrayRef (ref int[] arr)
// {
//     arr = new[] {5, 6, 7, 8};
// }

// UpdateArrayRef(ref nums1);
// WriteLineArray(nums1);

// static void WriteLineForeach (int[] arr)
// {
//     foreach
// }

//---------------------------------------------------------------------------------

int[] nums1 = { 1, 2, 3, 4 };
int[] nums2 = new[] { 1, 2, 3 };
int[] nums3 = new int[] { 1, 2, 3 };
int[] nums4 = new int[3] { 1, 2, 3 };
int[] nums5 = new int[5];

System.Console.WriteLine(nums1);
System.Console.WriteLine(nums2);
System.Console.WriteLine(nums3);
System.Console.WriteLine(nums4);
System.Console.WriteLine(nums5);

void WriteLineArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        System.Console.WriteLine(arr[i]);
    }
}

WriteLineArray(nums1);

int[] nullArr = null;
System.Console.WriteLine(nullArr);

if (nullArr != null)
{
    System.Console.WriteLine(nullArr);
}

void UpdateElementAt(int[] arr, int index, int newValue)
{
    arr[index] = newValue;
}

UpdateElementAt(nums1, 3, 90);
WriteLineArray(nums1);

static void UpdateArray(int[] arr)
{
    arr = new[] { 54, 53, 51 };
}

static void UpdateArrayRef(ref int[] arr)
{
    arr = new[] { 54, 53, 51 };
}

UpdateArray(nums1);
WriteLineArray(nums1);

UpdateArrayRef(ref nums1);
WriteLineArray(nums1);

static void WriteLineForeach(int[] arr)
{
    foreach (int item in arr)
    {
        System.Console.WriteLine(item);
    }
}

WriteLineForeach(nums1);
System.Console.WriteLine("nums1[1..3]");
WriteLineArray(nums1[1..3]);
System.Console.WriteLine("nums1[..3]");
WriteLineArray(nums1[..3]);
System.Console.WriteLine("nums1[1..]");
WriteLineArray(nums1[1..]);

System.Console.WriteLine("nums1[^3..^1]");
WriteLineArray(nums1[^3..^1]);
System.Console.WriteLine("nums1[..^1]");
WriteLineArray(nums1[..^1]);
// System.Console.WriteLine("nums1[1..]");
// WriteLineArray(nums1[1..]);

int Sum(int[] arr)
{
    int sum = 0;
    foreach (var item in arr)
    {
        sum += item;
    }

    return sum;
}

int SumParams(params int[] arr)
{
    int sum = 0;
    foreach (var item in arr)
    {
        sum += item;
    }

    return sum;
}

System.Console.WriteLine(Sum(nums2));
System.Console.WriteLine(SumParams(1, 2, 3));
System.Console.WriteLine(SumParams());

void ResizeArray(ref int[] arr, int size)
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

// ResizeArray(ref nums3, 6);
// WriteLineArray(nums3);

ResizeArray(ref nums3, 2);

Array.Resize(ref nums3, 6);
WriteLineArray(nums3);

int[] MulBy2(int[] arr)
{
    int[] copy = new int[arr.Length];
    Array.Copy(arr, copy, arr.Length);

    for (int i = 0; i < copy.Length; i++)
    {
        copy[i] *= 2;
    }
    return copy;
}

int[] nums3Mul = MulBy2(nums3);
WriteLineArray(nums3Mul);

int[,] matrix = new int[2, 4] { { 0, 1, 2, 3 }, { 4, 5, 6, 7 } };

foreach (int item in matrix)
{
    System.Console.WriteLine(item);
}

System.Console.WriteLine($"LENGTH = {matrix.Length}");
System.Console.WriteLine($"GetLength(0) = {matrix.GetLength(0)}");
System.Console.WriteLine($"GetLength(1) = {matrix.GetLength(1)}");

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        System.Console.WriteLine(matrix[i, j]);
    }
}

int[][] jagged = new int[2][]
{
    new int[] {1,2,3},
    new int[] {1,2}
};

System.Console.WriteLine("Jagged Array");
foreach (var item in jagged)
{
    WriteLineArray(item);
}

System.Console.WriteLine("Jagged array via for");
for (int i = 0; i < jagged.Length; i++)
{
    int[] inner = jagged[i];
    for (int j = 0; j < inner.Length; j++)
    {
        System.Console.WriteLine(inner[j]);
    }
}

//Insertion sort

int[] toSort = new int[] { -5, 10, 0, 15, -20, 100, 0 };

int[] Sort(int[] arr)
{
    int[] copy = new int[arr.Length];
    Array.Copy(arr, copy, arr.Length);

    for (int i = 1; i < copy.Length; i++)
    {
        var item = copy[i];
        var index = i;
        for (int j = i - 1; j >= 0; j--)
        {
            var current = copy[j];
            
            if (current > item)
            {
                copy[j+1] = copy[j];
                index = j;
            }
            else
            {
                break;
            }
        }

        copy[index] = item;
    }

    return copy;
}

int[] sorted = new int[] { -1, 0, 1, 3 };
int[] random = new int[] { -5, 10, 0, 15, -20, 100, 0 };
int[] backsorted = new int[] { 3, 1, 0, -1 };
int[] empty = new int[0];

System.Console.WriteLine("Sort array");
WriteLineArray(Sort(sorted));

System.Console.WriteLine("Random array");
WriteLineArray(Sort(random));

System.Console.WriteLine("BackSorted array");
WriteLineArray(Sort(backsorted));

System.Console.WriteLine("Null Array");
WriteLineArray(Sort(empty));

