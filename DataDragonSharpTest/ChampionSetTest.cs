using System;
using DataDragonSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataDragonNetTest
{
    [TestClass]
    public class ChampionSetTest
    {

        [TestMethod]
        public void LoadChampionFullSet()
        {
            DataDragonLoader dataDragonLoader = new DataDragonLoader("ddragon/8.19.1");
            var data = dataDragonLoader.LoadChampionFullSet();

            var akali = data.Data["Akali"];

            ChampionTest.TestAkali(akali);
        }

        [TestMethod]
        public void LoadChampionSet()
        {
            DataDragonLoader dataDragonLoader = new DataDragonLoader("ddragon/8.19.1");
            var data = dataDragonLoader.LoadChampionSet();

            Assert.AreEqual(null,data.Keys);

            var akali = data.Data["Akali"];

            // their properties are null
            Assert.AreEqual(null,akali.Skins);
            Assert.AreEqual(null,akali.Spells);
            Assert.AreEqual(null,akali.Passive);
            Assert.AreEqual(null,akali.Lore);
            Assert.AreEqual(null,akali.AllyTips);
            Assert.AreEqual(null,akali.EnemyTips);


            Assert.AreEqual("Akali", akali.Id);
            Assert.AreEqual(84, akali.Key);
            Assert.AreEqual("Akali", akali.Name);

            Assert.AreEqual("http://ddragon.leagueoflegends.com/cdn/8.19.1/img/champion/Akali.png",
                akali.GetIconUrl());

            Assert.AreEqual(1, akali.Tags.Length);
            Assert.AreEqual(Tag.Assassin, akali.Tags[0]);
            Assert.AreEqual(7, akali.Info.Difficulty);


            Assert.AreEqual(1.25, akali.Stats.SpellBlockPerLevel);
            Assert.AreEqual(125, akali.Stats.AttackRange);
        }

    }
}
