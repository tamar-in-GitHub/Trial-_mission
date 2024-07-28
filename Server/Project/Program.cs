using Microsoft.EntityFrameworkCore;
using Project.Models;
using BL.Interfaces;
using BL.Services;
using DAL.Interfaces;
using DAL.Data;
using AutoMapper; 
//using AutoMapper.Extensions.Microsoft.DependencyInjection;

public class Program
{
    private static readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // קבלת מחרוזת החיבור מקובץ appsettings.json
        var connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");

        // הוספת DbContext עם מחרוזת החיבור
        builder.Services.AddDbContext<DBContext>(options =>
            options.UseSqlServer(connectionString));

        // הוספת CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
            builder =>
            {
                builder.WithOrigins("*")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });

        // רישום השירותים שלך כאן
        builder.Services.AddScoped<ISettlementsServices, SettlementsServices>();
        builder.Services.AddScoped<ISettlementsData, SettlementsData>();

        // רישום AutoMapper
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // הוספת שירותים נוספים
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // הגדרות של האפליקציה
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // שימוש ב-CORS לפני UseRouting ו-UseAuthorization
        app.UseCors(MyAllowSpecificOrigins);

        app.UseRouting();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}


//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using DAL;
//using Project.Models;

//public class Program
//{
//    private static readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//    public static void Main(string[] args)
//    {
//        var builder = WebApplication.CreateBuilder(args);

//        // קבלת מחרוזת החיבור מקובץ appsettings.json
//        var connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");

//        // הוספת DbContext עם מחרוזת החיבור
//        builder.Services.AddDbContext<DBContext>(options =>
//            options.UseSqlServer(connectionString));

//        // הוספת CORS
//        builder.Services.AddCors(options =>
//        {
//            options.AddPolicy(MyAllowSpecificOrigins,
//            builder =>
//            {
//                builder.WithOrigins("*")
//                       .AllowAnyHeader()
//                       .AllowAnyMethod();
//            });
//        });

//        // הוספת שירותים נוספים
//        builder.Services.AddControllers();
//        builder.Services.AddEndpointsApiExplorer();
//        builder.Services.AddSwaggerGen();

//        var app = builder.Build();

//        // הגדרות של האפליקציה
//        if (app.Environment.IsDevelopment())
//        {
//            app.UseDeveloperExceptionPage();
//            app.UseSwagger();
//            app.UseSwaggerUI();
//        }

//        app.UseHttpsRedirection();

//        // שימוש ב-CORS לפני UseRouting ו-UseAuthorization
//        app.UseCors(MyAllowSpecificOrigins);

//        app.UseRouting();
//        app.UseAuthorization();

//        app.MapControllers();

//        app.Run();
//    }
//}










//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using DAL; 
//using Project.Models;
//var builder = WebApplication.CreateBuilder(args);

//// הוספת DbContext עם מחרוזת החיבור
//builder.Services.AddDbContext<DBContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));

//// הוספת CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", builder =>
//    {
//        builder.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//    });
//});

//// הוספת שירותים נוספים
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// הגדרות של האפליקציה
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//// שימוש ב-CORS
//app.UseCors("AllowAll");

//app.UseRouting();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();


//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using DAL; // ודא שמרחב השמות נכון
//using Project.Models;

//var builder = WebApplication.CreateBuilder(args);

//// קבלת מחרוזת החיבור מקובץ appsettings.json
//var connectionString = builder.Configuration.GetConnectionString("DefaultDatabase");

//// הוספת DbContext עם מחרוזת החיבור
//builder.Services.AddDbContext<DBContext>(options =>
//    options.UseSqlServer(connectionString));

//// קביעות נוספות של שירותים
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// הגדרות של האפליקציה
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseRouting();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();
