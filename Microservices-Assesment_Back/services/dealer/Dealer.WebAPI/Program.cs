using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Dealer.Application;
using Dealer.Persistence;
using Dealer.Infrastructure;
using Core.Security.Encryption;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationServices();
builder.Services.AddPresistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddInfrastructureServices(builder.Configuration);

//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//Dealer 
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidAudience = "mehmet.ali.aslan.abc@gmail.com",
            ValidIssuer = "mehmet.ali.aslan.abc@gmail.com",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey("StrongAndSecretKeyStrongAndSecretKeyStrongAndSecretKeyStrongAndSecretKey")
        };
    });



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//if (app.Environment.IsProduction())
app.ConfigureCustomExceptionMiddleware();

//app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
