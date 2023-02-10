DateTime date1 = DateTime.Now;

DateTime newYear2023 = new DateTime (2023, 1, 1);

DateTime newYear2024 = new DateTime (2023, 12, 31);

Console.WriteLine(newYear2024.DayOfYear - date1.DayOfYear + " days left to the New Year");
Console.WriteLine(date1.DayOfYear - newYear2023.DayOfYear + " days passed from the New Year");
