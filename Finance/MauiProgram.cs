using Finance.Servises;
using Finance.Servises.Implementations;
using Finance.Servises.Interfaces;
using Finance.View;
using Microsoft.Extensions.Logging;

namespace Finance
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
            builder.Services.AddScoped<ExpensesPage>();
            builder.Services.AddScoped<IncomePage>();
            builder.Services.AddSingleton<ICategoryServise, CategoryServise>();
            builder.Services.AddSingleton<IMyBudgetServise, MyBudgetService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
