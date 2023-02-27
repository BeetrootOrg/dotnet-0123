using System.Globalization;

static bool Compare(string s1, string s2)
{
    if (s1.Length != s2.Length)
    {
        return false;
    }

    for (int i = 0; i < s1.Length; i++)
    {
        if (s1[i] != s2[i])
        {
            return false;
        }
    }

    return true;
}

static void Analyze(string str)
{
    (int alphabet, int digits, int special) = (0, 0, 0);
    foreach (char symbol in str)
    {
        if (char.IsLetter(symbol))
        {
            alphabet++;
        }
        else if (char.IsDigit(symbol))
        {
            digits++;
        }
        else
        {
            special++;
        }
    }

    Console.WriteLine($"Letters: {alphabet}, digits: {digits}, special: {special}");
}

static string Sort(string str)
{
    char[] chars = new char[str.Length];
    string lower = str.ToLower(CultureInfo.CurrentCulture);
    for (int i = 0; i < str.Length; i++)
    {
        chars[i] = lower[i];
    }

    Array.Sort(chars);
    return new string(chars);
}

static char[] Duplicates(string str)
{
    string lower = str.ToLower(CultureInfo.CurrentCulture);
    char[] duplicates = Array.Empty<char>();

    for (int i = 0; i < lower.Length - 1; i++)
    {
        if (str[(i + 1)..].Contains(lower[i]))
        {
            bool alreadyInsideDuplicates = false;
            for (int j = 0; j < duplicates.Length; j++)
            {
                if (duplicates[j] == lower[i])
                {
                    alreadyInsideDuplicates = true;
                    break;
                }
            }

            if (!alreadyInsideDuplicates)
            {
                Array.Resize(ref duplicates, duplicates.Length + 1);
                duplicates[^1] = lower[i];
            }
        }
    }

    return duplicates;
}

Console.WriteLine(Compare("Hello", "Hello")); // True
Console.WriteLine(Compare("Hello", "World")); // False

Analyze("Hello, World! 123"); // Letters: 10, digits: 3, special: 3
Console.WriteLine(Sort("Hello")); // ehllo

Console.WriteLine(new string(Duplicates("Hello, World!"))); // lo