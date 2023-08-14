using HeavyService.Persistance.Dtos.Notifications;

namespace HeavyService.Service.Interfaces.Notifications;

public interface IEmailSMSSender
{
    public Task<bool> SendAsync(SmSMessage smSMessage);
}