//System.Console.WriteLine($"input x:");
//string input = Console.ReadLine();
//int x = int.Parse(input);

 //System.Console.WriteLine($"input y:");
 //input = Console.ReadLine();
//int y = int.Parse(input);
//у меня не работает останавливаеться на console.Readline() ввожу и код дальше не идёт
// поэтому не могу проверить как работает код с консольным вводом
// дальше решение без консольного ввода
int sum = 0;
int x = 10;
int y = 10;
for (; x <= y ; x++)
{
    sum+=x;
}
System.Console.WriteLine($"for x < y or x == y sum = {sum}");

for (; x >= y ; y++)
{
    sum +=y;
}
System.Console.WriteLine($"for x>=y sum = {sum}");
