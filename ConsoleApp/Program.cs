using ConsoleApp.Classes;

using System.Linq;
using System.Text;

//---------------- 17.02.2023----------------------
//--------- Гра життя ----------------
const char LifeCell = '*';
const char DeadCell = '.';

var cells = CreateRandomField(18, 50);

cells = Execute(cells);

//Основний метод  що повертає наступну ітерацію поля
static char[,] Execute(char[,] cells)
{
    return null;
}
//Виводе масив клітинок в консоль
static void PrintField(char[,] cells)
{
    int rows = cells.GetLength(0);
    int cols = cells.GetLength(1);
    var res = new StringBuilder();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            res.Append(cells[i, j]);
        }
        res.Append('\n');
    }
    Console.Clear();
    Console.WriteLine(res);
}
// создає довільне масив живих та мертвих клітинок розімром rows*cols
static char[,] CreateRandomField(int rows, int cols)
{
    var res = new char[rows, cols];
    var ran = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            res[i, j] = GetCellChar(ran.Next(0, 2));
        }
    }
    return res;

    static char GetCellChar(int code)
    {
        if (code == 1) return LifeCell;
        return DeadCell;
    }
}