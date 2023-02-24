using System.Text;

bool Compare(string str1, string str2)
{
    for (int i = 0; i < str1.Length; i++)
    {
        
        if (str1[i] != str2[i])
            return false;
    }

    return true;
}

void Analyze(string str)
{
    int digital = 0;
    int letters = 0;
    int anotherSpecialCharacters = 0;

    for (int i = 0; i < str.Length; i++)
    {
        if (char.IsDigit(str[i]))
        {
            digital++;
        }
        else if (char.IsLetter(str[i]))
        {
            letters++;
        }
        else if (char.IsControl(str[i]))
        {
            anotherSpecialCharacters++;
        }
    }
    Console.WriteLine("Digitals: " + digital);
    Console.WriteLine("Letters: " + letters);
    Console.WriteLine("Another special characters: " + anotherSpecialCharacters);
}

string Sort(string str)
{
    char temp;
    char[] chars = str.ToLower().ToCharArray();
    for (int i = 0; i < chars.Length; i++)
    {
        for (int j = 0; j < chars.Length - 1; j++)
        {
            if (chars[j] > chars[j + 1])
            {
                temp = chars[j];
                chars[j] = chars[j + 1];
                chars[j + 1] = temp;
            }
        }
    }
    string sorted = new string(chars);
    return sorted;
}


char[] Duplicate(string str)
{
    str = str.ToLower();
    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < str.Length; i++)
    {
        for (int j = i + 1; j < str.Length; j++)
        {
            if (str[i] != str[j])
                continue;

            sb.Append(str[i]);
            break;
        }
    }
    char[] duplicate = new char[sb.Length];
    return duplicate = sb.ToString().ToCharArray();
}

