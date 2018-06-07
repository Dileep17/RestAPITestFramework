using Newtonsoft.Json;
using RestSharp;

namespace RestAPITestFrameWork.Lib
{
    class RestReq
    {
        private readonly RestClient _client;
        private RestRequest _request;

        public RestReq(string url = null)
        {
            if (url == null)
                url = YamlReader.GetValue(("Base_url"));
            _client = new RestClient(url);
        }

        public RestReq Get(string endpoint)
        {
            _request = new RestRequest(endpoint, Method.GET);
            return this;
        }
        public RestReq Post(string endpoint)
        {
            _request = new RestRequest(endpoint, Method.POST);
            return this;
        }

        public RestReq Delete(string endpoint)
        {
            _request = new RestRequest(endpoint, Method.DELETE);
            return this;
        }

        public RestReq AddJsonBody(string jsonData)
        {
            _request.AddParameter("application/json", jsonData, ParameterType.RequestBody);
            return this;
        }

        public RestReq Param(string key, string value)
        {
            _request.AddParameter(key, value, ParameterType.UrlSegment);
            return this;
        }
        public RestReq AddHeader(string header, string value)
        {
            _request.AddHeader(header, value);
            return this;
        }

        public T Execute<T>()
        {

            var response = _client.Execute(_request);
            T t = JsonConvert.DeserializeObject<T>(response.Content);
            return t;
        }

        public IRestResponse Execute()
        {
            var response = _client.Execute(_request);
            return response;
        }



    }
}