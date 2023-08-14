using HeavyService.Domain.Constans;

namespace HeavyService.Persistance.Helpers;
public class TimeHealpers
{
    public static DateTime GetDateTime()
    {
        var dtTime = DateTime.UtcNow;
        dtTime.AddHours(TimeConstans.UTC);
        return dtTime;
    }
}