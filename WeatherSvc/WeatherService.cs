using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherSvc.Domain;

namespace WeatherSvc
{
    public class WeatherService
    {
        readonly WeatherApiConfig config;
        HttpClient httpClient;
        public WeatherService(IOptions<WeatherApiConfig> conf)
        {
            config = conf.Value;
        }

        void CreateClient()
        {
            // since this is a singleton we are not worried about concurrent creation
            if(httpClient == null)
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(config.BaseUrl);
            }
        }

        public async Task<WeatherResponse> GetWeather(string zip)
        {
            CreateClient();
            using (HttpResponseMessage response = await httpClient.GetAsync($"?access_key={config.ApiKey}&query={zip}"))
            {
                var str = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var result = JsonSerializer.Deserialize<WeatherError>(str);
                        if (result != null && result.Error != null)
                            throw new ApplicationException($"Weather service error: {result.Error.Code}, {result.Error.Error}");
                    }
                    catch { throw; }
                    return JsonSerializer.Deserialize<WeatherRequest>(str).Current;
                }
                throw new ApplicationException(str);
            }
        }
    }
}
