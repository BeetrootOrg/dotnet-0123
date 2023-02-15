int N = 10;
int f_n1 = 1;
int f_n2 = 1;
for (int i = 3; i <= N; i++ )
{
    int sum = f_n1 + f_n2;
    f_n1 = f_n2;
    f_n2 = sum;
}

System.Console.WriteLine($"{N}-member of Fibonacci = {f_n2}");

static int Sum(int a, int b)
{
   int sum = a + b;
   return sum;  
}

static int SumOneLine (int a, int b) => a + b;

int a = 10;
int b = 5;
System.Console.WriteLine(Sum(a, b));
System.Console.WriteLine(SumOneLine(a, b));

int inc = 0;
void Increment ()
{
    ++inc;
}

Increment();
Increment();

System.Console.WriteLine(inc);

void Assign42 (int param)
{
    param = 42;
}

Assign42(a);
System.Console.WriteLine(a);

void Assign42Ref (ref int param)
{
    param = 42;
}
Assign42Ref(ref a);
System.Console.WriteLine(a);

void Assign42Out (out int param)
{
    param = 42;
}

int temp1;
Assign42Out(out temp1);
System.Console.WriteLine($"temp1 = {temp1}");

Assign42Out(out int temp2);
System.Console.WriteLine($"temp2 = {temp2}");

void RefNoAssign(ref int param) {}
// void OutNoAssign(out int param) {}

int temp3 = 15;
RefNoAssign(ref temp3);
System.Console.WriteLine(temp3);

bool TryReadInt(out int result)
{
    var input = Console.ReadLine();
    return int.TryParse(input, out result);

    // if (int.TryParse(input, out result)) very ugly style
    // {
    //     return true;
    // }
    // else
    // {
    //     return false;
    // }
}

if (TryReadInt(out int temp4))
{
    System.Console.WriteLine(temp4);
}


bool TryDivideByThree (int num, out int result)
{
    if (num % 3 == 0)
    {
        result = num / 3;
        return true;
    }
    else
    {
        result = 0;
        return false;
    }
}
var result1 =  TryDivideByThree (6, out temp4);
System.Console.WriteLine($"TryDivideByThree(6) = {result1}. Result = {temp4}");

result1 =  TryDivideByThree (7, out temp4);
System.Console.WriteLine($"TryDivideByThree(7) = {result1}. Result = {temp4}");

bool TryDivideByThreeBetter (int num, out int result)
{
    if (num % 3 == 0)
    {
        result = num / 3;
        return true;
    }
    result = 0;
    return false;
}

bool TryDivideByThreeBest (int num, out int result)
{
    result = num / 3;
    return num % 3 == 0;
}

result1 =  TryDivideByThreeBetter  (7, out temp4);
System.Console.WriteLine($"TryDivideByThreeBetter (7) = {result1}. Result = {temp4}");

result1 =  TryDivideByThreeBest  (7, out temp4);
System.Console.WriteLine($"TryDivideByThreeBest (7) = {result1}. Result = {temp4}");

int Fibonacci (int n)
{
    // if (n == 1)
    // {
    //     return 1;
    // }
    // if ( n == 2)
    // {
    //     return 1;
    // }
    // return Fibonacci(n - 1) + Fibonacci(n - 2);
    return n == 1 
        ? 1 
        : n == 2 
        ? 1 
        : Fibonacci(n - 1) + Fibonacci (n - 2);
}

int temp5 = Fibonacci (3);
System.Console.WriteLine($"Fibonacci(5) = {temp5}");
System.Console.WriteLine($"Fibonacci({N}) = {Fibonacci(N)}");



// void Repeat(string X, int N)
// {
//     string r = X;
//     for (int i = 2; i <= N; i++ )
//     {
//         r += X;
//     }
//     System.Console.WriteLine(r);
// };

// String x = "mayday_";
// int n = 3;
// Repeat(x, n);


