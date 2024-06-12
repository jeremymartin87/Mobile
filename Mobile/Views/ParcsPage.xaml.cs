namespace AppMobile.Views;
using AppMobile.Models;

public partial class ParcsPage : ContentPage
{
    private readonly ParcsService _parcsService;

    public ParcsPage()
    {
        InitializeComponent();
        _parcsService = new ParcsService();
        LoadParcs();
        ParcsListView.ItemSelected += OnParcSelected;
    }

    private async void LoadParcs()
    {
        var parcs = await _parcsService.GetParcsAsync();

        if (parcs == null || !parcs.Any())
        {
            NoDataLabel.IsVisible = true;
            ParcsListView.IsVisible = false;
        }
        else
        {
            NoDataLabel.IsVisible = false;
            ParcsListView.IsVisible = true;
            ParcsListView.ItemsSource = parcs;
        }
    }

    private async void OnParcSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is parcs selectedParc)
        {
            await Navigation.PushAsync(new RoomsPage(selectedParc.id));
        }
    }
}
