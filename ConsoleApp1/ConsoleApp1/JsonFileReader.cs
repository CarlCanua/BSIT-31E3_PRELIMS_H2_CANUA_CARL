using ConsoleApp1;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace YourNamespace
{
    class JsonFileReader : BaseFileReader
    {
        public override string SupportedFormat => "JSON";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine(" -> Opening JSON stream...");

            string json = File.ReadAllText(filePath);

            using JsonDocument document = JsonDocument.Parse(json);

            int count = 0;

            if (document.RootElement.ValueKind == JsonValueKind.Object)
            {
                count = document.RootElement.EnumerateObject().Count();
                Console.WriteLine($" -> Parsed {count} root properties.");
            }
            else if (document.RootElement.ValueKind == JsonValueKind.Array)
            {
                count = document.RootElement.EnumerateArray().Count();
                Console.WriteLine($" -> Parsed {count} array elements.");
            }

            Console.WriteLine("\n--- First 100 Characters ---");

            Console.WriteLine(
                json.Length > 100
                ? json.Substring(0, 100) + "..."
                : json
            );

            Console.WriteLine("----------------------------");
        }
    }
}