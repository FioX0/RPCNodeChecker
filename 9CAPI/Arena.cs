using Newtonsoft.Json.Linq;
using RestSharp;
using RPCNodeChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RPCNodeChecker._9CAPI
{
    public class Arena
    {
        public static async Task<bool> ArenaParticipants(int chain, string address, string agent)
        {
            try
            {
                string url = "https://api.9capi.com/arenaParticipantsOdin";
                if (chain == 1)
                    url = "https://api.9capi.com/arenaParticipantsHeimdall";

                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                var body = "{\"agent\": \"" + agent + "\",\"avatar\": \"" + address + "\",\"override\": \"\"}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                RestResponse response = client.ExecutePost(request);
                JArray joResponse = JArray.Parse(response.Content);

                if (joResponse.Count() > 1)
                    return true;

                return false;
            }
            catch (Exception e) { return false; }
        }
    }
}
