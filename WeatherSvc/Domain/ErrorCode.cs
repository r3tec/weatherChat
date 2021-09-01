using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherSvc.Domain
{
    public class ErrorCode
    {
        // {"code":615,"type":"request_failed","info":"Your API request failed. Please try again or contact support."}
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("info")]
        public string Error { get; set; }

    }
}
