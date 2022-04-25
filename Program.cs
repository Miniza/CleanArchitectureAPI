using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineVets.Application.Handlers;
using OnlineVets.Core.Repositories;
using OnlineVets.Infrastructure.Data;
using OnlineVets.Infrastructure.Repositories;
using OnlineVets.Infrastructure.Repositories.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContextPool<ApplicationContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddMediatR(typeof(GetPetListHandler).GetTypeInfo().Assembly);
builder.Services.AddTransient(typeof(IRepository< >),typeof(Repository< >));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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
