using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.StaticFiles;
using VehicleManagementSystem.Infrastructure.Data;
using VehicleManagementSystem.Application.Services;
using VehicleManagementSystem.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// =====================
// SERVICES
// =====================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddDbContext<VehicleDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// =====================
// MIDDLEWARE PIPELINE
// =====================

// Swagger (only in development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// =====================
// STATIC FILES (FIXED FOR AVIF)
// =====================
var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".avif"] = "image/avif";

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

// =====================
// ROUTING + CORS
// =====================
app.UseRouting();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();

// using Microsoft.EntityFrameworkCore;
// using VehicleManagementSystem.Infrastructure.Data;
// using VehicleManagementSystem.Application.Services;
// using VehicleManagementSystem.Infrastructure.Services;

// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddScoped<IVehicleService, VehicleService>();
// builder.Services.AddDbContext<VehicleDbContext>(options =>
//     options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAngular", policy =>
//     {
//         policy.AllowAnyOrigin()
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//     });
// });

// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();
// app.UseStaticFiles();
// app.UseRouting();
// app.UseCors("AllowAngular");
// app.UseAuthorization();
// app.MapControllers();
// app.Run();