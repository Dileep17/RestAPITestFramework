using System;
using Newtonsoft.Json;
using NUnit.Framework;
using RestAPITestFrameWork.Lib;
using RestAPITestFrameWork.Models;
using RestSharp;

namespace RestAPITestFrameWork.ServiceTests
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void GetSingleUserTestWithRestSharp()
        {
            UserData expectedUserData = new UserData(2, "Janet", "Weaver", new Uri("https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg"));
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("api/users/{id}", Method.GET);
            request.AddParameter("id", 2, ParameterType.UrlSegment);
            IRestResponse response = client.Execute(request);
            UserData userData = JsonConvert.DeserializeObject<UserData>(response.Content);
            Assert.IsTrue(userData.Equals(expectedUserData), "verifying expected user is same as actual user returned by API");
        }

        [Test]
        public void GetSingleUserTestWithRestReqLib()
        {
            UserData expectedUserData = new UserData(2, "Janet", "Weaver", new Uri("https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg"));
            IRestResponse response = new RestReq()
                .Get(YamlReader.GetValue("Single_user"))
                .Param("id","2")
                .Execute();
            UserData actualUserData = JsonConvert.DeserializeObject<UserData>(response.Content);
            Assert.IsTrue(expectedUserData.Equals(actualUserData));
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Test]
        public void GetSingleUserTestWithRestReqLibDeserialized()
        {
            UserData expectedUserData = new UserData(2, "Janet", "Weaver", new Uri("https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg"));
            UserData actualUserData = new RestReq().Get(YamlReader.GetValue("Single_user")).Param("id", "2").Execute<UserData>();
            Assert.IsTrue(expectedUserData.Equals(actualUserData));
        }

        [Test]
        public void CreateUserTest()
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("api/users", Method.POST);
            request.AddParameter("{\"name\":\"morpheus\",\"job\": \"leader\"}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }


        [Test]
        public void CreateUserTestRestReq()
        {
            IRestResponse response = new RestReq()
                .Post("api/users")
                .AddJsonBody("{'name':'morpheus','job': 'leader'}")
                .Execute();
            Console.WriteLine(response.Content);

        }

    }
}