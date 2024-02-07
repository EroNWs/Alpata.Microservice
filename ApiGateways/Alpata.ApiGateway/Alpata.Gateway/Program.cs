using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Configuration.AddJsonFile($"configuration.{builder.Environment
	.EnvironmentName.ToLower()}.json");

builder.Services.AddOcelot();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.UseDeveloperExceptionPage();

app.MapControllers();

await app.UseOcelot();

app.Run();
