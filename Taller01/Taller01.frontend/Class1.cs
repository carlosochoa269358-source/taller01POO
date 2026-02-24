using System.Security.Cryptography.X509Certificates;

namespace Taller01.frontend
{
    public class Time

    {
        private int _hour;
        private int _millisecond;
        private int _minute;
        private int _second;

        public Time()
        {
            _hour = 0;
            _millisecond = 0;
            _minute = 0;
            _second = 0;
        }

        public Time(int hour, int millisecond, int minute, int second)
        {
            Hour = hour;
            Millisecond = millisecond;
            Minute = minute;
            Second = second;
        }

        public int Hour;
        {
            get => _hour;
            set => _hour = validateHour(value);
             }
        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = validateMillisecond(value);
         }
        public int Minute;
        {
            get => _minute;
            set => _minute = validateMinute(value);
        }
        public int Second;
        {
            get => _second;
            set => _second = validateSecond(value);
        }
    }

    public Time(): this(0, 0, 0, 0)
    public Time(int hour) : this(hour, 0, 0, 0) { }
    public Time(int hour, int minute) : this(hour, minute, 0, 0) { }
    public Time(int hour, int minute, int second) : this(hour, minute, second, 0)
    public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;

        }
        public override string ToString()
        {
            int hour12 = Hour % 12;
            if (hour12 == 0)
            {
                hour12 = 12;
            }
            string amPm = Hour < 12 ? "AM" : "PM";
            return $"{hour12:00}:{Minute:00}:{Second:00}.{Millisecond:000} {amPm}";
        }
        public int ToMilliseconds()
        {
            return ((Hour * 3600) + (Minute * 60) + Second) * 1000 + Millisecond;
        }
        public int ToSeconds()
        {
            return (Hour * 3600) + (Minute * 60) + Second;
         
        public int ToMinutes()
        {
            return (Hour * 60) + Minute;

        public bool IsOtherDay(Time other)
        {
            return Hour < other.Hour;

        }
        public Time Add(Time other)
        {
            int totalMilliseconds = ToMilliseconds() + other.ToMilliseconds();
            int newHour = (totalMilliseconds / (3600 * 1000)) % 24;
            int newMinute = (totalMilliseconds / (60 * 1000)) % 60;
            int newSecond = (totalMilliseconds / 1000) % 60;
            int newMillisecond = totalMilliseconds % 1000;
            return new Time(newHour, newMinute, newSecond, newMillisecond);
        }
        private bool ValidateHour(int value)
            => value >= 0 && value < 23;
        private bool ValidateMinute(int value)
            => value >= 0 && value < 59;
        private bool ValidateSecond(int value)
            => value >= 0 && value < 59;
        private bool ValidateMillisecond(int value)
            => value >= 0 && value < 999;

    }