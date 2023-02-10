
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
