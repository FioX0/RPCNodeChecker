﻿using Newtonsoft.Json;

namespace RPCNodeChecker.Models
{
    public class ChainModel
    {

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("rpcaddress")]
        public string rpcaddress { get; set; }

        [JsonProperty("active")]
        public string active { get; set; }

        [JsonProperty("difference")]
        public string difference { get; set; }

        [JsonProperty("users")]
        public int users { get; set; }

        [JsonProperty("response_time_seconds")]
        public float response_time_seconds { get; set; }
    }
}
