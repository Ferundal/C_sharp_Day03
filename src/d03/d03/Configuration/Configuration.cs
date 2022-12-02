using System;
using System.Collections;
using System.Globalization;
using d03.Configuration.Sources;

namespace d03.Configuration
{
    public class Configuration
    {
        public Hashtable Params;
        
        public Configuration(IConfigurationSource configurationSource)
        {
            Params = configurationSource.Hashtable;
        }

        public Configuration AddLowPrioritySource(IConfigurationSource configurationSource)
        {
            foreach (DictionaryEntry dictionaryEntry in configurationSource.Hashtable)
            {
                if (!Params.ContainsKey(dictionaryEntry.Key))
                    Params.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            }
            return this;
        }

        public override string ToString()
        {
            var result = $"Configuration{Environment.NewLine}";
            foreach (DictionaryEntry dictionaryEntry in Params)
            {
                result += $"{dictionaryEntry.Key}: {dictionaryEntry.Value}{Environment.NewLine}";
            }
            return result;
        }
    }
}