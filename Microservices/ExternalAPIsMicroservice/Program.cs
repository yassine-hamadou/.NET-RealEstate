using ExternalAPIsMicroservice.Properties;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9004
builder.WebHost.UseUrls("http://*:9004");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithConfig();

builder.Configuration.AddJsonFile("Properties/appsettings.json");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExternalAPI MS v1"));
}

app.UseHttpsRedirection().UseAuthorization();

app.MapControllers();

app.Map("/hc", builder =>
{
    builder.UseHealthChecks("/hc", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

app.Run();
