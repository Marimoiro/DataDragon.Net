using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DataDragonSharp
{
    public class ChampionSet
    {
        public string Type { get; set; }
        public string Format { get; set; }

        public string Version { get; set; }
        public Dictionary<string,Champion> Data { get; set; }
        public Dictionary<int, string> Keys { get; set; }

        private Dictionary<int, Champion> keyData;
        public Dictionary<int, Champion> KeyData => keyData ?? (keyData = Data.ToDictionary(kv => kv.Value.Key, kv => kv.Value));

        public ChampionSet(JToken jo)
        { 
            Type = jo["type"].ToObject<string>();
            Format = jo["format"].ToObject<string>();
            Version = jo["version"].ToObject<string>();
            Keys = jo["keys"]?.ToObject<Dictionary<int, string>>();
            Data = jo["data"].OfType<JProperty>().ToDictionary( p=> p.Name,p=> new Champion(p.Value, Version));

        }

    }
}