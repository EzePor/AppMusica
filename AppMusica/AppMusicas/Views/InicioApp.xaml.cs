using AppMusicas.Modelos;
using AppMusicas.Repositories;

using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace AppMusicas.Views;

public partial class InicioApp : ContentPage
{
	public ObservableCollection<Musica> Musicas { get; set; }
   
	RepositoryMusicas repositoryMusicas = new RepositoryMusicas();
    private Musica musicaSeleccionada;

    public Musica MusicaSeleccionada
    {
        get { return musicaSeleccionada; }
        set
        {
            musicaSeleccionada = value;
            OnPropertyChanged(nameof(MusicaSeleccionada));
        }
    }

    public InicioApp()
	{
		InitializeComponent();
		
		Musicas = new ObservableCollection<Musica>();
        MusicasCollectionView.SelectionChanged += SeleccionarMusica;

    }

    public void SeleccionarMusica(object sender, SelectionChangedEventArgs e)
    {
       if (MusicasCollectionView != null)
		{
			MusicaSeleccionada = (Musica)MusicasCollectionView.SelectedItem;
		}
    }

    public async void GetAllMusicas(object sender, EventArgs e)
	{
		// trae los temas y las asigna 

		 Musicas =  await repositoryMusicas.GetAllAsync();

		MusicasCollectionView.ItemsSource = Musicas;
		
	}
	
    public void SeleccionarMusicaEnCollectionWiew(object sender, EventArgs e )
    {
        // recorremos los temas hasta encontrar la que coincide con el tema seleccionado, al encontrarlo la utilizaremos para indicar que es el SelectedItem del collectionWiew e interrumpiremos la iteración.

        if (MusicaSeleccionada != null)
        {
            foreach (var musica in Musicas)
            {
                if (musica._id == MusicaSeleccionada._id)
                {
                    MusicasCollectionView.SelectedItem = musica;
                    MusicasCollectionView.ScrollTo(musica, null, ScrollToPosition.Center, true);
                    break;
                }
            }
        }
    }

    //método! inicio de la página.. donde hacemos que carguen los temas con getAllMusicas..
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        //Debug.Print("<<<<<<<<<<<<<<<<Se ha cargado la pantalla que muestra la lista de los temas>>>>>>>>>>>>>>");
        NetworkAccess conexionInternet = Connectivity.Current.NetworkAccess;
		if(conexionInternet == NetworkAccess.Internet)
		{
           GetAllMusicas(this, EventArgs.Empty);
            SeleccionarMusicaEnCollectionWiew(this, EventArgs.Empty);
        }
		

    }

	protected override bool OnBackButtonPressed()
	{
		Debug.Print("<<<<<<<<<<<<<<<<Se ha pulsado el botón de atrás>>>>>>>>>>>>>>");
		return false;
	}

    protected override void OnDisappearing()
    {
		Debug.Print("<<<<<<<<<<Se ha cerrado la ventana de la lista de los temas musicales>>>>>>>>>>>");
    }

	public async void AbrirPaginaInicio(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new PaginaDeInicio());
	}

   

    public async void AgregarMusicaBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgregarMusica());
    }

    private async void EliminarMusicaBtn_Clicked(object sender, EventArgs e)
    {
		if (MusicaSeleccionada != null)
		{
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Eliminar", $"¿Está seguro que desea eliminar el tema musical:{MusicaSeleccionada.nombre}?","SI" ,"NO");
			if (respuesta)
			{


				var eliminado = await repositoryMusicas.RemoveAsync(MusicaSeleccionada._id);
				if (eliminado)
				{
                    await Application.Current.MainPage.DisplayAlert("Eliminar", $"¿Se ha eliminado la película:{MusicaSeleccionada.nombre}", "OK");
					GetAllMusicas(this, EventArgs.Empty);
                }
				
            }
        }
		else
		{
			await Application.Current.MainPage.DisplayAlert("Eliminar", "ERROR: Debe seleccionar el tema musical que desea borrar", "OK");
		}
    }


    private async void EditarMusicaBtn_Clicked(object sender, EventArgs e)
    {
		if (MusicaSeleccionada != null)
		{
            await Navigation.PushAsync(new EditarMusica(MusicaSeleccionada));
        }
		else
		{
			await Application.Current.MainPage.DisplayAlert("Editar", "ERROR: Debe seleccionar el tema musical que quiere editar", "OK");
		}
    }

    private async void VerVideoBtn_Clicked(object sender, EventArgs e)
    {
		if(MusicaSeleccionada != null)
		{
			await Navigation.PushAsync(new ReproductorVideo(MusicaSeleccionada.video_url));
		}
		else
		{
            await Application.Current.MainPage.DisplayAlert("Editar", "ERROR: Debe seleccionar el video musical que quiere reproducir ", "OK");
        }
    }

    private async void VerLetraBtn_Clicked(object sender, EventArgs e)
    {
        if (MusicaSeleccionada != null)
        {
            await Navigation.PushAsync(new VerLetra(MusicaSeleccionada.letra_cancion));
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Editar", "ERROR: Debe seleccionar la letra del tema que quiere ver ", "OK");
        }
    }
}