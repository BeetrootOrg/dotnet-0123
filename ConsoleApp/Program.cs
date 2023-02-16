int[] SelectionSort(int[] array)
{
    int[] selected = new int[array.Length];
    selected = array;
    for (int i = 0; i < selected.Length; i++)
    {
        int smallest = i;
        for (int j = i + 1; j < selected.Length; j++)
        {
            if (selected[j] < selected[smallest]) smallest = j;
        }
        int[] item = new int[1];
        item[0] = selected[i];
        selected[i] = selected[smallest];
        selected[smallest] = item[0];
    }
    return selected;
}

int[] toSort = new int[] { 8, 4, -2, 100, 50, -40, 200, -300, 923, 90, 2, 0 };
foreach (int r in SelectionSort(toSort))
{
    Console.WriteLine(r);
}