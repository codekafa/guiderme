using Newtonsoft.Json;
using System;

namespace ServiceBuilderUI.Models
{
    public class ExceptionResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

    }
}
