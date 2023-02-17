// homework/06-arrays




// bubble sort
/*
Works by repeatedly swapping the adjacent elements if they are in the wrong order. 
This algorithm is not suitable for large data sets as its average and worst-case time complexity is quite high.
*/
static int[] BubbleSort(int[] arr)
{
    int length = arr.Length;
    bool flag = new bool(); //прапорець по замовчуванню false
    do
    {
        flag = true;
        for (int i = 1; i < length; i++)
        {
            if (arr[i - 1] > arr[i]) //якщо потрібно поміняти елементи, то міняємо
            {
                int tmp = arr[i - 1];
                arr[i - 1] = arr[i];
                arr[i] = tmp;
                flag = false; //якщо в нас була заміна, то опускаємо прапорець
            }

        }
    } while (flag == false); //сортуємо елементи, допоки прапорець опущений
    return arr;
}




// selection sort

/*
The algorithm repeatedly selects the smallest (or largest) element from the unsorted portion 
of the list and swaps it with the first element of the unsorted portion. 
This process is repeated for the remaining unsorted portion of the list until the entire list is sorted.
*/
static int[] SelectionSort(int[] arr)
{
    int length = arr.Length;
    for (int j = 0; j < length; j++) // цей цикл => від сортованої частини до несортованої (до кінця масиву)
    {
        for (int i = j; i < length; i++) // цей цикл => від першого до останнього елемента несортованої частини
        {
            if (arr[j] > arr[i])  // якщо потрібно, то міняємо поточний елемент сортованої частини з поточним елементом несортованої
            {
                int tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
        }
    }
    return arr;
}


//Нижче код тільки для перевірки

/*
int[] sorted = new[] { 1, 8, 16, 17, 17, 121, 255, 230, 250 };
int[] random = new[] { 8, 5, -85, 0, 8, -2, 5, 14 };
int[] backsorted = new[] { 20, 17, 15, 12, 8, 4, 0, 0, -2, -2, -15 };


Console.WriteLine("BubbleSort random");
WriteLineArray(BubbleSort(sorted));
Console.WriteLine("BubbleSort arranged");
WriteLineArray(BubbleSort(random));
Console.WriteLine("BubbleSort reversed");
WriteLineArray(BubbleSort(backsorted));
Console.WriteLine("ENDofsort");

Console.WriteLine('\n');
Console.WriteLine('\n');

Console.WriteLine("SelectionSort random");
WriteLineArray(SelectionSort(sorted));
Console.WriteLine("SelectionSort arranged");
WriteLineArray(SelectionSort(random));
Console.WriteLine("SelectionSort reversed");
WriteLineArray(SelectionSort(backsorted));

static void WriteLineArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine(array[i]);
    }
}

*/