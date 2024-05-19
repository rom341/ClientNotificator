using ClientCreator.DataAccess;
using ClientCreator.Models;
using ClientCreator.ViewModels;
using Microsoft.Extensions.Logging;

namespace ClientCreator
{
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

            builder.Services.AddDbContext<AppDBContext>();
            builder.Services.AddTransient<MainPage>();

            var dbContext = new AppDBContext();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();

            builder.Services.AddTransient<Client>();
            builder.Services.AddTransient<ClientContacts>();
            builder.Services.AddTransient<ClientPersonalInfo>();
            builder.Services.AddTransient<Service>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddTransient<CreateNewClientPage>();
            builder.Services.AddTransient<EditClientViewModel>();

            builder.Services.AddTransient<ClientListPage>();
            builder.Services.AddTransient<ClientListViewModel>();



#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
