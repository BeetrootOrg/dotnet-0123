string name = "dima";

if (name == "Dima")
{
    Console.WriteLine("Hi, Dima");
}
else if (name == "dima")
{
    Console.WriteLine("Hi, dima");
}
else if (name == "dima")
{
    Console.WriteLine("Hi, DIMA");
}
else
{
    Console.WriteLine("Hi, not Dima");
}

Console.WriteLine("next operation");

Console.WriteLine("SWITCH/CASE");
switch (name)
{
    case "Dima":
        Console.WriteLine("Hi, Dima");
        break;
    case "dima":
        Console.WriteLine("Hi, dima");
        break;
    default:
        Console.WriteLine("Hi, not Dima");
        break;
}

int a = 10;
int b = (a == 10 ? 15 : 20); // if (a == 10) { b = 15 } else { b = 20 }
Console.WriteLine(b);

// POSSIBLE BUT NOT PREFERABLE
if (a == 10)
    b = 15;
else
    b = 20;

Console.WriteLine("NUMBERS FROM 0 TO 9");
for (int i = 0; i < 10; ++i)
{
    Console.WriteLine(i);
}

var sum = 0;
for (int i = 0; i <= 10; ++i)
{
    sum += i;
}

Console.WriteLine($"Sum from 0 to 10 is equal to {sum}");

var mul = 1;
for (int i = 1; i <= 10; ++i)
{
    mul *= i; // 1 * 1 * 2 * 3 ... * 8 * 9 * 10
}

Console.WriteLine($"Mul from 1 to 10 is equal to {mul}");

mul = 1;
int j = 1;
while (j <= 10)
{
    mul *= j++;
}

Console.WriteLine($"Mul from 1 to 10 is equal to {mul}");

// for (;;)
// {
//     Console.WriteLine("INFINITE LOOP");
// }

// while (true)
// {
//     Console.WriteLine("INFINITE LOOP");
// }

mul = 1;
j = 1;
do
{
    mul *= j++;
} while (j <= 10);

Console.WriteLine($"Mul from 1 to 10 is equal to {mul}");

while (false)
{
    Console.WriteLine("NEVER INSIDE");
}

do
{
    Console.WriteLine("ONLY ONCE");
} while (false);

sum = 0;
for (int i = 0; i <= 42; i += 2)
{
    sum += i;
}

Console.WriteLine($"Sum of even from 0 to 42 is {sum}");

sum = 0;
for (int i = 1; i <= 42; i += 2)
{
    sum += i;
}

Console.WriteLine($"Sum of odd from 0 to 42 is {sum}");

sum = 0;
for (int i = 0; i <= 42; i++)
{
    sum += i;
}

Console.WriteLine($"Sum from 0 to 42 is {sum}");

sum = 0;
for (int i = 0; i <= 42; i++)
{
    if (i % 2 == 1)
    {
        continue;
    }

    sum += i;
}

Console.WriteLine($"Sum of even from 0 to 42 is {sum}");

for (int i = 0; i < 10; i++)
{
    if (i == 5)
    {
        break;
    }

    Console.WriteLine("NEW EXECUTION");
}

Console.WriteLine("PLEASE ENTER THE VALUE:");
string input = Console.ReadLine();
Console.WriteLine($"You've entered '{input}'");

Console.WriteLine("Please enter number #1:");
input = Console.ReadLine();
int num1 = int.Parse(input);

Console.WriteLine("Please enter number #2:");
input = Console.ReadLine();
int num2 = int.Parse(input);

Console.WriteLine($"Sum of 2 numbers is {num1 + num2}");

Console.WriteLine("Please enter number #3:");
input = Console.ReadLine();
bool success = int.TryParse(input, out int num3);
if (success)
{
    Console.WriteLine($"You entered number {num3}");
}
else
{
    Console.WriteLine($"You entered shit");
}