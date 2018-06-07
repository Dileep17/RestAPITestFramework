using NUnit.Framework;
using RestAPITestFrameWork.Lib;

namespace RestAPITestFrameWork.ServiceTests
{
    [TestFixture]
    public class MockTest
    {
        [SetUp]
        public void SetUp()
        {
            Mock.Start("MockTest.json");
        }

        [Test]
        public void MockTest1()
        {
            var response = new RestReq("http://localhost:1234")
                .Get("api/users/2")
                .Execute();
            Assert.AreEqual(200, (int)response.StatusCode);
            Assert.IsTrue(response.Content.Length > 0);
        }

        [TearDown]
        public void TearDown()
        {
            Mock.Stop();
        }
    }
}