﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoolBreeze.Helpers
{
    public class WeatherHelper
    {
        public static async Task<WeatherInformation> GetCurrentConditionsAsync(string cityName, string countryCode)
        {
            string url = $"http://traininglabservices.azurewebsites.net/api/weather/current/city?cityName={cityName}&countryCode={countryCode}&registrationCode={App.RegistrationCode}";
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherInformation>(response);
            return result;

        }
        public static async Task<WeatherInformation> GetCurrentConditionsAsync(double latitude, double longitude)
        {
            string url = $"http://traininglabservices.azurewebsites.net/api/weather/current?latitude={latitude}&longitude={longitude}&registrationCode={App.RegistrationCode}";
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherInformation>(response);
            return result;
        }
    }
}