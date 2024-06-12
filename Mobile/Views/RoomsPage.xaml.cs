namespace Mobile.Views;
using Mobile.Models;

public partial class RoomsPage : ContentPage
{
    private readonly RoomsService _roomsService;
    private readonly int _parcId;

    public RoomsPage(int parcId)
    {
        InitializeComponent();
        _roomsService = new RoomsService();
        _parcId = parcId;
        LoadRooms();
        RoomsListView.ItemSelected += OnRoomSelected;
    }

    private async void LoadRooms()
    {
        var rooms = await _roomsService.GetRoomsByParcAsync(_parcId);

        if (rooms == null || !rooms.Any())
        {
            NoRoomsLabel.IsVisible = true;
            RoomsListView.IsVisible = false;
        }
        else
        {
            NoRoomsLabel.IsVisible = false;
            RoomsListView.IsVisible = true;
            RoomsListView.ItemsSource = rooms;
        }
    }

    private async void OnRoomSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is rooms selectedRoom)
        {
            await Navigation.PushAsync(new DevicesPage(selectedRoom.id));
        }
    }
}