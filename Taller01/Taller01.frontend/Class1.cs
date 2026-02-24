namespace Taller01;
public class Time
{
    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;

    public Time() : this(0, 0, 0, 0) { }
    public Time(int hour) : this(hour, 0, 0, 0) { }
    public Time(int hour, int minute) : this(hour, minute, 0, 0) { }
    public Time(int hour, int minute, int second) : this(hour, minute, second, 0) { }
    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    public int Hour
    {
        get => _hour;
        set => _hour = ValidateHour(value);
    }

    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidateMillisecond(value);
    }

    public int Minute
    {
        get => _minute;
        set => _minute = ValidateMinute(value);
    }

    public int Second
    {
        get => _second;
        set => _second = ValidateSecond(value);
    }

    public override string ToString()
    {
        int hour12 = Hour % 12;
        if (hour12 == 0) hour12 = 0;
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
    }

    public int ToMinutes()
    {
        return (Hour * 60) + Minute;
    }

    public bool IsOtherDay(Time other)
    {
        const int MsPerSecond = 1000;
        const int MsPerMinute = 60 * MsPerSecond;   
        const int MsPerHour = 60 * MsPerMinute;  
        const int DayMs = 24 * MsPerHour;    

        int sum = this.ToMilliseconds() + other.ToMilliseconds();
        return sum >= DayMs;
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

    private int ValidateHour(int value)
    {
        if (value < 0 || value > 23) throw new Exception($"The hour: {value}, is not valid.");
        return value;
    }

    private int ValidateMinute(int value)
    {
        if (value < 0 || value > 59) throw new Exception($"The minute: {value}, is not valid.");
        return value;
    }

    private int ValidateSecond(int value)
    {
        if (value < 0 || value > 59) throw new Exception($"The second: {value}, is not valid.");
        return value;
    }

    private int ValidateMillisecond(int value)
    {
        if (value < 0 || value > 999) throw new Exception($"The millisecond: {value}, is not valid.");
        return value;
    }
}
