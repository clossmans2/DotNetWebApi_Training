using ContosoUniversity.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;


var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddControllers().AddApplicationPart(
    typeof(ContosoUniversity.Presentation.AssemblyReference).Assembly);

// Creates an IHost that hosts a web application.
// Creates an IApplicationBuilder for the middleware pipeline
// Creates and IEndpointRouteBuilder for the endpoints
var app = builder.Build();

/*
 * 1. Exception Handling
 * 2. HSTS (Strict Transport Security)
 * 3. Https Redirection
 * 4. Static Files
 * 5. Routing
 * 6. CORS
 * 7. Authentication
 * 8. Authorization
 * 9. Custom Middleware
 * 10. Endpoints
 */

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // add middleware for Http-Strict-Transport-Security
    app.UseHsts();
}

app.UseHttpsRedirection();

// allows using static files in the request, defaults to wwwroot
app.UseStaticFiles();

// Forward proxy headers to the current request.
// This is necessary when you have a reverse proxy between your server and the client.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
