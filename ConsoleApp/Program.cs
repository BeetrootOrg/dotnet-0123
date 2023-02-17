char c1 = 'c';
char c2 = (char)99;
char c3 = '\u0063';

Console.WriteLine(c1);
Console.WriteLine(c2);
Console.WriteLine(c3);

void DescribeChar( char c)
{
    Console.WriteLine($"Is ASCII = {char.IsAscii(c)}");
    Console.WriteLine($"Is Control = {char.IsControl(c)}");
    Console.WriteLine($"Is Digit = {char.IsDigit(c)}");
    Console.WriteLine($"Is Letter = {char.IsLetter(c)}");
    Console.WriteLine($"Is Lower = {char.IsLower(c)}");
    Console.WriteLine($"Is Upper = {char.IsUpper(c)}");
    Console.WriteLine($"Is Number = {char.IsNumber(c)}");
    Console.WriteLine($"Is Punctuation = {char.IsPunctuation(c)}");
    Console.WriteLine($"Is WhiteSpace = {char.IsWhiteSpace(c)}");
}
Console.WriteLine("Symbol 'c'");
DescribeChar('c');

System.Console.WriteLine($"C greater than c = {'C' > 'c'}");

string s1 = "Hello ,world";
int age = 26;
string s2 = "My age is " + age;
string s3 = $"My age is {age}";
string s4 = string.Format("My age is {0}", age);
string s5 = string.Format("My age is {0} and my name is {1}", age, "Dima");

Console.WriteLine(s1);
Console.WriteLine(s2);
Console.WriteLine(s3);
Console.WriteLine(s4);
Console.WriteLine(s5);

Console.WriteLine($"Contains 'W' = {s1.Contains('W')}");
Console.WriteLine($"Contains 'World' = {s1.Contains("World")}");
Console.WriteLine($"Contains 'World' = {s1.Contains("World")}");
Console.WriteLine($"Contains 'world' OrdinalIgnoreCase = {s1.Contains("world", StringComparison.OrdinalIgnoreCase )}");

Console.WriteLine($"Helo != World = {"Hello" != "World"}");
Console.WriteLine($"Helo != Hello = {"Hello" != "Hello"}");
Console.WriteLine($"Helo != helo = {"Hello" != "helo"}");

string multiline = "Hello, \nDima";
string multiline1 = @$"Hello,
Dima {age}"; 

Console.WriteLine(multiline);
Console.WriteLine(multiline1);

System.Console.WriteLine($"s1.Length = {s1.Length}");

Console.WriteLine($"s1.PadLeft(20) = {s1,20}");
Console.WriteLine($"{s1,-20} = s1.PadRight(20)");
Console.WriteLine($"12,4 = {12,4}");
Console.WriteLine($"12,-4 = {12,-4}");