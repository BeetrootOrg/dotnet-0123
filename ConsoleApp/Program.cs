char c1 = 'c';
char c2 = (char)99;
char c3 = '\u0063';
Console.WriteLine(c1);
Console.WriteLine(c2);
Console.WriteLine(c3);
 void DescribeChar(char c)
 {
    Console.WriteLine($"Is ASCII = {char.IsAscii(c)}");
    Console.WriteLine($"Is Control = {char.IsControl(c)}");
    Console.WriteLine($"Is Digit = {char.IsDigit(c)}");
    Console.WriteLine($"Is Letter = {char.IsLetter(c)}");
    Console.WriteLine($"Is Punctuation = {char.IsPunctuation(c)}");
    Console.WriteLine($"Is WhiteSpace = {char.IsWhiteSpace(c)}");

 }

 System.Console.WriteLine("Symbol '\u1234'");
 DescribeChar('\u1234');

 System.Console.WriteLine($"C greater than c = {'C'>'c'}");

 string s1 = "Hello, World";
 int age = 20;
 string s2 = $"my age is {age}";
 System.Console.WriteLine(s2);
 System.Console.WriteLine($"Contains 'world' = {s1.Contains("world",StringComparison.OrdinalIgnoreCase)}");
 System.Console.WriteLine($"Contains 'world' = {s1.Contains("world",StringComparison.CurrentCultureIgnoreCase)}");
 string multiline1 = "Hello,\n Maksym!";
 string multiline2 = @"Hello,
  Maksym!";
 System.Console.WriteLine(multiline1);
 System.Console.WriteLine(multiline2);

