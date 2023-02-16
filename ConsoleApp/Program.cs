using ConsoleApp.Classes;

using System.Linq;
using System.Text;
//---------------- 15.02.2023----------------------
//--------- Гра життя ----------------

var cs = new Cells(18, 50);
cs.Run();
class Cells
{
    public int Rows { get; }
    public int Cols { get; }
    Cell[,] matrix;
    public Cells(int rows, int cols)
    {
        Rows = rows; Cols = cols;
        matrix = new Cell[Rows, Cols];
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Cols; c++)
            {
                matrix[r, c] = new Cell(in matrix, r, c);
            }
        }
    }
    public async void Run()
    {
        bool flag = true;
        do
        {
            DrawCurrState();
            var copy = MakeCopy();
            UpdateNextStage();
            Thread.Sleep(400);
            flag = CheckState(copy);
        } while (flag);
         DrawCurrState();
    }
    bool CheckState(int[] copy)
    {
        int i = 0;
        foreach (var item in matrix)
        {
            if (copy[i] != item.NextState) return true;
            i++;
        }
        return false;
    }
    public void UpdateNextStage()
    {
        foreach (var c in matrix)
        {
            c.InitNexState();
        }
    }
    int[] MakeCopy()
    {
        int[] result = new int[matrix.Length];
        int i = 0;
        foreach (var item in matrix)
        {
            result[i] = item.CurrentState;
            i++;
        }
        return result;
    }
    public void DrawCurrState()
    {
        Console.Clear();
        //Console.WriteLine($"Draw Curr State {DateTime.Now}:");
        var s = new StringBuilder();
        foreach (var c in matrix)
        {
            c.CurrentState = c.NextState;
            s.Append(c.GetCurString());
        }
        Console.WriteLine(s);
    }
}


class Cell
{
    public int CurrentState { get; set; } = 0;
    public int NextState { get; set; } = 0;
    public int Row { get; set; }
    public int Col { get; set; }
    Cell[,] Cells { get; set; }
    int startrow, endrow, startcol, endcol;
    public Cell(in Cell[,] cells, int row, int col)
    {
        int rows = cells.GetLength(0) - 1;
        int cols = cells.GetLength(1) - 1;
        Row = row; Col = col; Cells = cells;
        if (row < 1) startrow = 0; else startrow = row - 1;
        if (row < rows) endrow = row + 1; else endrow = cells.GetLength(0) - 1;
        if (col < 1) startcol = 0; else startcol = col - 1;
        if (col < cols) endcol = col + 1; else endcol = cells.GetLength(1) - 1;
        var r = new Random();
        CurrentState = NextState = (byte)r.Next(0, 2);
    }

    public void InitNexState()
    {
        int sumNs = Neighbours();
        if (CurrentState == 0 && sumNs == 3) NextState = 1;
        else
        if (CurrentState == 1 && (sumNs ==3 || sumNs == 2)) NextState = 1; else NextState = 0;
    }
    public string GetCurString()
    {
        string res="-";
        if (CurrentState==1) res="8";
        if (Col == 0) res=$"\n{res}";
        return res;
    }
    public int Neighbours()
    {
        int res = 0;
        for (int r = startrow; r <= endrow; r++)
        {
            for (int c = startcol; c <= endcol; c++)
            {
                if (r == Row && c == Col) continue; else
                    res+=Cells[r, c].CurrentState;
            }
        }
        return res;
    }
}