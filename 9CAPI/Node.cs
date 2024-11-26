using Newtonsoft.Json;
using RestSharp;
using RPCNodeChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RPCNodeChecker._9CAPI
{
    public class Node
    {
        public static async Task<List<ChainModel>> RPCNodesAsync()
        {
            try
            {
                var client = new RestClient("https://api.9capi.com/rpc");

                var request = new RestRequest();
                RestResponse response = client.Get(request);
                List<ChainModel> jsonobject = JsonConvert.DeserializeObject<List<ChainModel>>(response.Content);
                return jsonobject;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<string> SubmitNodeRequest(string node, string arenaProvider)
        {
            try
            {
                var client = new RestClient("https://api.9capi.com/rpcNodeChecker");

                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                var body = "{\"node\": \"" + node + "\",\"arenaProvider\": \"" + arenaProvider + "\",\"override\": \"\"}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                RestResponse response = client.ExecutePost(request);
                Console.WriteLine(response.Content);
                if (!response.Content.Contains("Unable to Connect to Website."))
                    return response.Content;
                else return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
