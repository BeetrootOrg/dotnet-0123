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

Console.WriteLine($"s1.Contains('W') = {s1.Contains('W')}");
Console.WriteLine($"s1.Contains('World') = {s1.Contains("World")}");
Console.WriteLine($"s1.Contains('world') = {s1.Contains("world")}");
Console.WriteLine($"s1.Contains('world', OrdinalIgnoreCase) = {s1.Contains("world", StringComparison.OrdinalIgnoreCase)}");

Console.WriteLine($"Hello != World = {"Hello" != "World"}");
Console.WriteLine($"Hello != Hello = {"Hello" != "Hello"}");
Console.WriteLine($"Hello != hello = {"Hello" != "hello"}");

Console.WriteLine($"\"Hello\".Equals(\"Hello\", StringComparison.Ordinal) = {"Hello".Equals("Hello", StringComparison.Ordinal)}");
Console.WriteLine($"\"Hello\".Equals(\"hello\", StringComparison.Ordinal) = {"Hello".Equals("hello", StringComparison.Ordinal)}");
Console.WriteLine($"\"Hello\".Equals(\"hello\", StringComparison.OrdinalIgnoreCase) = {"Hello".Equals("hello", StringComparison.OrdinalIgnoreCase)}");

Console.WriteLine($"s1.EndsWith(\"rld\") = {s1.EndsWith("rld")}");
Console.WriteLine($"s1.EndsWith(\"rld!\") = {s1.EndsWith("rld!")}");
Console.WriteLine($"s1.EndsWith(\"RLD!\", StringComparison.OrdinalIgnoreCase) = {s1.EndsWith("RLD!", StringComparison.OrdinalIgnoreCase)}");

Console.WriteLine($"s1.StartsWith('ell') = {s1.StartsWith("ell")}");
Console.WriteLine($"s1.StartsWith('Hell') = {s1.StartsWith("Hell")}");
Console.WriteLine($"s1.StartsWith('HeLl', StringComparison.OrdinalIgnoreCase) = {s1.StartsWith("HeLl", StringComparison.OrdinalIgnoreCase)}");

Console.WriteLine($"s1.IndexOf(',') = {s1.IndexOf(',')}");
Console.WriteLine($"s1.IndexOf('l') = {s1.IndexOf('l')}");
Console.WriteLine($"s1.IndexOf('ll') = {s1.IndexOf("ll")}");
Console.WriteLine($"s1.IndexOf('a') = {s1.IndexOf("a")}");
Console.WriteLine($"s1.LastIndexOf('l') = {s1.LastIndexOf('l')}");