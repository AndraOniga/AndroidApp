using ProiectTry.Models;
namespace ProiectTry;

public partial class EchipamentPage : ContentPage
{
	public EchipamentPage()
	{
		InitializeComponent();
	}
    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Echipament echipament;
        var listechipament = (EchipamentAlpin)BindingContext;
        if (listView.SelectedItem != null)
        {
            echipament = listView.SelectedItem as Echipament; 

            var listProductAll = await App.Database.GetListEchipamente();
            var listProduct = listProductAll.FindAll(x => x.EchipamentID == echipament.ID & x.EchipamentAlpinID == listechipament.ID);
            await App.Database.DeleteListEchipamentAsync(listProduct.FirstOrDefault());
            await Navigation.PopAsync();
        }
    }
    async void OnSaveButtonClicked(object sender, EventArgs e) { var slist = (EchipamentAlpin)BindingContext; slist.Date = DateTime.UtcNow; await App.Database.SaveEchipamentAlpinAsync(slist); await Navigation.PopAsync(); }
	async void OnDeleteButtonClicked(object sender, EventArgs e) { var slist = (EchipamentAlpin)BindingContext; await App.Database.DeleteEchipamentAlpinAsync(slist); await Navigation.PopAsync(); }
	async void OnChooseButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EchipamentAPage((EchipamentAlpin)this.BindingContext) { BindingContext = new Echipament() });
	}
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (EchipamentAlpin)BindingContext;
        listView.ItemsSource = await App.Database.GetListEchipamentsAsync(shopl.ID);
    }
}