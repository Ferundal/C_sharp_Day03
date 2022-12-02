using System;
using System.Collections.Generic;
using System.IO;
using d03.Configuration;
using d03.Configuration.Sources;

var keyValuePairs = new List<KeyValuePair<string, int>>();
if (args.Length == 1)
{
    keyValuePairs.Add(new KeyValuePair<string, int>(args[0], 0));
}
else
{
    if (args.Length  != 4)
    {
        Console.WriteLine("Expecting input:\"{jsonPath}\" {jsonPriority} \"{yamlPath}\" {yamlPriority}}");
        return;
    }
}

var jsonPath = args[0];
var yamlPath = args[2];
if (!File.Exists(jsonPath) || !File.Exists(yamlPath))
{
    Console.WriteLine("Can't found file");
    return;
}

if (!int.TryParse(args[1], out var jsonPriority) || !int.TryParse(args[3], out var yamlPriority))
{
    Console.WriteLine("Priority should be integer");
    return;
}

IConfigurationSource mainConfigurationSource;
IConfigurationSource secondaryConfigurationSource;
try
{
    mainConfigurationSource = JsonSource.GetFromFile(jsonPath);
    secondaryConfigurationSource = YamlSource.GetFromFile(yamlPath);
}
catch (Exception e)
{
    Console.WriteLine("Invalid data. Check your config files and try again.");
    return;
}

if (jsonPriority < yamlPriority)
{
    (mainConfigurationSource, secondaryConfigurationSource) = (secondaryConfigurationSource, mainConfigurationSource);
}
Configuration configuration = new Configuration(mainConfigurationSource).AddLowPrioritySource(secondaryConfigurationSource);
Console.WriteLine(configuration);