﻿using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		//builder.Services.AddSingleton<MainPage>();
		//builder.Services.AddSingleton<ViewModel>();
    builder.Services.AddTransient<MainPage>();
    builder.Services.AddTransient<ViewModel>();

    return builder.Build();
	}
}