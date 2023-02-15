char c1 = 'c';
char c2 = (char)99;
char c3 = '\u0063'; //UTF = 16

System.Console.WriteLine(c1);
System.Console.WriteLine(c2);
System.Console.WriteLine(c3);

char c4 = '\'';
System.Console.WriteLine(c4);

// int.MaxValue;
// int.MinValue;

void DescribeChar (char c)
{
    Console.WriteLine($"Is ASCII = {char.IsAscii(c)}");
    Console.WriteLine($"Is Control = {char.IsControl(c)}");
    Console.WriteLine($"Is IsDigit = {char.IsDigit(c)}");
    Console.WriteLine($"Is Letter = {char.IsLetter(c)}");    
    Console.WriteLine($"Is Lower = {char.IsLower(c)}");
    Console.WriteLine($"Is Number = {char.IsNumber(c)}");
    Console.WriteLine($"Is Punctuation = {char.IsPunctuation(c)}");
    Console.WriteLine($"Is WhiteSpace = {char.IsWhiteSpace(c)}");
}

Console.WriteLine ("Symbol 'c'");
DescribeChar ('c');

Console.WriteLine ("Symbol 'C'");
DescribeChar ('C');

Console.WriteLine ("Symbol ' '");
DescribeChar (' ');

Console.WriteLine ("Symbol '4'");
DescribeChar ('4');

Console.WriteLine ("Symbol '\u1234'");
DescribeChar ('\u1234');

System.Console.WriteLine($"C greater than c = {'C' > 'c'}");

string s1 = "Hello, World!";
int age = 26;
string s2 = "My age is " + age;
string s3 = $"My age is {age}";
string s4 = string.Format("My age is {0}", age);
string s5 = string.Format("My age is {0} and my name is {1}", age, "Dima");

System.Console.WriteLine(s1);
System.Console.WriteLine(s2);
System.Console.WriteLine(s3);
System.Console.WriteLine(s4);
System.Console.WriteLine(s5);

System.Console.WriteLine($"Contains 'W' = {s1.Contains('W')}");
System.Console.WriteLine($"Contains 'World' = {s1.Contains("World")}");
System.Console.WriteLine($"Contains 'World ' = {s1.Contains("World ")}");
// System.Console.WriteLine($"Contains 'World' OrdinalIgnoresCase = {s1.Contains("World", StringComparison bool)}");

System.Console.WriteLine($"Hello == World = {"Hello" == "World"}");
System.Console.WriteLine($"Hello == hello = {"Hello" == "hello"}");