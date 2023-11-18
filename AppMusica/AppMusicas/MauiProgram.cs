using Firebase.Auth.Providers;
using Firebase.Auth;
using Microsoft.Extensions.Logging;

namespace AppMusicas;

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
				fonts.AddFont("BebasNeue-Regular.ttf", "Bbn-regular");
				fonts.AddFont("Oswald-VariableFont_wght.ttf", "Oswald");
                fonts.AddFont("SignikaNegative-VariableFont_wght.ttf", "Signika");
                fonts.AddFont("Ubuntu-Medium.ttf", "Ubuntu-media");
				fonts.AddFont("Kanit-Bold", "Kanit-Bold");

            });
		   // autenticación apikey en firebase
        builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
        {
            ApiKey = "AIzaSyAJu02w6o9rVt0aau1BjkQMsWyh_sgnRa4",
            AuthDomain = "fir-autenticacion-dc174.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
              {
                new EmailProvider(),
               }
        }));

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
