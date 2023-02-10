/* 
Домашня робота 04-functions

Define and call with different parameters next methods:
Method that will return max value among all the parameters
… min value …

Overload first two methods with 3 and 4 parameters
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
    result = a + b;     //ця сама змінна result передастся в шапку функції, їй потрібно присвоїти значення перед return
    return true;
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
        stroka += sign;
        n--;
    }
    return stroka;
}

