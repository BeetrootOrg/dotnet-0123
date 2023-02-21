/*
Compare that will return true if 2 strings are equal, otherwise false, but do not use build-in method (bool Compare(string, string))


Duplicate that will return array of characters that are duplicated in input string (e.g. 'Hello and hi' -> ['h', 'l']) (char[] Duplicate(string))
*/


static bool Compare(string str1, string str2)
{
    if (str1 == null && str2 == null) return true; // null exception, but "equal"
    if (str1 == null || str2 == null) return false; // null exception -- повертаємо false

    int length1 = str1.Length - 1;// максимальний індекс масиву меньше ніж кількість елементів масиву на 1
    int length2 = str2.Length - 1;

    if (length1 != length2) return false; //стрінги різної довжини -- повертаємо false

    char[] chr1 = new char[length1];
    char[] chr2 = new char[length1];

    chr1 = str1.ToCharArray(); //копіюємо в масив chr1 масив із стрінга
    chr2 = str2.ToCharArray();

    for (int i = 0; i < length1; i++)
    {
        if (chr1[i] != chr2[i]) return false;
    }
    return true; //нарешті все рівно одне одному
}




// Analyze that will return number of alphabetic chars in string, digits and another special characters (void Analyze(string))

void Analyze(string line)
{
    int abcNumbs = new int();
    int digits = new int();
    int specials = new int();

    if (line == null) return; //null exception
    int length = line.Length - 1;
    char[] chr1 = new char[length];
    chr1 = line.ToCharArray();

    for (int i = 0; i < length; i++)
    {
        if (char.IsLetter(chr1[i])) abcNumbs++;
        if (char.IsDigit(chr1[i])) digits++;
        if (char.IsControl(chr1[i])) specials++;
    }
    System.Console.WriteLine(@$"
    Letters = {abcNumbs}
    Digits = {digits}
    Special characters = {specials}
    ");
}



// Sort that will return string that contains all characters from input string sorted in alphabetical order (e.g. 'Hello' -> 'ehllo')
// (string Sort(string))
static string Sort(string str1)
{
    str1 = str1.ToLower();
    int length = str1.Length - 1;
    char[] charLine = new char[length];
    charLine = str1.ToCharArray();

    foreach (var item in charLine)
    {
        if (charLine[item] <= 97 && charLine[item] >= 122) //перевіряємо чи в нас тільки букви
        {
            return "game over";
        }
    }
    
    BubbleSort(charLine[]);
    return charLine[]; // зробити стрінг з масиву

}

static char[] BubbleSort(int[] arr)
{
    int length = arr.Length;
    bool flag = new bool();
    do
    {
        flag = true;
        for (int i = 1; i < length; i++)
        {
            if (arr[i - 1] > arr[i])
            {
                int tmp = arr[i - 1];
                arr[i - 1] = arr[i];
                arr[i] = tmp;
                flag = false;
            }

        }
    } while (flag == false);
    return arr;
}



// Нижче код тільки для перевірки

// string str1 = "";
// string str2 = "";
string str1 = "121fffdddSQA ♀]p♪♫ %3&#6$ ";
// string str2 = "111fffddd";
string str2 = null;
// string str1 = null;


Console.WriteLine(Compare(str1, str2));
Analyze(str1);






/*
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