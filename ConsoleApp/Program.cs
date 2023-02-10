int Max3(int a, int b, int c)
{
    if (a >= b & a>=c) return a;
    else
    {
        a = b;
        b = c;
    }
    return Max3(a, b, c);
}


int Min3 (int a, int b, int c)
{
    if (a <= b & a <= c)
    {
        return a;
    }
    else
    {
        a = b;
        b = c;
    }
    return Min3(a, b, c);
}


int Max4(int a, int b, int c, int d)
{
    if (a >= b & a >=c & a>=d) return a;
    else
    {
        a = b;
        b = c;
        c = d;
    }
    return Max3(a, b, c);
}


int Min4(int a, int b, int c, int d)
{
    if (a <= b & a <=c & a<=d) return a;
    else
    {
        a = b;
        b = c;
        c = d;
    }
    return Min3(a, b, c);
}


int Max5(int a, int b, int c, int d, int e)
{
    return Max3(a, b, Max3(c, d, e));
}


int Min5(int a, int b, int c, int d, int e)
{
    return Min3(a, b, Min3(c, d, e));
}


bool TrySumIfOdd(int a, int b, out int result)
{
    result = 0;
    for (int i = a; i <= b; i++)
    {
        result += i;
    }
    if (result % 2 == 0)
    {
        return false;
    }
    else return true;
}


string Repeat(string text, int count)
{
    string repeat_text = "";
    if (count == 0) return "";
    else
    {
        for (int i = 1; i <= count; i++)
        {
            repeat_text += text;
        }
        return repeat_text;
    }
}


Console.WriteLine(Max3(3, 18, 30));
Console.WriteLine(Min3(5, 4, 2));
Console.WriteLine(Max4(3, 18, 30, 100));
Console.WriteLine(Min4(5, 4, 2, 1));
Console.WriteLine(Max5(3, 18, 30, 67, 31));
Console.WriteLine(Min5(5, 4, 2, 6, 4));
Console.WriteLine(TrySumIfOdd(1, 7, out int result));
Console.WriteLine(Repeat("hello", 5));