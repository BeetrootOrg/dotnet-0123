// Define and call with different parameters next methods:
//
// Method that will return max value among all the parameters
//     … min value …
// Method TrySumIfOdd that accepts 2 parameters and returns true if sum of numbers between inputs is odd, otherwise false, sum return as out parameter
//     Overload first two methods with 3 and 4 parameters
//
// Extra:
//
// Define and call with different parameters next methods:
//
// Method Repeat that will accept string X and number N and return X repeated N times (e.g. Repeat(‘str’, 3) returns ‘strstrstr’ = ‘str’ three times)

var sourceArray = new int[] { 13, 4, 23, 0, 17, 9, 42, 24 };
Console.WriteLine($"max value {MaxValue(sourceArray)}");
Console.WriteLine($"min value {MinValue(sourceArray)}");
Console.WriteLine($"bool method {TrySumIfOdd(10, 10, out int result)}");
Console.WriteLine($"repeat string {Repeat("World", 5)}");

int MaxValue(int[] sourceArray)
{
    return sourceArray.Max();
}

int MinValue(int[] sourceArray)
{
    return sourceArray.Min();
}

bool TrySumIfOdd(int x, int y, out int result)
{
    result = (x + y) % 2;
    if (result != 0)
    {
        return true;
    }
        
    return false;
}

string Repeat(string str, int num)
{
    string result = string.Concat(Enumerable.Repeat(str, num));
    return result;
}

