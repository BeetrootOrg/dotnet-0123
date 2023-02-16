
void Repeat(string X, int N)
{
    string r = X + " ";
    for (int i = 2; i <= N; i++ )
    {
        r += X + " ";
    }
    System.Console.WriteLine(r);
};

System.Console.WriteLine("Enter a string");
String x = Console.ReadLine();

System.Console.WriteLine("Enter qty of repeat");
string nst = Console.ReadLine();
//int n = int.Parse(nst);

bool success = int.TryParse(nst, out int n);

if (!success)
{
    System.Console.WriteLine("Invalid input");
    return;
}

Repeat(x, n);

// Define and call with different parameters next methods:

// Method that will return max value among all the parameters
// … min value …
// Method TrySumIfOdd that accepts 2 parameters and returns true if sum of numbers between inputs is odd, otherwise false, sum return as out parameter
// Overload first two methods with 3 and 4 parameters

int Max2(int a, int b)
{
    return a < b ? b : a;
}

int Min2(int a, int b)
{
    return a < b ? a : b;
}

int Max3(int a, int b, int c)
{
    return a > Max2(b, c) ? a : Max2(b, c);
}

int Min3(int a, int b, int c)
{
    return a < Min2(b, c) ? a : Min2(b, c);
}

int Max4(int a, int b, int c, int d)
{
    return a > Max3(b, c, d) ? a : Max3(b, c, d);
}

int Min4(int a, int b, int c, int d)
{
    return a < Min3(b, c, d) ? a : Min3(b, c, d);
}

int Max(int a, int b, int c = int.MinValue, int d = int.MinValue)
{
    return Max2(a, b) > Max2(c, d) ? Max2(a, b) : Max2(c, d);
}

int Min(int a, int b, int c = int.MaxValue, int d = int.MaxValue)
{
    return Min2(a, b) < Min2(c, d) ? Min2(a, b) : Min2(c, d);
}

bool TrySumIfOdd(int a, int b, out int result)
{
    result = 0;
    for (int i = Min2(a, b); i <= Max2(a, b); i++)
    {
        result += i;
    }
    return result % 2 != 0 ? true : false;
}


System.Console.WriteLine($"Max2(5, 15) = {Max2(5, 15)}");
System.Console.WriteLine($"Min2(5, 15) = {Min2(5, 15)}");
System.Console.WriteLine($"Max3(3, -67, 6) = {Max3(3, -67, 6)}");
System.Console.WriteLine($"Min3(0, 56, -5) = {Min3(0, 56, -5)}");
System.Console.WriteLine($"Max4(1, 2, 3, 4) = {Max4(1, 2, 3, 4)}");
System.Console.WriteLine($"Min4(-7, 0, 9, 2147483647) = {Min4(-7, 0, 9, 2147483647)}");

System.Console.WriteLine($"Max(3, 4) = {Max(3, 4)}");
System.Console.WriteLine($"Max(3, -2147483648) = {Max(3, -2147483648)}");
System.Console.WriteLine($"Max(3, 0, 5, 2147483647) = {Max(3, 0, 5, 2147483647)}");

System.Console.WriteLine($"Min(7, 0, -514) = {Min(7, 0, -514)}");

bool ifSumOdd = TrySumIfOdd(7, 13, out int sum);
System.Console.WriteLine($"TrySumIfOdd = {ifSumOdd}, sum = {sum}");

