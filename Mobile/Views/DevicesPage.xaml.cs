namespace AppMobile.Views;

public partial class DevicesPage : ContentPage
{
    private readonly DevicesService _devicesService;
    private readonly int _roomId;
    public DevicesPage(int roomId)
	{
        InitializeComponent();
        _devicesService = new DevicesService();
        _roomId = roomId;
        LoadDevices();
    }

    private async void LoadDevices()
    {
        var devices = await _devicesService.GetDevicesByRoomAsync(_roomId);

        if (devices == null || !devices.Any())
        {
            NoDevicesLabel.IsVisible = true;
            DevicesListView.IsVisible = false;
        }
        else
        {
            NoDevicesLabel.IsVisible = false;
            DevicesListView.IsVisible = true;
            DevicesListView.ItemsSource = devices;
        }
    }
}
