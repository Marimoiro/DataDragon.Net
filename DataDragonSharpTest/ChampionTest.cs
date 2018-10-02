using System;
using System.Threading.Tasks;
using DataDragonSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataDragonNetTest
{
    [TestClass]
    public class ChampionTest
    {
        [TestMethod]
        public void LoadChampion()
        {
            DataDragonLoader dataDragonLoader = new DataDragonLoader("ddragon/8.19.1");
            var akali = dataDragonLoader.LoadChampion("Akali");

            TestAkali(akali);
        }

        [TestMethod]
        public async Task RequestChampion()
        {
            using (var client = new DataDragonClient("8.19.1"))
            {
                var akali = await client.RequestChampionAsync("Akali");

                TestAkali(akali);
            }
        }

        [TestMethod]
        public void LoadChampionSetWithKey()
        {
            DataDragonLoader dataDragonLoader = new DataDragonLoader("ddragon/8.19.1");
            var data = dataDragonLoader.LoadChampionFullSet();

            var akali = data.KeyData[84];

            TestAkali(akali);
        }


        public static void TestAkali(Champion akali)
        {
            Assert.AreEqual("Akali", akali.Id);
            Assert.AreEqual(84, akali.Key);
            Assert.AreEqual("Akali", akali.Name);

            Assert.AreEqual("http://ddragon.leagueoflegends.com/cdn/8.19.1/img/champion/Akali.png",
                akali.GetIconUrl());

            //Skins
            Assert.AreEqual("Stinger Akali", akali.Skins[1].Name);
            Assert.AreEqual("http://ddragon.leagueoflegends.com/cdn/img/champion/loading/Akali_1.jpg",
                akali.Skins[1].GetLoadingScreenUrl());
            Assert.AreEqual(true, akali.Skins[7].HasChromas);


            var blurb = akali.Blurb.StartsWith("Abandoning the Kinkou");
            Assert.IsTrue(blurb);

            Assert.AreEqual(1, akali.Tags.Length);
            Assert.AreEqual(Tag.Assassin, akali.Tags[0]);

            Assert.AreEqual(7, akali.Info.Difficulty);


            Assert.AreEqual(1.25, akali.Stats.SpellBlockPerLevel);
            Assert.AreEqual(125, akali.Stats.AttackRange);
        }

        [TestMethod]
        public void LoadChampionJa()
        {
            DataDragonLoader dataDragonLoader = new DataDragonLoader("ddragon/8.19.1", "ja_JP");
            var akali = dataDragonLoader.LoadChampion("Akali");

            TestAkaliJa(akali);
        }

        [TestMethod]
        public async Task RequestChampionJa()
        {
            using (var client = new DataDragonClient("8.19.1", "ja_JP"))
            {
                var akali = await client.RequestChampionAsync("Akali");

                TestAkaliJa(akali);
            }
        }


        private void TestAkaliJa(Champion akali)
        {
            Assert.AreEqual("Akali", akali.Id);
            Assert.AreEqual(84, akali.Key);
            Assert.AreEqual("アカリ", akali.Name);
            Assert.AreEqual("主なき暗殺者", akali.Title);

            Assert.AreEqual("http://ddragon.leagueoflegends.com/cdn/8.19.1/img/champion/Akali.png",
                akali.GetIconUrl());

            //Skins
            Assert.AreEqual("ブラッドムーン アカリ", akali.Skins[5].Name);
            Assert.AreEqual("http://ddragon.leagueoflegends.com/cdn/img/champion/loading/Akali_1.jpg",
                akali.Skins[1].GetLoadingScreenUrl());


            var blurb = akali.Blurb.StartsWith("「均衡の守人」であることをやめ、「影の拳」という立場も捨てたアカリ");
            Assert.IsTrue(blurb);
        }


    }
}
