using System;
using Newtonsoft.Json;
using NUnit.Framework;
using RestAPITestFrameWork.Models;
using RestSharp;

namespace RestAPITestFrameWork.ServiceTests
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void SingleUserTest()
        {
            UserData expectedUserData = new UserData(2, "Janet", "Weaver", new Uri("https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg"));
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("api/users/2", Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            UserData userData = JsonConvert.DeserializeObject<UserData>(response.Content);
            Assert.IsTrue(userData.Equals(expectedUserData), "verifying exprcted user is same as actual user returned by API");
            Console.WriteLine("heman");
        }
    }
}