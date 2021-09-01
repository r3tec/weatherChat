using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherSvc.Domain
{
    public class WeatherRequest
    {
        [JsonPropertyName("current")]
        public WeatherResponse Current { get; set; }

    }
}
