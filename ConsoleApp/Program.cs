char[,] CopyArray(char[,] originArray)
{
    char[,] copyArray = new char[originArray.GetLength(0),originArray.GetLength(1)];
    Array.Copy(originArray, copyArray, originArray.Length);
    return copyArray;
}

char[,] Execute(char[,] cells) 
{ 
    return cells;
}