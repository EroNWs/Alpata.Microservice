using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

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

builder.Services.AddAuthentication().
    AddJwtBearer("GatewayAuthenticationScheme", options =>
{
    options.Authority = builder.Configuration["IdentityServerURL"];
    options.Audience = "resource_gateway";
    options.RequireHttpsMetadata = false;
});




var app = builder.Build();
app.UseCors("CorsPolicy");
app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization();
app.UseDeveloperExceptionPage();
app.MapControllers();
await app.UseOcelot();

app.Run();
