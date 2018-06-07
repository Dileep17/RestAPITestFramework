

//Contract testing using manatee.json

using System;
using System.Collections.Generic;
using System.IO;
using Manatee.Json;
using Manatee.Json.Schema;
using NUnit.Framework;

namespace RestAPITestFrameWork.ServiceTests
{
    [TestFixture]
    public class UserContract
    {
        [Test]
        public void Test()
        {
            string text = File.ReadAllText(@"\\vmware-host\Shared Folders\Desktop\myjson.txt");
            var data = JsonValue.Parse(text);
            var schema = new JsonSchema06
            {
                Type = JsonSchemaType.String | JsonSchemaType.Object,
                Properties = new Dictionary<string, IJsonSchema>
                {
                    ["remaining"] = new JsonSchema06
                    {
                        Type = JsonSchemaType.Integer
                    },
                    ["shuffled"] = new JsonSchema06
                    {
                        Type = JsonSchemaType.Boolean
                    },
                    ["success"] = new JsonSchema06
                    {
                        Type = JsonSchemaType.Boolean
                    },
                    ["deck_id"] = new JsonSchema06
                    {
                        Type = JsonSchemaType.String
                    }
                }
            };
            var errors = schema.Validate(data);
            Console.WriteLine("Final output = " + errors.Valid);
            foreach (var error in errors.Errors)
            {
                Console.WriteLine(error.PropertyName + "  -- " + error.Message);
            }
            Console.WriteLine("heman");
        }

    }
}
