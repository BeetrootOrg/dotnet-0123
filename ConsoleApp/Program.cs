int N = 7;
int a1 = 1;
int a2 = 1;
int a = 0;
for (int i = 1; i<= N; i++ )
{
    a = a1 + a2;
    a1 = a2;
    a2 = a;
}
Console.WriteLine (a);
