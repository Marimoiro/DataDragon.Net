using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDragonSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataDragonNetTest
{
    class LoadRuneTest
    {
        [TestMethod]
        public void RuneTest()
        {
            DataDragonLoader dataDragonLoader = new DataDragonLoader("ddragon/8.19.1");
            var style = dataDragonLoader.LoadRune();

            var domination = style.Single(s => s.Key == "Domination");

            Assert.AreEqual(8100,domination.Id);

            Assert.AreEqual("https://ddragon.leagueoflegends.com/cdn/img/perk-images/Styles/7200_Domination.png",
                domination.GetIconUrl());


            var electrocute = domination.Runes[0].Single(r => r.Key == "Electrocute");

            Assert.AreEqual(8112, domination.Id);

            Assert.AreEqual("https://ddragon.leagueoflegends.com/cdn/img/perk-images/Styles/Domination/Electrocute/Electrocute.png",
                domination.GetIconUrl());

            Assert.AreEqual("Electrocute",electrocute.Name);
        }
    }
}
