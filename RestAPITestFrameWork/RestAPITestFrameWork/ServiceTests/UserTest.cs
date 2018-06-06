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
            Assert.IsTrue(userData.Equals(expectedUserData), "verifying exprcted user is same as actual user returned by API");
        }

        [SetUp]
        public void SetUp()
        {
            YamlReader.Load("QA");
        }

        [Test]
        public void GetSingleUserTestWithRestReqLib()
        {
            UserData expectedUserData = new UserData(2, "Janet", "Weaver", new Uri("https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg"));
            IRestResponse response = new RestReq()
                .EndPoint(YamlReader.GetValue("Single_user"))
                .Param("id","2")
                .Get();
            UserData actualUserData = JsonConvert.DeserializeObject<UserData>(response.Content);
            Assert.IsTrue(expectedUserData.Equals(actualUserData));
            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Test]
        public void GetSingleUserTestWithRestReqLibDeserialized()
        {
            UserData expectedUserData = new UserData(2, "Janet", "Weaver", new Uri("https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg"));
            UserData actualUserData = new RestReq().EndPoint(YamlReader.GetValue("Single_user")).Param("id", "2").Get<UserData>();
            Assert.IsTrue(expectedUserData.Equals(actualUserData));
        }
    }
}