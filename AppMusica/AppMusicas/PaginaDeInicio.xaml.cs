using AppMusicas.Modelos;
using AppMusicas.Repositories;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AppMusicas.Views;

public partial class PaginaDeInicio : ContentPage
{
    public ObservableCollection<Musica> Musicas { get; set; } = new();
   
   
    
    public PaginaDeInicio()
    {
        InitializeComponent();
        BindingContext = this;
       
        Musicas= new ObservableCollection<Musica>();

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