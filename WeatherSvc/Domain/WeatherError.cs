using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherSvc.Domain
{
    // {"success":false,"error":{"code":615,"type":"request_failed","info":"Your API request failed. Please try again or contact support."}}
    public class WeatherError
    {
        [JsonPropertyName("success")]
        public bool IsSuccess { get; set; }
        [JsonPropertyName("error")]
        public ErrorCode Error { get; set; }
    }
}
