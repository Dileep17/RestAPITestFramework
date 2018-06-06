using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace RestAPITestFrameWork.Lib
{
    class EndPoints
    {
        public Dictionary<string, Dictionary<string, string>> end_points { get; set; }
    }

    class YamlReader
    {
        private static EndPoints _endPoints;
        private static string _environment;
        public static void load(string environment)
        {
            _environment = environment;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "RestConfig.yml";

            using (var reader = new StreamReader(path))
            {
                var d = new Deserializer();
                _endPoints = d.Deserialize<EndPoints>(reader);
            }
        }

        public static string GetValue(string key)
        {
            return _endPoints.end_points[_environment][key];
        }
    }
}
