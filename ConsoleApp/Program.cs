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