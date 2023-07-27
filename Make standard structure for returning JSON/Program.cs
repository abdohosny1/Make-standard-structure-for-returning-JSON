using Make_standard_structure_for_returning_JSON.Core.Repository;
using Make_standard_structure_for_returning_JSON.Data;
using Make_standard_structure_for_returning_JSON.Data.Repositories;
using Make_standard_structure_for_returning_JSON.Helper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var connection = builder.Configuration.GetConnectionString("DefultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(
    op => op.UseSqlServer(connection));

// add services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

//add auto maper service
builder.Services.AddAutoMapper(typeof(MappingProfile));
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