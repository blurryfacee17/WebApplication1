using SmtpPractice;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<SmtpConfig>(builder.Configuration.GetSection("SmtpConfig"));
builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();
builder.Services.AddHostedService<ServiceStartupNotificationBackgroundService>();
var app = builder.Build();

app.MapGet("/", (IEmailSender sender) =>
{
    sender.Send("danildudyrev@mail.ru","Тема","Сообщение");
    return "Hello World!";
});

app.MapPost("/sendemail", (IEmailSender sender, string toEmail,string subject,string htmlBody) =>
{
    sender.Send(toEmail,subject,htmlBody);
});

app.Run();
