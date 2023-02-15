char c1 = 'c';
char c2 = (char)99;
char c3 = '\u0063';

Console.WriteLine(c1);
Console.WriteLine(c2);
Console.WriteLine(c3);

char c4 = '\'';
Console.WriteLine(c4);

static void DescribeChar(char c)
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

Console.WriteLine("Symbol 'C'");
DescribeChar('C');

Console.WriteLine("Symbol ' '");
DescribeChar(' ');

Console.WriteLine("Symbol '4'");
DescribeChar('4');

Console.WriteLine("Symbol '\u1234'");
DescribeChar('\u1234');

Console.WriteLine($"C greater than c = {'C' > 'c'}");

string s1 = "Hello, World!";
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