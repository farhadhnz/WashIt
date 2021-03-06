using Microsoft.EntityFrameworkCore;
using WashIt.API.Data;
using WashIt.API.Data.Repositories;
using WashIt.API.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMemory"));

builder.Services.AddScoped<IBaseRepo, BaseRepo>();
builder.Services.AddScoped<IDeviceRepo, DeviceRepo>();
builder.Services.AddScoped<IBookingRepo, BookingRepo>();
builder.Services.AddScoped<IWaitListRepo, WaitListRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IWashingModeRepo, WashingModeRepo>();

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IWaitListService, WaitListService>();
builder.Services.AddScoped<INotificationSender, EmailSender>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                builder.WithOrigins("https://localhost:7106")
                       .AllowAnyMethod()
                       .AllowAnyHeader());
            });

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

DbPrep.PreparePopulation(app);

app.Run();
