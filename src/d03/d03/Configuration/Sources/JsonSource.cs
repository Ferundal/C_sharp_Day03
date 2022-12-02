using System.Collections;
using System.IO;
using System.Net.Http.Json;
using System.Text.Json;

namespace d03.Configuration.Sources
{
    public class JsonSource : Hashtable, IConfigurationSource
    {

        public static JsonSource GetFromFile(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<JsonSource>(jsonString);
        }

        public Hashtable Hashtable => this;
    }
}