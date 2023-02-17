﻿// homework/06-arrays
// bubble sort
int[] sorted = new[] { -1, 0, 1, 3, 3 };
int[] random = new[] { -5, 10, 0, 15, -20, 100, 0 };
int[] backsorted = new[] { 3, 1, 0, -1, -1 };




static int[] BubbleSort(int[] arr)
{
    int length = arr.Length;
    bool flag = new bool(); //по замовчуванню false
    do
    {
        for (int i = 1; i < length; i++)
        {
            if (arr[i - 1] > arr[i]) //якщо потрібно поміняти елементи, то міняємо
            {
                int tmp = arr[i - 1];
                arr[i - 1] = arr[i];
                arr[i] = tmp;
            }
            else flag = true; //якщо в нас не було заміни, то піднімаємо прапорець
        }
    } while (flag == false); //сортуємо елементи, поки не буде піднятий прапорець
    return arr;
}





Console.WriteLine("BubbleSort random");
WriteLineArray(BubbleSort(new[] { 8, 5, -85, 0, 8, -2, 5, 14}));
Console.WriteLine("BubbleSort arranged");
WriteLineArray(BubbleSort(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 20 }));
Console.WriteLine("BubbleSort reversed");
WriteLineArray(BubbleSort(new[] { 20, 17, 15, 12, 8, 4, 0, 0, -2, -2, -15,}));







int[] nums1 = { 1, 2, 3 };
int[] nums2 = new[] { 1, 2, 3 };
int[] nums3 = new int[] { 1, 2, 3 };
int[] nums4 = new int[3] { 1, 2, 3 };
int[] nums5 = new int[3];
int[] nullArr = null;

/*
Console.WriteLine(nums1);
Console.WriteLine(nums2);
Console.WriteLine(nums3);
Console.WriteLine(nums4);
Console.WriteLine(nums5);
*/

static void WriteLineArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine(array[i]);
    }
}

// WriteLineArray(nums1);

static void arraychange(int[] arr, int index, int newRate)
{
    arr[index] = newRate;
}

arraychange(nums1, 1, 99);
// WriteLineArray(nums1);

nums1[1] = 100;
// WriteLineArray(nums1);

static void UpdateArrayR(ref int[] arr)
{
    arr = new[] { 4, 5, 6, 7 };
}
UpdateArrayR(ref nums1);

// WriteLineArray(nums1);



nums1 = new[] { 2, 5, 7, 10 };
// WriteLineArray(nums1);
// System.Console.WriteLine("udate null array");


UpdateArrayR(ref nullArr);
// WriteLineArray(nullArr);

// System.Console.WriteLine("foreach");
// WriteLineArrayForeach(nullArr);

static void WriteLineArrayForeach(int[] arr)
{
    foreach (int item in arr)
    {
        Console.WriteLine(item);
    }
}

/*
Console.WriteLine("RANGE OPERATOR 1..3");
WriteLineArray(nullArr[1..3]); // [1][2]

Console.WriteLine("RANGE OPERATOR ..3");
WriteLineArray(nullArr[..3]); // [0][1][2]

Console.WriteLine("RANGE OPERATOR ..3");
WriteLineArray(nullArr[1..]); // [1][2][3]
*/

/*
Console.WriteLine("COPY ARRAY");
int[] subarray = nullArr[1..];
subarray[0] = 42;
WriteLineArray(nullArr);
WriteLineArray(subarray);
*/

/*
Console.WriteLine("RANGE OPERATOR ^3..^1");
WriteLineArray(nullArr[^3..4]); // [1][2]

Console.WriteLine("RANGE OPERATOR ..^1");
WriteLineArray(nullArr[..^1]); // [0][1][2]

Console.WriteLine("RANGE OPERATOR ^3..");
WriteLineArray(nullArr[^3..]); // [1][2][3]
*/

/*
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
*/


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
Console.WriteLine(SumParams(10, 20, 30, 40));
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

Console.WriteLine("before RESIZE");
WriteLineArray(nums3);
Console.WriteLine("RESIZE");
ResizeArray(ref nums3, 8);
WriteLineArray(nums3);


System.Console.WriteLine("========resize to 2=========");
ResizeArray(ref nums3, 2);
WriteLineArray(nums3);

// BEST OPTION
System.Console.WriteLine("Array.Resize========resize to 5=========Array.Resize");
Array.Resize(ref nums3, 5);
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


System.Console.WriteLine("2D matrix");
int[,] matrix = new int[2, 4];// { { 0, 1, 2, 3 }, { 4, 5, 6, 7 } };
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

int[][] jagged = new int[2][]
{
    new[] { 1, 2, 3 },
    new[] { 1, 2},
};

foreach (int[] item in jagged)
{
    Console.WriteLine("JAGGED ARRAY");
    WriteLineArray(item);
}



Console.WriteLine($"LENGTH = {jagged.Length}");

for (int i = 0; i < jagged.Length; i++)
{
    int[] inner = jagged[i];
    for (int j = 0; j < inner.Length; j++)
    {
        Console.WriteLine(inner[j]);
    }
}



static int[] Sort(int[] arr)
{
    int[] sorted = new int[arr.Length];
    Array.Copy(arr, sorted, arr.Length);

    for (int i = 1; i < arr.Length; i++)
    {
        int item = arr[i];
        int index = i;

        for (int j = i - 1; j >= 0; j--)
        {
            int current = arr[j];
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



Console.WriteLine("SORTED ARRAY");
WriteLineArray(Sort(sorted));

Console.WriteLine("RANDOM ARRAY");
WriteLineArray(Sort(random));

Console.WriteLine("BACK SORTED ARRAY");
WriteLineArray(Sort(backsorted));




// 0, 1, 2 -> 2, 1, 0
// 0, 1, 2, 3 -> 3, 2, 1, 0
static int[] Reverse(int[] arr)
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

Console.WriteLine("REVERSE");
WriteLineArray(Reverse(new[] { 1, 2, 3 }));
Console.WriteLine("REVERSE");
WriteLineArray(Reverse(new[] { 1, 2, 3, 4 }));


//простіший спосіб
static int[] Reverse1(int[] arr)
{
    int[] reversed = new int[arr.Length];
    Array.Copy(arr, reversed, arr.Length);

    // int halfSize = reversed.Length / 2;

    for (int i = 0; i < arr.Length; i++)
    {
        // int temp = reversed[i];
        reversed[i] = arr[^(i + 1)];
        // reversed[^(i + 1)] = temp;
    }

    return reversed;
}

Console.WriteLine("REVERSE");
WriteLineArray(Reverse1(new[] { 1, 2, 3 }));
Console.WriteLine("REVERSE");
WriteLineArray(Reverse1(new[] { 1, 2, 3, 4, 5, 45, 99, 101 }));
Console.WriteLine("REVERSE");
WriteLineArray(Reverse1(new[] { 1, 2, 3, 4, 5 }));
Console.WriteLine("REVERSE");
WriteLineArray(Reverse1(new[] { 1, 2, 3, 4, 5, 45, 99, 101, 202 }));