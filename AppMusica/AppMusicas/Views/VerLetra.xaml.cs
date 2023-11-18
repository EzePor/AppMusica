namespace AppMusicas.Views;

public partial class VerLetra : ContentPage
{
	public VerLetra(string letra_cancion)
	{
		InitializeComponent();
		MostrarLetra.Text = letra_cancion;
		
	}
}

