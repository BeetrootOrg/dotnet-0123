using ConsoleApp.Classes;
//---------------- 11.02.2023----------------------
//--------- Масиви ----------------

int[] tosort = { 123, 3456, 5, 879, 789, 899, 900, 566 };
int[] tosortsel = { 123, 3456, 5, 879, 789, 899, 900, 566 };
int[] tosortbuble = { 123, 3456, 5, 879, 789, 899, 900, 566 };
int[] tosortins = { 123, 3456, 5, 879, 789, 899, 900, 566 };
bool flag = true;
int j = 1;

Console.WriteLine($"SelectionSort");
WriteLineArray(SelectionSort(tosortsel));
Console.WriteLine($"BubbleSort");
WriteLineArray(BubbleSort(tosortbuble));
Console.WriteLine($"SelectionSort");
WriteLineArray(SelectionSort(tosortbuble));
Console.WriteLine($"InsertionSort");
WriteLineArray(InsertionSort(tosortins));

int[] InsertionSort(int[] arrey)
{
    if (arrey.Length < 2) return arrey;
    int[] arr = new int[arrey.Length];
    Array.Copy(arrey, arr, arrey.Length);
    int buf;
    for (int i = 1; i < arrey.Length; i++)
    {
        buf = arr[i];
        for (int j = i - 1; j >= 0;)
        {
            if (buf < arr[j])
            {
                arr[j + 1] = arr[j];
                j--;
                arr[j + 1] = buf;
            }
            else
            {
                break;
            }
        }

    }
    return arr;
}

int[] BubbleSort(int[] arrey)
{
    if (arrey.Length < 2) return arrey;
    int[] arr = new int[arrey.Length];
    Array.Copy(arrey, arr, arrey.Length);
    int buf;
    for (int j = 0; j <= arr.Length - 2; j++)
    {
        for (int i = 0; i <= arr.Length - 2; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                buf = arr[i + 1];
                arr[i + 1] = arr[i];
                arr[i] = buf;
            }
        }
    }
    return arr;
}

int[] SelectionSort(int[] arrey)
{
    if (arrey.Length < 2) return arrey;
    int[] arr = new int[arrey.Length];
    Array.Copy(arrey, arr, arrey.Length);
    int minind, buf;
    for (int i = 0; i < arr.Length - 1; i++)
    {
        minind = i;
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[minind] > arr[j]) { minind = j; }
        }
        if (i != minind)
        {
            buf = arr[i];
            arr[i] = arr[minind];
            arr[minind] = buf;
        }
    }
    return arr;
}

void WriteLineArray(int[] arr)
{
    foreach (var item in arr)
    {
        Console.WriteLine(item);
    }
}

do
{
    flag = false;
    Console.WriteLine($"Проход {j}"); j++;
    for (int i = 1; i < tosort.Length; i++)
    {
        var c = tosort[i - 1];
        if (c > tosort[i])
        {
            tosort[i - 1] = tosort[i];
            tosort[i] = c;
            flag = true;
            WriteLineArray(tosort);
        }
    }
} while (flag);