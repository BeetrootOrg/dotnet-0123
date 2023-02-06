//----------06/02/2023-----------------
//--------Classwork 05 methods --------
// header 
//- what is methods;- how to use methods;- ref and out parameters;- optional parameters;- methods overloading


const int i=10;
//-----------Фібоначи Рекурсія---------------
Console.WriteLine("Фібоначи Рекурсія");
Console.WriteLine($"Fib={Fib(i)}");

int Fib(int n)
{
  return n > 1 ? Fib(n - 1) + Fib(n - 2) : n;
}
//-----------Фібоначи Цикл---------------
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