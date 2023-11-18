using AppMusicas.Modelos;
using System.Collections.ObjectModel;

namespace AppMusicas;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Musica> Musicas { get; set; }
    int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

