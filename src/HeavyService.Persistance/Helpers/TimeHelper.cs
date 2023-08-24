using HeavyService.Domain.Constans;

namespace HeavyService.Persistance.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var datetime = DateTime.UtcNow;
        datetime.AddHours(TimeConstans.UTC);
        
        return datetime;
    }
}