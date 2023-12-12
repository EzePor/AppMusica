namespace AppMusicas.Views;

public partial class ReproducirTema : ContentPage
{

    public ReproducirTema(string pista_url)
	{
		InitializeComponent();
        ReproductorWebWiew.Source = pista_url;
       
    }

    private async void VolverBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}