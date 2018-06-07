using NUnit.Framework;
using RestAPITestFrameWork.Lib;

namespace RestAPITestFrameWork.ServiceTests
{
    [SetUpFixture]
    public class ServiceTestSetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUpForServiceTests()
        {
            YamlReader.Load("QA");
        }

        [OneTimeTearDown]
        public void OneTimeTearDownForServiceTests()
        {
            
        }
    }
}