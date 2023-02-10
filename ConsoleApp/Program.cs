

/* static int Sum (int a, int b)
{
    var sum = a + b;
    return sum;   
}

int a = 15;
int b = 20;
System.Console.WriteLine(Sum(a, b));

static int SumOneLine (int a, int b) => a + b;

System.Console.WriteLine(SumOneLine(42, 80));

int inc = 0;
void Increment()
{
    ++inc;
}

Increment();
Increment();
System.Console.WriteLine(inc);

void Assing42(int c)
{
      c = 42;
}

Assing42(a);
System.Console.WriteLine(a);

void Assing42Ref (ref int c)
{
    c = 42;
}

Assing42Ref(ref a);
System.Console.WriteLine(a);

void Assing42Out (out int c)
{
    c = 42;
}
int d;
Assing42Out(out d);
System.Console.WriteLine(d);

Assing42Out(out int e);
System.Console.WriteLine(e);

bool TryreadInt(out int result)
{
    string input = Console.ReadLine();
    return int.TryParse(input, out result);
}
if (TryreadInt(out int temp4))
{
    System.Console.WriteLine(temp4);
}

bool TryDevideByThree(int num, out int result)
{
    if (num % 3 == 0)
    {
        result = num / 3;
        return true;
    }
    else 
        result = 0;
        return false;
}
bool result = TryDevideByThree(6, out temp4);
Console.WriteLine($"TryDevideByThree(6) = {result}. Result = {temp4}");

result = TryDevideByThree(7, out temp4);
Console.WriteLine($"TryDevideByThree(7) = {result}. Result = {temp4}");

bool TryDevideByThreeBest(int num, out int result)
{
    result = num / 3;
    return num % 3 == 0;
}
result = TryDevideByThree(7, out temp4);
Console.WriteLine($"TryDevideByThree(7) = {result}. Result = {temp4}");

int Fibanachi (int n)
{
    if ( n == 1)
    {
        return n = 1;
    }
    if ( n == 2)
    {
        return n = 1;
    }
    return Fibanachi(n - 1) + Fibanachi(n - 2);
}

int FibanachiLoop (int n)
{
    int prev = 1;
    int curr = 1;
    int i = n -2;
    while(i-- > 0)
    {
        int temp = prev;
        prev = curr;
        curr += temp;
    }
    return curr;
}
Console.WriteLine(Fibanachi(3));

void PrintHello( string name)
{
    System.Console.WriteLine($"Hello, {name}");
}
PrintHello("Dima");

void PrintHello1( string name = "Dima")
{
    System.Console.WriteLine($"Hello, {name}");
}
PrintHello1();

void PrintNumbersLoop(int a, int b)
{
    for(int i = a; i <= b; i++)
    Console.WriteLine(i);
}
PrintNumbersLoop(5, 15);

void PrintNumbersRecorsion(int a, int b)
{
    System.Console.WriteLine(a);
    if(a != b)
    {
        PrintNumbersRecorsion(a + 1, b);
    }
}
PrintNumbersRecorsion(5, 15); */




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


