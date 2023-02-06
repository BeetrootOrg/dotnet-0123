//----------06/02/2023-----------------
//--------Classwork 05 methods --------
// header 
//- what is methods;- how to use methods;- ref and out parameters;- optional parameters;- methods overloading

Console.WriteLine("Фібоначи");
const int i=10;

Console.WriteLine($"Fib={Fib(i)}");

int Fib(int n)
{
  return n > 1 ? Fib(n - 1) + Fib(n - 2) : n;
}