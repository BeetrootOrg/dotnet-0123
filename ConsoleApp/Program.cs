DateTime nextNewYear = new(2024, 1, 1);
DateTime now = DateTime.Now;
// NOT THE SAME AS ABOVE
// DateTime d1 = new DateTime();

Console.WriteLine($"{now.DayOfYear} days passed from New Year");
Console.WriteLine($"{(int)(nextNewYear - now).TotalDays} days left to New Year");