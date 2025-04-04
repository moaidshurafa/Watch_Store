using Microsoft.EntityFrameworkCore;
using WatchStore.API.Data;
using WatchStore.API.Mappings;
using WatchStore.API.Repositories.IRepository;
using WatchStore.API.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<WatchStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WatchStoreConnection")));
// Add services to the container.

builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IWatchRepository, WatchRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();


builder.Services.AddAutoMapper(typeof(AutoMappers));
builder.Services.AddControllers();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
