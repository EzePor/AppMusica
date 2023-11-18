namespace AppMusicas.Views;

public partial class ReproductorVideo : ContentPage
{
	public ReproductorVideo(string Video_url)
	{
		InitializeComponent();
		ReproductorWebWiew.Source = Video_url;
	}
}