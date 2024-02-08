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



builder.Services.AddAuthentication()
    .AddJwtBearer("GatewayAuthenticationScheme", options =>
    {
        options.Authority = builder.Configuration["IdentityServerUrl"];
        options.Audience = "resource_gateway";
        options.RequireHttpsMetadata = false;
    });

builder.Services.AddOcelot();


var app = builder.Build();
app.UseCors("CorsPolicy");
app.UseAuthentication(); 
app.UseAuthorization();
app.UseDeveloperExceptionPage();
app.MapControllers();
await app.UseOcelot();

app.Run();
