using ConsoleApp.Classes;

using System.Linq;
using System.Text;
//---------------- 15.02.2023----------------------
//--------- Гра життя ----------------

var cs=new Cells(10,10);

class Cells{
    public int Rows{get;}
    public int Cols{get;}
    Cell[,] matrix;
    public Cells (int rows,int cols){
        Rows=rows; Cols=cols;
        matrix=new Cell[rows,cols];
        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                matrix[r,c]=new Cell(in matrix,r,c);
            }
        }
        DrawCurrState();
    }
    public void DrawCurrState(){
        Console.Clear();
        foreach(var c in matrix){
            Console.Write(c.GetCurString());
        }
        //await Task.Run(()=>{Thread.Sleep(300);});
        Thread.Sleep(300);
    }
}


class Cell
{
    public byte CurrentState { get; set; } = 0;
    public byte NextState { get; set; } = 0;
    public int Row { get; }
    public int Col { get; }
    Cell[,] Cells { get; set; }
    int startrow, endrow, startcol, endcol;
    public Cell(in Cell[,] cells, int row, int col)
    {
        if (row < 1) startrow = 0; else startrow = row - 1;
        if (row < cells.GetLength(0) - 1) endrow = cells.GetLength(0) - 2; else endrow = cells.GetLength(0) - 1;
        if (col < 1) startcol = 0; else startcol = col - 1;
        if (col < cells.GetLength(1) - 1) endcol = cells.GetLength(1) - 2; else endcol = cells.GetLength(1) - 1;
        var r = new Random(); Row = row; Col = Col; Cells = cells;
        CurrentState = NextState = (byte)r.Next(0, 1);
    }
    public void InitNexState()
    {
        int sumNs = Neighbours();
        if (CurrentState == 0 && sumNs == 3) { NextState = 1; return; }
        if (CurrentState == 1 && (sumNs == 3 || sumNs == 2)) NextState = 1; else NextState = 0;
    }
    public string GetCurString()
    {
        if (Col == 0) return $"\n{CurrentState}";
        return $"{CurrentState}";
    }
    public int Neighbours()
    {
        int res = -1;
        for (var r = startrow; r <= endrow; r++)
        {
            for (var c = startrow; c <= endrow; c++)
            {
                res += Cells[r,c].CurrentState;
            }
        }
        return res;
    }
}