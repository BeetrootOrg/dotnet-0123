using ConsoleApp;

Complex c1 = new();
Complex c2 = new();

Console.WriteLine(c1);
Console.WriteLine(c2);
// COMPILATION ERROR WITHOUT OPERATOR OVERLOAD
// Console.WriteLine(c1 == c2);

Console.WriteLine(c1.Imaginary);
Console.WriteLine(c1.Real);