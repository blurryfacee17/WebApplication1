namespace SmtpPractice;

public class ServiceStartupNotificationBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<ServiceStartupNotificationBackgroundService> _logger;

    public ServiceStartupNotificationBackgroundService(IServiceScopeFactory serviceScopeFactory,
        ILogger<ServiceStartupNotificationBackgroundService> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Сервер запущен");
        using var scope = _serviceScopeFactory.CreateScope();
        var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();
        var email = "danildudyrev@mail.ru";
        var isError = true;
        var attempts = 2;

        while (isError)
        {
            isError = false;
            try
            {
                emailSender.Send(
                    email,
                    "Сервер запущен",
                    "Сервер успешно запущен");
            }

            catch (Exception e)
            {
                isError = true;
                attempts--;
                if(attempts == 0)
                    _logger.LogError(e, "Ошибка отправки сообщения на почту о старте программы {ToEmail}, {Service}", email, emailSender.GetType());
            }
        }
    }
}