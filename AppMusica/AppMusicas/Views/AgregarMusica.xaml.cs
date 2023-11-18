using AppMusicas.Modelos;
using AppMusicas.Repositories;
using Newtonsoft.Json;
using System.Text;

namespace AppMusicas.Views;

public partial class AgregarMusica : ContentPage   
{
    RepositoryMusicas repositoryMusicas = new RepositoryMusicas();
	public AgregarMusica()
	{
		InitializeComponent();
	}

    private async void GuardarBtn_Clicked(object sender, EventArgs e)
    {


        Musica nuevaMusica = new Musica()
        {
            nombre = txtNombre.Text,
            artista = txtArtista.Text,
            genero = txtGenero.Text,
            portada_url = txtPortadaUrl.Text,
            duracion = Convert.ToInt32(txtDuracion.Text),
            video_url = txtVideoUrl.Text,
            pista_url = txtPistaUrl.Text,
            letra_cancion = txtLetraCancion.Text,


        };

        // enviamos por POST el objeto que creamos a la URL de la API
        var agregada = await repositoryMusicas.AddAsync(nuevaMusica);

        //retorna el objeto que se agregó en la API ya con si ID generado por la base de datos


        if (agregada) {

            await DisplayAlert("¡ NOTIFICACIÓN !", "Se ha guardado el tema musical", "OK");
            await Navigation.PopAsync();
        }

    }

    private async void CancelarBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}