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
            DateTime now = DateTime.Now;
            int age = now.Year - birthday.Year;
            if (birthday.Month > now.Month || (birthday.Month == now.Month && birthday.Day > now.Day))
            {
                age--;
            }

            return age < 0
                ? throw new ArgumentException("Birthday should be in past!")
                : age;
        }

        public static bool IsWorkday(this DateOnly date)
        {
            return date.DayOfWeek is not DayOfWeek.Saturday and not DayOfWeek.Sunday;
        }

        public static bool IsWeekend(this DateOnly date)
        {
            return !date.IsWorkday();
        }

        public static DateOnly NextWorkday(this DateOnly date)
        {
#pragma warning disable IDE0072
            return date.DayOfWeek switch
            {
                DayOfWeek.Friday => date.AddDays(3),
                DayOfWeek.Saturday => date.AddDays(2),
                _ => date.AddDays(1)
            };
#pragma warning restore IDE0072
        }
    }
}