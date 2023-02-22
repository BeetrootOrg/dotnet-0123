using System.Diagnostics.Metrics;
using System.Text;

bool CompareSrtings(string text1, string text2)
{
    if (text1.Length != text2.Length) return false;
    for (int i = 0; i < text1.Length; i++)
    {
        if (text1[i] != text2[i]) return false;
    }
    return true;
}


void Analyze(string text)
{
    int letter_chars = 0, digit_chars = 0, symbol_chars = 0, whitespace = 0, counter = 0;

    for (counter = 0; counter < text.Length; counter++)
    {
        if (Char.IsLetter(text[counter]) == true) letter_chars += 1;
        else if (Char.IsDigit(text[counter]) == true) digit_chars += 1;
        else if (Char.IsSymbol(text[counter]) == true || Char.IsPunctuation(text[counter]) == true) symbol_chars += 1;
        else if (Char.IsWhiteSpace(text[counter]) == true) whitespace += 1;

    }
    Console.WriteLine($"Text \"{text}\" contains {letter_chars} letters, {digit_chars} digits, {symbol_chars} symbols, {whitespace} whitespaces");
}


string Sort(string text)
{
    text = text.ToLower();
    
    char[] tosort = new char[text.Length];
    Array.Copy(text.ToCharArray(), tosort, text.Length);
    
    for (int i = 1; i < tosort.Length; i++)
    {
        for (int j = 1; j < tosort.Length; j++)
        {
            if (tosort[j - 1] > tosort[j])
            {
                char[] item = new char[1];
                item[0] = tosort[j];
                tosort[j] = tosort[j - 1];
                tosort[j - 1] = item[0];
            }
        }
    }
    return text = new string (tosort);
 }


char[] Duplicate(string text)
{
    text = text.ToLower();
    StringBuilder dupl = new StringBuilder();

    for (int index1 = 0; index1 < text.Length; index1++)
    {
        for (int index2 = index1+1; index2 <= text.Length-1; index2++)
        {
            if (text[index1] != text[index2]) continue;
            dupl.Append(text[index1]);
            break;
        }
    }
    char[] duplicate = new char[dupl.Capacity];
    return duplicate = dupl.ToString().ToCharArray();  
}