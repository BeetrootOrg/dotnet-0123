﻿using ConsoleApp.Classes;
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