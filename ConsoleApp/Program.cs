void WriteArray(char[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j]);
        }
        Console.Write("\n");
    }
}

int CountNeighbours(char[,] array, int i_index, int j_index)
{
    int min_i = (i_index - 1) < 0 ? 0 : i_index - 1;
    int max_i = (i_index + 1) > array.GetLength(0) - 1 ? array.GetLength(0) - 1 : i_index + 1;
    int min_j = (j_index - 1) < 0 ? 0 : j_index - 1;
    int max_j = (j_index + 1) > array.GetLength(1) - 1 ? array.GetLength(1) - 1 : j_index + 1;
    int count = 0;
    for (int i = min_i; i <= max_i; i++)
    {
        for (int j = min_j; j <= max_j; j++)
        {
            if (array[i, j] == '*')
            {
                count++;
            }
        }
    }
    count -= (array[i_index, j_index] == '*') ? 1 : 0;
    return count;
}

char[,] Execute(char[,] cells)
{
    int columns = cells.GetLength(0);
    int rows = cells.GetLength(1);
    char[,] nextTurnCells = new char[columns, rows];
    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            nextTurnCells[i, j] = '.';
            int count = CountNeighbours(cells, i, j);
            bool IsDead = cells[i, j] == '.';
            if (IsDead)
            {
                if (count == 3)
                {
                    nextTurnCells[i, j] = '*';
                }
            }
            else
            {
                if ((count == 3) || (count == 2))
                {
                    nextTurnCells[i, j] = '*';
                }
            }
        }
    }
    return nextTurnCells;
}