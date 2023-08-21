using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiMarket.Data;
using ApiMarket.Service;
using ApiMarket.Service.Impl;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApiMarketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiMarketContext") ?? throw new InvalidOperationException("Connection string 'ApiMarketContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>{
    c.EnableAnnotations();
});
builder.Services.AddScoped<IClientArticleService, ClientArtcleServiceImpl>();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod(); ;
                      }) ;
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
