namespace RazorPages.Domain.Entities;

public class ClockUtc : IClock
{
    public DateTime GetCurrent()
    {
        return DateTime.UtcNow;
    }
}