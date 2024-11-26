using Newtonsoft.Json;

namespace RPCNodeChecker.Models
{
    public class ArenaParticipant
    {

        [JsonProperty("rank")]
        public int rank { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("avatarAddr")]
        public string avatarAddr { get; set; }

        [JsonProperty("cp")]
        public int cp { get; set; }

        [JsonProperty("score")]
        public int score { get; set; }

        [JsonProperty("winScore")]
        public int winScore { get; set; }
   
    }
}
