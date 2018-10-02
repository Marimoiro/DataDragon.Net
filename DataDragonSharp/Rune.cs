using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataDragonSharp
{
    public class Style
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }

        public Slot[] Slots { get; set; }

        public Rune[][] Runes => Slots.Select(s => s.Runes).ToArray();

        public string GetIconUrl()
        {
            return $"https://ddragon.leagueoflegends.com/cdn/img/{Icon}";
        }
    }

    public class Slot
    {
        public Rune[] Runes { get; set; }
    }

    public class Rune
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }

        public string GetIconUrl()
        {
            return $"https://ddragon.leagueoflegends.com/cdn/img/{Icon}";
        }
    }
}
