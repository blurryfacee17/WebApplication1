namespace RazorPages.Domain.Entities;

public class CurrentUtc : ICurrentUtc
{
    public DateTime GetTime()
    {
        return DateTime.UtcNow;
    }
}