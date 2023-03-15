using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public static class DateOnlyExtensions
    {
        public static IEnumerable<DateOnly> DaysBetween(this DateOnly date1, DateOnly date2)
        {
            if (date1 > date2)
            {
                throw new ArgumentException("date1 should be before date2!");
            }

            for (DateOnly result = date1; result <= date2; result = result.AddDays(1))
            {
                yield return result;
            }
        }

        public static int Age(this DateOnly birthday)
        {
            DateTime today = DateTime.Now;
            int age = today.Year - birthday.Year;
            if (birthday.Month > today.Month || (birthday.Month == today.Month && birthday.Day > today.Day))
            {
                age--;
            }

            return age;
        }
    }
}