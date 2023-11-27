using MediatR;
using sensitive_words.core.Abstractions;
using sensitive_words.core.Factories;
using sensitive_words.core.Services;
using sensitive_words.services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WordsDatabase");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SensitiveWords API", Version = "v1" });
});
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(MediatREntryPoint).Assembly));
builder.Services.AddScoped<ISensitiveWordsService, SensitiveWordsService>();
builder.Services.AddSingleton<ISqlConnectionFactory>(provider => new SqlConnectionFactory(connectionString));
builder.Services.AddScoped<ISensitiveWordsRepository, MSSQLSensitiveWordsRepository>();
ServiceProvider serviceProvider = new ServiceCollection()
    .AddLogging((loggingBuilder) => loggingBuilder
        .SetMinimumLevel(LogLevel.Trace)
        .AddConsole()
        )
    .BuildServiceProvider();

var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("../swagger/v1/swagger.json", "SensitiveWords API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
