using Firebase.Auth.Repository;
using Firebase.Auth;
using AppMusicas.Views;

namespace AppMusicas;

public partial class AppShell : Shell
{
    private FileUserRepository _userRepository;
    FirebaseAuthClient _clientAuth;

    public AppShell(FirebaseAuthClient firebaseAuthClient)
    {
        InitializeComponent();
        _userRepository = new FileUserRepository("Musica");
        _clientAuth = firebaseAuthClient;
    }

   

    private async void MenuItem_Clicked_1(object sender, EventArgs e)
    {
          _userRepository.DeleteUser();
        //con esta línea logramos salir del Shell y volver al inicio de sesión
        Application.Current.MainPage = new NavigationPage(new IniciarSesion(_clientAuth));    
    }
}