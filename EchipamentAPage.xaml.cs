using ProiectTry.Models;

namespace ProiectTry;

public partial class EchipamentAPage : ContentPage
{
    EchipamentAlpin sl;
    public EchipamentAPage(EchipamentAlpin slist)
    {
        InitializeComponent();
        sl = slist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e) { var echipament = (Echipament)BindingContext; await App.Database.SaveEchipamenttAAsync(echipament); listView.ItemsSource = await App.Database.GetEchipamentsAsync(); }
    async void OnDeleteButtonClicked(object sender, EventArgs e) { var echipament = (Echipament)BindingContext; await App.Database.DeleteEchipamentAAsync(echipament); listView.ItemsSource = await App.Database.GetEchipamentsAsync(); }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetEchipamentsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Echipament p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Echipament;
            var lp = new ListEchipament()
            {
                EchipamentAlpinID = sl.ID,
                EchipamentID = p.ID
            };
            await App.Database.SaveListEchipamentAsync(lp);
            p.ListEchipamente = new List<ListEchipament> { lp };
            await Navigation.PopAsync();
        }
    }
}