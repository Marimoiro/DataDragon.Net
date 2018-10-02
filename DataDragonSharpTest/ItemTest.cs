using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDragonSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataDragonNetTest
{
    class LoadItemTests
    {
        [TestMethod]
        public void ItemTest()
        {
            DataDragonLoader dataDragonLoader = new DataDragonLoader("ddragon/8.19.1");
            var itemset = dataDragonLoader.LoadItemSet();

            var boots = itemset.Data["1001"];
            Assert.AreEqual("Boots of Speed",boots.Name);
            Assert.AreEqual("Slightly increases Movement Speed",boots.Plaintext);

            Assert.AreEqual("http://ddragon.leagueoflegends.com/cdn/8.19.1/img/item/1001.png",
                boots.GetImageUrl());
            
        }
    }
}
