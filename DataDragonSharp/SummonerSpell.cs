using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataDragonSharp
{
    public class SummonerSpell : Spell
    {
        public string[] Modes { get; set; }

        public int Key { get; set; }
    }

    public class SummonerSpellSet
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string,SummonerSpell> Data { get; set; }

        public Dictionary<int, SummonerSpell> KeyData => Data.ToDictionary(kv => kv.Value.Key, kv => kv.Value);

        public void AddVersion()
        {
            foreach (var spell in Data.Values)
            {
                spell.Version = Version;
            }
        }
    }
}
