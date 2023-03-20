using System.Globalization;


// Compare that will return true if 2 strings are equal,
// otherwise false, but do not use build-in method (bool Compare(string, string))


bool Compare(string a, string b, bool checkStringEqualWithCase = true)
{
    if (checkStringEqualWithCase == false)
    {
        if (a.ToLower(CultureInfo.CurrentCulture)==b.ToLower(CultureInfo.CurrentCulture))
        {
            return true;
        } 
    }
    if (a == b)
    {
        return true;
    }

    return false;
}

// Analyze that will return number of alphabetic chars in string,
// digits and another special characters (void Analyze(string))

void Analyze(string text)
{
    int digits=0, letters=0, symbols=0;
    
    foreach (char x in text)
    {
        if (char.IsLetter(x))
        {
            letters++;
    
        }
        else if (char.IsDigit(x))
        {
            digits++;
        }
        else 
        {
            symbols++;
        }
    
    }
    Console.WriteLine(letters);
    Console.WriteLine(digits);
    Console.WriteLine(symbols);
}

// Sort that will return string that contains all characters from input string
// sorted in alphabetical order (e.g. 'Hello' -> 'ehllo') (string Sort(string))
string Sort(string text)
{
    char[] chars = new char[text.Length];
    
    string low = text.ToLower(CultureInfo.CurrentCulture);
    
    
    for (int i = 0; i < text.Length; i++)
    {
        chars[i] = low[i];
    }

    Array.Sort(chars);
    return new string(chars);
}

// Duplicate that will return array of characters that are
// duplicated in input string (e.g. 'Hello and hi' -> ['h', 'l']) (char[] Duplicate(string))
char[] Duplicate(string str)
{
    string lower = str.ToLower(CultureInfo.CurrentCulture);
    char[] duplicat = Array.Empty<char>();

    for (int i = 0; i < lower.Length - 1; i++)
    {
        if (str[(i + 1)..].Contains(lower[i]))
        {
            bool alreadyInsideDuplicates = false;
            for (int j = 0; j < duplicat.Length; j++)
            {
                if (duplicat[j] == lower[i])
                {
                    alreadyInsideDuplicates = true;
                    break;
                }
            }

            if (!alreadyInsideDuplicates)
            {
                Array.Resize(ref duplicat, duplicat.Length + 1);
                duplicat[^1] = lower[i];
            }
        }
    }

    return duplicat;
}
Console.WriteLine("Compare Method");
Console.WriteLine(Compare("sdfsd", "dsfsd"));
Console.WriteLine(Compare("sdfsd", "dsfsd", false));
Console.WriteLine(Compare("sdfsd", "sdfsd"));
Console.WriteLine(Compare("sdfsd", "Sdfsd", false));

Console.WriteLine("Analyze Method");
Analyze("aasdas IJIUIUH £%$%^");
Console.WriteLine("Sort Method");
Console.WriteLine(Sort("aasdas IJIUIUH fsejdfj"));
Console.WriteLine("Duplicate Method");
Console.WriteLine(Duplicate("aasdas IJIUIUH fsejdfj"));
