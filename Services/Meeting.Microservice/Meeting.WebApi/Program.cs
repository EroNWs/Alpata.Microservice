using Meeting.Business.Extensions;
using Meeting.Dal.EF.Extensions;
using Meeting.WebApi.Infrastracture.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services
    //.AddDataAccessServices(builder.Configuration)
    .AddEFCoreServices(builder.Configuration)
    .AddBusinessServices();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerURL"];
    options.RequireHttpsMetadata = false;
    options.Audience = "resource_meetingResource";

});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MeetingFullPermission", policy => policy.RequireClaim("scope", "Meeting_fullpermission"));
});

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
