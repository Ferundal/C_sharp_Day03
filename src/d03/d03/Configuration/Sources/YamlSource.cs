using System.Collections;
using System.IO;
using System.Text.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace d03.Configuration.Sources
{
    public class YamlSource : Hashtable, IConfigurationSource
    {

        public static YamlSource GetFromFile(string filePath)
        {
            var yamlString = File.ReadAllText(filePath);
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            return deserializer.Deserialize<YamlSource>(yamlString);
        }

        public Hashtable Hashtable => this;
    }
}