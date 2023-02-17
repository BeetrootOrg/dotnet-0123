using ConsoleApp.Classes;

using System.Linq;
using System.Text;
//---------------- 17.02.2023----------------------
// Домашка
// Основне

// 1. Compare that will return true if 2 strings are equal, otherwise false, but do not use build-in method
Console.WriteLine(Compare("Andrey", "Andrey"));
Console.WriteLine(Compare("Andrey", "ANDREY"));
Thread.Sleep(1000);
bool Compare(string str1, string str2)
{
    if (str1.Length != str2.Length) return false;
    for (int i = 0; i < str1.Length; i++)
    {
        if (str1[i] != str2[i]) return false;
    }
    return true;
}
// 2. Analyze that will return number of alphabetic chars in string, digits and another special characters
Analyze("Andrey12345!,.\n\t");
void Analyze(string str)
{
    int alpha = 0;
    int digi = 0;
    int spec = 0;
    int punct = 0;
    foreach (char c in str)
    {
        if (char.IsLetter(c)) alpha++;
        if (char.IsDigit(c)) digi++;
        if (char.IsControl(c)) spec++;
        if (char.IsPunctuation(c)) punct++;
    }
    Console.WriteLine($"Letters {alpha}");
    Console.WriteLine($"Digits {digi}");
    Console.WriteLine($"Controls {spec}");
    Console.WriteLine($"Punctuations {punct}");
}
Thread.Sleep(1000);
//3. Sort that will return string that contains all characters from input 
// string sorted in alphabetical order (e.g. 'Hello' -> 'ehllo')
Console.WriteLine(Sort("Andrey"));
Thread.Sleep(1000);
string Sort(string s)
{
    var arr=s.ToCharArray();
    if (arr.Length < 2) return new string(arr);
    char buf;
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
    return new string(arr);
}
// 4.Duplicate that will return array of characters that are duplicated in input string 
// (e.g. 'Hello and hi' -> ['h', 'l'])
Console.WriteLine(new string(DuplicateCheck("Andrey Vasya")));
Thread.Sleep(1000);
char[] DuplicateCheck(string s){
    var arr=s.ToCharArray();
    string res=string.Empty;
    foreach(char c in arr){
        int i=0;
        foreach(char c1 in arr){
            if (c1==c) i++;
        }
        if (i>1) res=res+c;
    }
    return res.Distinct().ToArray();
}
//--------- Гра життя ----------------
const char LifeCell = '*';
const char DeadCell = '.';

var cells = CreateRandomField(5, 5);
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