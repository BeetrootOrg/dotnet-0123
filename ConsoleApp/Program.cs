const int n = 5;

int previous = 0;
int current = 1;

if(n == 1)
{
    Console.WriteLine(previous);
}
else if(n == 2)
{
    Console.WriteLine(current);
}
else
{
    for (int i = 3; i <= n; i++)
    {
        int temp = current;
        current += previous;
        previous = temp;
    }
    Console.WriteLine(current);
}