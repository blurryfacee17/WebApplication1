using Microsoft.Extensions.Options;
using Polly;

namespace SmtpPractice;

public class StartupNotificationBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<StartupNotificationBackgroundService> _logger;
    private readonly PolicyConfig _policyConfig;

    public StartupNotificationBackgroundService(IServiceScopeFactory serviceScopeFactory,
        ILogger<StartupNotificationBackgroundService> logger, IOptionsMonitor<PolicyConfig> options)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
        _policyConfig = options.CurrentValue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Server started");
        using var scope = _serviceScopeFactory.CreateScope();
        var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();
        var email = "danildudyrev@mail.ru";

        var policy = Policy
            .Handle<Exception>()
            .WaitAndRetry(_policyConfig.RetryCount, 
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (exception, retryAttempt) =>
                {
                    _logger.LogWarning(
                        exception, "Error while sending email. Retrying: {Attempt}", retryAttempt);
                }
            );
        PolicyResult? result = policy.ExecuteAndCapture(token => emailSender.Send(email,
            "Server started",
            "Server successfully started"), stoppingToken);

        if (result.Outcome == OutcomeType.Failure)
        {
            _logger.LogError(result.FinalException, "There was an error while sending email");
        }
    }
}