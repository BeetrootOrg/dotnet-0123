
Console.WriteLine(MMax(1, 2,11345,234));
Console.WriteLine(MMin(3, 2,-124235));
bool f = TrySumIfOdd(4, 5, out int sum);
Console.WriteLine($"result {f} summ {sum}");
Console.WriteLine(Repeat("str", 3));

int MMax(int val1, int val2, int val3 = int.MinValue, int val4 = int.MinValue, int val5 = int.MinValue)
{
    var result = Math.Max(val1, val2);
    result = Math.Max(result, val3);
    result = Math.Max(result, val4);
    result = Math.Max(result, val5);
    return result;
}
int MMin(int val1, int val2, int val3 = int.MaxValue, int val4 = int.MaxValue, int val5 = int.MaxValue)
{
    var result = Math.Min(val1, val2);
    result = Math.Min(result, val3);
    result = Math.Min(result, val4);
    result = Math.Min(result, val5);
    return result;
}
bool TrySumIfOdd(int val1, int val2, out int sum)
{
    sum = val1 + val2;
    if (sum % 2 == 0) return true;
    return false;
}

string Repeat(string x, int num)
{
    num = num - 1;
    if (num > 0) return x + Repeat(x, num);
    return x;
}