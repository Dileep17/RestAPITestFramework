using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestAPITestFrameWork.Models;
using RestSharp;

namespace RestAPITestFrameWork.Lib
{
    class RestReq
    {
        private string _baseUrl;
        private string _endPoint;
        private RestClient _client;
        private RestRequest _request;

        public RestReq()
        {
            _client = new RestClient(YamlReader.GetValue(("Base_Url")));
        }

        public RestReq EndPoint(string endpoint)
        {
            _request = new RestRequest(endpoint);
            return this;
        }

        public RestReq AddHeader(string header, string value)
        {
            _request.AddHeader(header, value);
            return this;
        }

        public T Get<T>()
        {
            var response = _client.Execute(_request);
            T t = JsonConvert.DeserializeObject<T>(response.Content);
            return t;
        }

        public IRestResponse Get()
        {
            var response = _client.Execute(_request);
            return response;
        }


    }
}




/*
 * new Get().Endpoint().addHeader().addJsonBody().Execute()
 * 
 * 
 * new Get().Endpoint().addHeader().addJsonBody().Execute<Model>()
 * 
 * 
 */
