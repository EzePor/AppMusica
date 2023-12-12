using AppMusicas.Modelos;
using AppMusicas.Repositories;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AppMusicas.Views;

public partial class PaginaDeInicio : ContentPage
{
    public ObservableCollection<Musica> Musicas { get; set; } = new();
    RepositoryMusicas repositoryMusicas = new RepositoryMusicas();



    public PaginaDeInicio()
    {
        InitializeComponent();
        BindingContext = this;
       
        Musicas= new ObservableCollection<Musica>();


        GetAllMusicas(this, EventArgs.Empty);



    }

    public async void GetAllMusicas(object sender, EventArgs e)
    {
        // trae los temas y las asigna 

        Musicas = await repositoryMusicas.GetAllAsync();

        carouselView.ItemsSource = Musicas;

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }



    private async void VolverBtn_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    
}