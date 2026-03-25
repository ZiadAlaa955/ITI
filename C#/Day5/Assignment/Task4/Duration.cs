using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace Task4
{
    internal class Duration
    {
        #region Properties
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        #endregion

        #region Constructors
        public Duration() {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }
        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Duration(int total)
        {
            int hours = 0, minutes = 0, seconds = 0;

            if (total / (60 * 60) > 0)
            {
                hours = total / (60 * 60);
                total -= hours * 60 * 60;
            }

            if (total / 60 > 0)
            {
                minutes = total / 60;
                total -= minutes * 60;
            }

            seconds = total;

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        #endregion

        #region System.object override
        public override string ToString()
        {
            if (Hours == 0)
            {
                if (Minutes == 0)
                {
                    return $"Seconds:{Seconds}";
                }
                else
                {
                    return $"Minutes:{Minutes}, Seconds:{Seconds}";
                }
            }
            else
            {
                return $"Hours: {Hours}, Minutes:{Minutes}, Seconds:{Seconds}";
            }
        }
        public override bool Equals(Object? obj)
        {
            if (obj is Duration other)
            {
                return this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }
        #endregion

        #region Operators overloading
        public static Duration operator +(Duration D1, Duration D2)
        {
            return new Duration()
            {
                Hours = D1.Hours + D2.Hours,
                Minutes = D1.Minutes + D2.Minutes,
                Seconds = D1.Seconds + D2.Seconds
            };
            
        }
        public static Duration operator +(Duration D1, int total)
        {
            int hours = 0, minutes = 0, seconds = 0;

            if (total / (60 * 60) > 0)
            {
                hours = total / (60 * 60);
                total -= hours * 60 * 60;
            }

            if (total / 60 > 0)
            {
                minutes = total / 60;
                total -= minutes * 60;
            }

            seconds = total;
            return new Duration()
            {
                Hours = D1.Hours + hours,
                Minutes = D1.Minutes = minutes,
                Seconds = D1.Seconds + seconds
            };

        }
        public static Duration operator +(int total, Duration D1)
        {
            int hours = 0, minutes = 0, seconds = 0;

            if (total / (60 * 60) > 0)
            {
                hours = total / (60 * 60);
                total -= hours * 60 * 60;
            }

            if (total / 60 > 0)
            {
                minutes = total / 60;
                total -= minutes * 60;
            }

            seconds = total;
            return new Duration()
            {
                Hours = D1.Hours + hours,
                Minutes = D1.Minutes = minutes,
                Seconds = D1.Seconds + seconds
            };

        }
        public static Duration operator ++(Duration D) 
        {
            return new Duration() { 
                Hours = D.Hours + 1,
                Minutes = D.Minutes + 1,
                Seconds = D.Seconds + 1
            };
        }
        public static Duration operator --(Duration D)
        {
            return new Duration()
            {
                Hours = D.Hours - 1,
                Minutes = D.Minutes - 1,
                Seconds = D.Seconds - 1
            };
        }
        public static Duration operator -(Duration D)
        {
            return new Duration(-D.Hours, -D.Minutes, -D.Seconds);
        }
        public static bool operator >(Duration D1, Duration D2)
        {
            int totalSeconds1 = D1.Hours * 60 * 60 + D1.Minutes * 60 + D1.Seconds;
            int totalSeconds2 = D2.Hours * 60 * 60 + D2.Minutes * 60 + D2.Seconds;

            return totalSeconds1 > totalSeconds2;
        }
        public static bool operator <(Duration D1, Duration D2)
        {
            int totalSeconds1 = D1.Hours * 60 * 60 + D1.Minutes * 60 + D1.Seconds;
            int totalSeconds2 = D2.Hours * 60 * 60 + D2.Minutes * 60 + D2.Seconds;

            return totalSeconds1 < totalSeconds2;
        }
        public static bool operator <=(Duration D1, Duration D2)
        {
            int totalSeconds1 = D1.Hours * 60 * 60 + D1.Minutes * 60 + D1.Seconds;
            int totalSeconds2 = D2.Hours * 60 * 60 + D2.Minutes * 60 + D2.Seconds;

            return totalSeconds1 <= totalSeconds2;
        }
        public static bool operator >=(Duration D1, Duration D2)
        {
            int totalSeconds1 = D1.Hours * 60 * 60 + D1.Minutes * 60 + D1.Seconds;
            int totalSeconds2 = D2.Hours * 60 * 60 + D2.Minutes * 60 + D2.Seconds;

            return totalSeconds1 >= totalSeconds2;
        }
        public static bool operator true(Duration D)
        {
            return D.Hours != 0 || D.Minutes !=0 || D.Seconds != 0;
        }
        public static bool operator false(Duration D)
        {
            return D.Hours == 0 && D.Minutes == 0 && D.Seconds == 0;
        }
        public static explicit operator DateTime(Duration D)
        {
            int totalSeconds = D.Hours * 60 * 60 + D.Minutes * 60 + D.Seconds;
            DateTime baseDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return baseDate.AddSeconds(totalSeconds);
        }
        #endregion
    }
}
