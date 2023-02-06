//----------06/02/2023-----------------
//--------Classwork 05 methods --------
// header 
//- what is methods;- how to use methods;- ref and out parameters;- optional parameters;- methods overloading


using System.Diagnostics;

const int i=10;
//-----------Фібоначчи Рекурсія---------------
Console.WriteLine("Фібоначи Рекурсія");
Console.WriteLine($"Fib={Fib(i)}");

int Fib(int n)
{
  return n > 1 ? Fib(n - 1) + Fib(n - 2) : n;
}
//-----------Фібоначчи Цикл---------------
Console.WriteLine("Фібоначи Цикл");
int count=i;
int fib1=1;
int fib2=0;
int fib3;

while (count>0 ){
    fib3=fib1+fib2;
    Console.WriteLine($"Cur fib={fib3}");
    fib1=fib2;
    fib2=fib3;
    count--;
}
//-------------урок--------------------
int Sum(int a,int b)=>a+b;
int a=10;int b=20;

Console.WriteLine($"Summ {a}+{b}={Sum(a,b)}");
// -----------Value типи-----------------
//Method(int param) - param передається як значення, зовнішна змінна не буде змінюваться
void Assign42(int param){param=42;}
Assign42(a);
Console.WriteLine($"перевірка значення метод(велью тип) а={a}");
// -----------ref типи-----------------
//Method(ref int param) - param передається як полислання, зовнішна змінна буде змінюваться
void AssignRef42(ref int param){param=42;}
AssignRef42(ref a);
Console.WriteLine($"перевірка значення метод(реф тип) а={a}");
// -----------out типи-----------------
//Method(out int param) - param передається як полислання, зовнішна змінна буде ініціалізована в методі
void AssignOut42(out int param){param=42;}
int ou;
AssignOut42(out ou);
Console.WriteLine($"перевірка значення метод(аут тип) au={ou}");

//-----------------------------------------
bool TryReadInt(out int result)
{
    var input=Console.ReadLine();
    return int.TryParse(input,out result);
}
if (TryReadInt(out int temp)) Console.WriteLine($"Можно парсити число {temp}");
//-----------------------------------------
bool TryDivideByThree(int num,out int result ){
    result=num/3;
    if (num%3==0) return true; 
    return false;
}

bool flag=TryDivideByThree(6,out temp);
Console.WriteLine($"TryDivideByThree(6)={flag}. Result={temp}" );
flag=TryDivideByThree(7,out temp);
Console.WriteLine($"TryDivideByThree(7)={flag}. Result={temp}" );
//-------------------Рекурсія----------------------
//-------------------Рекурсія Фібоначчи----------------------
int Fibonacci(int n){
    Console.WriteLine($"Fibonacci n={n}");
    if (n==1) return n;
    if (n==2) return 1;
    return Fibonacci(n-1)+Fibonacci(n-2);
}

Console.WriteLine($"Фібоначі для 10={Fibonacci(10)}");
var sw=new Stopwatch();
sw.Start();
Console.WriteLine($"Фібоначі для 25={Fibonacci(25)}");
sw.Stop();
Console.WriteLine($"Time calc fib={sw.Elapsed}");
//-----------Виклики  з параметрами та без----
void Hello(string Name="Andrey")=>Console.WriteLine($"Hello, {Name}!");
Hello();
Hello("Dima");

void PrintNumberLoop(int a,int b){
    for(int i=a;i<=b;i++){
        Console.WriteLine(@$"PrintNumberLoop {i}");
    }
}