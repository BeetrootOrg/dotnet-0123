int Max5(int a, int b, int c = 0, int d = 0, int e = 0)
{
    if (a >= b)
    {
        if (a >= c)
            if (a >= d)
                if (a >= e)
                    return a;
    }
    else
    {
        a = b;
        b = c;
        c = d;
        d = e;
    }
    return Max5(a, b, c, d, e);
}


int Min5(int a, int b, int c=0, int d=0, int e=0)
{
    if (a <= b)
    {
        if (a <= c)
            if (a <= d)
                if (a <= e)
                    return a;
    }
    else
    {
        a = b;
        b = c;
        c = d;
        d = e;
    }
    return Min5(a, b, c, d, e);
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


Console.WriteLine(Max5(3, 18, 30, 20, 5));
Console.WriteLine(Min5(5, 2, 5, 1, 4));
Console.WriteLine(TrySumIfOdd(1, 3, out int result));
Console.WriteLine(Repeat("hello", 5));