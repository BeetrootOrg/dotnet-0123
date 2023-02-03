byte byteExample = 1;
short shortExample = 7;
int intExample = 764;
long longExample = -64673;

float floatExample = 1.9F;
double doubleExample = -23.85;
decimal decimalExample = 65.899M;

bool boolExample = true;

char charExample = '!';
string stringExample = "my homework";


Console.WriteLine(byteExample + intExample);
Console.WriteLine(floatExample + doubleExample);
Console.WriteLine(stringExample + charExample);

Console.WriteLine(shortExample * floatExample);

Console.WriteLine(longExample / decimalExample);

int x = 4;
int y = -6;

Console.WriteLine($"-6x ^ 3 + 5x ^ 2 - 10x + 15 = {-6 * Math.Pow(x, 3) + 5 * x * x -10 * x + 15}" );

Console.WriteLine($"abs(x) * sin(x)= {Math.Abs(x) * Math.Sin(x)}");

Console.WriteLine($"2 * pi *x = {2 * Math.PI * x}");

Console.WriteLine($"max(x, y) = {Math.Max(x, y)}");

// abs(x) * sin(x)
// 2 * pi *x
// max(x, y)