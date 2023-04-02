using ConsoleApp;
using System.Collections.Concurrent;
bool isLost = false;


char[,] field = new char [12,12]
{{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'},
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'}};

 char[,] emptyfield = new char [12,12]
 {{'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'},
 {'X', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', 'X'}, 
 {'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'}};


static void Print2DArray<T>(T[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            //if (i != 0 & j != 0 & i != matrix.GetLength(0)-1 & j != matrix.GetLength(1)-1)
            Console.Write(matrix[i,j] + "\t");
        }
        Console.WriteLine();
    }
}


Print2DArray<char>(field);

Snake snake = new Snake();
snake.CreateSnake();
snake.createApple();

void Game()
{
    while (isLost != true)
    {
        if (snake.snakeCells.Count <= 20)
        {
        System.Threading.Thread.Sleep(1200 - 50*snake.snakeCells.Count);
        }
        else
        {
        System.Threading.Thread.Sleep(200);
        }

        Console.Clear();
        Cell firstCell = (Cell)snake.snakeCells[0];


        snake.Step(firstCell.vector);

        isGameOver();
        Print2DArray(snake.Execute(field));

    }
}

Task.Run(async () =>
{
    while (isLost != true)
    {   
        Cell firstCell = (Cell)snake.snakeCells[0];
        ConsoleKeyInfo key1 = Console.ReadKey(false);
        if (key1.Key == ConsoleKey.W)
        {
            firstCell.vector = 1;
        }
        if (key1.Key == ConsoleKey.A)
        {
            firstCell.vector = 2;
        }
        if (key1.Key == ConsoleKey.S)
        {
            firstCell.vector = 3;
        }
        if (key1.Key == ConsoleKey.D)
        {
            firstCell.vector = 4;
        }
    }
});




void isGameOver()
{
    foreach (Cell firstCell in snake.snakeCells.ToList())
    {
        if (firstCell.name == 0)
        {
            if (snake.getY(firstCell._core) == 0 & firstCell.vector == 2)
            {
                isLost = true;
            }
            if (snake.getY(firstCell._core) == 9 & firstCell.vector == 4)
            {
                isLost = true;
            }
            if (snake.getX(firstCell._core) == 0 & firstCell.vector == 1)
            {
                isLost = true;
            }
            if (snake.getX(firstCell._core) == 9 & firstCell.vector == 3)
            {
                isLost = true;
            }

            foreach (Cell cell in snake.snakeCells.ToList())
            {
                if (cell.name != 0)
                {
                    if (snake.getX(cell._core) == snake.getX(firstCell._core) & snake.getY(cell._core) == snake.getY(firstCell._core))
                    {
                        isLost = true;
                    }
                }
            }
        }
    }
}

Game();
Console.Clear();
Console.WriteLine("Game over!");
Console.WriteLine($"Score: {snake.snakeCells.Count-4}");