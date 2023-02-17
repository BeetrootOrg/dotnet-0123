using System.Text;

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

string s1 = "Hello ,World";
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
Console.WriteLine($"Contains 'world' = {s1.Contains("world")}");
Console.WriteLine($"Contains 'world' OrdinalIgnoreCase = {s1.Contains("world", StringComparison.OrdinalIgnoreCase )}");

Console.WriteLine($"Hello != World = {"Hello" != "World"}");
Console.WriteLine($"Hello != Hello = {"Hello" != "Hello"}");
Console.WriteLine($"Hello != hello = {"Hello" != "hello"}");

Console.WriteLine($"\"Hello\".Equals(\"Hello\") = {"Hello".Equals("Hello")}");
Console.WriteLine($"\"Hello\".Equals(\"hello\") = {"Hello".Equals("hello")}");

Console.WriteLine($"s1.EndsWith(\"rld\") = {s1.EndsWith("rld")}");
Console.WriteLine($"s1.EndsWith(\"rld!\") = {s1.EndsWith("rld!")}");

Console.WriteLine($"s1.StarstWith(\"ell\") = {s1.StartsWith("ell")}");
Console.WriteLine($"s1.StarstWith(\"He\") = {s1.StartsWith("He")}");

Console.WriteLine($"s1.IndexOf(',') = {s1.IndexOf(',')}");
Console.WriteLine($"s1.IndexOf('l') = {s1.IndexOf('l')}");
Console.WriteLine($"s1.LastIndexOf('l') = {s1.LastIndexOf('l')}");
Console.WriteLine($"s1.IndexOf('ll') = {s1.IndexOf("ll")}");
Console.WriteLine($"s1.IndexOfAny('o', 'l') = {s1.IndexOfAny(new[] {'o', 'l'})}");
Console.WriteLine($"s1.LastIndexOfAny('o', 'l') = {s1.LastIndexOfAny(new[] {'o', 'l'})}");

Console.WriteLine($"s1.Insert(6, 'interesting') = {s1.Insert(6, " interesting")}");



string multiline = "Hello, \nDima";
string multiline1 = @$"Hello,
Dima {age}"; 

Console.WriteLine(multiline);
Console.WriteLine(multiline1);

System.Console.WriteLine($"s1.Length = {s1.Length}");

Console.WriteLine($"s1.PadLeft(20) = {s1,20}");
Console.WriteLine($"{s1,-20} = s1.PadRight(20)");
Console.WriteLine($"12,4 = {12,4}");
Console.WriteLine($"{12,-4} = 12, -4");

var now = DateTime.Now;
Console.WriteLine($"date = {now}");
Console.WriteLine($"date = {now:D}");
Console.WriteLine($"date = {now:yyy dd mm}");

Console.WriteLine($"s1.Replace('World', 'Dima') = {s1.Replace("World", "Dima")}");
Console.WriteLine($"s1.Replace('world', 'Dima') = {s1.Replace("world", "Dima")}");

string[] splitted = s1.Split(',');
Console.WriteLine("After Split");
foreach (var part in splitted)
{
    Console.WriteLine(part);
}

Console.WriteLine($"s1.Substring(2, 5) = {s1.Substring(2, 5)}");
Console.WriteLine($"s1[2..5] = {s1[2..5]}");
 
Console.WriteLine($"s1.ToUpper() = {s1.ToUpper()}");
Console.WriteLine($"s1.ToLower() = {s1.ToLower()}");

Console.WriteLine($"s1.Trim('H') = {s1.Trim('H')}");
Console.WriteLine($"s1.TrimEnd('H') = {s1.TrimEnd('H')}");
Console.WriteLine($"s1.TrimEnd('!') = {s1.TrimEnd('!')}");
Console.WriteLine($"s1.TrimStart('H') = {s1.TrimStart('H')}");

Console.WriteLine($"string.IsNullOrEmpty(null) = {string.IsNullOrEmpty(null)}");
Console.WriteLine($"string.IsNullOrEmpty('') = {string.IsNullOrEmpty("")}");
Console.WriteLine($"string.IsNullOrEmpty('  ') = {string.IsNullOrEmpty("  ")}");
Console.WriteLine($"string.IsNullOrWhiteSpace = {string.IsNullOrWhiteSpace("")}");

string result = string.Empty;
for (int i = 0; i < 100; i++)
{
    result += $"{i}, ";
}

Console.WriteLine(result[..^2]);

StringBuilder sb = new();
for (int i = 0; i < 100; i++)
{
    sb.Append($"{i}, ");
}

Console.WriteLine(sb.ToString()[..^2]);

 