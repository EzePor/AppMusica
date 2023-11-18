using AppMusicas.Modelos;
using AppMusicas.Repositories;
using Newtonsoft.Json;
using System.Text;

namespace AppMusicas.Views;

public partial class EditarMusica : ContentPage
{
    RepositoryMusicas repositoryMusicas = new RepositoryMusicas();
    public Musica MusicaSeleccionada { get; }

    public EditarMusica()
	{
		InitializeComponent();
	}

    public EditarMusica(Musica musicaSeleccionada)
    {
        InitializeComponent();
        MusicaSeleccionada = musicaSeleccionada;
        CargarDatosEnPantalla();
    }

    private void CargarDatosEnPantalla()
    {
        txtNombre.Text = MusicaSeleccionada.nombre;
        txtArtista.Text = MusicaSeleccionada.artista;
        txtGenero.Text = MusicaSeleccionada.genero;
        txtPortadaUrl.Text = MusicaSeleccionada.portada_url;
        txtDuracion.Text = MusicaSeleccionada.duracion.ToString();
        txtVideoUrl.Text = MusicaSeleccionada.video_url;
        txtPistaUrl.Text = MusicaSeleccionada.pista_url;
        txtLetraCancion.Text = MusicaSeleccionada.letra_cancion.ToString();



    }

    private async void GuardarBtn_Clicked(object sender, EventArgs e)
    {
       

      

        Musica musicaEdidata = new Musica()
        {
            _id = MusicaSeleccionada._id,
            nombre = txtNombre.Text,
            artista = txtArtista.Text,
            genero = txtGenero.Text,
            portada_url = txtPortadaUrl.Text,
            duracion = Convert.ToInt32(txtDuracion.Text),
            video_url = txtVideoUrl.Text,
            pista_url = txtPistaUrl.Text,
            letra_cancion = txtLetraCancion.Text,
        };

        // enviamos por PUT el objeto que creamos a la URL de la API
        var guardada = await repositoryMusicas.UpdateAsync(musicaEdidata);

        //retorna el objeto que se agregó en la API ya con si ID generado por la base de datos

        

        if (guardada)
        {

            await DisplayAlert("¡ NOTIFICACIÓN !", "Música almacenada", "OK");
            await Navigation.PopAsync();
            
            
        }
    }

    private async void CancelarBtn_Clicked(object sender, EventArgs e)
    {
         await Navigation.PopAsync();
    }
}