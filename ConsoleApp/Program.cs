(int, string) tuple = (42, "hello");
Console.WriteLine(tuple);

(string, string) fullname1 = ("Dmytro", "Misik");
Console.WriteLine(fullname1);
Console.WriteLine(fullname1.Item1);
Console.WriteLine(fullname1.Item2);

(string, string) fullname2 = ("Dmytro", "Misik");
Console.WriteLine(fullname1 == fullname2);

static (int, string) GetSome()
{
    return (42, "something");
}

(int, string) result = GetSome();
(int num, string some) = GetSome();
(int a, string b) = result;

Console.WriteLine(result);
Console.WriteLine(num);
Console.WriteLine(some);
Console.WriteLine(a);
Console.WriteLine(b);