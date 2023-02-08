using ConsoleApp.Classes;
//---------------- 08.02.2023----------------------
//--------- Classwork 6. Debugging ----------------

// ------test stat class------------------------
Lesson06.Test();
// ------ 1 завдання-----------------------------
// --------факториал-------------------------
Console.WriteLine(Lesson06.Factorial(10));
// ------ 2 завдання-----------------------------
// --------цифри від n до 1-------------------------
Lesson06.WriteNumbers(10);
//---------------Debugging------------------------
int res = Lesson06.Sum(10, 5);
Console.WriteLine(res);
for (int i = 0; i < 10; i++)
{
    Console.Write(i);
}
// ---------------дебаг фибоначчи
Console.WriteLine(Lesson06.Fibonacci(5));
// ---------------Рандом
Random random =new ((int)DateTime.Now.Ticks);
Console.WriteLine(random.Next());
Console.WriteLine(random.Next(10));//[0,10) 10 не включено
Console.WriteLine(random.Next(-10,10));//[-10,10) 10 не включено
Console.WriteLine(random.NextSingle());//0.0<= <1.0
Console.WriteLine(random.NextDouble());//0.0<= <1.0
//-----------------------
Console.WriteLine(Lesson06.SumFromTo(1,10));
//-------------Відстань між 2 точками 
Console.WriteLine(Lesson06.Distance(0,0,5,5));
Console.WriteLine(Lesson06.Distance(0,3,4,0));