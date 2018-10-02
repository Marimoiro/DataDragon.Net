
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataDragonSharp
{
    public class DataDragonClient : IDisposable
    {
        public string RequestBase => $"http://ddragon.leagueoflegends.com/cdn/{Patch}/data/{Locale}";
        public string Patch { get; }
        public string Locale => _dataDragonLoader.Locale;

        private readonly DataDragonLoader _dataDragonLoader;
        private HttpClient httpClient;

        public DataDragonClient( string patch, string locale = "en_US")
        {
            Patch = patch;
            _dataDragonLoader = new DataDragonLoader("",locale);
            httpClient = new HttpClient();
        }

        public async Task<Champion> RequestChampionAsync(string championName)
        {
            var url = $"{RequestBase}/champion/{championName}.json";
            return _dataDragonLoader.LoadChampionFromJson(await RequestApi(url));
        }

        public async Task<ChampionSet> RequestChampionFullSetAsync()
        {
            var url = $"{RequestBase}/championFull.json";
            return _dataDragonLoader.LoadChampionSet(await RequestApi(url));
        }

        public async Task<ChampionSet> RequestChampionSetAsync()
        {
            var url = $"{RequestBase}/champion.json";
            return _dataDragonLoader.LoadChampionSet(await RequestApi(url));
        }

        public async Task<ItemSet> RequestItemSetAsync()
        {
            var url = $"{RequestBase}/item.json";
            return _dataDragonLoader.LoadItemSet(await RequestApi(url));
        }

        public async Task<SummonerSpellSet> RequestSummonerSpellSetAsync()
        {
            var url = $"{RequestBase}/summoner.json";
            return _dataDragonLoader.LoadSummonerSpellSet(await RequestApi(url));
        }

        public async Task<Style[]> RequestRuneAsync()
        {
            var url = $"{RequestBase}/runesReforged.json";
            return _dataDragonLoader.LoadRune(await RequestApi(url));
        }


        async Task<string> RequestApi(string url)
        {
            var result = await httpClient.GetAsync(url);
            return await result.Content.ReadAsStringAsync();
        }


        public void Dispose()
        {
            ((IDisposable)httpClient).Dispose();
        }
    }
}