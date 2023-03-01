// Task:
//
// Implement 3 arr algorithms:
//
// Selection
//     Bubble
// Insertion
//
// Extra:
//
// Define enum arrAlgorithmType with all 3 algorithms types and create single function arr that will accept array and arrAlgorithmType and use passed algorithm to arr array
//
// Define enum OrderBy with 2 values: Asc and Desc and update arr method with this parameter that will change arr order

using System;


int[] sort = {12, 1243,5,5656,234,56,234,23,5567,976,1,0,4,24,56};
int[] selection = Selection(sort);
int[] bublle = Bubble(sort);
int[] insertion = Insertion(sort);
Console.WriteLine("Selection Sort");
selection.ToList().ForEach(i => Console.WriteLine(i.ToString()));
Console.WriteLine("Selection Sort end");

Console.WriteLine("Bubble Sort");
bublle.ToList().ForEach(i => Console.WriteLine(i.ToString()));
Console.WriteLine("Bubble Sort end");

Console.WriteLine("Insertion Sort");
insertion.ToList().ForEach(i => Console.WriteLine(i.ToString()));
Console.WriteLine("Insertion Sort end");
int[]? Selection(int[]? arr)
{
    var arrayLength = arr.Length;

    for (int i = 0; i < arrayLength - 1; i++)
    {
        var smallestVal = i;

        for (int j = i + 1; j < arrayLength; j++)
        {
            if (arr[j] < arr[smallestVal])
            {
                smallestVal = j;
            }
        }

        (arr[smallestVal], arr[i]) = (arr[i], arr[smallestVal]);
    }
    return arr;
}

int[]? Bubble(int[]? arr)
{
    int temp;
    for (int j = 0; j <= arr.Length - 2; j++) {
        for (int i = 0; i <= arr.Length - 2; i++) {
            if (arr[i] > arr[i + 1]) {
                temp= arr[i + 1];
                arr[i + 1] = arr[i];
                arr[i] = temp;
            }
        }
    }
    return arr;
}

int[]? Insertion(int[]? arr)
{
    for (int i = 1; i < arr.Length; i++)
    {
        var key = arr[i];
        var flag = 0;
        for (int j = i - 1; j >= 0 && flag != 1;)
        {
            if (key < arr[j])
            {
                arr[j + 1] = arr[j];
                j--;
                arr[j + 1] = key;
            }
            else flag = 1;
        }
    }
    return arr;
}