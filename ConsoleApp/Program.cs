/*
Compare that will return true if 2 strings are equal, otherwise false, but do not use build-in method (bool Compare(string, string))
Analyze that will return number of alphabetic chars in string, digits and another special characters (void Analyze(string))
Sort that will return string that contains all characters from input string sorted in alphabetical order (e.g. 'Hello' -> 'ehllo') (string Sort(string))
Duplicate that will return array of characters that are duplicated in input string (e.g. 'Hello and hi' -> ['h', 'l']) (char[] Duplicate(string))
*/


string str1 = "111f";
string str2 = "111s";
System.Console.WriteLine(str1 == str2);

/*

static bool Compare(string str1, string str2)
{
    if (str1 == str2) return false

    int length1 = str1.Length;
    int length2 = str2.Length;
    if (length1 != length2) return false; //стірнги різної довжини

    char[]
    for (int i = 0; i < length1; i++)
    {

    }
}

// using System.Text;

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

System.Console.WriteLine(s1.EndsWith("!"));


Console.WriteLine($"s1.IndexOf(',') = {s1.IndexOf(',')}");
Console.WriteLine($"s1.IndexOf('l') = {s1.IndexOf('l')}");
Console.WriteLine($"s1.IndexOf('ll') = {s1.IndexOf("ll")}");
Console.WriteLine($"s1.IndexOf('a') = {s1.IndexOf("a")}");
Console.WriteLine($"s1.LastIndexOf('l') = {s1.LastIndexOf('l')}");
Console.WriteLine($"s1.IndexOfAny('o', 'l') = {s1.IndexOfAny(new[] { 'o', 'l' })}");
Console.WriteLine($"s1.LastIndexOfAny('o', 'l') = {s1.LastIndexOfAny(new[] { 'o', 'l' })}");

Console.WriteLine($"s1.Insert(5, 'interesting') = {s1.Insert(6, " interesting")}");

string multiline1 = "Hello, \nDima";
string multiline2 = @$"Hello, 
Dima {age}";

Console.WriteLine(@"
Hello.
How are you?
I'm fine!
");

Console.WriteLine(multiline1);
Console.WriteLine(multiline2);

Console.WriteLine($"s1.Length = {s1.Length}");

Console.WriteLine($"s1.PadLeft(20) = {s1,14}");
Console.WriteLine($"{s1,-20} = s1.PadRight(20)");


Console.WriteLine($"12,4 = {12,4}");
Console.WriteLine($"{12,-4} = 12,-4");
// SAME AS ABOVE
// Console.WriteLine($"s1.PadLeft(20) = {s1.PadLeft(20)}");

DateTime now = DateTime.Now;
Console.WriteLine($"now = {now}");
Console.WriteLine($"now:D = {now:D}");
Console.WriteLine($"now:yyy dd mm = {now:yyy M dd}");

Console.WriteLine($"s1.Replace('World', 'Dima') = {s1.Replace("World", "Dima")}");
Console.WriteLine($"s1.Replace('world', 'Dima') = {s1.Replace("world", "Dima")}");
Console.WriteLine($"s1.Replace('world', 'Dima', StringComparison.OrdinalIgnoreCase) = {s1.Replace("world", "Dima", StringComparison.OrdinalIgnoreCase)}");

string[] splitted = s1.Split(',');
Console.WriteLine("After Split");
foreach (string part in splitted)
{
    Console.WriteLine(part);
}

Console.WriteLine($"s1.Substring(2, 5) = {s1.Substring(2, 5)}");
Console.WriteLine($"s1[2..5] = {s1[2..5]}");

Console.WriteLine($"s1.ToUpper() = {s1.ToUpper()}");
Console.WriteLine($"s1.ToLower() = {s1.ToLower(System.Globalization.CultureInfo.CurrentCulture)}");



Console.WriteLine($"s1.Trim('H') = {s1.Trim('H')}");
Console.WriteLine($"s1.TrimEnd('H') = {s1.TrimEnd('H')}");
Console.WriteLine($"s1.TrimEnd('!') = {s1.TrimEnd('!')}");
Console.WriteLine($"s1.TrimStart('H') = {s1.TrimStart('H')}");
Console.WriteLine($"s1.Trim(' ') = {s1.Trim(' ')}");
Console.WriteLine($"s1.TrimStart('!') = {s1.TrimStart('!')}");


Console.WriteLine($"string.IsNullOrEmpty(null) = {string.IsNullOrEmpty(null)}");
Console.WriteLine($"string.IsNullOrEmpty('') = {string.IsNullOrEmpty("")}");
Console.WriteLine($"string.IsNullOrEmpty('   ') = {string.IsNullOrEmpty("   ")}");
Console.WriteLine($"string.IsNullOrWhiteSpace('   ') = {string.IsNullOrWhiteSpace("   ")}");
/*
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


var tuple = (5, 10);
Console.WriteLine(tuple.Item1); // 5
Console.WriteLine(tuple.Item2); // 10
tuple.Item1 += 26;
Console.WriteLine(tuple.Item1); // 31

*/