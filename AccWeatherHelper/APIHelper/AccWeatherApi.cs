using AccWeatherHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AccWeatherHelper.APIHelper
{
    public class AccWeatherApi
    {
        private static readonly string API_KEY = Environment.GetEnvironmentVariable("AccWeather:KEY");
        private static readonly string BaseUrl = @"http://dataservice.accuweather.com/";
        private static string AutoCompleteEndPoint = @"locations/v1/cities/autocomplete/apikey={0}&Q={1}";
        private static string CurrentConditionsEndPoint = @"currentconditions/v1/{0}/apikey={1}";

        public static async Task<List<City>> GetCitiesAsync(string query)
        {
            List<City> cities = new();

            string url = $"{BaseUrl}{string.Format(AutoCompleteEndPoint, API_KEY, query)}";

            using (HttpClient httpClient = new())
            {
                var response = await httpClient.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditionsAsync(string citykey)
        {
            CurrentConditions currentConditions = new();

            string url = $"{BaseUrl}{string.Format(CurrentConditionsEndPoint, citykey, API_KEY)}";

            using (HttpClient httpClient = new())
            {
                var response = await httpClient.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                currentConditions = JsonConvert
                    .DeserializeObject<List<CurrentConditions>>(json)
                    .FirstOrDefault();
            }

            return currentConditions;
        }
    }
}
