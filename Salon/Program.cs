using Business_Logic_Layer.Services;
using Business_Logic_Layer.Services.Interfaces;
using Data_Access_Layer;
using Data_Access_Layer.RepositoryWithUOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
                            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SalonDBContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IClientServices, ClientServices>();
builder.Services.AddScoped<IFeedbackServices, FeedbackServices>();
builder.Services.AddScoped<IMaterialManufacturerServices, MaterialManufacturerServices>();
builder.Services.AddScoped<IMaterialServices, MaterialServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IProcesureServices, ProcedureServices>();
builder.Services.AddScoped<IProfileServices, ProfileServices>();
builder.Services.AddScoped<IScheduleServices, ScheduleServices>();
builder.Services.AddScoped<ISpecializationServices, SpecializationServices>();
builder.Services.AddScoped<IMediaFileServices, MediaFileServices>();

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
