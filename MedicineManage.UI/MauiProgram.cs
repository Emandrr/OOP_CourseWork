using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.EntityFrameworkCore;
using MedicineManage.DataAccess.Data;
using MedicineManage.DataAccess;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Reflection;
using MedicineManage.UI.Pages;
using MedicineManage.UI.ViewModels;
using MedicineManage.Aplication;
using System.Runtime.CompilerServices;
using MedicineManage.DataAccess.Interfaces;
using MedicineManage.Domain.Models;
namespace MedicineManage.UI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        string settingsStream = "MedicineManage.UI.appsettings.json";
        var builder = MauiApp.CreateBuilder();
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);

        builder.Configuration.AddJsonStream(stream);
        //var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
        string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
        connStr = String.Format(connStr, dataDirectory);
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connStr)
            .Options;
        builder.Services.AddPersistance(options);
        builder.Services.AddApplication();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddTransient<SearchPage>();
        builder.Services.AddTransient<SearchViewModel>();
        builder.Services.AddTransient<PatientsDetailsViewModel>();
        builder.Services.AddTransient<PatientsDetailsPage>();
        builder.Services.AddTransient<EditPatientViewModel>();
        builder.Services.AddTransient<EditPatientPage>();
        builder.Services.AddTransient<PatientFullInfoViewModel>();
        builder.Services.AddTransient<PatientFullInfoPage>();
        builder.Services.AddTransient<DiagnosisInfoViewModel>();
        builder.Services.AddTransient<DiagnosisInfoPage>();
        DbInitializer.Initialize(builder.Services.BuildServiceProvider()).Wait();

        
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
