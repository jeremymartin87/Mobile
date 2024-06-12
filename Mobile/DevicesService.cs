using Newtonsoft.Json;
using AppMobile.Models;

namespace AppMobile
{
    public class DevicesService
    {
        private readonly HttpClient _httpClient;

        public DevicesService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:5062/api/Devices/");
        }

        public async Task<List<Devices>> GetDevicesByRoomAsync(int roomId)
        {
            var response = await _httpClient.GetStringAsync($"byRoom/{roomId}");
            return JsonConvert.DeserializeObject<List<Devices>>(response);
        }
    }

}

