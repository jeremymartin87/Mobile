using Newtonsoft.Json;
using AppMobile.Models;

namespace AppMobile
{
    public class RoomsService
    {
        private readonly HttpClient _httpClient;

        public RoomsService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:5062/api/Rooms/");
        }

        public async Task<List<rooms>> GetRoomsByParcAsync(int parcId)
        {
            var response = await _httpClient.GetStringAsync($"byParc/{parcId}");
            return JsonConvert.DeserializeObject<List<rooms>>(response);
        }
    }

}

