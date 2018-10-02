using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataDragonSharp
{
    public class DataDragonLoader
    {

        public string DataDragonPath { get; }
        public string Locale { get; }


        public string BasePath => $"{DataDragonPath}/data/{Locale}";
        public string ChampionBasePath => $"{BasePath}/champion";

        public DataDragonLoader(string dataDragonPath, string locale = "en_US")
        {
            DataDragonPath = dataDragonPath;
            Locale = locale;
        }


        public Champion LoadChampion(string championName)
        {
            var path = Path.Combine(ChampionBasePath, championName + ".json");
            return LoadChampionFromJson(File.ReadAllText(path));
        }

        public Champion LoadChampionFromJson(string json)
        {
            var jo = JObject.Parse(json);
            return new Champion(jo["data"].First.First,jo["version"].ToString());
        }

        public ChampionSet LoadChampionFullSet()
        {
            var path = Path.Combine(BasePath, "championFull.json");
            return LoadChampionSet(File.ReadAllText(path));
        }
        public ChampionSet LoadChampionSet()
        {
            var path = Path.Combine(BasePath, "champion.json");
            return LoadChampionSet(File.ReadAllText(path));
        }

        public ChampionSet LoadChampionSet(string json)
        {

            JObject jo = JObject.Parse(json);
            return new ChampionSet(jo);

        }

        public ItemSet LoadItemSet()
        {
            var path = Path.Combine(BasePath, "item.json");
            return LoadItemSet(File.ReadAllText(path));

        }

        public ItemSet LoadItemSet(string json)
        {
            return JsonConvert.DeserializeObject<ItemSet>(json);
        }


        public Style[] LoadRune()
        {
            var path = Path.Combine(BasePath, "runesReforged.json");
            return LoadRune(File.ReadAllText(path));

        }

        public Style[] LoadRune(string json)
        {
            return JsonConvert.DeserializeObject<Style[]>(json);
        }

        public SummonerSpellSet LoadSummonerSpellSet()
        {
            var path = Path.Combine(BasePath, "summoner.json");
            var set = LoadSummonerSpellSet(File.ReadAllText(path));
            set.AddVersion();
            return set;
        }

        public SummonerSpellSet LoadSummonerSpellSet(string json)
        {
            return JsonConvert.DeserializeObject<SummonerSpellSet>(json);
        }
    }
}
