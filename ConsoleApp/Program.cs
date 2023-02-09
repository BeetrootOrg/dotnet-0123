// string name = "Mayday2";

// if (name == "Mayday")
// {
//     System.Console.WriteLine($"Hi, {name}");
// }
// else if (name == "Mayday1")
// {
//     System.Console.WriteLine($"Hi, {name}");
// }
// else
// {
//     System.Console.WriteLine("Hello, not Mayday");
// };

// System.Console.WriteLine("Next Operation");
// System.Console.WriteLine("SWITCH/CASE");

// switch (name)
// {
//     case "Mayday":
//     System.Console.WriteLine("Hello, Mayday");
//     break;
//     case "Mayday1":
//     System.Console.WriteLine("Hello, Mayday1");
//     break;
//     default:
//     System.Console.WriteLine("Hello, not Mayday");
//     break;
// }

// int a = 11;
// int b = (a == 10 ? 15 : 20);
// System.Console.WriteLine(b);

// int sum = 0;
// for (int i = 0; i <= 10; ++i)
// {
//     sum += i;
// }

// System.Console.WriteLine(sum);

// int mul = 1;
// for (int i = 1; i <= 10; i++)
// {
//     mul *= i;
// }

// System.Console.WriteLine(mul);

// int i2 = 10;
// int sum2 = 0;
// while (i2 > 0)
// {
//     sum2 += i2;
//     i2--;
// }

// System.Console.WriteLine(sum2);

// i2 = 10;
// int mul2 = 1;

// while (i2 > 0)
// {
//     mul2 *= i2--;
// }

// System.Console.WriteLine(mul2);

// i2 = 10;
// mul2 = 1;
// do
// {
//     mul2 *= i2--;
// } while (i2 > 0);

// System.Console.WriteLine(mul2);

// int sum_odd = 0;

// for (int i3 = 0; i3 <= 42; i3++)
// {
//     if (i3 % 2 == 0)
//     {
//         continue;
//     }
//     sum_odd += i3;
// }

// int sum_even = 0;
// for (int i4 = 0; i4 <= 42; i4++)
// {
//     if (i4 % 2 == 1)
//     {
//         continue;
//     }
//     sum_even += i4;
// }

// System.Console.WriteLine(sum_odd);
// System.Console.WriteLine(sum_even);

// for (int i5 = 0; i5 < 10; i5++)
// {
//     if (i5 == 5)
//     {
//         break;
//     }
//     System.Console.WriteLine($"Iteration {i5}");
// }

string input1 = Console.ReadLine();
int num1 = int.Parse(input1);

string input2 = Console.ReadLine();
int num2 = int.Parse(input2);

int sum4 = num1 + num2;
System.Console.WriteLine(sum4);

input1 = Console.ReadLine();
bool success = int.TryParse(input1, out int num3);

if (success)
{
    System.Console.WriteLine(num3);
}