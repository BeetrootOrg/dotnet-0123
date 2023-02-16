using System.Text;

bool Compare(string s1, string s2)
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

void Analyze(string str)
{
    (int letters, int digits, int controls) t = (0, 0, 0);

    foreach (char ch in str)
    {
        if (Char.IsLetter(ch))
        {
            t.letters++;
        }
        if (Char.IsDigit(ch))
        {
            t.digits++;
        }
        if (Char.IsControl(ch))
        {
            t.controls++;
        }
    }

    string result = String.Format("Letters: {0}\nDigits: {1}\nControls: {2}", t.letters, t.digits, t.controls);
    Console.WriteLine(result);
}

string Sort(string s)
{
    string str = s.ToLower();
    char[] arr = str.ToCharArray();
    
    for (int i = 1; i < arr.Length; i++)
    {
        for (int j = i; j > 0; j--)
        {
            if (arr[j] < arr[j - 1])
            {
                char temp = arr[j - 1];
                arr[j - 1] = arr[j];
                arr[j] = temp;
            }
        }
    }
    
    return String.Join("", arr);
}

char[] Duplicate(string s)
{
    StringBuilder sb = new();
    string str = s.ToLower();
    
    foreach (char ch in str)
    {
        if (sb.ToString().Contains(ch) || Char.IsWhiteSpace(ch))
        {
            continue;
        }

        int i = str.Split(ch).Length - 1;
        
        if (i > 1)
        {
            sb.Append(ch);
        }
    }
    
    return sb.ToString().ToCharArray(); 
}
