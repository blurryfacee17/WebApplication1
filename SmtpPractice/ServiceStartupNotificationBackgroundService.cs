namespace SmtpPractice;

public class ServiceStartupNotificationBackgroundService: BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ServiceStartupNotificationBackgroundService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope1 = _serviceScopeFactory.CreateScope();
        using var scope2 = _serviceScopeFactory.CreateScope();
        var emailSender1 = scope1.ServiceProvider.GetRequiredService<IEmailSender>();
        var emailSender2 = scope2.ServiceProvider.GetRequiredService<IEmailSender>();
        Parallel.Invoke(() => 
            emailSender1.Send(
                "danildudyrev@mail.ru",
                "Сервер запущен", 
                "Сервер успешно запущен"),
            () => emailSender2.Send(
                "danildudyrev@mail.ru",
                "Сервер запущен", 
                "Сервер успешно запущен")
            );
    }
    
}