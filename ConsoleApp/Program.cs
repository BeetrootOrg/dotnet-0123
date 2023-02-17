using ConsoleApp.Classes;

using System.Linq;
using System.Text;

//---------------- 17.02.2023----------------------
//--------- Гра життя ----------------
const char LifeCell = '*';
const char DeadCell = '.';

var cells = CreateRandomField(10, 50);
PrintField(cells);
bool flag = false;
var before = new char[cells.GetLength(0), cells.GetLength(1)];
var before1 = new char[cells.GetLength(0), cells.GetLength(1)];
do
{
    before1 = CopyArr(before);
    before = CopyArr(cells);
    cells = Execute(cells);
    PrintField(cells);
    flag = MustCancel(cells, before, before1);
} while (!flag);

//Основний метод  що повертає наступну ітерацію поля
static char[,] Execute(char[,] cells)
{
    int rows = cells.GetLength(0);
    int cols = cells.GetLength(1);
    var res = new char[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            res[i, j] = GetCellNewStatus(i, j, cells);
        }
    }
    return res;
}
//копия масиву
static char[,] CopyArr(char[,] source)
{
    int rows = source.GetLength(0);
    int cols = source.GetLength(1);
    var res = new char[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            res[i, j] = source[i, j];
        }
    }
    return res;
}
// Фунцкія перевіряє чи потрібно прервати цикл гри на основі 3-х знімків масивів
static bool MustCancel(char[,] cells, char[,] before, char[,] before1)
{
    bool res = true;
    int rows = cells.GetLength(0);
    int cols = cells.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (before[i, j] != cells[i, j]) { res = false; break; }
        }
    }
    if (!res)
    {
        res = true;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (before1[i, j] != cells[i, j]) { res = false; break; }
            }
        }
    }
    return res;
}
//Повертає новий статус клітинки, залежно від її сусідів row,col адреса клітина
static char GetCellNewStatus(int row, int col, char[,] cells)
{
    int sum = SummLifeNeighbour(row, col, cells);
    return GetCharStatus(sum, cells[row, col]);
}
//повертае статус клітинки від суми живих сусідів, та поточного статусу
static char GetCharStatus(int summlife, char status)
{
    if (status == DeadCell && summlife == 3) return LifeCell;
    if (status == LifeCell && (summlife == 3 || summlife == 2)) return LifeCell;
    return DeadCell;
}
//повертає кількість живих сусідів row,col адреса клітина
static int SummLifeNeighbour(int row, int col, char[,] cells)
{
    int rows = cells.GetLength(0) - 1;
    int cols = cells.GetLength(1) - 1;
    int summ = 0;
    int srow, erow, scol, ecol;
    if (row == 0) srow = 0; else srow = row - 1;
    if (row == rows) erow = rows; else erow = row + 1;
    if (col == 0) scol = 0; else scol = col - 1;
    if (col == cols) ecol = cols; else ecol = col + 1;
    for (int i = srow; i <= erow; i++)
    {
        for (int j = scol; j <= ecol; j++)
        {
            if (i == row && j == col) continue;
            if (cells[i, j] == LifeCell) summ++;
        }
    }
    return summ;
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
    Thread.Sleep(100);
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