char[,] a = new char [8,8] {{'.','.','.','*','*','.','.','.'},{'.','.','*','*','*','*','.','.'},{'.','*','.','.','.','.','*','.'},{'*','*','.','.','.','.','*','*'},{'*','*','.','.','.','.','*','*'},{'.','*','.','.','.','.','*','.'},{'.','.','*','*','*','*','.','.'},{'.','.','.','*','*','.','.','.'}};


static void Print2DArray<T>(T[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i,j] + "\t");
        }
        Console.WriteLine();
    }
}

//1) Any live cell with fewer than two live neighbours dies, as if by underpopulation.
//2) Any live cell with two or three live neighbours lives on to the next generation.
//3) Any live cell with more than three live neighbours dies, as if by overpopulation.
//4) Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.


char[,] Execute(char[,] cells) 
{ 

    
    int iterations = cells.Length;
    int x = cells.GetLength(0);
    int y = cells.GetLength(1);

    char[,] solution = new char[x+2,y+2];
    char[,] answer = new char[x,y];

    //creating game borders
    for (int i = 0; i < x+2; i++)
    {
        for (int j = 0; j < y+2; j++)
        {
            if (i == 0 || j == 0 || i == x+1 || j == y+1)
            {
                solution[i,j] = '+';
            }
            else
            {
                solution[i,j] = cells[i-1,j-1];
            }
        }
    }

    for (int i = 1; i < x+1; i++)
    {
        for (int j = 1; j < y+1; j++)
        {
            int neighbours = 0;

            if (solution[i+1,j] == '*')
            {
                neighbours += 1;
            }
            if (solution[i,j+1] == '*')
            {
                neighbours += 1;
            }
            if (solution[i-1,j] == '*')
            {
                neighbours += 1;
            }
            if (solution[i,j-1] == '*')
            {
                neighbours += 1;
            }
            if (solution[i+1,j+1] == '*')
            {
                neighbours += 1;
            }
            if (solution[i+1,j-1] == '*')
            {
                neighbours += 1;
            }
            if (solution[i-1,j-1] == '*')
            {
                neighbours += 1;
            }
            if (solution[i-1,j+1] == '*')
            {
                neighbours += 1;
            }

            if (solution[i,j] == '*')
            {
                if (neighbours == 2 || neighbours == 3)
                {
                    answer[i-1,j-1] = '*';
                }
                else
                {
                    answer[i-1,j-1] = '.';
                }
            }
            else if (solution[i,j] == '.')
            {
                if (neighbours == 3)
                {
                    answer[i-1,j-1] = '*';
                }
                else
                {
                    answer[i-1,j-1] = '.';
                }
            }
        }
    }
    return(answer);
}

char[,] Run(char[,] cells, int t)
{
    while(true)
    {
    Console.Clear();

    Print2DArray(cells);
    cells = Execute(cells);
    System.Threading.Thread.Sleep(t*1000);
    }
    return cells;
} 
