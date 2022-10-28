namespace SmtpPractice;

public class ServiceStartupNotificationBackgroundService: BackgroundService
{
    private readonly IEmailSender _emailSender;

    public ServiceStartupNotificationBackgroundService(IServiceScopeFactory serviceScopeFactory)
    {
        var scope = serviceScopeFactory.CreateScope();
        _emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _emailSender.Send("danildudyrev@mail.ru","Сервер запущен","Сервер успешно запущен");
    }
    
}