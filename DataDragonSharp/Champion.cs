using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.SymbolStore;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataDragonSharp
{
    public class Champion
    {
        public string Id { get; set; }
        public int Key { get; set; }

        /// <summary>
        /// patch
        /// </summary>
        public string Version { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public Image Image { get; set; }

        public Skin[] Skins { get; set; }

        public string Lore { get; set; }

        public string Blurb { get; set; }
        public string[] AllyTips { get; set; }

        public string[] EnemyTips { get; set; }

        public Tag[] Tags { get; set; }

        public string ParType { get; set; }

        public Info Info { get; set; }
        public Stats Stats { get; set; }

        public Spell[] Spells { get; set; }
        public Passive Passive { get; set; }

        //TODO
        //public ItemSet[] Recommended { get; }


        
        public Champion() { }

        public Champion(JToken jo,string version)
        {
            var root = jo;

            Id = root["id"].ToObject<string>();
            Key = root["key"].ToObject<int>();
            Version = version;

            Name = root["name"].ToObject<string>();
            Title = root["title"].ToObject<string>();
            Lore = root["lore"]?.ToObject<string>();

            Blurb = root["blurb"].ToObject<string>();
            ParType = root["partype"].ToObject<string>();

            AllyTips = root["allytips"]?.ToObject<string[]>();
            EnemyTips = root["enemytips"]?.ToObject<string[]>();

            Skins = root["skins"]?.ToObject<Skin[]>();
            Tags = root["tags"].ToObject<Tag[]>();

            Info = root["info"].ToObject<Info>();
            Stats = root["stats"].ToObject<Stats>();

            Spells = root["spells"]?.ToObject<Spell[]>();
            Passive = root["passive"]?.ToObject<Passive>();

            Image = root["image"].ToObject<Image>();


            if (Passive != null)
            {
                Passive.Version = Version;
            }

            if (Skins != null)
            {
                foreach (var skin in Skins)
                {
                    skin.ChampionId = Id;
                }
            }

            if (Spells != null)
            {
                foreach (var spell in Spells)
                {
                    spell.Version = Version;
                }
            }
        }

        public string GetIconUrl()
        {
            return $"http://ddragon.leagueoflegends.com/cdn/{Version}/img/champion/{Image.Full}";
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this,Formatting.Indented);
        }
    }

    public class Skin
    {
        public int Id { get; set; }


        [JsonProperty("num")]
        public int Number { get; set; }

        public string Name { get; set; }

        [JsonProperty("chromas")]
        public bool HasChromas { get; set; }

        public string ChampionId { get; set; }

        public string GetLoadingScreenUrl()
        {
            return $"http://ddragon.leagueoflegends.com/cdn/img/champion/loading/{ChampionId}_{Number}.jpg";
        }

        public string GetSprashArtUrl()
        {
            return $"http://ddragon.leagueoflegends.com/cdn/img/champion/splash/{ChampionId}_{Number}.jpg";
        }
    }

    public enum Tag {
        None,
        Assassin,
        Support,
        Tank,
        Mage,
        Fighter,
        Marksman

    }

    public class Info
    {
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }
        public int Difficulty { get; set; }
    }

    public class Stats
    {
        public double Hp { get; set; }
        public double HpPerLevel { get; set; }
        public double Mp { get; set; }
        public double MpPerLevel { get; set; }
        public double MoveSpeed { get; set; }
        public double Armor { get; set; }
        public double ArmorPerLevel { get; set; }
        public double SpellBlock { get; set; }
        public double SpellBlockPerLevel { get; set; }
        public double AttackRange { get; set; }
        public double HpRegen { get; set; }
        public double HpRegenperLevel { get; set; }
        public double MpRegen { get; set; }
        public double MpRegenLevel { get; set; }
        public int Crit { get; set; }
        public double CritPerLevel { get; set; }
        public double AttackDamage { get; set; }
        public double AttackDamagePerLevel { get; set; }
        public double AttackSpeedOffset { get; set; }
        public double AttackSpeedPerLevel { get; set; }
    }

    public class Passive
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
        public string Version { get; set; }

        public string GetImageUrl(string patch)
        {
            return $"http://ddragon.leagueoflegends.com/cdn/{Version}/img/passive/{Image.Full}";
        }
    }

    public class Spell
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }

        public string Tooltip { get; set; }

        public LevelTip LevelTip { get; set; }
        public int MaxRank { get; set; }

        public double[] CoolDown { get; set; }
        public string CoolDownBurn { get; set; }


        public int[] CostDown { get; set; }
        public string CostDownBurn { get; set; }

        public double[][] Effect { get; set; }
        public string[] EffectBurn { get; set; }

        public Dictionary<string, Object>[] Vars{ get; set; }

        public string CostType { get; set; }

        public string Maxammo { get; set; }

        public double[] Range { get; set; }
        public string RangeBurn { get; set; }

        public string Resource { get; set; }
        public string Version { get; set; }

        public string GetImageUrl()
        {
            return $"http://ddragon.leagueoflegends.com/cdn/{Version}/img/spell/{Image.Full}";
        }

    }

    public class LevelTip
    {
        public string[] Label { get; set; }
        public string[] Effect { get; set; }
    }
}
