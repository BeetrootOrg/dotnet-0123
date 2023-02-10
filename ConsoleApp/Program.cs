/* Домашня робота 04-functions

Define and call with different parameters next methods:
Method that will return max value among all the parameters
… min value …

Overload first two methods with 3 and 4 parameters
Extra:

Define and call with different parameters next methods:


*/


int x1 = 99;
int x2 = 1013;
int x3 = 297;
int x4 = 976;

/////////////////////////////////////////////////
int result = Max2(x1, x2);
// Console.WriteLine(result);
int Max2(int a, int b)
{
    if (a > b) return a;
    return b;
}
/////////////////////////////////////////////////
result = Max3(x1, x2, x3);     // тут без int, бо вже визначили тип
// Console.WriteLine(result);
int Max3(int a, int b, int c)
{
    if (Max2(a, b) < c) return c;
    return (Max2(a, b));
}
/////////////////////////////////////////////////
result = Max4(x1, x2, x3, x4);
// Console.WriteLine(result);
int Max4(int a, int b, int c, int d)
{
    if (Max2(a, b) < Max2(c, d))
    {
        return Max2(c, d);
    }
    return Max2(a, b);
}
/////////////////////////////////////////////////
result = Max(x4, x2, x1);
// Console.WriteLine(result);
int Max(int a, int b, int c = 0, int d = 0)
{
    // return c == 0 ? Max3(a, b, d)    // тут чомусь помилка компілятора
    // : d == 0 ? Max3(a, b, c);        // тут чомусь помилка компілятора
    if (c == 0) return Max3(a, b, d);
    return Max3(a, b, c);
}
/////////////////////////////////////////////////
// з Min не роблю бо все те саме.
/////////////////////////////////////////////////


/*
Method TrySumIfOdd that accepts 2 parameters and returns 
true if sum of numbers between inputs is odd, 
otherwise false, sum return as out parameter
*/

bool oddEven = TrySumIfOdd(x1, x2, out var suma); //ініціалізуємо змінну suma і записуємо туди значення із result
Console.WriteLine($"{x1} + {x2} = {suma}...{oddEven}");

bool TrySumIfOdd(int a, int b, out int result) // тут де result, у нас буде назва змінної (suma) із виклику
{
    if ((a + b) % 2 == 0)
    {
        result = a + b; //ця сама змінна result передастся в шапку функції, їй потрібно присвоїти значення перед return
        return false;
    }
    result = a + b;
    return true;        //ця сама змінна result передастся в шапку функції, їй потрібно присвоїти значення перед return
}
/////////////////////////////////////////////////

/* 
Method Repeat that will accept string X and number N and return X repeated N times
(e.g. Repeat(‘str’, 3) returns ‘strstrstr’ = ‘str’ three times)
*/

string text = Repeat(x1); //без опціонального параметра
string text2 = Repeat(x1, "str "); //з опціональним параметром
Console.WriteLine(text);
Console.WriteLine(text2);

string Repeat(int n, string sign = "yourtext ")
{
    string stroka = sign;
    while (n > 1)
    {
        //sign += "str ";
        stroka += sign;
        n--;
    }
    return stroka;
}

/*



int Sum(int a, int b)
{
    var sumaa = a + b;
    return sumaa;
}

int x = 20;
int y = 15;

Console.WriteLine(Sum(x, y));

int sumOneLine(int a, int b) => a + b; //
Console.WriteLine(sumOneLine(42, 80));



int inc = 0;
void IncrementWithClosure()
{
    ++inc;
}

static void IncrementWithoutClosure()
{
    int inc = 0; // ця змінна внутрішня і ніякого відношення до зовнішньої змінної inc вона не має; замикання змінної
    ++inc;
}


IncrementWithClosure();
IncrementWithClosure();
IncrementWithoutClosure();


Console.WriteLine(inc);


void Assign42(int param)
{
    param = 42;
}

Assign42(x);  // тут значення змінної копіюється для відпрацювання в функції, але сама змінна не міняється
Console.WriteLine(x);


void Assign42R(ref int param)
{
    param = 42;
}

Assign42R(ref x);  // тут значення змінної копіюється для відпрацювання в функції, але сама змінна не міняється тобто x залишиться 20
Console.WriteLine(x);


void Assign42Ref(ref int param) //тут вже значення посилається на змінну і змінна міняється реально
{
    param = 42;
}

Assign42Ref(ref x); //тобто тут змінна х = 42
Console.WriteLine(x);

void Assign42Out(out int param)
{
    param = 42;
}

int temp1; // цю строку можна було взагалі закоментвати, бо out ініціалізує змінну
Assign42Out(out temp1); // в нас міняєтья непроініціалізована змінна і вона приймає значення 42 
Console.WriteLine(temp1);

Assign42Out(out int temp2); //тут ще одна змінна ініціалізується і теж приймає значення 42
Console.WriteLine(temp2);

void RefNoAssign(ref int param) { }  // а тут нічого немає в функції навіть ніякого return

// COMPILATION ERROR
// void OutNoAssign(out int param) { }

int temp3 = 15;
RefNoAssign(ref temp3);
Console.WriteLine(temp3); // а тут нічого немає в функції, тож ніяких змін зі змінною не буде


bool TryReadInt(out int result) //результатом ф-ції є булеан (аргумент int result)
{
    string input = Console.ReadLine();
    return int.TryParse(input, out result); // повертає true або false, якщо тру, то в result розпарсене стрінгове значення input
}

if (TryReadInt(out int temp4)) //тут значення фуції bool, але аргумент temp4 це змінна що ініціалізується і створюється вона в функції - див. вище.
{
    Console.WriteLine(temp4);
}


bool TryDivideByThree(int num, out int result)
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

bool TryDivideByThreeBetter(int num, out int result)
{
    if (num % 3 == 0)
    {
        result = num / 3;
        return true;
    }

    result = 0;
    return false;
}


bool TryDivideByThreeBest(int num, out int result)
{
    result = num / 3;
    return num % 3 == 0; // тут буде булеве значення при дійсній умові, але при не дійсній змінна result буде мати будь-що, навіть не int
}

bool result = TryDivideByThree(6, out temp4);
Console.WriteLine($"TryDivideByThree(6) = {result}. Result = {temp4}"); //тут result це true або false, а temp4 це результат

result = TryDivideByThreeBetter(7, out temp4);
Console.WriteLine($"TryDivideByThree(7) = {result}. Result = {temp4}");

result = TryDivideByThreeBest(7, out temp4);
Console.WriteLine($"BEST VERSION: TryDivideByThree(7) = {result}. Result = {temp4}");



long Fibonacci(int n)   // тут функція з рекурсією
{

    if (n == 1)
    {
        return 1;
    }

    if (n == 2)
    {
        return 1;
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);

}


long FibonacciLoop(int n)
{
    long prev = 1;
    long curr = 1;

    int i = n - 2;
    while (i-- > 0)
    {
        long temp = prev;
        prev = curr;
        curr += temp;
    }

    return curr;
}

long FibonacciWithTernary(int n)
{
    return n == 1 ? 1
    : n == 2 ? 1
    : FibonacciWithTernary(n - 1) + FibonacciWithTernary(n - 2);
}

Console.WriteLine(Fibonacci(3));
Console.WriteLine(Fibonacci(5));
Console.WriteLine(FibonacciWithTernary(3));

const int n = 30;


// Stopwatch sw = new();

// sw.Start();
Console.WriteLine(FibonacciLoop(n));
// sw.Stop();

// Console.WriteLine($"Elapsed: {sw.ElapsedMilliseconds}ms");

// sw.Reset();

// sw.Start();
Console.WriteLine(Fibonacci(n));
// sw.Stop();

// Console.WriteLine($"Elapsed: {sw.ElapsedMilliseconds}ms");

void PrintHello(string name = "Dima") //опціональний параметр
{
    Console.WriteLine($"Hello, {name}!");
}

PrintHello("Vova");
PrintHello();
PrintHello("World");

void PrintNumbersLoop(int a, int b)
{
    for (int i = a; i <= b; i++)
    {
        Console.WriteLine(i);
    }
}

void PrintNumbersRecursion(int a, int b)
{
    Console.WriteLine(a);
    if (a != b)
    {
        PrintNumbersRecursion(a + 1, b);
    }
}

PrintNumbersLoop(5, 15);
PrintNumbersRecursion(5, 15);
*/