using ConsoleApp1;
using System;
using System.Xml.Linq;

namespace YourNamespace
{
    class XmlFileReader : BaseFileReader
    {
        public override string SupportedFormat => "XML";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine(" -> Opening XML stream...");

            XDocument document = XDocument.Load(filePath);

            string xmlContent = document.ToString();

            Console.WriteLine($" -> Root element: <{document.Root.Name}> with {document.Descendants().Count()} descendant nodes.");

            Console.WriteLine("\n--- First 100 Characters ---");

            Console.WriteLine(
                xmlContent.Length > 100
                ? xmlContent.Substring(0, 100) + "..."
                : xmlContent
            );

            Console.WriteLine("----------------------------");
        }
    }
}