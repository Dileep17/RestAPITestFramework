using System.IO;

namespace RestAPITestFrameWork.Lib
{
    class Mock
    {
        public static void Start(string fileName)
        {
            var path = System.AppDomain.CurrentDomain.BaseDirectory + "Mocks\\" + fileName;
            var imposter = File.ReadAllText(path);
            new RestReq(YamlReader.GetValue("Mountebank"))
                .Post("imposters")
                .AddHeader("Content-Type", "application/json")
                .AddJsonBody(imposter)
                .Execute();
        }

        public static void Stop()
        {
            new RestReq(YamlReader.GetValue("Mountebank"))
                .Delete("imposters")
                .Execute();
        }

    }
}
