using ProiectTry.Models;

namespace ProiectTry;

public partial class EchipamentEntryPage : ContentPage
{
	public EchipamentEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetEchipamentAlpinsAsync();
    }
    async void OnEchipamentAddedClicked(object sender, EventArgs e) { await Navigation.PushAsync(new EchipamentPage { BindingContext = new EchipamentAlpin() }); }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null) { await Navigation.PushAsync(new EchipamentPage { BindingContext = e.SelectedItem as EchipamentAlpin }); }
    }
}