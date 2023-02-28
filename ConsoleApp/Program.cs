
// Max value
 int a = 10;
 int b = 15;
 int c = 20;
 int d = 25;
 int Max2(int a, int b)
{
   if (a > b)
   {
     return a;
   }
     return b;
}
Console.WriteLine(Max2(a, b));


int Max3(int a, int b, int c)
{
    if (a > b && a > c)
    {
        return a;
    }
    if (b > a && b > c )
    {
        return b;
    }
    return c;
}
System.Console.WriteLine(Max3(a, b, c));

int Max4(int a, int b, int c , int d)
{
    if (a > b && a > c && a > d)
    {
     return a;
    }
    if (b > a && b > c && b > d)
    {
     return b;
    }
    if (c > a && c > b && c > d)
    {
     return c;
    }
    return d;
}
Console.WriteLine(Max4(a, b, c, d));

//Min value
int a1 = 20;
int b1 = 15;
int c1 = 25;
int d1 = 10;
int Min2(int a1, int b1) => a1 < b1 ? a1 : b1;
    System.Console.WriteLine(Min2(a1, b1));

int Min3(int a1, int b1, int c1) => Min2(a1, b1) < c ? Min2(a1, b1) : c1;
    System.Console.WriteLine(Min3(a1, b1, c1));

int Min4(int a1, int b1, int c1, int d1) => Min3(a1, b1, c1) < d1 ? Min3(a1, b1, c1) : d1;
    System.Console.WriteLine(Min4(a1, b1, c1, d1));




//Method TrySumIfOdd
bool TrySumIfOdd( int a, int b, out int result)
{
    if((a + b) % 2 == 1)
    {
        result = (a + b) / 2;
        return true;
    }
    else
    {
        result = (a + b) / 2;
        return false;
    }    
    
}
 bool result = TrySumIfOdd(15, 15, out int temp1);
 Console.WriteLine($"TrySumIfOdd(15, 15) = {result}. Result = {temp1}");

 result = TrySumIfOdd(15, 20, out int temp2);
 Console.WriteLine($"TrySumIfOdd(15, 20) = {result}. Result = {temp2}");


//Extra
Console.WriteLine("Enter the word");
string X = Console.ReadLine();

Console.WriteLine("Enter the number");
int N = Convert.ToInt32(Console.ReadLine());

void Repeat( string X,  int N)
{
    if ( N == 1)
    {
        Console.WriteLine(X);
    }
    else 
    {
        System.Console.WriteLine(X);
        Repeat(X, N - 1);
    }
}
Repeat(X, N);


