using SmtpPractice;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IEmailSender, MailKitEmailSender>();
builder.Services.AddHostedService<ServiceStartupNotificationBackgroundService>();
var app = builder.Build();

app.MapGet("/", (IEmailSender sender) =>
{
    sender.Send("danildudyrev@mail.ru","Тема","Сообщение");
    return "Hello World!";
});

app.Run();