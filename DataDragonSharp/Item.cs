using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DataDragonSharp
{

    public class Gold
    {
        [JsonProperty("base")]
        public int BaseGold { get; set; }
        public bool Purchasable { get; set; }
        public int Total { get; set; }
        public int Sell { get; set; }
    }


    public class ItemStats
    {
        public int FlatHPPoolMod { get; set; }
        public int FlatMPPoolMod { get; set; }
        public double PercentHPPoolMod { get; set; }
        public double PercentMPPoolMod { get; set; }
        public double FlatHPRegenMod { get; set; }
        public int PercentHPRegenMod { get; set; }
        public double FlatMPRegenMod { get; set; }
        public int FlatArmorMod { get; set; }
        public double PercentArmorMod { get; set; }
        public int FlatPhysicalDamageMod { get; set; }
        public double PercentPhysicalDamageMod { get; set; }
        public int FlatMagicDamageMod { get; set; }
        public double PercentMagicDamageMod { get; set; }
        public int FlatMovementSpeedMod { get; set; }
        public double PercentMovementSpeedMod { get; set; }
        public int FlatAttackSpeedMod { get; set; }
        public double PercentAttackSpeedMod { get; set; }
        public int PercentDodgeMod { get; set; }
        public double FlatCritChanceMod { get; set; }
        public double PercentCritChanceMod { get; set; }
        public int FlatCritDamageMod { get; set; }
        public double PercentCritDamageMod { get; set; }
        public int FlatBlockMod { get; set; }
        public double PercentBlockMod { get; set; }
        public int FlatSpellBlockMod { get; set; }
        public double PercentSpellBlockMod { get; set; }
        public int FlatEXPBonus { get; set; }
        public double PercentEXPBonus { get; set; }
        public int FlatEnergyRegenMod { get; set; }
        public int FlatEnergyPoolMod { get; set; }
        public double PercentLifeStealMod { get; set; }
        public int PercentSpellVampMod { get; set; }
    }


    public class Item
    {
        public string Name { get; set; }

        public string Version { get; set; }
        public string Description { get; set; }
        public string Colloq { get; set; }
        public string Plaintext { get; set; }
        public string[] Into { get; set; }
        public Image Image { get; set; }
        public Gold Gold { get; set; }
        public string[] Tags { get; set; }
        public Dictionary<string,bool> Maps { get; set; }
        public ItemStats Stats { get; set; }

        public string GetImageUrl()
        {
            return $"http://ddragon.leagueoflegends.com/cdn/{Version}/img/item/{Image.Full}";
        }
    }

    public class ItemGroup
    {
        public string Id { get; set; }
        public string MaxGroupOwnable { get; set; }

        public int MaxGroupOwnableCount => Int32.Parse(MaxGroupOwnable);
    }

    public class TreeItem
    {
        public string Header { get; set; }
        public string[] Tags { get; set; }
    }

    public class ItemSet
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string,Item> Data { get; set; }
        public ItemGroup[] Groups { get; set; }
        public TreeItem[] Tree { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this,Formatting.Indented);
        }

        public void AddVersion()
        {
            foreach (var item in Data.Values)
            {
                item.Version = Version;
            }
        }
    }
}
