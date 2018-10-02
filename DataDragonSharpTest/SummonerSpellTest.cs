using System;
using System.Text;
using System.Collections.Generic;
using DataDragonSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataDragonNetTest
{
    /// <summary>
    /// SummonerSpell の概要の説明
    /// </summary>
    [TestClass]
    public class SummonerSpellTest
    {
        [TestMethod]
        public void LoadSummonerSpell()
        {
            DataDragonLoader dataDragonLoader = new DataDragonLoader("ddragon/8.19.1");
            var spells = dataDragonLoader.LoadSummonerSpellSet();

            var barrier = spells.Data["SummonerBarrier"];

            Assert.AreEqual("Barrier",barrier.Name);

            var ttip = barrier.Tooltip.StartsWith("Temporarily shields");
            Assert.IsTrue(ttip);

            Assert.AreEqual("180",barrier.CoolDownBurn);

            Assert.AreEqual("http://ddragon.leagueoflegends.com/cdn/8.19.1/img/spell/SummonerBarrier.png",
                barrier.GetImageUrl());
        }
    }
}
