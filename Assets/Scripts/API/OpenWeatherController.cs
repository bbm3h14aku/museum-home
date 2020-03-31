using System;
using System.Net;
using System.IO;
using UnityEngine;

namespace API 
{
    public class OpenWeatherController
    {
        private const string API_KEY = "a9113d9eed556e9a4622ec9c8804343a";

        public static void GetWeather(string CityId)
        {
            APIClient client = new APIClient(String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}", CityId, API_KEY));
            string jsonResponse = client.Get();
            Debug.Log(jsonResponse);

            client = new APIClient("http://localhost/api/openweather.php");
            client.Post((APIObject) JsonUtility.FromJson<OpenWeather>(jsonResponse));
        }
    }
}