using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DelabinService.Data;
using DelabinService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DelabinServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DelabinServiceContext") ?? throw new InvalidOperationException("Connection string 'DelabinServiceContext' not found.")));

// Add services to the container.
builder.Services.ConfigureRepositoryWrapper();
builder.Services.AddAutoMapper(typeof(Program));
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
