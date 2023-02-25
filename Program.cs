using System.Text;


bool Compare(string a, string b)
{
    int len1 = a.Length;
    int len2 = b.Length;

    if (len1 == len2)
    {
        for (int i = 0; i<len1; i++)
        {
            if (a[i]!= b[i])
            {
                return false;
            }
        }
        return true;
    }
    else
    {
        return false;
    }
}

void Analyze(string a)
{
    int charCount = 0;
    int digCount = 0;
    int specialCount = 0;

    for (int i = 0; i < a.Length; i++)
    {
        if (Char.IsLetter(a[i]))
        {
            charCount++;
        }
        else if (Char.IsDigit(a[i]))
        {
            digCount++;
        }
        else
        {
            specialCount++;
        }
    }
    Console.WriteLine($"{a} have {charCount} letters, {digCount} digitals and {specialCount} another symbols");
    return;
}

string Sort(string a)
{
    StringBuilder b = new StringBuilder(a);

    for (int i = 0; i < a.Length-1; i++)
    {
        for (int j = 0; j < a.Length-1; j++)
        {
            if (Char.ConvertToUtf32(b.ToString().ToLower(), j) >= Char.ConvertToUtf32(b.ToString().ToLower(), j+1))
            {
                char temp = b[j];
                b[j] = b[j+1];
                b[j+1] = temp;
            }
        }
    }
    return b.ToString();
}

// void Write(char [] array)
// {
//     foreach (var item in array) 
//     {
//         Console.WriteLine(item);
//     }
// }

char[] Duplicate(string a)
{
    char[] b = new char[0];

    for (int i = 0; i < a.Length; i++)
    {
        for (int j = 0; j < a.Length; j++)
        {
            if (a[i] == a[j] && i != j && !b.Contains(a[i]) && Char.IsLetter(a[i]))
            {
                Array.Resize(ref b, b.Length + 1);
                b[b.Length - 1] = a[i];
            }
        }
    }
    return b;
}


// Console.WriteLine(Compare("123", "123"));
// Analyze("Hello123&$*");
// Console.WriteLine(Sort("dcba"));
// Write(Duplicate("hello and hi l a"));
