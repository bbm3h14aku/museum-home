using System.Collections;
using System.Collections.Generic;

namespace API
{
    [System.Serializable]
    public class Weather
    {
        public int id;
        public string main;
    }

    [System.Serializable]
    public class OpenWeather : APIObject
    {
        public int id;
        public string name;
        public List<Weather> weather;
    }
}