using System.Text; //for StringBuilder

// Нижче код тільки для перевірки
// string str1 = "";
// string str2 = "";
string str1 = "121fffdddSQA ♀]p♪♫ babyboy%3&#6$ ";
// string str1 = "121fl';jdfenvoi3m38093845t bjlkjflks dlkjsdf/";
string str2 = "111fffddd";
// string str1 = "Hello and hi";
// string str2 = null;
// string str1 = null;

Console.WriteLine(Compare(str1, str2));
Analyze(str1);
System.Console.WriteLine(Sort(str1));
System.Console.WriteLine(Sort(str2));
System.Console.WriteLine("DUPLICATE");
Duplicate(str1); //просто викликаємо ф-цію




// HERE and below STARTS HOMEWORK

//TASK 1
// Compare that will return true if 2 strings are equal, otherwise false, but do not use build-in method (bool Compare(string, string))
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



//TASK 2
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


//TASK 3
// Sort that will return string that contains all characters from input string sorted in alphabetical order (e.g. 'Hello' -> 'ehllo')
// (string Sort(string))
static string Sort(string str1)
{
    str1 = str1.ToLower();
    int length = str1.Length - 1;
    char[] charLine = new char[length];
    charLine = str1.ToCharArray();

    BubbleSort(charLine); //сортуємо бульбашково

    // just to check if charLine[] is sorted
    // for (int i = 0; i < length; i++) System.Console.WriteLine(charLine[i])

    StringBuilder sb = new();
    for (int i = 0; i < length; i++)
    {
        sb.Append($"{charLine[i]}");
    }
    // Console.WriteLine(sb); //just to check


    return sb.ToString();

}


static char[] BubbleSort(char[] arr)
{
    int length = arr.Length - 1;
    bool flag = new bool();
    do
    {
        flag = true;
        for (int i = 1; i < length; i++)
        {
            if (arr[i - 1] > arr[i])
            {
                var tmp = arr[i - 1];
                arr[i - 1] = arr[i];
                arr[i] = tmp;
                flag = false;
            }

        }
    } while (!flag);
    return arr;
}




//TASK 4
// Duplicate that will return array of characters that are duplicated in input string 
// (e.g. 'Hello and hi' -> ['h', 'l']) (char[] Duplicate(string))

//алгоритм
// Сортуємо стрінг попереднім методом
// прибираємо пробіли
// копіюємо string в char[]
// цикл...j
// {
//      порівнюємо поточний з наступним; якщо рівний то
//      {
//           то змінюємо розмір вихідного масиву і добавляємо char[j] в новий масив[] і піднімаємо прапор
//      }
//      інакше
//      {
//           опускаємо прапор //цей прапор фіксує перехід на нову послідовність відсортованих символів
//      }
//    
//  }
//  return новий масив;
// 

char[] Duplicate(string stringCheckDuplicate)
{
    string sorted = Sort(stringCheckDuplicate);
    sorted = sorted.ToLower();
    sorted = sorted.TrimStart(' ');

    int length = sorted.Length - 1;
    char[] charArrFromString = new char[length];
    charArrFromString = sorted.ToCharArray(); // copy from string

    char[] outputChar = new char[1]; //here we'll put duplicated symbols
    int count = 0;
    bool flag = false;

    for (int j = 0; j < length; j++)
    {
        if (charArrFromString[j + 1] == charArrFromString[j] && flag == false)
        {
            flag = true;
            Array.Resize(ref outputChar, ++count); //we increase count directly here
            outputChar[count - 1] = charArrFromString[j]; //and add duplicated character from arr to outputChar
            Console.Write($"{outputChar[count - 1]}, ");

        }
        else
        {
            flag = false;
        }
    }
    return outputChar;
}








