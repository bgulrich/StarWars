using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.ApiClient.Models
{
    public abstract class ModelBase 
    {
        [JsonProperty("url")]
        public Uri Uri { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
