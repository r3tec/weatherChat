using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherSvc.Domain
{
    /*
    {   "request":{"type":"Zipcode","query":"30076","language":"en","unit":"m"},
        "location":{"name":"Roswell","country":"USA","region":"Georgia","lat":"34.026","lon":"-84.312","timezone_id":"America\/New_York","localtime":"2021-09-01 12:31","localtime_epoch":1630499460,"utc_offset":"-4.0"},
        "current":{
        "observation_time":"04:31 PM",
        "temperature":27,
        "weather_code":116,
        "weather_icons":["https:\/\/assets.weatherstack.com\/images\/wsymbols01_png_64\/wsymbol_0002_sunny_intervals.png"],"weather_descriptions":["Partly cloudy"],
        "wind_speed":26,"wind_degree":300,"wind_dir":"WNW","pressure":1009,
        "precip":0,"humidity":64,"cloudcover":50,"feelslike":31,
        "uv_index":5,"visibility":16,"is_day":"yes"}
    }
    */
    public class WeatherResponse
    {
        [JsonPropertyName("temperature")]
        public int Temperature { get; set; }
        [JsonPropertyName("precip")]
        public float Precipitation { get; set; }
        [JsonPropertyName("uv_index")]
        public int UvIndex { get; set; }
        [JsonPropertyName("wind_speed")]
        public int WindSpeed { get; set; }

        public override string ToString()
        {
            return $"Wind {WindSpeed}, Uv: {UvIndex}, Precip: {Precipitation}, Temp: {Temperature}";
        }
    }
}
