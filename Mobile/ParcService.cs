using Newtonsoft.Json;
using AppMobile.Models;

namespace AppMobile
{
    public class ParcsService
    {
        private readonly HttpClient _httpClient;

        public ParcsService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:5062/api/Parcs/");
        }

        public async Task<List<parcs>> GetParcsAsync()
        {
            var response = await _httpClient.GetStringAsync("");
            return JsonConvert.DeserializeObject<List<parcs>>(response);
        }

        public async Task<parcs> GetParcsAsync(int id)
        {
            var response = await _httpClient.GetStringAsync(id.ToString());
            return JsonConvert.DeserializeObject<parcs>(response);
        }
    }
}

