using System.Collections;

namespace d03.Configuration.Sources
{
    public interface IConfigurationSource
    {
        public Hashtable Hashtable { get; }
    }
}