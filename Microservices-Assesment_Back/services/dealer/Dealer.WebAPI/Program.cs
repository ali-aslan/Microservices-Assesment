using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Dealer.Application;
using Dealer.Persistence;
using Dealer.Infrastructure;


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
            builder.WithOrigins("http://localhost:4200", "http://localhost:4400", "http://localhost:4500", "http://localhost:4600")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
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

//if (app.Environment.IsProduction())
app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();



//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
