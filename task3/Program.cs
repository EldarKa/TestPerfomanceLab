using Newtonsoft.Json.Linq;
namespace task3
{
    ///dotnet run --project C:\...\task3 -- "C:\...\tests.json" "C:\...\values.json"  "C:\...\report.json"
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string testsJson = File.ReadAllText(args[0]);
                string valuesJson = File.ReadAllText(args[1]);

                JObject testsObj = JObject.Parse(testsJson);
                JObject valuesObj = JObject.Parse(valuesJson);

                JArray testsArray = (JArray)testsObj["tests"];
                JArray valuesArray = (JArray)valuesObj["values"];

                RecursionFun(testsArray, valuesArray);

                File.WriteAllText(args[2], testsObj.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e);
            }
        }

        static void RecursionFun(JArray tests, JArray values)
        {
            foreach (var testItem in tests)
            {
                JObject testObj = (JObject)testItem;
                long testId = testObj["id"].ToObject<long>();

                foreach (var valueItem in values)
                {
                    JObject valObj = (JObject)valueItem;
                    long valId = valObj["id"].ToObject<long>();

                    if (testId == valId)
                    {
                        testObj["value"] = valObj["value"];
                        break;
                    }
                }

                if (testObj["values"] is JArray nestedTests)
                {
                    RecursionFun(nestedTests, values);
                }
            }
        }
    }
}
